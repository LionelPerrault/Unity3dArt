using System;
using System.Collections.Generic;
using System.Linq;
using Cells;
using Units;

namespace Maps
{
	/// <summary>
	/// Provides methods to populate and repopulate a map.
	/// </summary>
	public class Populator
	{
		internal readonly List<PopulationRule> Rules;
		static readonly Random _r = new Random ();

		public IList<Unidad> BuildPop (LogicGrid grid, float totalExp = 0)
		{
			var ret = new List<Unidad> ();
			foreach (var rule in Rules.Where (rule => _r.NextDouble () < rule.Chance))
				foreach (var st in rule.Stacks)
				{
					var qt = st.UnitQuantityDistribution.Pick ();
					// build 'qt' copies of this race
					for (int i = 0; i < qt; i++)
					{
						// TODO: calculate properly the exp of this un
						var un = st.Race.MakeEnemy (grid, totalExp);
						ret.Add (un);
					}
				}
			return ret;
		}

		public void AddRule (PopulationRule rule)
		{
			rule.LinkWith (this);
		}

		public Populator ()
		{
			Rules = new List<PopulationRule> ();
		}
	}
	
}