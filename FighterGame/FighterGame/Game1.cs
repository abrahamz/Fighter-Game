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

namespace FighterGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Movement speed
        Vector2 walkspeed = new Vector2(5, 0);
        Vector2 jumpspeed = new Vector2(0, 25);

        //Textures
        Texture2D character;
        Texture2D enemy;

        //Timing
        float timer = 0f;
        float interval = 200f;

        //Movement
        Vector2 walk = new Vector2(5, 0);
        Vector2 jump = new Vector2(0, 25);
        Vector2 position = new Vector2(0, 0);

        //User input
        KeyboardState oldKeyState;

        Dictionary<string, Rectangle> spriteRects = new Dictionary<string, Rectangle>();
        Dictionary<string, State> charStates = new Dictionary<string, State>();
        Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /*Initialize Dictionaries*/
            //Sprites
            spriteDict["player"] = new Sprite("Attack.Block", 1);
            spriteDict["enemy"] = new Sprite("Attack.Block", 0, 0, 5);
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

            // TODO: use this.Content to load your game content here
            foreach (Sprite sprite in spriteDict.Values)
                sprite.texture = Content.Load<Texture2D>(sprite.name);
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
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            foreach (Sprite sprite in spriteDict.Values) 
            {
                switch (sprite.state.getAction())
                {
                    /*Gonna do some stuff..*/
                }
            }
            
        }

        private void UpdateKey()
        {
            KeyboardState newState = Keyboard.GetState();

            //Is the DUBAU key down?! 
            if (newState.IsKeyDown(Keys.W))
            {
                if (!oldKeyState.IsKeyDown(Keys.W))
                    charStates["player"].jump = true;
            }
            else 
            { charStates["player"].jump = false; }

            //Is the DEE key down?!
            if (newState.IsKeyDown(Keys.D))
            {
                charStates["player"].walk = true;
                charStates["player"].direction = 1;
            }
            else
            { charStates["player"].walk = false; }

            //Is the EH key down?!
            if (newState.IsKeyDown(Keys.A))
            {
                charStates["player"].walk = true;
                charStates["player"].direction = -1;
            }
            else
            { charStates["player"].walk = false; }
            
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Draw the sprite
            //Rectangle of section
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(/*character, position, rect, Color.White*/);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}