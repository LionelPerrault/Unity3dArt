﻿using System.Collections.Generic;
using Units.Skills;
using Newtonsoft.Json;
using AoM;

namespace Items.Declarations.Equipment
{
	/// <summary>
	/// Weapon that has a inner skills
	/// </summary>
	public class GenericSkillListEquipment : Equipment, ISkillEquipment
	{
		/// <summary>
		/// Gets the slot where it can be equiped.
		/// </summary>
		public override EquipSlot Slot { get; }

		public readonly string [] InvokedSkillNames;

		/// <summary>
		/// Devuelve el skill que se invoca al usar este item
		/// </summary>
		public IEnumerable <ISkill> InvokedSkills
		{
			get
			{
				foreach (var i in InvokedSkillNames)
					yield return Program.MyGame.SkillList.GetSkill (i);
			}
		}

		IEnumerable<ISkill> ISkillEquipment.GetEquipmentSkills ()
		{
			return InvokedSkills;
		}

		/// <summary>
		/// Gets the value or worth of the item
		/// </summary>
		public override float Value
		{
			get
			{
				var ret = base.Value;
				foreach (var sk in InvokedSkills)
					ret += sk.Value;
				return ret;
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="NombreBase">Nombre.</param>
		/// <param name="InvokedSkill">Invoked skill list.</param>
		/// <param name="Slot">Slot</param>
		/// <param name="TextureName">Texture</param>
		[JsonConstructor]
		public GenericSkillListEquipment (string NombreBase,
		                                  string [] InvokedSkill, 
		                                  EquipSlot Slot,
		                                  string TextureName)
			: base (NombreBase)
		{
			InvokedSkillNames = InvokedSkill;
			this.Slot = Slot;
			this.TextureName = TextureName;
		}

		/// <summary>
		/// Clone this instance.
		/// </summary>
		public override object Clone ()
		{
			return new GenericSkillListEquipment (NombreBase, InvokedSkillNames, Slot)
			{
				TextureName = TextureName,
				Texture = Texture,
				Color = Color
			};
		}

		/// <summary>
		/// </summary>
		/// <param name="nombre">Nombre.</param>
		/// <param name="invokedSkill">Invoked skill list.</param>
		/// <param name="slot">Slot</param>
		public GenericSkillListEquipment (string nombre,
		                                  string [] invokedSkill, 
		                                  EquipSlot slot)
			: this (nombre, invokedSkill, slot, nombre)
		{
		}
	}
}