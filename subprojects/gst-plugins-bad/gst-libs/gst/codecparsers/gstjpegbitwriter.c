/* GStreamer
 *  Copyright (C) 2024 Intel Corporation
 *     Author: He Junyan <junyan.he@intel.com>
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Library General Public
 * License as published by the Free Software Foundation; either
 * version 2 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Library General Public License for more details.
 *
 * You should have received a copy of the GNU Library General Public
 * License along with this library; if not, write to the0
 * Free Software Foundation, Inc., 51 Franklin St, Fifth Floor,
 * Boston, MA 02110-1301, USA.
 */

/* TODO: Add the support for the "differential mode(lossless mode)",
   "arithmetic mode" and "progressive mode". */

#ifdef HAVE_CONFIG_H
#include "config.h"
#endif

#include "gstjpegbitwriter.h"
#include <gst/base/gstbytewriter.h>

#define WRITE_BYTE_UNCHECK(bw, val)    gst_byte_writer_put_uint8 (bw, val)
#define WRITE_BYTE(bw, val)                                         \
  if (!WRITE_BYTE_UNCHECK (bw, val)) {                              \
    have_space = FALSE;                                             \
    goto error;                                                     \
  }

/*****************************  End of Utils ****************************/
/**
 * gst_jpeg_bit_writer_frame_header:
 * @frame_hdr: the frame header of #GstJpegFrameHdr to write
 * @marker: the #GstJpegMarker id for this segment
 * @data: (out): the bit stream generated by this frame header
 * @size: (inout): the size in bytes of the input and output
 *
 * Generating the according JPEG bit stream by providing the frame header.
 *
 * Returns: a #GstJpegBitWriterResult
 *
 * Since: 1.26
 **/
GstJpegBitWriterResult
gst_jpeg_bit_writer_frame_header (const GstJpegFrameHdr * frame_hdr,
    GstJpegMarker marker, guint8 * data, guint * size)
{
  gboolean have_space = TRUE;
  GstByteWriter bw;
  guint total_size, value;
  guint i;

  g_return_val_if_fail (frame_hdr != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (marker >= GST_JPEG_MARKER_SOF_MIN
      && marker <= GST_JPEG_MARKER_SOF_MAX, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (data != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (size != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (*size > 0, GST_JPEG_BIT_WRITER_ERROR);

  gst_byte_writer_init_with_data (&bw, data, *size, FALSE);

  /* marker */
  WRITE_BYTE (&bw, 0xff);
  WRITE_BYTE (&bw, marker);

  total_size = 2;

  if (frame_hdr->num_components > GST_JPEG_MAX_SCAN_COMPONENTS)
    goto error;

  total_size += (1 + 2 + 2 + 1);
  total_size += frame_hdr->num_components * (1 + 1 + 1);

  /* S1 and S2 */
  WRITE_BYTE (&bw, (total_size >> 8) & 0xff);
  WRITE_BYTE (&bw, total_size & 0xff);

  WRITE_BYTE (&bw, frame_hdr->sample_precision);

  if (!gst_byte_writer_put_uint16_be (&bw, frame_hdr->height)) {
    have_space = FALSE;
    goto error;
  }
  if (!gst_byte_writer_put_uint16_be (&bw, frame_hdr->width)) {
    have_space = FALSE;
    goto error;
  }

  WRITE_BYTE (&bw, frame_hdr->num_components);

  for (i = 0; i < frame_hdr->num_components; i++) {
    WRITE_BYTE (&bw, frame_hdr->components[i].identifier);

    if (frame_hdr->components[i].horizontal_factor > 4
        || frame_hdr->components[i].vertical_factor > 4
        || frame_hdr->components[i].quant_table_selector >= 4)
      goto error;

    value = (frame_hdr->components[i].horizontal_factor & 0x0F) << 4 |
        (frame_hdr->components[i].vertical_factor & 0x0F);
    WRITE_BYTE (&bw, value);

    WRITE_BYTE (&bw, frame_hdr->components[i].quant_table_selector);
  }

  *size = gst_byte_writer_get_size (&bw);
  gst_byte_writer_reset (&bw);

  return GST_JPEG_BIT_WRITER_OK;

error:
  gst_byte_writer_reset (&bw);
  *size = 0;
  return have_space ? GST_JPEG_BIT_WRITER_INVALID_DATA :
      GST_JPEG_BIT_WRITER_NO_MORE_SPACE;
}

/**
 * gst_jpeg_bit_writer_scan_header:
 * @frame_hdr: the scan header of #GstJpegScanHdr to write
 * @data: (out): the bit stream generated by this scan header
 * @size: (inout): the size in bytes of the input and output
 *
 * Generating the according JPEG bit stream by providing the scan header.
 *
 * Returns: a #GstJpegBitWriterResult
 *
 * Since: 1.26
 **/
GstJpegBitWriterResult
gst_jpeg_bit_writer_scan_header (const GstJpegScanHdr * scan_hdr,
    guint8 * data, guint * size)
{
  gboolean have_space = TRUE;
  GstByteWriter bw;
  guint total_size, value;
  guint i;

  g_return_val_if_fail (scan_hdr != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (data != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (size != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (*size > 0, GST_JPEG_BIT_WRITER_ERROR);

  gst_byte_writer_init_with_data (&bw, data, *size, FALSE);

  /* marker */
  WRITE_BYTE (&bw, 0xff);
  WRITE_BYTE (&bw, GST_JPEG_MARKER_SOS);

  total_size = 2;

  if (scan_hdr->num_components > GST_JPEG_MAX_SCAN_COMPONENTS)
    goto error;

  total_size += 1;
  total_size += scan_hdr->num_components * (1 + 1);
  total_size += 3;

  /* S1 and S2 */
  WRITE_BYTE (&bw, (total_size >> 8) & 0xff);
  WRITE_BYTE (&bw, total_size & 0xff);

  WRITE_BYTE (&bw, scan_hdr->num_components);

  for (i = 0; i < scan_hdr->num_components; i++) {
    WRITE_BYTE (&bw, scan_hdr->components[i].component_selector);

    if (scan_hdr->components[i].dc_selector >= 4
        || scan_hdr->components[i].ac_selector >= 4)
      goto error;

    value = (scan_hdr->components[i].dc_selector & 0x0F) << 4 |
        (scan_hdr->components[i].ac_selector & 0x0F);
    WRITE_BYTE (&bw, value);
  }

  /* Not use: Ss, Se, Ah, Al */
  WRITE_BYTE (&bw, 0);
  WRITE_BYTE (&bw, 0);
  WRITE_BYTE (&bw, 0);

  *size = gst_byte_writer_get_size (&bw);
  gst_byte_writer_reset (&bw);

  return GST_JPEG_BIT_WRITER_OK;

error:
  gst_byte_writer_reset (&bw);
  *size = 0;
  return have_space ? GST_JPEG_BIT_WRITER_INVALID_DATA :
      GST_JPEG_BIT_WRITER_NO_MORE_SPACE;
}

/**
 * gst_jpeg_bit_writer_huffman_table:
 * @huff_tables: the huffman tables of #GstJpegHuffmanTables to write
 * @data: (out): the bit stream generated by the huffman tables
 * @size: (inout): the size in bytes of the input and output
 *
 * Generating the according JPEG bit stream by providing the huffman tables.
 *
 * Returns: a #GstJpegBitWriterResult
 *
 * Since: 1.26
 **/
GstJpegBitWriterResult
gst_jpeg_bit_writer_huffman_table (const GstJpegHuffmanTables * huff_tables,
    guint8 * data, guint * size)
{
  gboolean have_space = TRUE;
  GstByteWriter bw;
  const GstJpegHuffmanTable *huf_table;
  guint32 value_count;
  guint total_size, value;
  guint i, j, k;

  g_return_val_if_fail (huff_tables != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (data != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (size != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (*size > 0, GST_JPEG_BIT_WRITER_ERROR);

  gst_byte_writer_init_with_data (&bw, data, *size, FALSE);

  /* marker */
  WRITE_BYTE (&bw, 0xff);
  WRITE_BYTE (&bw, GST_JPEG_MARKER_DHT);

  total_size = 2;

  for (i = 0; i < GST_JPEG_MAX_SCAN_COMPONENTS; i++) {
    for (j = 0; j < 2; j++) {   /* DC or AC */
      huf_table =
          (j == 0 ? &huff_tables->dc_tables[i] : &huff_tables->ac_tables[i]);
      if (!huf_table->valid)
        continue;

      total_size += (1 + 16);

      value_count = 0;
      for (k = 0; k < 16; k++)
        value_count += huf_table->huf_bits[k];

      total_size += value_count;
    }
  }

  /* S1 and S2 */
  WRITE_BYTE (&bw, (total_size >> 8) & 0xff);
  WRITE_BYTE (&bw, total_size & 0xff);

  for (i = 0; i < GST_JPEG_MAX_SCAN_COMPONENTS; i++) {
    for (j = 0; j < 2; j++) {   /* DC or AC */
      huf_table =
          (j == 0 ? &huff_tables->dc_tables[i] : &huff_tables->ac_tables[i]);
      if (!huf_table->valid)
        continue;

      /* table class and index */
      value = (j & 0x0F) << 4 | (i & 0x0F);
      WRITE_BYTE (&bw, value);

      if (!gst_byte_writer_put_data (&bw, huf_table->huf_bits, 16)) {
        have_space = FALSE;
        goto error;
      }

      value_count = 0;
      for (k = 0; k < 16; k++)
        value_count += huf_table->huf_bits[k];

      if (!gst_byte_writer_put_data (&bw, huf_table->huf_values, value_count)) {
        have_space = FALSE;
        goto error;
      }
    }
  }

  *size = gst_byte_writer_get_size (&bw);
  gst_byte_writer_reset (&bw);

  return GST_JPEG_BIT_WRITER_OK;

error:
  gst_byte_writer_reset (&bw);
  *size = 0;
  return have_space ? GST_JPEG_BIT_WRITER_INVALID_DATA :
      GST_JPEG_BIT_WRITER_NO_MORE_SPACE;
}

/**
 * gst_jpeg_bit_writer_quantization_table:
 * @quant_tables: the quantization tables of #GstJpegQuantTables to write
 * @data: (out): the bit stream generated by the quantization tables
 * @size: (inout): the size in bytes of the input and output
 *
 * Generating the according JPEG bit stream by providing the quantization tables.
 *
 * Returns: a #GstJpegBitWriterResult
 *
 * Since: 1.26
 **/
GstJpegBitWriterResult
gst_jpeg_bit_writer_quantization_table (const GstJpegQuantTables * quant_tables,
    guint8 * data, guint * size)
{
  gboolean have_space = TRUE;
  GstByteWriter bw;
  const GstJpegQuantTable *quant_table;
  guint total_size, value;
  guint i, j;

  g_return_val_if_fail (quant_tables != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (data != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (size != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (*size > 0, GST_JPEG_BIT_WRITER_ERROR);

  gst_byte_writer_init_with_data (&bw, data, *size, FALSE);

  /* marker */
  WRITE_BYTE (&bw, 0xff);
  WRITE_BYTE (&bw, GST_JPEG_MARKER_DQT);

  total_size = 2;

  for (i = 0; i < GST_JPEG_MAX_SCAN_COMPONENTS; i++) {
    guint32 element_size;

    quant_table = &quant_tables->quant_tables[i];
    if (!quant_table->valid)
      continue;

    element_size = (quant_table->quant_precision == 0) ? 1 : 2;
    total_size += (1 + GST_JPEG_MAX_QUANT_ELEMENTS * element_size);
  }

  /* S1 and S2 */
  WRITE_BYTE (&bw, (total_size >> 8) & 0xff);
  WRITE_BYTE (&bw, total_size & 0xff);

  for (i = 0; i < GST_JPEG_MAX_SCAN_COMPONENTS; i++) {
    quant_table = &quant_tables->quant_tables[i];
    if (!quant_table->valid)
      continue;

    value = ((quant_table->quant_precision & 0x0F) << 4) | (i & 0x0F);
    WRITE_BYTE (&bw, value);

    for (j = 0; j < GST_JPEG_MAX_QUANT_ELEMENTS; j++) {
      if (!quant_table->quant_precision) {      /* 8-bit values */
        guint8 val = quant_table->quant_table[j];
        WRITE_BYTE (&bw, val);
      } else {                  /* 16-bit values */
        if (!gst_byte_writer_put_uint16_be (&bw, quant_table->quant_table[j])) {
          have_space = FALSE;
          goto error;
        }
      }
    }
  }

  *size = gst_byte_writer_get_size (&bw);
  gst_byte_writer_reset (&bw);

  return GST_JPEG_BIT_WRITER_OK;

error:
  gst_byte_writer_reset (&bw);
  *size = 0;
  return have_space ? GST_JPEG_BIT_WRITER_INVALID_DATA :
      GST_JPEG_BIT_WRITER_NO_MORE_SPACE;
}

/**
 * gst_jpeg_bit_writer_restart_interval:
 * @interval: the interval value for restart
 * @data: (out): the bit stream generated by the interval value
 * @size: (inout): the size in bytes of the input and output
 *
 * Generating the according JPEG bit stream by providing the interval value.
 *
 * Returns: a #GstJpegBitWriterResult
 *
 * Since: 1.26
 **/
GstJpegBitWriterResult
gst_jpeg_bit_writer_restart_interval (guint16 interval, guint8 * data,
    guint * size)
{
  gboolean have_space = TRUE;
  GstByteWriter bw;
  guint total_size;

  g_return_val_if_fail (data != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (size != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (*size > 0, GST_JPEG_BIT_WRITER_ERROR);

  gst_byte_writer_init_with_data (&bw, data, *size, FALSE);

  /* marker */
  WRITE_BYTE (&bw, 0xff);
  WRITE_BYTE (&bw, GST_JPEG_MARKER_DRI);

  total_size = 2;
  total_size += 2;

  /* S1 and S2 */
  WRITE_BYTE (&bw, (total_size >> 8) & 0xff);
  WRITE_BYTE (&bw, total_size & 0xff);

  if (!gst_byte_writer_put_uint16_be (&bw, interval)) {
    have_space = FALSE;
    goto error;
  }

  *size = gst_byte_writer_get_size (&bw);
  gst_byte_writer_reset (&bw);

  return GST_JPEG_BIT_WRITER_OK;

error:
  gst_byte_writer_reset (&bw);
  *size = 0;
  return have_space ? GST_JPEG_BIT_WRITER_INVALID_DATA :
      GST_JPEG_BIT_WRITER_NO_MORE_SPACE;
}

/**
 * gst_jpeg_bit_writer_segment_with_data:
 * @marker: the #GstJpegMarker id for this segment
 * @seg_data: (in) (allow-none): the user provided bit stream data
 * @seg_size: (in): the size of the segment data
 * @data: (out): the generated bit stream of this segment
 * @size: (inout): the size in bytes of the input and output
 *
 * Generating the bit stream for a JPEG segment.
 *
 * Returns: a #GstJpegBitWriterResult
 *
 * Since: 1.26
 **/
GstJpegBitWriterResult
gst_jpeg_bit_writer_segment_with_data (GstJpegMarker marker, guint8 * seg_data,
    guint seg_size, guint8 * data, guint * size)
{
  gboolean have_space = TRUE;
  GstByteWriter bw;
  guint total_size;

  g_return_val_if_fail (marker >= GST_JPEG_MARKER_SOF0
      && marker <= GST_JPEG_MARKER_COM, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (data != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (size != NULL, GST_JPEG_BIT_WRITER_ERROR);
  g_return_val_if_fail (*size > 0, GST_JPEG_BIT_WRITER_ERROR);

  if (seg_data)
    g_return_val_if_fail (seg_size > 0, GST_JPEG_BIT_WRITER_ERROR);

  gst_byte_writer_init_with_data (&bw, data, *size, FALSE);

  /* marker */
  WRITE_BYTE (&bw, 0xff);
  WRITE_BYTE (&bw, marker);

  if (seg_size > 0) {
    total_size = 2;
    total_size += seg_size;

    /* S1 and S2 */
    WRITE_BYTE (&bw, (total_size >> 8) & 0xff);
    WRITE_BYTE (&bw, total_size & 0xff);

    /* Copy the user provided data. */
    if (seg_data) {
      if (!gst_byte_writer_put_data (&bw, seg_data, seg_size)) {
        have_space = FALSE;
        goto error;
      }
    } else {
      if (!gst_byte_writer_fill (&bw, 0, seg_size)) {
        have_space = FALSE;
        goto error;
      }
    }
  }

  *size = gst_byte_writer_get_size (&bw);
  gst_byte_writer_reset (&bw);

  return GST_JPEG_BIT_WRITER_OK;

error:
  gst_byte_writer_reset (&bw);
  *size = 0;
  return have_space ? GST_JPEG_BIT_WRITER_INVALID_DATA :
      GST_JPEG_BIT_WRITER_NO_MORE_SPACE;
}
