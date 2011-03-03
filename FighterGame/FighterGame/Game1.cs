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
        //Floor
        public static int floor = 300;

        //Movement speed
        Vector2 walkspeed = new Vector2(5, 0);
        Vector2 jumpspeed = new Vector2(0, 25);

        //Timing
        float timer = 0f;
        float interval = 200f;

        //Movement
        Vector2 walk = new Vector2(5, 0);
        Vector2 jump = new Vector2(0, 25);
        
        //User input
        public static KeyboardState oldKeyState;

        Dictionary<string, Rectangle> spriteRects = new Dictionary<string, Rectangle>();
        Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /*Initialize Dictionaries*/
            //Sprites
            spriteDict["player"] = new Sprite("Attack.Block", 1, new Vector2(25, floor));
            spriteDict["enemy"] = new Sprite("enemy-attack-block", 0, new Vector2(200, floor));
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

            if (timer >= 25)
            {
                timer = 0;
                foreach (Sprite sprite in spriteDict.Values)
                {
                    sprite.execute();
                }
            }

            UpdateKey();
            base.Update(gameTime);
            
        }

        private void UpdateKey()
        {
            KeyboardState newKeyState = Keyboard.GetState();

            //Is the KAY key down?!
            if (newKeyState.IsKeyDown(Keys.K))
            {
                spriteDict["player"].state.attack = true;
            }

            //Is the JAY key down?!
            if (newKeyState.IsKeyDown(Keys.J))
            {
                spriteDict["player"].state.defend = true;
            }

            //Is the DUBAU key down?! 
            if (newKeyState.IsKeyDown(Keys.W))
            {
                if (!oldKeyState.IsKeyDown(Keys.W))
                    spriteDict["player"].state.jump = true;
            }

            //Is the EH key down?!
            if (newKeyState.IsKeyDown(Keys.A))
            {
                spriteDict["player"].state.walk = true;
                spriteDict["player"].state.direction = -1;
            }

            //Is the DEE key down?!
            if (newKeyState.IsKeyDown(Keys.D))
            {
                spriteDict["player"].state.walk = true;
                spriteDict["player"].state.direction = 1;
            }

            oldKeyState = newKeyState;
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
            foreach (Sprite sprite in spriteDict.Values)
            {
                if (sprite.state.shown)
                    spriteBatch.Draw(sprite.texture, sprite.position, sprite.rect, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}