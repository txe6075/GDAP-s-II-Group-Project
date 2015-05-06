/*
 * Team: Elimmination Platform
 * 
 * Static variables
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Huntr
{
    static class Variables
    {
        public static int playerNums;
        public static int screenWidth = 1440;
        public static int screenHeight = 816;
        public static int playerSpeed = 2;

        // standing frame y position
        public static int STANDING_Y = 463;
        //dead fram y position;
        public static int DEAD_Y = 591;
        // running frame y position
        public static int RUNNING_Y = 230;
        // jumping frame y position
        public static int JUMPING_Y = 110;
        // sliding frame x and y position
        public static int SLIDING_X = 400;
        public static int SLIDING_Y = 500;
        // running frame sizes
        public static int RUN_WIDTH = 92;
        public static int RUN_HEIGHT = 116;
        // jumping frame sizes
        public static int JUMP_WIDTH = 92;
        public static int JUMP_HEIGHT = 120;
        // standing frame sizes
        public static int STAND_WIDTH = 60;
        public static int STAND_HEIGHT = 128;
        // death frame sizes
        public static int DEAD_WIDTH = 123;
        public static int DEAD_HEIGHT = 127;
        // sliding frame sizes
        public static int SLIDE_WIDTH = 95;
        public static int SLIDE_HEIGHT = 90;
    }
}
