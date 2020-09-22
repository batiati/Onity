using Onity.HT24.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onity.HT24
{
	internal class Command
	{
		#region Fields

		public const byte STX = 0x02;
		public const byte ETX = 0x03;
		public const byte ACK = 0x06;
		public const byte NAK = 0x15;
		public const byte ENQ = 0x05;
		public const byte SEP = 0xB3;

		private List<string> parameters = new List<string>();

		#endregion Fields

		#region Properties

		public CommandType CommandType { get; private set; }

		public int? CommandArg { get; private set; }

		public string[] Parameters => parameters.ToArray();

		#endregion Properties

		#region Constructor

		public Command(CommandType commandType, int? commandArg = null)
		{
			this.CommandType = commandType;
			this.CommandArg = commandArg;
		}

		#endregion Constructor

		#region Methods

		public static Command Parse(byte[] data)
		{
			const int START = 2;

			if (data == null || data.Length < START) return null;
			if (data[0] != STX && data[1] != SEP) return null;

			var parameters = new List<string>();
			var part = new List<byte>();

			for (int i = START; i < data.Length; i++)
			{
				if (data[i] == ETX) break;

				if (data[i] == SEP || i == data.Length - 1)
				{
					var str = Encoding.ASCII.GetString(part.ToArray());
					parameters.Add(str);
					part.Clear();
				}
				else
				{
					part.Add(data[i]);
				}
			}

			if (parameters.Count == 0) return null;

			const int REPLY_LEN = 2;

			var firstParam = parameters[0];
			var replyToken = parameters[0].Substring(0, REPLY_LEN);

			var isError = Enum.TryParse(replyToken, out ErrorCode errorCode);
			if (isError) throw new CommandException(errorCode);

			var isValidCommand = Enum.TryParse(replyToken, out CommandType commandType);
			if (!isValidCommand) throw new ProtocolException(string.Format(Messages.InvalidReply, firstParam, string.Join("|", parameters)));

			int? commandArg = null;
			if (firstParam.Length > 2 && int.TryParse(firstParam.Substring(REPLY_LEN), out int _commandArg)) commandArg = _commandArg;

			var command = new Command(commandType, commandArg);
			command.parameters.AddRange(parameters.Skip(1));

			return command;
		}

		public void AddParameter(string parameter)
		{
			parameters.Add(parameter);
		}

		public void AddParameter(DateTime? parameter)
		{
			var str = FormatDateTime(parameter);
			parameters.Add(str);
		}

		public void AddParameter(int? parameter)
		{
			var str = FormatInt(parameter);
			parameters.Add(str);
		}

		private string FormatDateTime(DateTime? value)
		{
			if (value == null) return null;
			return $"{value:HHddMMyy}";
		}

		private string FormatInt(int? value)
		{
			return value?.ToString();
		}

		public byte[] GetBytes()
		{
			var buffer = new List<byte>();

			buffer.Add(STX);
			buffer.Add(SEP);
			AddToBuffer(buffer, $"{CommandType}{CommandArg}");
			buffer.Add(SEP);

			foreach (var parameter in parameters)
			{
				AddToBuffer(buffer, parameter);
				buffer.Add(SEP);
			}

			buffer.Add(ETX);
			buffer.Add(GetChecksum(buffer));

			return buffer.ToArray();
		}

		private void AddToBuffer(List<byte> buffer, string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				buffer.AddRange(Encoding.ASCII.GetBytes(value));
			}
		}

		private byte GetChecksum(List<byte> buffer)
		{
			const int START = 1;

			byte lrc = 0;
			for (int i = START; i < buffer.Count; i++)
			{
				lrc = (byte)(lrc ^ buffer[i]);
			}

			return lrc;
		}

		#endregion Methods
	}
}