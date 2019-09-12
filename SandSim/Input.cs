using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GPUSand
{
	public class Input 
	{
		public static KeyboardState CurrentState;
		public static KeyboardState PastState;

		public static MouseState CurrentMouseState;
		public static MouseState PastMouseState;

		public static bool SpaceClick => CurrentState.IsKeyDown(Keys.Space) && PastState.IsKeyUp(Keys.Space);

		public static Point MousePos => new Point(CurrentMouseState.Position.X / 2, CurrentMouseState.Position.Y / 4);
		public static bool MouseClick => CurrentMouseState.LeftButton == ButtonState.Pressed && PastMouseState.LeftButton == ButtonState.Released;
		public static bool MouseHold => CurrentMouseState.LeftButton == ButtonState.Pressed;
		public static bool RightMouseHold => CurrentMouseState.RightButton == ButtonState.Pressed;
	}
}