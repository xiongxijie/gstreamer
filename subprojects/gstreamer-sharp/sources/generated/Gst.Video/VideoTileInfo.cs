// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Video {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct VideoTileInfo : IEquatable<VideoTileInfo> {

		public uint Width;
		public uint Height;
		public uint Stride;
		public uint Size;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst=4)]
		private uint[] Padding;

		public static Gst.Video.VideoTileInfo Zero = new Gst.Video.VideoTileInfo ();

		public static Gst.Video.VideoTileInfo New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.Video.VideoTileInfo.Zero;
			return (Gst.Video.VideoTileInfo) Marshal.PtrToStructure (raw, typeof (Gst.Video.VideoTileInfo));
		}

		public bool Equals (VideoTileInfo other)
		{
			return true && Width.Equals (other.Width) && Height.Equals (other.Height) && Stride.Equals (other.Stride) && Size.Equals (other.Size);
		}

		public override bool Equals (object other)
		{
			return other is VideoTileInfo && Equals ((VideoTileInfo) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ Width.GetHashCode () ^ Height.GetHashCode () ^ Stride.GetHashCode () ^ Size.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
