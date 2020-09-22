namespace Onity.HT24
{
	public sealed class CheckoutData
	{
		#region Documentation

		/// <summary>
		/// Recorder number where you want to record the card. See the list of peripherals of the HT24 program for the number assigned to each recorder.
		/// </summary>

		#endregion Documentation

		public int EncoderNumber { get; set; }

		#region Documentation

		/// <summary>
		/// Room granted nº 1. (main room)
		/// </summary>

		#endregion Documentation

		public string Room { get; set; }
	}
}