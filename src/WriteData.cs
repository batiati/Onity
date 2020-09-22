using System;

namespace Onity.HT24
{
	public sealed class WriteData
	{
		#region Documentation

		/// <summary>
		/// Values from 1 to 9 to record x cards of the same room with a single request from the PMS
		/// </summary>

		#endregion Documentation

		public int? Quantity { get; set; }

		#region Documentation

		/// <summary>
		/// Recorder number where you want to record the card. See the list of peripherals of the HT24 program for the number assigned to each recorder.
		/// </summary>

		#endregion Documentation

		public int EncoderNumber { get; set; }

		#region Documentation

		/// <summary>
		/// Retention or expulsion of the card. At the end of the recording operation, the card may be retained inside the recorder for other operations or be ejected
		/// </summary>

		#endregion Documentation

		public EjectionType EjectionType { get; set; }

		#region Documentation

		/// <summary>
		/// Room granted No.1 (main room)
		/// </summary>

		#endregion Documentation

		public string Room1 { get; set; }

		#region Documentation

		/// <summary>
		/// Room granted No.2
		/// </summary>

		#endregion Documentation

		public string Room2 { get; set; }

		#region Documentation

		/// <summary>
		/// Room granted No.3
		/// </summary>

		#endregion Documentation

		public string Room3 { get; set; }

		#region Documentation

		/// <summary>
		/// Room granted No.4
		/// </summary>

		#endregion Documentation

		public string Room4 { get; set; }

		#region Documentation

		/// <summary>
		/// Authorizations granted to the client
		/// Mention the number of authorizations that are granted to the client. If we want to grant a client the use of the pool and the safe (authorizations nº 3 and 6 respectively in the closure plan), the fields will be: "36"
		/// </summary>

		#endregion Documentation

		public string Authorization { get; set; }

		#region Documentation

		/// <summary>
		/// Authorizations denied to the client.
		/// Mention the number of authorizations that are denied to the client. If we want to grant a client the use of the pool and the safe (authorizations nº 3 and 6 respectively in the closure plan), the fields will be: "36"
		/// </summary>

		#endregion Documentation

		public string Deny { get; set; }

		#region Documentation

		/// <summary>
		/// Start date of the card.
		/// </summary>

		#endregion Documentation

		public DateTime? InitialDateTime { get; set; }

		#region Documentation

		/// <summary>
		/// Expiration date of the card.
		/// </summary>

		#endregion Documentation

		public DateTime FinalDateTime { get; set; }

		#region Documentation

		/// <summary>
		/// Data of the operator who records the card
		/// </summary>

		#endregion Documentation

		public string User { get; set; }

		#region Documentation

		/// <summary>
		/// Message to be recorded on track 1 according to ISO standards.
		/// </summary>

		#endregion Documentation

		public string Track1 { get; set; }

		#region Documentation

		/// <summary>
		/// Message to be recorded on track 2 according to ISO standards
		/// </summary>

		#endregion Documentation

		public string Track2 { get; set; }
	}
}