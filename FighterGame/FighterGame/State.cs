using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FighterGame
{
    class State
    {
        /*Fighting states*/
        public bool attack = false;
        public bool defend = false;
        
        /*Movement states*/
        public bool walk = false;
        public bool jump = false;
        public int direction = 1; //or -1
        

        public string getAction()
        {
            if (attack)
                return "attack";
            else if (walk)
                return "walk";
            else if (defend)
                return "defend";
            else if (jump)
                return "jump";
            else
                return "none";
        }
    }
}
