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
        Texture2D kunai;
        Texture2D shadowSprite;
        Texture2D ach1;
        Vector2 ach1Pos;
        Vector2 ach1PosUpdated;
        Texture2D ach2;
        Texture2D ach3;
        Texture2D ach4;
        Texture2D ach5;
        Texture2D ach6;
        Texture2D ach7;
        Texture2D ach8;
        int[] achieves; //array of achievements (9 in total)
        LoadAchievements load;

        public Achievements(Texture2D text, Vector2 pos, Texture2D kai, Texture2D sha, Texture2D text2, Vector2 pos2, Texture2D text3, Texture2D text4, Texture2D text5, Texture2D text6, Texture2D text7, Texture2D text8, Texture2D text9)
        {
            texture = text;
            position = pos;
            kunai = kai;
            shadowSprite = sha;
            ach1 = text2;
            ach1Pos = pos2;
            ach1PosUpdated = ach1Pos;
            ach2 = text3;
            ach3 = text4;
            ach4 = text5;
            ach5 = text6;
            ach6 = text7;
            ach7 = text8;
            ach8 = text9;
            load = new LoadAchievements();
        }

        //Check what achievements are completed from the string
        public void CheckAchievements(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Boolean Demo = false;
            if (Demo == false)
            {
                //Bring over the achievement list from the load achievements
                load.Load(Variables.FILENAME);
                achieves = Variables.achieves;
                load.CheckGames(Variables.GAMESPLAYEDFILENAME);
                load.CheckQuits("GamesExited.txt");
                ach1Pos = ach1PosUpdated;
                WriteAchievements();
                if (achieves == null)
                {
                    return;
                }

                //Check each of the nine numbers to see if it exists or if it is a 1
                if (achieves[0] == 1 || Variables.gamesPlayed >= 1)//one game completed
                {
                    achieves[0] = 1;
                    Variables.achieves[0] = 1;
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
                        achieves[1] = 1;
                        Variables.achieves[1] = 1;
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

                        if (achieves[2] == 1 || Variables.gamesPlayed >= 10)//10 games completed
                        {
                            achieves[2] = 1;
                            Variables.achieves[2] = 1;
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
                                achieves[3] = 1;
                                Variables.achieves[3] = 1;
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
                                    achieves[4] = 1;
                                    Variables.achieves[4] = 1;
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
                                        achieves[5] = 1;
                                        Variables.achieves[5] = 1;
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

                if (achieves[6] == 1)//perfect game
                {
                    //draw trophy
                    achieves[6] = 1;
                    Variables.achieves[6] = 1;
                    //draw trophy
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
                    ach7, // spritesheet
                    ach1Pos, // where to draw in window
                    new Rectangle(0, 0, 40, 60), // pick out a section of spritesheet
                    Color.White, // dont change image color
                    0, // don't rotate the image
                    Vector2.Zero, // rotation center (not used)
                    2.25f, // scaling factor - dont change image size
                    SpriteEffects.None, // no effects
                    0  // default layer
                    );
                }
                if (achieves[7] == 1 || Variables.thrownKunai >= 2000)//lots of kunai thrown
                {
                    achieves[7] = 1;
                    Variables.achieves[7] = 1;
                    //draw trophy
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

                    Vector2 kunaiPos = ach1Pos;
                    kunaiPos.X = ach1Pos.X + 36;
                    kunaiPos.Y = ach1Pos.Y + 40;

                    spriteBatch.Draw(
                    kunai, // spritesheet
                    kunaiPos, // where to draw in window
                    new Rectangle(0, 0, 8, 40), // pick out a section of spritesheet
                    Color.Gold, // dont change image color
                    0, // don't rotate the image
                    Vector2.Zero, // rotation center (not used)
                    2.25f, // scaling factor - dont change image size
                    SpriteEffects.None, // no effects
                    0  // default layer
                    );
                }
                if (achieves[8] == 1 || Variables.gamesQuit >= 1)//exit game once
                {
                    achieves[8] = 1;
                    Variables.achieves[8] = 1;
                    //draw trophy
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
                    ach8, // spritesheet
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

        public void WriteAchievements()
        {
            if (achieves != null)
            {
                load.WriteAchievements(achieves);
            }
            load.WriteExitGame();
            load.WriteGamesPlayed();
        }

        public void CheckPerfectGame(int p1Kills, int p2Kills, int p1Health, int p2Health)
        {
            Console.WriteLine("CHECKING PERFECT GAME"); //DEBUG
            //Is p1's kills 15 and p2Kills 0?
            if(p2Kills == 0)
            {
                //Did p1 take any damage?
                if(p1Health == 5)
                {
                    achieves = Variables.achieves;
                    achieves[6] = 1;
                    achieves[6] = 1;
                    Console.WriteLine("PLAYER ONE GOT A PERFECT GAME");
                    load.WriteAchievements(achieves);
                    Console.WriteLine("SHOULD HAVE WRITTEN TO THE FILE");
                }
            }

            //Did p2 play a perfect game?
            if(p1Kills == 0)
            {
                //Did p2 take any damage?
                if(p2Health == 5)
                {
                    achieves = Variables.achieves;
                    achieves[6] = 1;
                    Variables.achieves[6] = 1;
                    Console.WriteLine("PLAYER TWO GOT A PERFECT GAME");
                    load.WriteAchievements(achieves);
                    Console.WriteLine("SHOULD HAVE WRITTEN TO THE FILE");
                }
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
