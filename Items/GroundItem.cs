using Cells;
using Cells.CellObjects;
using Items;

namespace Items
{
	/// <summary>
	/// Representa un <see cref="IItem"/> en el suelo.
	/// </summary>
	public class GroundItem : GridObject
	{
		/// <summary>
		/// Gets the <see cref="IItem"/> this object refers
		/// </summary>
		/// <value>The item class.</value>
		public IItem ItemClass { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Items.GroundItem"/> class.
		/// </summary>
		/// <param name="type">Item type</param>
		/// <param name="grid">Grid.</param>
		public GroundItem (IItem type, Grid grid)
			: base (type.DefaultTextureName, grid)
		{
			ItemClass = type;
			Depth = Depths.Foreground;
			UseColor = ItemClass.DefaultColor;
		}
	}
}