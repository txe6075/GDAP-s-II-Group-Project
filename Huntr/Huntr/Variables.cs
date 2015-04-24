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
        public static const int STANDING_Y = 463;
        //dead fram y position;
        public static const int DEAD_Y = 591;
        // running frame y position
        public static const int RUNNING_Y = 230;
        // jumping frame y position
        public static const int JUMPING_Y = 105;
        // running frame sizes
        public static const int RUN_WIDTH = 92;
        public static const int RUN_HEIGHT = 116;
        // jumping frame sizes
        public static const int JUMP_WIDTH = 90;
        public static const int JUMP_HEIGHT = 119;
        // standing frame sizes
        public static const int STAND_WIDTH = 60;
        public static const int STAND_HEIGHT = 128;
        // death frame sizes
        public static const int DEAD_WIDTH = 123;
        public static const int DEAD_HEIGHT = 127;
    }
}
