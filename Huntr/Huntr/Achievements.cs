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

        //attributes
        Texture2D texture;
        Vector2 position;
        Texture2D shadowSprite;
        Texture2D ach1;
        Vector2 ach1Pos;
        Vector2 ach1PosUpdated;
        Texture2D ach2;
        Texture2D ach3;
        Texture2D ach4;
        Texture2D ach5;
        Texture2D ach6;
        int[] achieves; //array of achievements (9 in total)
        LoadAchievements load;

        public Achievements(Texture2D text, Vector2 pos, Texture2D sha, Texture2D text2, Vector2 pos2, Texture2D text3, Texture2D text4, Texture2D text5, Texture2D text6, Texture2D text7)
        {
            texture = text;
            position = pos;
            shadowSprite = sha;
            ach1 = text2;
            ach1Pos = pos2;
            ach1PosUpdated = ach1Pos;
            ach2 = text3;
            ach3 = text4;
            ach4 = text5;
            ach5 = text6;
            ach6 = text7;
            load = new LoadAchievements();
        }

        //Check what achievements are completed from the string
        public void CheckAchievements(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Bring over the achievement list from the load achievements
            achieves = load.Load(Variables.FILENAME);
            load.CheckGames(Variables.GAMESFILENAME);
            Variables.gamesPlayed = 500000;
            ach1Pos = ach1PosUpdated;

            //Check each of the nine numbers to see if it exists or if it is a 1
            if(achieves[0] == 1 || Variables.gamesPlayed >= 1)//one game completed
            {
                //draw the trophy & shadow
                spriteBatch.Draw(
                shadowSprite, // spritesheet
                ach1Pos, // where to draw in window
                new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );

                spriteBatch.Draw(
                ach1, // spritesheet
                ach1Pos, // where to draw in window
                new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                Color.White, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                2.25f, // scaling factor - dont change image size
                SpriteEffects.None, // no effects
                0  // default layer
                );


                //nest these ones because they have to unlock them in order
                if (achieves[1] == 1 || Variables.gamesPlayed >= 5)//5 games completed
                {
                    ach1Pos.X = ach1Pos.X + 100;
                    //draw the trophy
                    //draw the trophy & shadow
                    spriteBatch.Draw(
                    shadowSprite, // spritesheet
                    ach1Pos, // where to draw in window
                    new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                    Color.White, // dont change image color
                    0, // don't rotate the image
                    Vector2.Zero, // rotation center (not used)
                    2.25f, // scaling factor - dont change image size
                    SpriteEffects.None, // no effects
                    0  // default layer
                    );

                    spriteBatch.Draw(
                    ach2, // spritesheet
                    ach1Pos, // where to draw in window
                    new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                    Color.White, // dont change image color
                    0, // don't rotate the image
                    Vector2.Zero, // rotation center (not used)
                    2.25f, // scaling factor - dont change image size
                    SpriteEffects.None, // no effects
                    0  // default layer
                    );

                    if(achieves[2] == 1 || Variables.gamesPlayed >= 10)//10 games completed
                    {
                        ach1Pos.X = ach1Pos.X + 100;
                        //draw the trophy
                        //draw the trophy & shadow
                        spriteBatch.Draw(
                        shadowSprite, // spritesheet
                        ach1Pos, // where to draw in window
                        new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                        Color.White, // dont change image color
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        2.25f, // scaling factor - dont change image size
                        SpriteEffects.None, // no effects
                        0  // default layer
                        );

                        spriteBatch.Draw(
                        ach3, // spritesheet
                        ach1Pos, // where to draw in window
                        new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                        Color.White, // dont change image color
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        2.25f, // scaling factor - dont change image size
                        SpriteEffects.None, // no effects
                        0  // default layer
                        );
                        if (achieves[3] == 1 || Variables.gamesPlayed >= 100)//100 games completed
                        {
                            ach1Pos.X = ach1Pos.X + 100;
                            //draw the trophy
                            //draw the trophy & shadow
                            spriteBatch.Draw(
                            shadowSprite, // spritesheet
                            ach1Pos, // where to draw in window
                            new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                            Color.White, // dont change image color
                            0, // don't rotate the image
                            Vector2.Zero, // rotation center (not used)
                            2.25f, // scaling factor - dont change image size
                            SpriteEffects.None, // no effects
                            0  // default layer
                            );

                            spriteBatch.Draw(
                            ach4, // spritesheet
                            ach1Pos, // where to draw in window
                            new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                            Color.White, // dont change image color
                            0, // don't rotate the image
                            Vector2.Zero, // rotation center (not used)
                            2.25f, // scaling factor - dont change image size
                            SpriteEffects.None, // no effects
                            0  // default layer
                            );
                            if (achieves[4] == 1 || Variables.gamesPlayed >= 1337)//1337 games completed
                            {
                                ach1Pos.X = ach1Pos.X + 100;
                                //draw the trophy
                                //draw the trophy & shadow
                                spriteBatch.Draw(
                                shadowSprite, // spritesheet
                                ach1Pos, // where to draw in window
                                new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                                Color.White, // dont change image color
                                0, // don't rotate the image
                                Vector2.Zero, // rotation center (not used)
                                2.25f, // scaling factor - dont change image size
                                SpriteEffects.None, // no effects
                                0  // default layer
                                );

                                spriteBatch.Draw(
                                ach5, // spritesheet
                                ach1Pos, // where to draw in window
                                new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                                Color.White, // dont change image color
                                0, // don't rotate the image
                                Vector2.Zero, // rotation center (not used)
                                2.25f, // scaling factor - dont change image size
                                SpriteEffects.None, // no effects
                                0  // default layer
                                );
                                if (achieves[5] == 1 || Variables.gamesPlayed >= 10000)//10,000 games completed
                                {
                                    ach1Pos.X = ach1Pos.X + 100;
                                    //draw the trophy
                                    //draw the trophy & shadow
                                    spriteBatch.Draw(
                                    shadowSprite, // spritesheet
                                    ach1Pos, // where to draw in window
                                    new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
                                    Color.White, // dont change image color
                                    0, // don't rotate the image
                                    Vector2.Zero, // rotation center (not used)
                                    2.25f, // scaling factor - dont change image size
                                    SpriteEffects.None, // no effects
                                    0  // default layer
                                    );

                                    spriteBatch.Draw(
                                    ach6, // spritesheet
                                    ach1Pos, // where to draw in window
                                    new Rectangle(0, 0, 40, 64), // pick out a section of spritesheet
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
                    }
                }
            }

            if(achieves[6] == 1)//perfect game
            {
                //draw trophy

            }
            if(achieves[7] == 1)//lots of kunai thrown
            {
                //draw trophy

            }
            if(achieves[8] == 1)//exit game once
            {
                //draw trophy

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

    }
}
