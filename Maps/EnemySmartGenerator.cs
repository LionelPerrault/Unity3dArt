using System;
using System.Collections.Generic;
using Cells;
using Microsoft.Xna.Framework;
using Units;
using Helper;

namespace Maps
{
	/// <summary>
	/// The enemy generator for a <see cref="LogicGrid"/>
	/// </summary>
	public class EnemySmartGenerator
	{
		UnidadFactory Factory { get; }

		readonly Random _r;

		LogicGrid grid { get { return Factory.Grid; } }

		readonly IDistribution<int> NumEnemiesInterval;

		static readonly Color enemyColor = Color.Blue;

		List<EnemyGenerationData> enemyType { get; }

		/// <summary>
		/// Add new enemies to it's <see cref="LogicGrid"/>
		/// </summary>
		public void PopulateGrid ()
		{
			var numEnemies = NumEnemiesInterval.Pick ();	// Number of enemies
			var expEach = Difficulty / numEnemies;			// Experience for each enemy

			var enemyTeam = new TeamManager (enemyColor);
			for (int i = 0; i < numEnemies; i++)
			{
				// Pick a data
				var data = enemyType [_r.Next (enemyType.Count)];

				var enemy = Factory.MakeEnemy (data.Type, data.Class, expEach);
				enemy.Team = enemyTeam;

				var point = grid.GetRandomEmptyCell ();
				enemy.Location = point;
				grid [point].Add (enemy);
			}
		}

		/// <summary>
		/// Difficulty of the enemies of the grid.
		/// It is the total received exp for it's enemies.
		/// </summary>
		public float Difficulty;

		public void AddEnemyType (EnemyType type, EnemyClass @class)
		{
			enemyType.Add (new EnemyGenerationData (type, @class));
		}

		public void AddEnemyType (EnemyGenerationData enemyType)
		{
			this.enemyType.Add (enemyType);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Maps.EnemySmartGenerator"/> class.
		/// </summary>
		public EnemySmartGenerator (UnidadFactory factory,
		                            float difficulty,
		                            int minEnemies = 1,
		                            int maxEnemines = 10)
		{
			Factory = factory;
			Difficulty = difficulty;
			NumEnemiesInterval = new Helper.IntegerInterval (minEnemies, maxEnemines);
			enemyType = new List<EnemyGenerationData> ();
			_r = new Random ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Maps.EnemySmartGenerator"/> class.
		/// </summary>
		public EnemySmartGenerator (LogicGrid grid,
		                            float difficulty,
		                            int minEnemies = 1,
		                            int maxEnemines = 10)
			: this (new UnidadFactory (grid),
			        difficulty,
			        minEnemies,
			        maxEnemines)
		{
		}

		public struct EnemyGenerationData
		{
			public EnemyType Type { get; }

			public EnemyClass Class { get; }

			public EnemyGenerationData (EnemyType type, EnemyClass @class)
			{
				Type = type;
				Class = @class;
			}
		}
	}
	
}