// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace GES {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class Marker : GLib.Object, GES.IMetaContainer {

		public Marker (IntPtr raw) : base(raw) {}

		protected Marker() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		[GLib.Property ("position")]
		public ulong Position {
			get {
				GLib.Value val = GetProperty ("position");
				ulong ret = (ulong) val;
				val.Dispose ();
				return ret;
			}
		}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _class_abi = null;
		static public new GLib.AbiStruct class_abi {
			get {
				if (_class_abi == null)
					_class_abi = new GLib.AbiStruct (GLib.Object.class_abi.Fields);

				return _class_abi;
			}
		}


		// End of the ABI representation.

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr ges_marker_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = ges_marker_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_add_metas_from_string(IntPtr raw, IntPtr str);

		public bool AddMetasFromString(string str) {
			IntPtr native_str = GLib.Marshaller.StringToPtrGStrdup (str);
			bool raw_ret = ges_meta_container_add_metas_from_string(Handle, native_str);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_str);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_check_meta_registered(IntPtr raw, IntPtr meta_item, out int flags, out IntPtr type);

		public bool CheckMetaRegistered(string meta_item, out GES.MetaFlag flags, out GLib.GType type) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			int native_flags;
			IntPtr native_type;
			bool raw_ret = ges_meta_container_check_meta_registered(Handle, native_meta_item, out native_flags, out native_type);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			flags = (GES.MetaFlag) native_flags;
			type = new GLib.GType(native_type);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern void ges_meta_container_foreach(IntPtr raw, GESSharp.MetaForeachFuncNative func, IntPtr user_data);

		public void Foreach(GES.MetaForeachFunc func) {
			GESSharp.MetaForeachFuncWrapper func_wrapper = new GESSharp.MetaForeachFuncWrapper (func);
			ges_meta_container_foreach(Handle, func_wrapper.NativeDelegate, IntPtr.Zero);
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_boolean(IntPtr raw, IntPtr meta_item, out bool dest);

		public bool GetBoolean(string meta_item, out bool dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_boolean(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_date(IntPtr raw, IntPtr meta_item, out IntPtr dest);

		public bool GetDate(string meta_item, out GLib.Date dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr native_dest;
			bool raw_ret = ges_meta_container_get_date(Handle, native_meta_item, out native_dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			dest = new GLib.Date(native_dest);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_date_time(IntPtr raw, IntPtr meta_item, out IntPtr dest);

		public bool GetDateTime(string meta_item, out Gst.DateTime dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr native_dest;
			bool raw_ret = ges_meta_container_get_date_time(Handle, native_meta_item, out native_dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			dest = native_dest == IntPtr.Zero ? null : (Gst.DateTime) GLib.Opaque.GetOpaque (native_dest, typeof (Gst.DateTime), true);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_double(IntPtr raw, IntPtr meta_item, out double dest);

		public bool GetDouble(string meta_item, out double dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_double(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_float(IntPtr raw, IntPtr meta_item, out float dest);

		public bool GetFloat(string meta_item, out float dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_float(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_int(IntPtr raw, IntPtr meta_item, out int dest);

		public bool GetInt(string meta_item, out int dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_int(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_int64(IntPtr raw, IntPtr meta_item, out long dest);

		public bool GetInt64(string meta_item, out long dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_int64(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr ges_meta_container_get_marker_list(IntPtr raw, IntPtr key);

		public GES.MarkerList GetMarkerList(string key) {
			IntPtr native_key = GLib.Marshaller.StringToPtrGStrdup (key);
			IntPtr raw_ret = ges_meta_container_get_marker_list(Handle, native_key);
			GES.MarkerList ret = GLib.Object.GetObject(raw_ret, true) as GES.MarkerList;
			GLib.Marshaller.Free (native_key);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr ges_meta_container_get_meta(IntPtr raw, IntPtr key);

		public GLib.Value GetMeta(string key) {
			IntPtr native_key = GLib.Marshaller.StringToPtrGStrdup (key);
			IntPtr raw_ret = ges_meta_container_get_meta(Handle, native_key);
			GLib.Value ret = (GLib.Value) Marshal.PtrToStructure (raw_ret, typeof (GLib.Value));
			GLib.Marshaller.Free (native_key);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr ges_meta_container_get_string(IntPtr raw, IntPtr meta_item);

		public string GetString(string meta_item) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr raw_ret = ges_meta_container_get_string(Handle, native_meta_item);
			string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_uint(IntPtr raw, IntPtr meta_item, out uint dest);

		public bool GetUint(string meta_item, out uint dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_uint(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_get_uint64(IntPtr raw, IntPtr meta_item, out ulong dest);

		public bool GetUint64(string meta_item, out ulong dest) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_get_uint64(Handle, native_meta_item, out dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr ges_meta_container_metas_to_string(IntPtr raw);

		public string MetasToString() {
			IntPtr raw_ret = ges_meta_container_metas_to_string(Handle);
			string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta(IntPtr raw, int flags, IntPtr meta_item, IntPtr value);

		public bool RegisterMeta(GES.MetaFlag flags, string meta_item, GLib.Value value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr native_value = GLib.Marshaller.StructureToPtrAlloc (value);
			bool raw_ret = ges_meta_container_register_meta(Handle, (int) flags, native_meta_item, native_value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			Marshal.FreeHGlobal (native_value);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_boolean(IntPtr raw, int flags, IntPtr meta_item, bool value);

		public bool RegisterMetaBoolean(GES.MetaFlag flags, string meta_item, bool value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_boolean(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_date(IntPtr raw, int flags, IntPtr meta_item, IntPtr value);

		public bool RegisterMetaDate(GES.MetaFlag flags, string meta_item, GLib.Date value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_date(Handle, (int) flags, native_meta_item, value == null ? IntPtr.Zero : value.Handle);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_date_time(IntPtr raw, int flags, IntPtr meta_item, IntPtr value);

		public bool RegisterMetaDateTime(GES.MetaFlag flags, string meta_item, Gst.DateTime value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_date_time(Handle, (int) flags, native_meta_item, value == null ? IntPtr.Zero : value.Handle);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_double(IntPtr raw, int flags, IntPtr meta_item, double value);

		public bool RegisterMetaDouble(GES.MetaFlag flags, string meta_item, double value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_double(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_float(IntPtr raw, int flags, IntPtr meta_item, float value);

		public bool RegisterMetaFloat(GES.MetaFlag flags, string meta_item, float value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_float(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_int(IntPtr raw, int flags, IntPtr meta_item, int value);

		public bool RegisterMetaInt(GES.MetaFlag flags, string meta_item, int value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_int(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_int64(IntPtr raw, int flags, IntPtr meta_item, long value);

		public bool RegisterMetaInt64(GES.MetaFlag flags, string meta_item, long value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_int64(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_string(IntPtr raw, int flags, IntPtr meta_item, IntPtr value);

		public bool RegisterMetaString(GES.MetaFlag flags, string meta_item, string value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
			bool raw_ret = ges_meta_container_register_meta_string(Handle, (int) flags, native_meta_item, native_value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			GLib.Marshaller.Free (native_value);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_uint(IntPtr raw, int flags, IntPtr meta_item, uint value);

		public bool RegisterMetaUint(GES.MetaFlag flags, string meta_item, uint value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_uint(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_meta_uint64(IntPtr raw, int flags, IntPtr meta_item, ulong value);

		public bool RegisterMetaUint64(GES.MetaFlag flags, string meta_item, ulong value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_meta_uint64(Handle, (int) flags, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_register_static_meta(IntPtr raw, int flags, IntPtr meta_item, IntPtr type);

		public bool RegisterStaticMeta(GES.MetaFlag flags, string meta_item, GLib.GType type) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_register_static_meta(Handle, (int) flags, native_meta_item, type.Val);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_boolean(IntPtr raw, IntPtr meta_item, bool value);

		public bool SetBoolean(string meta_item, bool value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_boolean(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_date(IntPtr raw, IntPtr meta_item, IntPtr value);

		public bool SetDate(string meta_item, GLib.Date value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_date(Handle, native_meta_item, value == null ? IntPtr.Zero : value.Handle);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_date_time(IntPtr raw, IntPtr meta_item, IntPtr value);

		public bool SetDateTime(string meta_item, Gst.DateTime value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_date_time(Handle, native_meta_item, value == null ? IntPtr.Zero : value.Handle);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_double(IntPtr raw, IntPtr meta_item, double value);

		public bool SetDouble(string meta_item, double value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_double(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_float(IntPtr raw, IntPtr meta_item, float value);

		public bool SetFloat(string meta_item, float value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_float(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_int(IntPtr raw, IntPtr meta_item, int value);

		public bool SetInt(string meta_item, int value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_int(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_int64(IntPtr raw, IntPtr meta_item, long value);

		public bool SetInt64(string meta_item, long value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_int64(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_marker_list(IntPtr raw, IntPtr meta_item, IntPtr list);

		public bool SetMarkerList(string meta_item, GES.MarkerList list) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_marker_list(Handle, native_meta_item, list == null ? IntPtr.Zero : list.Handle);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_meta(IntPtr raw, IntPtr meta_item, IntPtr value);

		public bool SetMeta(string meta_item, GLib.Value value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr native_value = GLib.Marshaller.StructureToPtrAlloc (value);
			bool raw_ret = ges_meta_container_set_meta(Handle, native_meta_item, native_value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			Marshal.FreeHGlobal (native_value);
			return ret;
		}

		public bool SetMeta(string meta_item) {
			return SetMeta (meta_item, GLib.Value.Empty);
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_string(IntPtr raw, IntPtr meta_item, IntPtr value);

		public bool SetString(string meta_item, string value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
			bool raw_ret = ges_meta_container_set_string(Handle, native_meta_item, native_value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			GLib.Marshaller.Free (native_value);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_uint(IntPtr raw, IntPtr meta_item, uint value);

		public bool SetUint(string meta_item, uint value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_uint(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[DllImport("ges-1.0", CallingConvention = CallingConvention.Cdecl)]
		static extern bool ges_meta_container_set_uint64(IntPtr raw, IntPtr meta_item, ulong value);

		public bool SetUint64(string meta_item, ulong value) {
			IntPtr native_meta_item = GLib.Marshaller.StringToPtrGStrdup (meta_item);
			bool raw_ret = ges_meta_container_set_uint64(Handle, native_meta_item, value);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_meta_item);
			return ret;
		}

		[GLib.Signal("notify-meta")]
		public event GES.NotifyMetaHandler NotifyMeta {
			add {
				this.AddSignalHandler ("notify-meta", value, typeof (GES.NotifyMetaArgs));
			}
			remove {
				this.RemoveSignalHandler ("notify-meta", value);
			}
		}

		static NotifyMetaNativeDelegate NotifyMeta_cb_delegate;
		static NotifyMetaNativeDelegate NotifyMetaVMCallback {
			get {
				if (NotifyMeta_cb_delegate == null)
					NotifyMeta_cb_delegate = new NotifyMetaNativeDelegate (NotifyMeta_cb);
				return NotifyMeta_cb_delegate;
			}
		}

		static void OverrideNotifyMeta (GLib.GType gtype)
		{
			OverrideNotifyMeta (gtype, NotifyMetaVMCallback);
		}

		static void OverrideNotifyMeta (GLib.GType gtype, NotifyMetaNativeDelegate callback)
		{
			OverrideVirtualMethod (gtype, "notify-meta", callback);
		}
		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void NotifyMetaNativeDelegate (IntPtr inst, IntPtr key, IntPtr value);

		static void NotifyMeta_cb (IntPtr inst, IntPtr key, IntPtr value)
		{
			try {
				GES.Marker __obj = GLib.Object.GetObject (inst, false) as GES.Marker;
				__obj.OnNotifyMeta (GLib.Marshaller.Utf8PtrToString (key), (GLib.Value) Marshal.PtrToStructure (value, typeof (GLib.Value)));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(GES.Marker), ConnectionMethod="OverrideNotifyMeta")]
		protected virtual void OnNotifyMeta (string key, GLib.Value value)
		{
			InternalNotifyMeta (key, value);
		}

		private void InternalNotifyMeta (string key, GLib.Value value)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (3);
			GLib.Value[] vals = new GLib.Value [3];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (key);
			inst_and_params.Append (vals [1]);
			vals [2] = new GLib.Value (value);
			inst_and_params.Append (vals [2]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}


		static Marker ()
		{
			GtkSharp.GstEditingServices.ObjectManager.Initialize ();
		}

		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _abi_info = null;
		static public new GLib.AbiStruct abi_info {
			get {
				if (_abi_info == null)
					_abi_info = new GLib.AbiStruct (GLib.Object.abi_info.Fields);

				return _abi_info;
			}
		}


		// End of the ABI representation.

#endregion
	}
}
