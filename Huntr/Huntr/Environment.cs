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
    class Environment : OnScreen
    {
        public Environment(Vector2 pos, Point s, Texture2D ti)
            : base(pos, s, ti)
        {

        }
    }
}
