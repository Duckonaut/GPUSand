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

		public static bool Button1 => CurrentState.IsKeyDown(Keys.Q) && PastState.IsKeyUp(Keys.Q);
		public static bool Button1Down => CurrentState.IsKeyDown(Keys.Q);
		public static bool Button2 => CurrentState.IsKeyDown(Keys.E) && PastState.IsKeyUp(Keys.E);
		public static bool Button2Down => CurrentState.IsKeyDown(Keys.E);

		public static bool Up => CurrentState.IsKeyDown(Keys.W);
		public static bool Down => CurrentState.IsKeyDown(Keys.S);
		public static bool LeftClick => CurrentState.IsKeyDown(Keys.A) && PastState.IsKeyUp(Keys.A);
		public static bool Left => CurrentState.IsKeyDown(Keys.A);
		public static bool RightClick => CurrentState.IsKeyDown(Keys.D) && PastState.IsKeyUp(Keys.D);
		public static bool Right => CurrentState.IsKeyDown(Keys.D);
		public static bool SpaceClick => CurrentState.IsKeyDown(Keys.Space) && PastState.IsKeyUp(Keys.Space);

		public static Point MousePos => new Point(CurrentMouseState.Position.X / 2, CurrentMouseState.Position.Y / 4);
		public static bool MouseClick => CurrentMouseState.LeftButton == ButtonState.Pressed && PastMouseState.LeftButton == ButtonState.Released;
		public static bool MouseHold => CurrentMouseState.LeftButton == ButtonState.Pressed;
		public static bool RightMouseHold => CurrentMouseState.RightButton == ButtonState.Pressed;
	}
}