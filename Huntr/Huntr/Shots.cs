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

namespace Huntr //Filled and completed by Zane Draper
{

    class Shots: Actives
    {
        //Variables

        private int direction;      //between left and right
        private int angle;          //rotation of kunai
        private int count;          //keeps the kunai from rotating too fast
        private bool alive;         //whether or not the kunai is active
        private Vector2 origin;     //the point the kunai rotates around

        //properties
        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public Shots(Vector2 pos, Point s, Texture2D ti) //uses base constructor
            : base(pos, s, ti)
        {
            direction = 1;          //initializing variables
            angle = 0;
            alive = false;
            count = 0;
            origin = new Vector2();
        }
        public override void Update(KeyboardState kState) //unneccesary function. need to rebuild the hierarchy
        {
            throw new NotImplementedException();
        }

        public void Update() //updates rotation and location automatically
        {
            count++;
            int distance = 0;
            if (direction == 1) //left
            {
                Position = new Vector2(Position.X - 8, Position.Y);
                distance = -1;
            }
            else if (direction == 2) //right
            {
                Position = new Vector2(Position.X + 8, Position.Y);
                distance = 1;
            }

            if (count >= 4)
            {
                angle += distance; //degree the angle changes by
                count = 0;
            }

            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y }; //keep the rectangle the same, because of such a small change in area
            origin = new Vector2(Size.X / 2, Size.Y / 2);
        }

        public void Set(Vector2 pos, int dir) //initializes the kunai when needed (wanted to fully use pooling for memory allocation, this is similar)
        {
            this.Position = new Vector2(pos.X, pos.Y); //players location
            direction = dir;                            //players direction
            angle = 0;
            alive = true;
            origin = new Vector2(Size.X / 2, Size.Y / 2);
            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y };     //updates rectangle to new location
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
