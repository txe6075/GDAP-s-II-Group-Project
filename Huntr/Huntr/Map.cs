﻿/*
 * Team: Elimmination Platform
 * 
 * All environment objects in one class
 */

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

namespace Huntr //Done by Zane
{
    class Map
    {

        //Variables
        private Texture2D environment1;
        private Texture2D environment2;
        private Texture2D environment3;
        private Texture2D environment4;

        private List<Environment> environments;

        //properties
        public List<Environment> Environments
        {
            get { return environments; }
        }

        public Map(Texture2D ev1, Texture2D ev2, Texture2D ev3, Texture2D ev4) //all the textures needed
        {
            environments = new List<Environment>();
            environment1 = ev1;
            environment2 = ev2;
            environment3 = ev3;
            environment4 = ev4;
        }

        public void LoadMap(string fileName){ //takes the map name and read it in 
            StreamReader input = new StreamReader(fileName);
            try
            {
                string text = "";
                int i = 0;

                while ((text = input.ReadLine()) != null)
                {
                    string[] words = text.Split();
                    int j = 0;
                    foreach (string word in words) //read each different number and assigns the proper texture
                    {
                        if (int.Parse(word) == 1)
                        {
                            environments.Add(new Environment(new Vector2(j * Variables.screenWidth / 30, i * Variables.screenHeight / 17), new Point(Variables.screenWidth / 30, Variables.screenHeight / 17), environment1));
                        }
                        else if (int.Parse(word) == 2)
                        {
                            environments.Add(new Environment(new Vector2(j * Variables.screenWidth / 30, i * Variables.screenHeight / 17), new Point(Variables.screenWidth / 30, Variables.screenHeight / 17), environment2));
                        }
                        else if (int.Parse(word) == 3)
                        {
                            environments.Add(new Environment(new Vector2(j * Variables.screenWidth / 30, i * Variables.screenHeight / 17), new Point(Variables.screenWidth / 30, Variables.screenHeight / 17), environment3));
                        }
                        else if (int.Parse(word) == 4)
                        {
                            environments.Add(new Environment(new Vector2(j * Variables.screenWidth / 30, i * Variables.screenHeight / 17), new Point(Variables.screenWidth / 30, Variables.screenHeight / 17), environment4));
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
                    new Rectangle(0, 0, 64, 64), // pick out a section of spritesheet
                    Color.White, // dont change image color
                    0, // don't rotate the image
                    Vector2.Zero, // rotation center (not used)
                    .75f, // scaling factor - dont change image size
                    SpriteEffects.None, // no effects
                    0  // default layer
                );
            }
        }
    }
}
