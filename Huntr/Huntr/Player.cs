/*
 * Team: Elimmination Platform
 * 
 * The instantiation for both players
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
    /*Pedro DelaCuadra*/


    class Player: Lifers
    {
        private int playerNum;
        SpriteEffects effect = SpriteEffects.None;
        Keys leftKey;
        Keys rightKey;
        Keys upKey;
        Keys downKey;
        Keys fireKey;
        public bool left;
        public bool right;
        public bool bottom;
        public bool top;
        public bool jumpPress;
        public int gravEffect;
        private int gravCounter;

        private int direction;

        Shots[] shots = new Shots[5];

        // attributes for updating the image
        Rectangle charRect = new Rectangle(0, 463, 60, 128); // character is facing forward initially
        // standing frame y position
        const int STANDING_Y = 463;
        // running frame y position
        const int RUNNING_Y = 230;
        // jumping frame y position
        const int JUMPING_Y = 105;
        // running frame sizes
        const int RUN_WIDTH = 92;
        const int RUN_HEIGHT = 116;
        // jumping frame sizes
        const int JUMP_WIDTH = 90;
        const int JUMP_HEIGHT = 119;
        // standing frame sizes
        const int STAND_WIDTH = 60;
        const int STAND_HEIGHT = 128;
        int frame;
        int framesElapsed;
        int numFrames = 10;
        double timePerFrame = 100;

        // enumeration
        enum CharState { runLeft, runRight, faceForward, jump }
        CharState charState = CharState.faceForward;

        public Player(Vector2 pos, Point s, Texture2D ti, Texture2D kunai, int num)
            : base(pos, s, ti)
        {
            playerNum = num;    //sets the keys
            if (playerNum == 1)
            {
                rightKey = Keys.D;
                leftKey = Keys.A;
                upKey = Keys.W;
                downKey = Keys.S;
                fireKey = Keys.F;
                direction = 2;
            }
            else
            {
                rightKey = Keys.L;
                leftKey = Keys.J;
                upKey = Keys.I;
                downKey = Keys.K;
                fireKey = Keys.H;
                direction = 1;
            }
            right = false;
            left = false;
            bottom = false;
            top = false;
            jumpPress = false;
            gravEffect = 0;
            gravCounter = 0;

            for (int i = 0; i < 5; i++)
            {
                shots[i] = new Shots(Position, Size, kunai);
            }
        }

        // updates the player image depending on key presses
        public override void UpdateImg(GameTime gameTime, KeyboardState kState)
        {
            // Calculate the frame to draw based on the time
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
            frame = framesElapsed % numFrames;

            // character is running right
            if (kState.IsKeyDown(rightKey))
            {
                charState = CharState.runRight;
            }
            // character is running left
            if (kState.IsKeyDown(leftKey))
            {
                charState = CharState.runLeft;
            }
            // character is jumping
            if (kState.IsKeyDown(upKey))
            {
                charState = CharState.jump;
            }

            if (kState.IsKeyUp(rightKey) && kState.IsKeyUp(leftKey) && kState.IsKeyUp(upKey))
            {
                charState = CharState.faceForward;
            }

            // finite state machine code
            switch (charState)
            {
                case CharState.jump:
                    charState = CharState.jump;
                    break;
                case CharState.runLeft:
                    charState = CharState.runLeft;
                    break;
                case CharState.runRight:
                    charState = CharState.runRight;
                    break;
                default:
                    charState = CharState.faceForward;
                    break;
            }

            if (charState == CharState.runLeft)
            {
                charRect = new Rectangle(5 + frame * RUN_WIDTH, RUNNING_Y, RUN_WIDTH, RUN_HEIGHT);
                direction = 1;
                effect = SpriteEffects.FlipHorizontally;
            }

            if (charState == CharState.runRight)
            {
                charRect = new Rectangle(5 + frame * RUN_WIDTH, RUNNING_Y, RUN_WIDTH, RUN_HEIGHT);
                direction = 2;
                effect = SpriteEffects.None;
            }

            if (charState == CharState.jump && kState.IsKeyDown(leftKey))
            {
                charRect = new Rectangle(5 + frame * JUMP_WIDTH, JUMPING_Y, JUMP_WIDTH, JUMP_HEIGHT);
                direction = 1;
                effect = SpriteEffects.FlipHorizontally;
            }
            else if (charState == CharState.jump && kState.IsKeyDown(rightKey))
            {
                charRect = new Rectangle(5 + frame * JUMP_WIDTH, JUMPING_Y, JUMP_WIDTH, JUMP_HEIGHT);
                direction = 2;
                effect = SpriteEffects.None;
            }
            else if (charState == CharState.jump)
            {
                charRect = new Rectangle(5 + frame * JUMP_WIDTH, JUMPING_Y, JUMP_WIDTH, JUMP_HEIGHT);
            }

            if (charState == CharState.faceForward)
            {
                charRect = new Rectangle(0, STANDING_Y, STAND_WIDTH, STAND_HEIGHT);
            }

            // make sure jumping animation doesnt happen while on the ground
            if (charState != CharState.runLeft && charState != CharState.runRight && bottom == true)
            {
                charRect = new Rectangle(0, STANDING_Y, STAND_WIDTH, STAND_HEIGHT);
            }
        }

        public override void Update(KeyboardState kState)
        {
            Gravity();

            if (Position.Y <= 36) Position = new Vector2(Position.X, 37);

            if (kState.IsKeyDown(rightKey) && right == false)
            {
                left = false;

                Position = new Vector2(Position.X + Variables.playerSpeed, Position.Y);
            }
            if (kState.IsKeyDown(leftKey) && left == false)
            {
                right = false;

                Position = new Vector2(Position.X - Variables.playerSpeed, Position.Y);
            }
            if (kState.IsKeyDown(upKey) && top == false && jumpPress == false)
            {
                top = true;
                bottom = false;
                jumpPress = true;

                Position = new Vector2(Position.X, Position.Y - 10);

                gravEffect = 5;
            }
            else if (!kState.IsKeyDown(upKey)) jumpPress = false;

            if (!kState.IsKeyDown(fireKey))
            {
                foreach (Shots s in shots)
                {
                    if (s.alive == false)
                        s.Set(Position, direction);
                }
            }

            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y };
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                TextureImage, // spritesheet
                Position, // where to draw in window
                charRect, // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                .5f, // scaling factor - scale image down to .4
                effect, // no effects
                0  // default layer
            );

            foreach (Shots s in shots)
            {
                if(s.alive == true)
                    s.Draw(gameTime, spriteBatch);
            }
        }

        public void Gravity()
        {
            if (bottom == false)
            {
                Position = new Vector2(Position.X, Position.Y - gravEffect);

                gravCounter++;
                if (gravCounter % 10 == 0)
                {
                    if(gravEffect > -10)
                        gravEffect -= 1;
                    gravCounter = 0;

                }
            }
            else
            {

                gravCounter = 0;
                gravEffect = 0;
            }

        }

        public void Falsify()
        {
            bottom = false;
            left = false;
            right = false;
        }
    }
}
