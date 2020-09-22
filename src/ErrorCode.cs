namespace Onity.HT24
{
	public enum ErrorCode
	{
		#region Documentation

		/// <summary>
		/// Syntax error.
		/// </summary>

		#endregion Documentation

		ES,

		#region Documentation

		/// <summary>
		/// The recorder / reader is not answered. Communications failure, off or does not exist.
		/// </summary>

		#endregion Documentation

		NC,

		#region Documentation

		/// <summary>
		/// No files. PC files interface damaged or not found
		/// </summary>

		#endregion Documentation

		NF,

		#region Documentation

		/// <summary>
		/// Overflow. The addressed recorder / reader has not yet completed the previous task.
		/// </summary>

		#endregion Documentation

		OV,

		#region Documentation

		/// <summary>
		/// Magnetic track error. Card inserted from reverse or missing magnetic track.
		/// </summary>

		#endregion Documentation

		EP,

		#region Documentation

		/// <summary>
		/// Magnetic format error.
		/// The card has been recorded according to other standards (usually this error will occur when you want to read on track 3 according to ISO standards a card recorded according to ONITY standards) or the magnetic stripe is defective
		/// </summary>

		#endregion Documentation

		EF,

		#region Documentation

		/// <summary>
		/// Level error.
		/// The card has been recorded too low. (Dirt on the recorder head or low quality card).
		/// </summary>

		#endregion Documentation

		EN,

		#region Documentation

		/// <summary>
		/// Card stuck.
		/// The card does not comply with the physical measures required
		/// </summary>

		#endregion Documentation

		ET,

		#region Documentation

		/// <summary>
		/// Unknown card.
		/// When ordering a card for a room that does not exist.
		/// </summary>

		#endregion Documentation

		TD,

		#region Documentation

		/// <summary>
		/// Timed out. The recorder / reader cancels the current operation if it can not swallow the card.
		/// </summary>

		#endregion Documentation

		ED,

		#region Documentation

		/// <summary>
		/// Exit single opening cards. Only 4 single opening cards per room and customer can be edited.
		/// If you are prompted to edit more, this error message is generated.
		/// </summary>

		#endregion Documentation

		EA,

		#region Documentation

		/// <summary>
		/// Room out of service. The card can not be recorded until the room is back in service indicating it in the HT24 program.
		/// </summary>

		#endregion Documentation

		OS,
	}
}