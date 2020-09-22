namespace Onity.HT24
{
	internal enum CommandType
	{
		#region Documentation

		/// <summary>
		/// To record a card for a new customer. This card will void automatically the card of the previous customer.
		/// </summary>

		#endregion Documentation

		CN,

		#region Documentation

		/// <summary>
		/// To record a copy for the person who shares the room.
		/// </summary>

		#endregion Documentation

		CC,

		#region Documentation

		/// <summary>
		/// Check-out of a client. All customer cards in the corresponding room are unsubscribed.
		/// </summary>

		#endregion Documentation

		CO,

		#region Documentation

		/// <summary>
		/// Recording a single aperture card. Single-opening cards are only valid on room locks. They are void when changing customer or when used once
		/// </summary>

		#endregion Documentation

		CA,

		#region Documentation

		/// <summary>
		/// Cancels a task and ejects the card if it has been held inside the recorder in a previous operation.
		/// </summary>

		#endregion Documentation

		EX,

		#region Documentation

		/// <summary>
		/// Reading and interpretation of data recorded on track 3 according to ONITY standards.
		/// </summary>

		#endregion Documentation

		LT,
	}
}