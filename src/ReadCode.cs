namespace Onity.HT24
{
	internal enum ReadCode
	{
		#region Documentation

		/// <summary>
		/// Tarjeta de cliente NO válida
		/// </summary>

		#endregion Documentation

		LC,

		#region Documentation

		/// <summary>
		/// Tarjeta maestra o tarjeta especial (programadora, anuladora o bloqueadora)
		/// </summary>

		#endregion Documentation

		LM,

		#region Documentation

		/// <summary>
		/// Tarjeta de repuesto para clientes
		/// </summary>

		#endregion Documentation

		LR,

		#region Documentation

		/// <summary>
		/// Tarjeta de diagnóstico
		/// </summary>

		#endregion Documentation

		LS,

		#region Documentation

		/// <summary>
		/// Tarjeta desconocida
		/// </summary>

		#endregion Documentation

		LD,
	}
}