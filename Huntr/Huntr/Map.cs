using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Huntr
{
    class Map
    {
        List<Environment> environments;

        Texture2D environment1;

        public Map( Texture2D ev1)
        {
            environments = new List<Environment>();
            environment1 = ev1;
        }

        public void LoadMap(string fileName){
            StreamReader input = new StreamReader(fileName);
            try
            {
                string text = "";
                int i = 0;

                while ((text = input.ReadLine()) != null)
                {
                    string[] words = text.Split();
                    int j = 0;
                    foreach (string word in words)
                    {
                        if (int.Parse(word) == 1)
                        {
                            environments.Add(new Environment(new Vector2(j * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 30, i * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 17), new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/30, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/17), environment1));
                        }
                        j++;
                    }
                    i++;
                }
            }
            catch (IOException ioe)
            {
                // write out the message and the stack trace
                Console.WriteLine("Message: " + ioe.Message);
                Console.WriteLine("Stack Trace: " + ioe.StackTrace);
            }
            finally
            {
                input.Close();  // close regardless of exceptions
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Environment tile in environments)
            {
                spriteBatch.Draw(
                    tile.TextureImage, // spritesheet
                    tile.Position, // where to draw in window
                    new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 30, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 17), // pick out a section of spritesheet
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
}
