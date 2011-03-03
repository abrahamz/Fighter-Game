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
        public int maxJumpHeight = 225;
        public int currentJumpHeight = 0;
        public int jumpSpeed = 7;
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
        }
        public Sprite(string name, int row)
        {
            this.name = name;
            this.row = row;
        }
        public Sprite(string name, int row, Vector2 position)
        {
            this.name = name;
            this.row = row;
            this.position = position;
        }
        public Sprite(string name, int row, int minStep, int maxStep)
        {
            this.name = name;
            this.row = row;
            this.minStep = minStep;
            this.maxStep = maxStep;
        }
        public Sprite(string name, int row, int spriteWidth, int spriteHeight, int minStep, int maxStep)
        {
            this.name = name;
            this.row = row;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
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
                case "defend":
                    if (state.jump)
                        jump();
                    defend();
                    break;
                case "attack":
                    if (state.jump)
                        jump();
                    attack();
                    break;
                case "walk":
                    if (state.jump)
                        jump();
                    else if (position.Y == Game1.floor)
                    {
                        position.X += speed * state.direction;
                    }
                    state.walk = false;
                    break;
                case "jump":
                    jump();
                    break;
            }

        }
        public void defend()
        {
            row = 0;

            //If the key has been released, then smoothly transition out of defense state
            if (!Game1.oldKeyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.J) & col >= 5 & col <= 10)
                col++;
            //Overwriting maxstep here to make it 5 so block can stick
            else if (col < 5)
                col++;
            else if (col != 5)
            {
                col = 0;
                state.defend = false;
            }
        }
        public void attack()
        {
            row = 1;
            if (col != maxStep)
                col++;
            else
            {
                col = 0;
                state.attack = false;
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
