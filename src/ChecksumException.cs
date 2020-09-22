using Onity.HT24.Properties;

namespace Onity.HT24
{
	public sealed class ChecksumException : ProtocolException
	{
		#region Constructor

		internal ChecksumException() : base(Messages.ChecksumError)
		{
		}

		#endregion Constructor
	}
}