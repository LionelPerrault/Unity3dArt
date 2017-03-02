﻿using Cells;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Moggle.Controles;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using AoM;

namespace Componentes
{
	/// <summary>
	/// Control taht connects to a <see cref="MemoryGrid"/> and display its minimap
	/// </summary>
	public class MinimapControl : DSBC
	{
		/// <summary>
		/// Gets the memory grid linked to this minimap
		/// </summary>
		public MemoryGrid DisplayingGrid { get; set; }

		Texture2D borderTexture;

		/// <summary>
		/// Produces a texture based on <see cref="DisplayingGrid"/>
		/// </summary>
		public Texture2D ProduceTexture ()
		{
			var size = DisplayingGrid.MemorizingGrid.Size;
			var ret = new Texture2D (Game.GraphicsDevice, size.Width, size.Height);

			var _data = new Color[size.Width * size.Height];
			for (int i = 0; i < size.Width * size.Height; i++)
			{
				var px = i % size.Width;
				var py = i / size.Width;
				_data [i] = DisplayingGrid [new Point (px, py)].MinimapColor;
			}

			ret.SetData<Color> (_data);
			return ret;
		}

		Rectangle _location;

		/// <summary>
		/// Gets the last produces texture of the minimap
		/// </summary>
		protected Texture2D LastGeneratedTexture { get; private set; }

		/// <summary>
		/// Gets or sets the location of this control
		/// </summary>
		/// <value>The location.</value>
		public Rectangle Location
		{
			get{ return _location; }
			set
			{
				_location = value;
				if (IsInitialized)
					OnLocationChanged ();
			}
		}

		/// <summary>
		/// initializes this minimap, and susbribes to the DisplayingGrid update event
		/// </summary>
		public override void Initialize ()
		{
			base.Initialize ();
			DisplayingGrid.Updated += update;
			RegenerateTexture ();
		}

		/// <summary>
		/// Shuts down the component.
		/// Unsuscribes the events of the mouse and from DisplayingGrid
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="Componentes.MinimapControl"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="Componentes.MinimapControl"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="Componentes.MinimapControl"/> so
		/// the garbage collector can reclaim the memory that the <see cref="Componentes.MinimapControl"/> was occupying.</remarks>
		protected override void Dispose ()
		{
			DisplayingGrid.Updated += update;
			base.Dispose ();
		}

		void update (object sender, System.EventArgs e)
		{
			RegenerateTexture ();
		}

		/// <summary>
		/// This is invoked whenever the location is changed (after initialization).
		/// It regenerates the minima texture
		/// </summary>
		protected virtual void OnLocationChanged ()
		{
			RegenerateTexture ();
		}

		Color _outColor = Color.White;
		Color _inColor = Color.DarkGray * 0.1f;

		public void RegenerateTexture ()
		{
			LastGeneratedTexture = ProduceTexture ();
			var size = new Size (Location.Width, Location.Height);
			borderTexture = (Game as Juego).SimpleTextureGenerator.OutlineTexture (size, _outColor, _inColor);
		}

		/// <summary>
		/// Draws this minimap
		/// </summary>
		protected override void Draw ()
		{
			var bat = Screen.Batch;
			bat.Draw (borderTexture, Location, Color.White);
			bat.Draw (LastGeneratedTexture, Location, Color.White);
		}

		public override void Update (GameTime gameTime)
		{
		}

		protected override IShapeF GetBounds ()
		{
			return Location.ToRectangleF ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Componentes.MinimapControl"/> class.
		/// </summary>
		public MinimapControl (IComponentContainerComponent<IControl> cont)
			: base (cont)
		{
		}
	}
}