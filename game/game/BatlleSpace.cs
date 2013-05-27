using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BatlleSpace.Helpers;
using BatlleSpace.GameObjects;



namespace BatlleSpace
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BatlleSpace : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int Width;
        public static int Height;

        private GameManager manager;
        public static GameState State = GameState.MainMenu;
        private MainMenu menu;

        public   BatlleSpace()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Width = graphics.PreferredBackBufferWidth = 600;
            Height = graphics.PreferredBackBufferHeight = 700;
            menu = new MainMenu();

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

            LoadHelper.Load(Content);

            manager = new GameManager();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            var kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Q)) this.Exit();


            // TODO: Add your update logic here
            if (State == GameState.MainMenu)
            {
                menu.Update();
            }
            if (State == GameState.Exit)
            {
               //AudioManager.StopMainTheme();
                this.Exit();
            }
            if (State == GameState.Game)
            {
                KeyboardInput();
                MouseInput();
                manager.Update();
            }
       

            base.Update(gameTime);
        }
        private void MouseInput()
        {
            MouseState mouse = Mouse.GetState();

            int deltaX = mouse.X - Width / 2;
            int deltaY = mouse.Y - Height / 2;

            manager.MoveShip(deltaX / 3, deltaY / 3);

            Mouse.SetPosition(Width / 2, Height / 2);

            if (mouse.LeftButton == ButtonState.Pressed)
                manager.ShipShoot();

        }
        private void KeyboardInput()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
                State = GameState.MainMenu;

            if (keyboard.IsKeyDown((Keys.Left)))
                manager.MoveShip(-7, 0);
            if (keyboard.IsKeyDown((Keys.Right)))
                manager.MoveShip(7, 0);
            if (keyboard.IsKeyDown((Keys.Up)))
                manager.MoveShip(0, -7);
            if (keyboard.IsKeyDown((Keys.Down)))
                manager.MoveShip(0, 7);
            if (keyboard.IsKeyDown((Keys.Space)))
                manager.ShipShoot();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            if (State == GameState.MainMenu)
            {
                menu.Draw(spriteBatch);
            }
            if (State == GameState.Game)
            {
                manager.Draw(spriteBatch);
            }

            base.Draw(gameTime);
        }

    }
}
