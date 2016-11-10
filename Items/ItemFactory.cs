﻿using System;
using Items.Declarations.Equipment;
using Items.Declarations.Pots;
using Microsoft.Xna.Framework;

namespace Items
{
	/// <summary>
	/// Tipo de objeto
	/// </summary>
	public enum ItemType
	{
		/// <summary>
		/// Sword
		/// </summary>
		/// <seealso cref="Items.Declarations.Equipment.Sword"/>
		Sword,
		/// <summary>
		/// Potion
		/// </summary>
		/// <seealso cref="Items.Declarations.Pots.HealingPotion"/>
		HealingPotion,
		Leather_Armor,
		Leather_Cap
	}

	/// <summary>
	/// This class produces new items from its type
	/// </summary>
	public static class ItemFactory
	{
		/// <summary>
		/// Creates a new item of the given type
		/// </summary>
		/// <returns>A newly created item</returns>
		/// <param name="type">Type of the item</param>
		public static IItem CreateItem (ItemType type)
		{
			IItem ret;
			switch (type)
			{
				case ItemType.Sword:
					ret = new Sword ();
					break;
				case ItemType.HealingPotion:
					ret = new HealingPotion ();
					break;
				case ItemType.Leather_Armor:
					ret = new GenericArmor ("Leather Armor", EquipSlot.Body)
					{
						Color = Color.OrangeRed,
						TextureNameGeneric = "Items//body armor"
					};
					break;
				case ItemType.Leather_Cap:
					ret = new GenericArmor ("Leather Cap", EquipSlot.Head)
					{
						Color = Color.OrangeRed,
						TextureNameGeneric = "Items//helmet"
					};
					break;
				default:
					throw new Exception ();
			}
			ret.Initialize ();
			return ret;
		}
	}
}