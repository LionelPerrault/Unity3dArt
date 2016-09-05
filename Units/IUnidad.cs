﻿using System;
using Cells;
using Cells.CellObjects;
using Componentes;
using Moggle.Screens;
using Units.Recursos;

namespace Units
{
	public interface IUnidad : IUpdateGridObject
	{
		Grid MapGrid { get; }

		/// <summary>
		/// Try to damage a target.
		/// </summary>
		void MeleeDamage (IUnidad target);

		ManejadorRecursos Recursos { get; }

		bool Habilitado { get; }

		int Equipo { get; }
	}

	static class UnidadImplementation
	{
		/// <summary>
		/// Muere esta unidad.
		/// </summary>
		[Obsolete ("El encargado de esto es Grid.")]
		public static void Die (this IUnidad u)
		{
			u.MapGrid.RemoveObject (u);
		}

		/// <summary>
		/// Se causa daño
		/// </summary>
		/// <param name="u">Unidad</param>
		/// <param name="dmg">Cantidad de daño propuesto.</param>
		public static void DoDamage (this IUnidad u,
		                             float dmg)
		{
			var hp = u.Recursos.GetRecurso ("hp");
			hp.Valor -= dmg;

		}

		/// <summary>
		/// Se causa daño
		/// </summary>
		/// <param name="u">Unidad</param>
		/// <param name="dmg">Cantidad de daño propuesto.</param>
		/// <param name="scr">Screen.</param>
		public static void DoDamage (this IUnidad u,
		                             float dmg, IScreen scr)
		{
			TimeSpan duración = TimeSpan.FromMilliseconds (300);
			DoDamage (u, dmg);
			var vs = new VanishingString (scr, dmg.ToString (), duración);
			scr.AddComponent (vs);
		}
	}
}