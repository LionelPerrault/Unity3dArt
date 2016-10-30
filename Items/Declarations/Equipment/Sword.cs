﻿using Units.Buffs;
using Units.Recursos;
using Units;
using Units.Order;

namespace Items.Declarations.Equipment
{
	/// <summary>
	/// Una espada sin propiedades especiales
	/// </summary>
	public class Sword : Equipment, IBuffGenerating, IMeleeEffect
	{
		/// <summary>
		/// Enumera los stats y la cantidad que son modificados.
		/// </summary>
		/// <returns>The delta stat.</returns>
		public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, float>> GetDeltaStat ()
		{
			yield return new System.Collections.Generic.KeyValuePair<string, float> (
				ConstantesRecursos.DañoMelee,
				3);
		}

		#region IEquipment implementation

		/// <summary>
		/// Gets the equipment slot.
		/// </summary>
		/// <value>The slot.</value>
		public override EquipSlot Slot { get { return EquipSlot.MainHand; } }

		#endregion

		public void DoMeleeOn (IUnidad target)
		{
			Owner.Owner.EnqueueOrder (new MeleeDamageOrder (UnidadOwner, target));
			Owner.Owner.EnqueueOrder (new CooldownOrder (
				UnidadOwner,
				calcularTiempoMelee ()));
		}

		float calcularTiempoMelee ()
		{
			var dex = Owner.Owner.Recursos.ValorRecurso (ConstantesRecursos.Destreza);
			return 1 / dex;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Items.Declarations.Equipment.Sword"/> class.
		/// </summary>
		/// <param name="nombre">Nombre.</param>
		/// <param name="icon">Icon.</param>
		protected Sword (string nombre, string icon)
			: base (nombre)
		{
			TextureName = icon;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Items.Declarations.Equipment.Sword"/> class.
		/// </summary>
		public Sword ()
			: this ("Sword", @"Items/katana")
		{
			Color = Microsoft.Xna.Framework.Color.Black;
		}
	}
}