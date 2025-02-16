// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace GstSharp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate bool MiniObjectDisposeFunctionNative(IntPtr obj);

	internal class MiniObjectDisposeFunctionInvoker {

		MiniObjectDisposeFunctionNative native_cb;
		IntPtr __data;
		GLib.DestroyNotify __notify;

		~MiniObjectDisposeFunctionInvoker ()
		{
			if (__notify == null)
				return;
			__notify (__data);
		}

		internal MiniObjectDisposeFunctionInvoker (MiniObjectDisposeFunctionNative native_cb) : this (native_cb, IntPtr.Zero, null) {}

		internal MiniObjectDisposeFunctionInvoker (MiniObjectDisposeFunctionNative native_cb, IntPtr data) : this (native_cb, data, null) {}

		internal MiniObjectDisposeFunctionInvoker (MiniObjectDisposeFunctionNative native_cb, IntPtr data, GLib.DestroyNotify notify)
		{
			this.native_cb = native_cb;
			__data = data;
			__notify = notify;
		}

		internal Gst.MiniObjectDisposeFunction Handler {
			get {
				return new Gst.MiniObjectDisposeFunction(InvokeNative);
			}
		}

		bool InvokeNative (Gst.MiniObject obj)
		{
			bool __result = native_cb (obj == null ? IntPtr.Zero : obj.Handle);
			return __result;
		}
	}

	internal class MiniObjectDisposeFunctionWrapper {

		public bool NativeCallback (IntPtr obj)
		{
			try {
				bool __ret = managed (obj == IntPtr.Zero ? null : (Gst.MiniObject) GLib.Opaque.GetOpaque (obj, typeof (Gst.MiniObject), false));
				if (release_on_call)
					gch.Free ();
				return __ret;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
				return false;
			}
		}

		bool release_on_call = false;
		GCHandle gch;

		public void PersistUntilCalled ()
		{
			release_on_call = true;
			gch = GCHandle.Alloc (this);
		}

		internal MiniObjectDisposeFunctionNative NativeDelegate;
		Gst.MiniObjectDisposeFunction managed;

		public MiniObjectDisposeFunctionWrapper (Gst.MiniObjectDisposeFunction managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new MiniObjectDisposeFunctionNative (NativeCallback);
		}

		public static Gst.MiniObjectDisposeFunction GetManagedDelegate (MiniObjectDisposeFunctionNative native)
		{
			if (native == null)
				return null;
			MiniObjectDisposeFunctionWrapper wrapper = (MiniObjectDisposeFunctionWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}
