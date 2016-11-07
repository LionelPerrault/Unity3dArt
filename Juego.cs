using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AoM
{
	/// <summary>
	/// The game engine
	/// </summary>
	public class Juego : Moggle.Game
	{
		#region Texturas definidas

		/// <summary>
		/// Gets the set of predefined run-time-generated <see cref="Texture"/>
		/// </summary>
		/// <value>The textures.</value>
		public static Textures Textures { get; private set; }

		#endregion

		/// <summary>
		/// Carga el contenido del juego, incluyendo los controles universales.
		/// </summary>
		protected override void LoadContent ()
		{
			base.LoadContent ();
			Textures = new Textures (GraphicsDevice);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AoM.Juego"/> class.
		/// </summary>
		public Juego ()
		{
			Content.RootDirectory = @"Content/Content";
			Graphics.IsFullScreen = true;
		}
	}

	/// <summary>
	/// Set of easy definable textures
	/// </summary>
	public class Textures
	{
		/// <summary>
		/// Solid white color texture
		/// </summary>
		public readonly Texture2D SolidTexture;

		/// <summary>
		/// Initializes a new instance of the <see cref="AoM.Textures"/> class.
		/// </summary>
		/// <param name="gd">Gd.</param>
		internal Textures (GraphicsDevice gd)
		{
			SolidTexture = new Texture2D (gd, 1, 1);
			var data = new Color[1];
			data [0] = Color.White;
			SolidTexture.SetData (data);
		}
	}
}