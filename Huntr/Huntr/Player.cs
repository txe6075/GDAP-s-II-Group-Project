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

        // get keyboard state
        KeyboardState kState = Keyboard.GetState();

        public Player(Vector2 pos, Point s, Texture2D ti)
            : base(pos, s, ti)
        {
            playerNum = ++Variables.playerNums;
        }

        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (kState.IsKeyDown(Keys.D))
            {
                // update the x position
                Position = new Vector2(Position.X + 10, Position.Y);
                // redraw the image
                Draw(gameTime, spriteBatch);
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
                .6f, // scaling factor - scale image down to .6
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }
    }
}
