/*
 * Team: Elimmination Platform
 * 
 * All menu info and objects
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
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;

namespace Huntr
{
    class Menu
    {
        //attributes
        public enum gameState { MainMenu, Exit, Multiplayer, Achievements };
        gameState state;
        Texture2D texture;
        Texture2D button1;
        Texture2D button2;
        Texture2D button3;
        Vector2 position;
        Vector2 button1Pos;
        Vector2 button2Pos;
        Vector2 button3Pos;
        int option = 0; //This is what keeps track of the highlighted menu option (0,1,2,3 are acceptable values)
        Boolean enterPressed;

        public Menu(Texture2D txtr, Vector2 pos, Texture2D but1, Vector2 but1Pos, Texture2D but2, Vector2 but2Pos, Texture2D but3, Vector2 but3Pos)
        {
            texture = txtr;
            position = pos;

            button1 = but1;
            button1Pos = but1Pos;

            button2 = but2;
            button2Pos = but2Pos;

            button3 = but3;
            button3Pos = but3Pos;
        }

        public Boolean CheckPress
        {
            get { return enterPressed; }
            set { enterPressed = value; }
        }

        public int Navigate(GameTime gameTime, SpriteBatch spriteBatch, int opt) //take key presses to navigate the menu
        {
            option = opt;
            while (true)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start)) //detect when the enter key is pressed
                {
                    enterPressed = true;
                    switch (option)
                    {
                        case 0: //set the gameState to multiplayer
                            return 0;
                        case 1: //set the gameState to achievements
                            return 1;
                        case 2: //set the gameState to exit
                            return 2;
                    }
                    enterPressed = true;
                    return option;
                }
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y >= .5) //pressed up, move the cursor up (decrease option)
                {
                    //if value is 0, don't decrease it
                    if (option == 0)
                    {
                        option = 0;
                    }
                    else
                    {
                        option--; //decreases option by 1
                    }

                    Thread.Sleep(100);
                    
                }
                else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y <= -.5)
                {
                    //if option is 3, don't increase it
                    if (option == 2)
                    {
                        option = 2;
                    }
                    else
                    {
                        option++; //increases option by 1
                    }
                    Thread.Sleep(100);
                }
                
                Draw(gameTime, spriteBatch);
                DrawButtons(gameTime, spriteBatch, option);
                return option;
                
                
            }
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


        public void DrawButtons(GameTime gameTime, SpriteBatch spriteBatch, int option)
        {
            if(option == 0)
            {
                spriteBatch.Draw(
                button1, // spritesheet
                button1Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.Gray, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                button2, // spritesheet
                button2Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                button3, // spritesheet
                button3Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );
            }
            else if(option == 1)
            {
                spriteBatch.Draw(
                button2, // spritesheet
                button2Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.Gray, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                button1, // spritesheet
                button1Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                button3, // spritesheet
                button3Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );
            }
            else if(option == 2)
            {
                spriteBatch.Draw(
                button1, // spritesheet
                button1Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                button2, // spritesheet
                button2Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                button3, // spritesheet
                button3Pos, // where to draw in window
                new Rectangle(0, 0, 64, 40), // pick out a section of spritesheet
                Color.Gray, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );
            }
            //Two Draws to show the buttons and whether or not they're highlighted
            

            
        }
    }
}
