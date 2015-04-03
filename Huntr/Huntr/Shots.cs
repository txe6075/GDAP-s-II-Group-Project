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



    class Shots: Actives
    {
        public Shots(Vector2 pos, Point s, Texture2D ti)
            : base(pos, s, ti)
        {

        }

        public override void Update(KeyboardState kState)
        {
            
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                TextureImage, // spritesheet
                Position, // where to draw in window
                new Rectangle(0, 0, 0, 0), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                1f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }
    }
}
