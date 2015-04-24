using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;

namespace Huntr
{
    class Achievements
    {

        Texture2D texture;
        Vector2 position;
        
        public Achievements(Texture2D text, Vector2 pos)
        {
            texture = text;
            position = pos;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, // spritesheet
                position, // where to draw in window
                new Rectangle(0, 0, 640, 400), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }

    }
}
