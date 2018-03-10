using MapMaker.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MapMaker
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;




		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			bool fullscreen = false;
			if (!fullscreen)
			{
				graphics.PreferredBackBufferWidth = 1900;  // set this value to the desired width of your window
				graphics.PreferredBackBufferHeight = 900;   // set this value to the desired height of your window
				graphics.ApplyChanges();
			}
			else
			{
				graphics.ToggleFullScreen();
			}


			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			// TODO: Add your initialization logic here



			Texture2D[] textures = {	Content.Load<Texture2D>("testTile001"),			//white
										Content.Load<Texture2D>("testTile002"),			//black
										Content.Load<Texture2D>("testTile003"),			//blue
										Content.Load<Texture2D>("testTile004"),
										Content.Load<Texture2D>("testTile005"),
										Content.Load<Texture2D>("testTile006"),
										Content.Load<Texture2D>("testTile007"),
										Content.Load<Texture2D>("testTile008"),
										Content.Load<Texture2D>("testTile999")		};  //red default

			Texture2D bitMap = Content.Load<Texture2D>("testmap004");
			
			GS.I.mapGenerator = new MapGenerator(new Point(100, 100));

			//GS.I.tileMap = new TileMap(textures, bitMap);

			GS.I.tileMap = new TileMap(textures, GS.I.mapGenerator.bitMap);

			GS.I.player = new Player(Content.Load<Texture2D>("testPlayer001"));

			GS.I.camera = new Camera(GraphicsDevice.Viewport);

			base.Initialize();
		}


		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}


		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			GS.I.player.Update(gameTime);

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Purple);

			spriteBatch.Begin(transformMatrix: GS.I.camera.GetViewMatrix());

			GS.I.tileMap.Draw(spriteBatch);
			GS.I.player.Draw(spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
