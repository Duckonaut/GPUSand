using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GPUSand
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		RenderTarget2D MainTarget, StoreTarget;
		private bool drawDuck;

		Texture2D Pixel { get; set; }
		Texture2D Duck { get; set; }
		Effect FallEffect { get; set; }


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			graphics.PreferredBackBufferHeight = 360;
			graphics.PreferredBackBufferWidth = 640;
			graphics.GraphicsProfile = GraphicsProfile.HiDef;

		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			MainTarget = new RenderTarget2D(GraphicsDevice, 160, 90);
			StoreTarget = new RenderTarget2D(GraphicsDevice, 160, 90, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);

			Pixel = Content.Load<Texture2D>("Pixel");
			Duck = Content.Load<Texture2D>("Duck");
			FallEffect = Content.Load<Effect>("FallEffect");
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			Input.CurrentState = Keyboard.GetState();
			Input.CurrentMouseState = Mouse.GetState();

			drawDuck = false;
			if (Input.SpaceClick) drawDuck = true;

				Input.PastState = Input.CurrentState;
			Input.PastMouseState = Input.CurrentMouseState;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.SetRenderTarget(StoreTarget);
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, effect: null, samplerState: SamplerState.PointClamp);

			spriteBatch.Draw(MainTarget, position: Vector2.Zero, color: Color.White);

			if (Input.MouseHold) spriteBatch.Draw(Pixel, Input.MousePos.ToVector2(), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);

			if (Input.RightMouseHold) spriteBatch.Draw(Pixel, Input.MousePos.ToVector2(), null, Color.Black, 0f, new Vector2(0.5f), 4f, SpriteEffects.None, 0);

			if(drawDuck) spriteBatch.Draw(Duck, Input.MousePos.ToVector2(), null, Color.White, 0f, Duck.Bounds.Size.ToVector2() / 2, 1f, SpriteEffects.None, 0);

			spriteBatch.End();



			GraphicsDevice.SetRenderTarget(MainTarget);
			GraphicsDevice.Clear(Color.Black);

			FallEffect.Parameters["SpriteTexture"].SetValue(StoreTarget);
			FallEffect.Parameters["size"].SetValue(new Vector2(160, 90));
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, effect: FallEffect, samplerState: SamplerState.PointClamp);

			spriteBatch.Draw(StoreTarget, position: Vector2.Zero, color: Color.White);

			spriteBatch.End();

			GraphicsDevice.SetRenderTarget(null);
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, effect: null, samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(4f));

			spriteBatch.Draw(MainTarget, position: Vector2.Zero, color: Color.White);

			spriteBatch.Draw(Pixel, Input.MousePos.ToVector2(), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void AddEffect(Effect effect)
		{
			
		}
	}
}
