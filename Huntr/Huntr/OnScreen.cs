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
    abstract class OnScreen
    {
        private Vector2 position;
        private Point size;
        private Texture2D textureImage;
        private Rectangle rectangle;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Point Size
        {
            get { return size; }
            set { size = value; }
        }

        public Texture2D TextureImage
        {
            get { return textureImage; }
            set { textureImage = value; }
        }

        public Rectangle Rect
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public OnScreen(Vector2 pos, Point s, Texture2D ti)
        {
            position = pos;
            size = s;
            textureImage = ti;

            rectangle = new Rectangle((int)position.X, (int)position.Y, size.X, size.Y);
        }
    }
}
