﻿using Cells.CellObjects;
using Microsoft.Xna.Framework.Content;
using Cells;

namespace Units
{
	public interface IIntelligence
	{
		void DoAction ();
	}

	public class ChaseIntelligence  : IIntelligence
	{
		public ChaseIntelligence (Grid mapGrid, UnidadArtificial yo)
		{
			MapGrid = mapGrid;
			Yo = yo;
		}

		public Grid MapGrid { get; }

		public readonly UnidadArtificial Yo;

		public void DoAction ()
		{
			var target = MapGrid.Objects.Find (z => z is UnidadHumano);
			var dir = Yo.Location.GetDirectionTo (target.Location);
			if (dir == MovementDirectionEnum.NoMov)
				return;
			MapGrid.MoveCellObject (Yo, dir);
		}
	}

	public class UnidadArtificial : UnidadHumano
	{
		public UnidadArtificial (ContentManager content,
		                         string texture = TextureType)
			: base (content, texture)
		{
		}

		public IIntelligence IA { get; set; }
	}
}