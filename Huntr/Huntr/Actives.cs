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



    abstract class Actives: OnScreen
    {
        public Actives(Vector2 pos, Point s, Texture2D ti)
            : base(pos, s, ti)
        {

        }

        // public abstract void UpdateImg();

        public abstract void Update(KeyboardState kState);
    }
}
