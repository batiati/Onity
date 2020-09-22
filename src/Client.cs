using Onity.HT24.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;

namespace Onity.HT24
{
	public class Client : IDisposable
	{
		#region Fields

		private const int DEFAULT_PORT = 6669;
		private TcpClient tcpClient;

		#endregion Fields

		#region Properties

		public bool Connected => tcpClient != null;

		public string Address { get; private set; }

		public int Port { get; private set; }

		#endregion Properties

		#region Constructor

		public Client(string address, int port)
		{
			if (string.IsNullOrEmpty(address)) throw new ArgumentException($"Onity address is empty");

			this.Address = address;

			if (port == 0)
			{
				this.Port = DEFAULT_PORT;
			}
			else
			{
				this.Port = port;
			}
		}

		public Client(string address)
		{
			if (string.IsNullOrEmpty(address)) throw new ArgumentException($"Onity address is empty");

			var parts = address.Split(':');
			if (parts.Length > 2) throw new ArgumentException($"Onity address \"{address}\" is invalid");

			if (parts.Length == 1)
			{
				this.Address = address;
				this.Port = DEFAULT_PORT;
			}
			else
			{
				if (!int.TryParse(parts[1], out int port)) throw new ArgumentException($"Onity port \"{parts[1]}\" is invalid");

				this.Address = parts[0];
				this.Port = port;
			}
		}

		~Client()
		{
			Dispose(disposing: false);
		}

		#endregion Constructor

		#region Methods

		public void Connect()
		{
			if (tcpClient == null)
			{
				tcpClient = new TcpClient(Address, Port);
			}
		}

		public void Disconnect()
		{
			if (tcpClient != null)
			{
				tcpClient.Close();
				tcpClient = null;
			}
		}

		#region Documentation

		/// <summary>
		/// To record a card for a new customer. This card will automatically void the previous customer's card
		/// </summary>

		#endregion Documentation

		public string Write(WriteData data)
		{
			var command = new Command(CommandType.CN, data.Quantity);
			command.AddParameter(data.EncoderNumber);
			command.AddParameter(data.EjectionType.ToString());
			command.AddParameter(data.Room1);
			command.AddParameter(data.Room2);
			command.AddParameter(data.Room3);
			command.AddParameter(data.Room4);
			command.AddParameter(data.Authorization);
			command.AddParameter(data.Deny);
			command.AddParameter(data.InitialDateTime);
			command.AddParameter(data.FinalDateTime);
			command.AddParameter(data.User);
			command.AddParameter(data.Track1);
			command.AddParameter(data.Track2);

			var reply = Process(command);

			if (reply?.CommandType == CommandType.CN && reply.Parameters.Length > 1)
			{
				return reply.Parameters[1];
			}
			else
			{
				return null;
			}
		}

		#region Documentation

		/// <summary>
		/// To record a copy for the person who shares the room.
		/// </summary>

		#endregion Documentation

		public string WriteCopy(WriteData data)
		{
			var command = new Command(CommandType.CC, data.Quantity);
			command.AddParameter(data.EncoderNumber);
			command.AddParameter(data.EjectionType.ToString());
			command.AddParameter(data.Room1);
			command.AddParameter(data.Room2);
			command.AddParameter(data.Room3);
			command.AddParameter(data.Room4);
			command.AddParameter(data.Authorization);
			command.AddParameter(data.Deny);
			command.AddParameter(data.InitialDateTime);
			command.AddParameter(data.FinalDateTime);
			command.AddParameter(data.User);
			command.AddParameter(data.Track1);
			command.AddParameter(data.Track2);

			var reply = Process(command);

			if ((reply?.CommandType == CommandType.CC || reply?.CommandType == CommandType.CN) && reply.Parameters.Length > 1)
			{
				return reply.Parameters[1];
			}
			else
			{
				return null;
			}
		}

		#region Documentation

		/// <summary>
		/// Check-out of a client. All customer cards in the room correspondent are discharged
		/// </summary>

		#endregion Documentation

		public void Checkout(CheckoutData data)
		{
			var command = new Command(CommandType.CO);
			command.AddParameter(data.EncoderNumber);
			command.AddParameter(data.Room);

			Process(command);
		}

		#region Documentation

		/// <summary>
		/// Reading and interpretation of data recorded on track 3 according to ONITY standards
		/// </summary>

		#endregion Documentation

		public ReadResult Read(ReadData data)
		{
			var command = new Command(CommandType.LT);
			command.AddParameter(data.EncoderNumber);
			command.AddParameter(data.ExpellingType.ToString());

			var reply = Process(command);

			if (reply.CommandType == CommandType.LT)
			{
				if (reply.Parameters.Length < 2 || !int.TryParse(reply.Parameters[0], out int encoderNumber))
				{
					throw new ProtocolException(string.Format(Messages.InvalidReply, CommandType.LT, string.Join("|", reply.Parameters)));
				}

				CardType cardType;
				string room1 = null;
				string room2 = null;
				string room3 = null;
				string room4 = null;
				bool checkedIn = false;
				string copy = null;
				string authorization = null;
				DateTime? initialDateTime = null;
				DateTime? finalDateTime = null;
				string user = null;
				string uid = null;
				string errorMessage = null;

				var isRoom = !Enum.GetNames(typeof(ReadCode)).Contains(reply.Parameters[1]);

				if (isRoom)
				{
					cardType = CardType.CustomerCard;

					room1 = reply.Parameters.Length > 1 ? reply.Parameters[1] : null;
					room2 = reply.Parameters.Length > 2 ? reply.Parameters[2] : null;
					room3 = reply.Parameters.Length > 3 ? reply.Parameters[3] : null;
					room4 = reply.Parameters.Length > 4 ? reply.Parameters[4] : null;
					checkedIn = reply.Parameters.Length > 5 && reply.Parameters[5] == "CI";
					copy = reply.Parameters.Length > 6 ? reply.Parameters[6] : null;
					authorization = reply.Parameters.Length > 7 ? reply.Parameters[7] : null;
					initialDateTime = reply.Parameters.Length > 8 && !string.IsNullOrEmpty(reply.Parameters[8]) ? DateTime.ParseExact(reply.Parameters[8], "HHddMMyy", CultureInfo.InvariantCulture) : (DateTime?)null;
					finalDateTime = reply.Parameters.Length > 9 && !string.IsNullOrEmpty(reply.Parameters[9]) ? DateTime.ParseExact(reply.Parameters[9], "HHddMMyy", CultureInfo.InvariantCulture) : (DateTime?)null;
					user = reply.Parameters.Length > 10 ? reply.Parameters[10] : null;
					uid = reply.Parameters.Length > 11 ? reply.Parameters[11] : null;
				}
				else
				{
					Enum.TryParse(reply.Parameters[1], out ReadCode readCode);

					switch (readCode)
					{
						case ReadCode.LC:
							cardType = CardType.InvalidCustomerCard;
							break;

						case ReadCode.LM:
							cardType = CardType.MasterCard;
							break;

						case ReadCode.LR:
							cardType = CardType.SpareCard;
							break;

						case ReadCode.LS:
							cardType = CardType.DiagnosticCard;
							break;

						case ReadCode.LD:

							cardType = CardType.UnknownCard;
							errorMessage = reply.Parameters.Length > 2 ? reply.Parameters[2] : null;
							break;

						default: throw new NotImplementedException();
					}
				}

				return new ReadResult
				{
					EncoderNumber = encoderNumber,
					CardType = cardType,
					Room1 = room1,
					Room2 = room2,
					Room3 = room3,
					Room4 = room4,
					CheckedIn = checkedIn,
					Authorization = authorization,
					Copy = copy,
					InitialDateTime = initialDateTime,
					FinalDateTime = finalDateTime,
					User = user,
					Uid = uid,
					ErrorMessage = errorMessage,
				};
			}
			else
			{
				return null;
			}
		}

		#region Documentation

		/// <summary>
		/// Cancels a task and ejects the card if it has been held inside the recorder in a previous operation.
		/// </summary>

		#endregion Documentation

		public void Eject(EjectData data)
		{
			var command = new Command(CommandType.EX);
			command.AddParameter(data.EncoderNumber);

			Process(command);
		}

		private Command Process(Command command)
		{
			#region Comments

			//Timeout do protocolo sugerido no manual para 2 segundos
			//Timeout de operação definido em 1 minuto

			#endregion Comments

			const int PROTOCOL_TIMEOUT = 2 * 1000;
			const int OPERATION_TIMEOUT = 60 * 1000;

			if (!Connected) Connect();

			var stream = tcpClient.GetStream();
			byte ret;

			tcpClient.ReceiveTimeout = tcpClient.SendTimeout = PROTOCOL_TIMEOUT;

			#region Comments

			//Send the ENQ command to verify if the device is avaiable

			#endregion Comments

			stream.WriteByte(Command.ENQ);
			ret = (byte)stream.ReadByte();
			if (ret != Command.ACK) throw new BusyDeviceException();

			#region Comments

			//Send the command

			#endregion Comments

			var bytes = command.GetBytes();
			stream.Write(bytes, 0, bytes.Length);
			ret = (byte)stream.ReadByte();

			if (ret == Command.NAK) throw new ChecksumException();
			if (ret != Command.ACK) throw new ProtocolException(string.Format(Messages.InvalidReply, ret, null));

			tcpClient.ReceiveTimeout = tcpClient.SendTimeout = OPERATION_TIMEOUT;
			var response = new List<byte>();

			for (; ; )
			{
				var read = (byte)stream.ReadByte();
				response.Add(read);

				if (tcpClient.ReceiveTimeout == OPERATION_TIMEOUT) tcpClient.ReceiveTimeout = tcpClient.SendTimeout = PROTOCOL_TIMEOUT;

				if (read == Command.ETX)
				{
					var lrc = (byte)stream.ReadByte();
					response.Add(lrc);
					break;
				}
			}

			return Command.Parse(response.ToArray());
		}

		#endregion Methods

		#region IDisposable

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		private void Dispose(bool disposing)
		{
			if (disposing) GC.SuppressFinalize(this);

			Disconnect();
		}

		#endregion IDisposable
	}
}