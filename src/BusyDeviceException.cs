using Onity.HT24.Properties;

namespace Onity.HT24
{
	public sealed class BusyDeviceException : ProtocolException
	{
		#region Constructor

		internal BusyDeviceException() : base(Messages.BusyDevice)
		{
		}

		#endregion Constructor
	}
}