using System;
using System.Collections.Generic;
using System.Linq;
using MonocleDemoNamespace.Logic;
using MonocleDemoNamespace.Scenes.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Monocle;

namespace MonocleDemoNamespace
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MonoDemo : Engine
    {
        public MonoDemo() : base(1280, 720, 640, 360, "MonocleEngine Test", false)
        {
            Engine.ClearColor = Color.CornflowerBlue;
            Content.RootDirectory = "Content";
            ViewPadding = -32;
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

            // Initialize some components
            {
                int initGAccess = GAccess.WallTag.ID;
                GFX graphicsInit = GFX.Instance;
            }

            base.Initialize();
            InitScene isc = new InitScene();
            Scene = isc;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            

            // TODO: use this.Content to load your game content here
            base.LoadContent();

            //SetFullscreen();

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);


            // TODO: Add your drawing code here
        }
    }
}
