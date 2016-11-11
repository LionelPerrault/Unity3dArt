﻿using System;
using Items.Declarations.Equipment;
using Items.Declarations.Pots;
using Moggle;

namespace Items
{
	/// <summary>
	/// Gets the type of an item
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
		HealingPotion
	}

	/// <summary>
	/// This class produces new items from its type
	/// </summary>
	public static class ItemFactory
	{
		public static BibliotecaContenido ContentManager;

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
					ret = new Sword (ContentManager);
					break;
				case ItemType.HealingPotion:
					ret = new HealingPotion (ContentManager);
					break;
				default:
					throw new Exception ();
			}
			ret.Initialize ();
			return ret;
		}
	}
}