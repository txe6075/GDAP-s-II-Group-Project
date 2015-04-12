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

namespace Huntr
{
    class Menu
    {
        //attributes
        public enum gameState { MainMenu, SinglePlayer, Multiplayer, Achievements };
        gameState state;
        Texture2D texture;
        Vector2 position;


        public Menu(Texture2D txtr, Vector2 pos)
        {
            texture = txtr;
            position = pos;
        }

        public gameState ChangeGameState(gameState state)
        {
            this.state = state;
            return this.state;
        }


        public void CheckGameState(gameState state)
        {
            this.state = state;


        }

        public gameState Navigate(gameState st) //take key presses to navigate the menu
        {
            int option = 0; //This is what keeps track of the highlighted menu option (0,1,2,3 are acceptable values)
            while (true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W)) //pressed up, move the cursor up (decrease option)
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
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
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
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Enter)) //detect when the enter key is pressed
                {
                    switch (option)
                    {
                        case 0: this.state = gameState.SinglePlayer; //set the gameState to singleplayer
                            break;
                        case 1: this.state = gameState.Multiplayer; //set the gameState to multiplayer
                            break;
                        case 2: this.state = gameState.Achievements; //set the gameState to achievement
                            break;
                    }
                    return this.state;
                }

                return st;
            }
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, // spritesheet
                position, // where to draw in window
                new Rectangle(0, 0, 2400, 6400), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                9f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
            );
        }
        public void DrawButton(GameTime gameTime, SpriteBatch spriteBatch, int option)
        {
            
        }
    }
}
