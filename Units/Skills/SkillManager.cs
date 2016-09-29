﻿using System.Collections.Generic;
using System.Linq;

namespace Units.Skills
{
	public class SkillManager
	{
		public IUnidad Unidad { get; }

		public List<ISkill> Skills { get; }

		public bool Any { get { return Skills.Any (); } }

		public SkillManager (IUnidad unid)
		{
			Unidad = unid;
			Skills = new List<ISkill> ();
		}
	}
}