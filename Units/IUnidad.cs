﻿using Cells.CellObjects;

namespace Units
{
	public interface IUnidad
	{
		/// <summary>
		/// Devuelve el objeto de celda asociado a esta unidad.
		/// </summary>
		/// <value>The cell object.</value>
		ICellObject CellObject { get; }
	}
}