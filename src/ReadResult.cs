using System;

namespace Onity.HT24
{
	public sealed class ReadResult
	{
		#region Documentation

		/// <summary>
		/// No. of the recorder / reader involved
		/// </summary>

		#endregion Documentation

		public int EncoderNumber { get; set; }

		#region Documentation

		/// <summary>
		/// CardType
		/// </summary>

		#endregion Documentation

		public CardType CardType { get; set; }

		#region Documentation

		/// <summary>
		/// Room No. 1 (main) that opens the card.
		/// </summary>

		#endregion Documentation

		public string Room1 { get; set; }

		#region Documentation

		/// <summary>
		/// Room No. 2 that opens the card.
		/// </summary>

		#endregion Documentation

		public string Room2 { get; set; }

		#region Documentation

		/// <summary>
		/// Room No. 3 that opens the card.
		/// </summary>

		#endregion Documentation

		public string Room3 { get; set; }

		#region Documentation

		/// <summary>
		/// Room No. 4 that opens the card.
		/// </summary>

		#endregion Documentation

		public string Room4 { get; set; }

		#region Documentation

		/// <summary>
		/// Card with valid code of the main room, otherwise a card whose code of the main room canceled by Check-Out.
		/// </summary>

		#endregion Documentation

		public bool CheckedIn { get; set; }

		#region Documentation

		/// <summary>
		/// Copy number indication or single opening card (from the main room).
		/// 0: original card
		/// 1: 1st copy
		/// 2: 2nd copy
		/// 3: 3rd copy
		/// 4: 4th copy
		/// I: indefinite copy(fifth or successive)
		/// A: single opening card.
		/// </summary>

		#endregion Documentation

		public string Copy { get; set; }

		#region Documentation

		/// <summary>
		/// Authorizations granted.
		/// Numbers(from 1 to 8) of the authorizations granted to the card or empty field if none authorization granted.
		/// </summary>

		#endregion Documentation

		public string Authorization { get; set; }

		#region Documentation

		/// <summary>
		/// Validity start date of the card or empty field if it does not have a start date.
		/// </summary>

		#endregion Documentation

		public DateTime? InitialDateTime { get; set; }

		#region Documentation

		/// <summary>
		/// Expiration date of the card or empty field if it does not expire.
		/// </summary>

		#endregion Documentation

		public DateTime? FinalDateTime { get; set; }

		#region Documentation

		/// <summary>
		/// Name of the operator who recorded the card if there is still evidence of this in the auditor record of the system or empty field if not.
		/// </summary>

		#endregion Documentation

		public string User { get; set; }

		#region Documentation

		/// <summary>
		/// NFC uid
		/// </summary>

		#endregion Documentation

		public string Uid { get; set; }

		#region Documentation

		/// <summary>
		/// Error message if Unknown card (Pertaining to another hotel or withdrawal from the closure plan)
		/// </summary>

		#endregion Documentation

		public string ErrorMessage { get; set; }
	}
}