using Onity.HT24.Properties;

namespace Onity.HT24
{
	public sealed class CommandException : ProtocolException
	{
		#region Properties

		public ErrorCode ErrorCode { get; private set; }

		#endregion Properties

		#region Constructor

		internal CommandException(ErrorCode errorCode) : base(GetMessage(errorCode))
		{
			ErrorCode = errorCode;
		}

		#endregion Constructor

		#region Methods

		private static string GetMessage(ErrorCode errorCode)
		{
			switch (errorCode)
			{
				case ErrorCode.ES: return Messages.ES;
				case ErrorCode.NC: return Messages.NC;
				case ErrorCode.NF: return Messages.NF;
				case ErrorCode.OV: return Messages.OV;
				case ErrorCode.EP: return Messages.EP;
				case ErrorCode.EF: return Messages.EF;
				case ErrorCode.EN: return Messages.EN;
				case ErrorCode.ET: return Messages.ET;
				case ErrorCode.TD: return Messages.TD;
				case ErrorCode.ED: return Messages.ED;
				case ErrorCode.EA: return Messages.EA;
				case ErrorCode.OS: return Messages.OS;
				default: return string.Format(Messages.UnknownErrorCode, errorCode);
			}
		}

		#endregion Methods
	}
}