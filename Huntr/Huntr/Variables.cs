﻿/*
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

        //Pause variables
        public static Boolean isPaused = false;
        public static Boolean gameOver = false;

        //Achievements Variables
        public const string FILENAME = "Achievements.txt";
        public static int gamesPlayed = 0;
        public static int thrownKunai = 0;
        public const string GAMESPLAYEDFILENAME = "GamesPlayed.txt";
        public static int gamesQuit = 0;
        public static int[] achieves;
    }
}
