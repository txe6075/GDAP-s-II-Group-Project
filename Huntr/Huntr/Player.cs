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

        // get keyboard state

        public Player(Vector2 pos, Point s, Texture2D ti, int num)
            : base(pos, s, ti)
        {
            playerNum = num;    //sets the keys
            if (playerNum == 1)
            {
                rightKey = Keys.D;
                leftKey = Keys.A;
            }
            else
            {
                rightKey = Keys.L;
                leftKey = Keys.J;
            }
        }

        public override void Update(KeyboardState kState)
        {
            if (kState.IsKeyDown(rightKey))
            {
                // update the x position
                Position = new Vector2(Position.X + Variables.playerSpeed, Position.Y);
            }
            if (kState.IsKeyDown(leftKey))
            {
                // update the x position
                Position = new Vector2(Position.X - Variables.playerSpeed, Position.Y);
            }
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                TextureImage, // spritesheet
                Position, // where to draw in window
                new Rectangle(0, 465, 60, 110), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                .4f, // scaling factor - scale image down to .4
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }
    }
}
