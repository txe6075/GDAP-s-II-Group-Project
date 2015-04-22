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
        Keys leftKey;
        Keys rightKey;
        Keys upKey;
        Keys downKey;
        public bool left;
        public bool right;
        public bool bottom;
        public bool top;
        public bool jumpPress;
        public int gravEffect;
        private int gravCounter;

        // get keyboard state

        public Player(Vector2 pos, Point s, Texture2D ti, int num)
            : base(pos, s, ti)
        {
            playerNum = num;    //sets the keys
            if (playerNum == 1)
            {
                rightKey = Keys.D;
                leftKey = Keys.A;
                upKey = Keys.W;
                downKey = Keys.S;
            }
            else
            {
                rightKey = Keys.L;
                leftKey = Keys.J;
                upKey = Keys.I;
                downKey = Keys.K;
            }
            right = false;
            left = false;
            bottom = false;
            top = false;
            jumpPress = false;
            gravEffect = 0;
            gravCounter = 0;
        }

        public override void Update(KeyboardState kState)
        {
            Gravity();

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

            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y };
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                TextureImage, // spritesheet
                Position, // where to draw in window
                new Rectangle(0, 463, 60, 128), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                .5f, // scaling factor - scale image down to .4
                SpriteEffects.None, // no effects
                0  // default layer
            );
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
