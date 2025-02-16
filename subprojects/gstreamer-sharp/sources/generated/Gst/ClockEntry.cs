// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class ClockEntry : GLib.Opaque {

		public int Refcount {
			get {
				unsafe {
					int* raw_ptr = (int*)(((byte*)Handle) + abi_info.GetFieldOffset("refcount"));
					return (*raw_ptr);
				}
			}
			set {
				unsafe {
					int* raw_ptr = (int*)(((byte*)Handle) + abi_info.GetFieldOffset("refcount"));
					*raw_ptr = value;
				}
			}
		}

		public ClockEntry(IntPtr raw) : base(raw) {}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _abi_info = null;
		static public GLib.AbiStruct abi_info {
			get {
				if (_abi_info == null)
					_abi_info = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("refcount"
							, 0
							, (uint) Marshal.SizeOf(typeof(int)) // refcount
							, null
							, "clock"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_refcountAlign), "refcount")
							, 0
							),
						new GLib.AbiField("clock"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // clock
							, "refcount"
							, "type"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("type"
							, -1
							, (uint) Marshal.SizeOf(System.Enum.GetUnderlyingType(typeof(Gst.ClockEntryType))) // type
							, "clock"
							, "time"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_typeAlign), "type")
							, 0
							),
						new GLib.AbiField("time"
							, -1
							, (uint) Marshal.SizeOf(typeof(ulong)) // time
							, "type"
							, "interval"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_timeAlign), "time")
							, 0
							),
						new GLib.AbiField("interval"
							, -1
							, (uint) Marshal.SizeOf(typeof(ulong)) // interval
							, "time"
							, "status"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_intervalAlign), "interval")
							, 0
							),
						new GLib.AbiField("status"
							, -1
							, (uint) Marshal.SizeOf(System.Enum.GetUnderlyingType(typeof(Gst.ClockReturn))) // status
							, "interval"
							, "func"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_statusAlign), "status")
							, 0
							),
						new GLib.AbiField("func"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // func
							, "status"
							, "user_data"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("user_data"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // user_data
							, "func"
							, "destroy_data"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("destroy_data"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // destroy_data
							, "user_data"
							, "unscheduled"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_destroy_dataAlign), "destroy_data")
							, 0
							),
						new GLib.AbiField("unscheduled"
							, -1
							, (uint) Marshal.SizeOf(typeof(bool)) // unscheduled
							, "destroy_data"
							, "woken_up"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_unscheduledAlign), "unscheduled")
							, 0
							),
						new GLib.AbiField("woken_up"
							, -1
							, (uint) Marshal.SizeOf(typeof(bool)) // woken_up
							, "unscheduled"
							, "_gst_reserved"
							, (long) Marshal.OffsetOf(typeof(GstClockEntry_woken_upAlign), "woken_up")
							, 0
							),
						new GLib.AbiField("_gst_reserved"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) * 4 // _gst_reserved
							, "woken_up"
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _abi_info;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_refcountAlign
		{
			sbyte f1;
			private int refcount;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_typeAlign
		{
			sbyte f1;
			private Gst.ClockEntryType type;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_timeAlign
		{
			sbyte f1;
			private ulong time;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_intervalAlign
		{
			sbyte f1;
			private ulong interval;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_statusAlign
		{
			sbyte f1;
			private Gst.ClockReturn status;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_destroy_dataAlign
		{
			sbyte f1;
			private GLib.DestroyNotify destroy_data;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_unscheduledAlign
		{
			sbyte f1;
			private bool unscheduled;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstClockEntry_woken_upAlign
		{
			sbyte f1;
			private bool woken_up;
		}


		// End of the ABI representation.

#endregion
	}
}
