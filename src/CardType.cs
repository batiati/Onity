namespace Onity.HT24
{
	public enum CardType
	{
		#region Documentation

		/// <summary>
		/// Customer card
		/// </summary>

		#endregion Documentation

		CustomerCard,

		#region Documentation

		/// <summary>
		/// Customer card NOT valid
		/// </summary>

		#endregion Documentation

		InvalidCustomerCard,

		#region Documentation

		/// <summary>
		/// Master card or special card (programmer, canceller or blocker)
		/// </summary>

		#endregion Documentation

		MasterCard,

		#region Documentation

		/// <summary>
		/// Spare card for customers
		/// </summary>

		#endregion Documentation

		SpareCard,

		#region Documentation

		/// <summary>
		/// Diagnostic card
		/// </summary>

		#endregion Documentation

		DiagnosticCard,

		#region Documentation

		/// <summary>
		/// Tarjeta desconocida (Perteneciente a otro hotel o retirada del plan de cierre)
		/// </summary>

		#endregion Documentation

		UnknownCard
	}
}