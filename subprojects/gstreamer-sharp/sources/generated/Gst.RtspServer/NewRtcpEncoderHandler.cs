// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServer {

	using System;

	public delegate void NewRtcpEncoderHandler(object o, NewRtcpEncoderArgs args);

	public class NewRtcpEncoderArgs : GLib.SignalArgs {
		public Gst.Element Object{
			get {
				return (Gst.Element) Args [0];
			}
		}

	}
}
