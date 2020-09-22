using System;

namespace Onity.HT24
{
	public class ProtocolException : Exception
	{
		#region Constructor

		internal ProtocolException(string message) : base(message)
		{
		}

		#endregion Constructor
	}
}