using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Art_of_Meow
{
	public class Juego : Moggle.Game
	{
		#region Texturas definidas

		public static Textures Textures { get; private set; }

		#endregion

		public Juego ()
		{
			Graphics.IsFullScreen = true;
			Textures = new Textures (GraphicsDevice);
		}
	}

	public class Textures
	{
		public readonly Texture2D SolidTexture;

		public Textures (GraphicsDevice gd)
		{
			SolidTexture = new Texture2D (gd, 1, 1);
			var data = new Color[1];
			data [0] = Color.White;
			SolidTexture.SetData (data);
		}
	}
}