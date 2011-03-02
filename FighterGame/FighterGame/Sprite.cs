using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FighterGame
{
    /*Animation/sprites information holder*/
    class Sprite
    {
        //General
        public string name = null;
        public Texture2D texture;
        public Vector2 position = new Vector2(0, 400);
        public int speed = 10;

        //Animation
        public State state = new State();
        int col = 0;
        int row = 0;

        //Jumping
        public int maxJumpHeight = 150;
        public int currentJumpHeight = 0;
        public int jumpSpeed = 5;
        public int jumpDirection = -1;

        int spriteWidth = 100;
        int spriteHeight = 100;
        public Rectangle rect
        {
            get { return new Rectangle(spriteWidth * col, spriteWidth * row, spriteWidth, spriteHeight); }
        }

        //Splice of frames to use
        int minStep = 0;
        int maxStep = 10;

        public Sprite(string name)
        {
            this.name = name;
            //rect = new Rectangle(spriteWidth * col, spriteWidth * row, spriteWidth, spriteHeight);
        }
        public Sprite(string name, int row)
        {
            this.name = name;
            this.row = row;
            // rect = new Rectangle(spriteWidth * col, spriteWidth * row, spriteWidth, spriteHeight);
        }
        public Sprite(string name, int row, Vector2 position)
        {
            this.name = name;
            this.row = row;
            this.position = position;
            //rect = new Rectangle(spriteWidth * col, spriteWidth * row, spriteWidth, spriteHeight);
        }
        public Sprite(string name, int row, int minStep, int maxStep)
        {
            this.name = name;
            this.row = row;
            this.minStep = minStep;
            this.maxStep = maxStep;
           // rect = new Rectangle(spriteWidth * col, spriteWidth * row, spriteWidth, spriteHeight);
        }
        public Sprite(string name, int row, int spriteWidth, int spriteHeight, int minStep, int maxStep)
        {
            this.name = name;
            this.row = row;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
          // rect = new Rectangle(spriteWidth * col, spriteWidth * row, spriteWidth, spriteHeight);
        }

        public void increment()
        {
            if (col != maxStep)
                col++;
            else
                col = minStep;
        }

        public void move(Vector2 distance)
        {
            position += distance;
        }

        public void execute()
        {
            switch (state.getAction())
            {
                case "walk":
                    position.X += speed * state.direction;
                    state.walk = false;
                    break;
                case "jump":
                    jump();
                    break;
            }

        }
        public void jump()
        {
            position.Y += jumpDirection * jumpSpeed;

            if (position.Y <= maxJumpHeight)
            {
                jumpDirection = 1;
            }
            else if (position.Y >= Game1.floor)
            {
                state.jump = false;
                jumpDirection = -1;
                position.Y = Game1.floor;
            }
        }
    }
}
