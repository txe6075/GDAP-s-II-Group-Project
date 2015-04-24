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
        public int count;
        public bool alive;
        private Vector2 origin;

        public Shots(Vector2 pos, Point s, Texture2D ti)
            : base(pos, s, ti)
        {
            direction = 1;
            angle = 0;
            alive = false;
            count = 0;
            origin = new Vector2();
        }
        public override void Update(KeyboardState kState) { }

        public void Update()
        {
            count++;
            int distance = 0;
            if (direction == 1)
            {
                Position = new Vector2(Position.X - 8, Position.Y);
                distance = -1;
            }
            else if (direction == 2)
            {
                Position = new Vector2(Position.X + 8, Position.Y);
                distance = 1;
            }

            if (count >= 4)
            {
                angle += distance;
                count = 0;
            }

            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y };
            origin = new Vector2(Size.X / 2, Size.Y / 2);
        }

        public void Set(Vector2 pos, int dir)
        {
            this.Position = new Vector2(pos.X, pos.Y);
            direction = dir;
            angle = 0;
            alive = true;
            origin = new Vector2(Size.X / 2, Size.Y / 2);
            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y };
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
                new Rectangle(0, 0, 8, 32), // pick out a section of spritesheet
                Color.White, // dont change image color
                angle, // don't rotate the image
                origin, // rotation center (not used)
                1f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }
    }
}
