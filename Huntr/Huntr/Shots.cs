/*
 * Team: Elimmination Platform
 * 
 * Thrown objects that damage players or enemies
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

    class Shots: Actives
    {
        public int direction;
        public int angle;
        public bool alive;

        public Shots(Vector2 pos, Point s, Texture2D ti)
            : base(pos, s, ti)
        {
            direction = 0;
            angle = 0;
            alive = false;
        }

        public override void Update(KeyboardState kState)
        {
            if (direction == 1)
            {
                Position = new Vector2(Position.X - Variables.playerSpeed, Position.Y);
                angle -= 2;
            }
            else if (direction == 2)
            {
                Position = new Vector2(Position.X + Variables.playerSpeed, Position.Y);
                angle += 2;
            }

            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y };
        }

        public void Set(Vector2 pos, int dir)
        {
            this.Position = new Vector2(pos.X, pos.Y);
            direction = dir;
            angle = 0;
            alive = true;
        }

        public override void UpdateImg(GameTime gameTime, KeyboardState kState)
        {
            throw new NotImplementedException();
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                TextureImage, // spritesheet
                Position, // where to draw in window
                new Rectangle(0, 0, 0, 0), // pick out a section of spritesheet
                Color.White, // dont change image color
                angle, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                1f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }
    }
}
