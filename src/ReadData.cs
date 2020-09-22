namespace Onity.HT24
{
	public sealed class ReadData
	{
		#region Documentation

		/// <summary>
		/// Número del grabador donde se desea grabar la tarjeta
		/// Véase en la lista de periféricos del programa HT24 el número otorgado a cada grabador.
		/// </summary>

		#endregion Documentation

		public int EncoderNumber { get; set; }

		#region Documentation

		/// <summary>
		/// Retención o expulsión de la tarjeta.
		/// Al acabar la operación de grabación, la tarjeta puede quedar retenida dentro del grabador para otras operaciones o ser expulsada
		/// </summary>

		#endregion Documentation

		public EjectionType ExpellingType { get; set; }
	}
}