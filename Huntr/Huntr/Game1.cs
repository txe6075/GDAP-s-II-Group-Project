/*
 * Team: Elimmination Platform
 * 
 * Main class
 */

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;
#endregion

namespace Huntr
{
    /* Pedro DelaCuadra */


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //VARIABLES

        //basic stuff
        KeyboardState kState = new KeyboardState();
        GraphicsDeviceManager graphics;

        //stuff to load
        SpriteBatch spriteBatch;
        Texture2D environment1;
        Texture2D environment2;
        Texture2D environment3;
        Texture2D environment4;
        Texture2D playerSprite; // sprite for player object
        Texture2D player2Sprite; // sprite for second player object
        Texture2D heart;
        Texture2D kunai;
        Texture2D speed;
        Texture2D jump;
        Texture2D p1win;
        Texture2D p2win;
        SpriteFont font;

        //Unique classes
        Player p1;
        Player p2; 
        Map map;

        //Menu related attributes
        Menu menu;
        Texture2D menuSprite;
        Texture2D button1Sprite;
        Texture2D button2Sprite;
        Texture2D button3Sprite;
        public enum gameState { MainMenu, Exit, Multiplayer, Achievements };
        gameState state;
        int option = 0;


        //Pause Screen Attributes
        Texture2D pauseSprite;
        Texture2D resumeButton;
        Texture2D mainMenuButton;
        Pause pause;


        public Game1()
            : base()
        {
            Variables.playerNums = 0; //sets a global variable
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //***NOT OUR CODE**//
            Window.SetPosition(new Point(0, 0));                            //NOT OUR CODE

            graphics.PreferredBackBufferWidth = Variables.screenWidth;      //setting the screen size
            graphics.PreferredBackBufferHeight = Variables.screenHeight;
            graphics.ApplyChanges(); 
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // basics
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //textures for on screen
            heart = Content.Load<Texture2D>("redheart");
            environment1 = Content.Load<Texture2D>("tile1"); //loading in the different tiles
            environment2 = Content.Load<Texture2D>("tile2"); 
            environment3 = Content.Load<Texture2D>("tile3");
            environment4 = Content.Load<Texture2D>("tile4"); 
            kunai = Content.Load<Texture2D>("Kunai");
            playerSprite = Content.Load<Texture2D>("sheet"); //loads the character sheets
            player2Sprite = Content.Load<Texture2D>("redChar");
            speed = Content.Load<Texture2D>("speed");
            jump = Content.Load<Texture2D>("jump");

            //fonts
            font = Content.Load<SpriteFont>("font1");

            //initializing our variables
            map = new Map(environment1, environment2, environment3, environment4);
            map.LoadMap("testMap.txt");
            p1 = new Player(new Vector2(120, GraphicsDevice.Viewport.Height - 250), new Point(30, 64), playerSprite, kunai, 1); // instantiate the player 1 object
            p2 = new Player(new Vector2(GraphicsDevice.Viewport.Width - 150, GraphicsDevice.Viewport.Height - 250), new Point(30, 64), player2Sprite, kunai, 2); // instantiate the player 2 object

            p1win = Content.Load<Texture2D>("p1win");
            p2win = Content.Load<Texture2D>("p2win");

            //Menu object
            menuSprite = Content.Load<Texture2D>("Menu3");
            button1Sprite = Content.Load<Texture2D>("Multiplayer Button");
            button2Sprite = Content.Load<Texture2D>("Achievement Button");
            button3Sprite = Content.Load<Texture2D>("Exit Game Button");
            menu = new Menu(menuSprite, new Vector2(0, 0), button1Sprite, new Vector2(600,400), button2Sprite, new Vector2(600, 500), button3Sprite, new Vector2(600, 600));



            //Pause 
            pauseSprite = Content.Load<Texture2D>("Paused Screen");
            resumeButton = Content.Load<Texture2D>("Resume Button");
            mainMenuButton = Content.Load<Texture2D>("Main Menu Button");
            pause = new Pause(pauseSprite, new Vector2(0, 0), resumeButton, new Vector2(600, 400), mainMenuButton, new Vector2(600,500), button3Sprite, new Vector2(600, 600));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // both player one and two can exit the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || GamePad.GetState(PlayerIndex.Two).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Variables.gamesQuit++;
                Exit();
            }
            // both player one and two can pause and unpause the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || GamePad.GetState(PlayerIndex.Two).Buttons.Start == ButtonState.Pressed)
            {
                Variables.isPaused = true;
            }

            if (Variables.isPaused == false)
            {
                kState = Keyboard.GetState(); //registers button pushes

                p1.Update(kState, GamePad.GetState(PlayerIndex.One)); // update players
                p2.Update(kState, GamePad.GetState(PlayerIndex.Two));

                // update character images for animation
                p1.UpdateImg(gameTime, kState, GamePad.GetState(PlayerIndex.One));
                p2.UpdateImg(gameTime, kState, GamePad.GetState(PlayerIndex.Two));

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Update(gameTime);

            WinCondition();

            Collision(); //All collision is registered before drawing

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            switch (state)
            {
                case gameState.MainMenu://if the correct menu selection is selected and enter is pressed, switch to the correct game state

                    //This is what keeps track of the highlighted menu option (0,1,2,3 are acceptable values)
                    menu.Draw(gameTime, spriteBatch);
                    //menu.DrawButtons(gameTime, spriteBatch, option);
                    option = menu.Navigate(gameTime, spriteBatch, option);
                    if (menu.CheckPress == true)
                    {
                        switch (option)
                        {
                            case 0: state = gameState.Multiplayer;
                                pause.CheckPress = false;
                                option = 0;
                                break;
                            case 1: state = gameState.Achievements;
                                break;
                            case 2: state = gameState.Exit;
                                break;
                        }
                    }
                    break;

                case gameState.Exit:
                    Variables.gamesQuit++;
                    Exit();
                    break;
                case gameState.Multiplayer:
                    map.Draw(gameTime, spriteBatch); //draw map

                    p1.Draw(gameTime, spriteBatch); // draw player 1
            
                    p2.Draw(gameTime, spriteBatch); // draw player 2

                    ExtraSprites(spriteBatch); //Calls all extra in game stuff

                    //Draw the pause menu and enable navigation
                    if(Variables.isPaused)
                    {
                        if (!Variables.gameOver)
                        {
                            //This is what keeps track of the highlighted menu option (0,1,2,3 are acceptable values)
                            pause.Draw(gameTime, spriteBatch);
                            //menu.DrawButtons(gameTime, spriteBatch, option);
                            option = pause.Navigate(gameTime, spriteBatch, option);
                            if (pause.CheckPress == true)
                            {
                                switch (option)
                                {
                                    case 0: Variables.isPaused = false;
                                        pause.CheckPress = false;
                                        break;
                                    case 1: state = gameState.MainMenu;
                                        menu.CheckPress = false;
                                        option = 0;
                                        Thread.Sleep(400);
                                        Variables.gamesQuit++;
                                        break;
                                    case 2: state = gameState.Exit;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            string winner = "";

                            if (p1.KillCount >= 15)
                                spriteBatch.Draw(p1win, new Rectangle(Variables.screenWidth/2 - p1win.Width/2, Variables.screenHeight/2 - p1win.Height/2, 800, 300), Color.White);
                            else if (p2.KillCount >= 15)
                                spriteBatch.Draw(p2win, new Rectangle(Variables.screenWidth / 2 - p1win.Width / 2, Variables.screenHeight / 2 - p1win.Height / 2, 800, 300), Color.White);

                            spriteBatch.DrawString(font, "To exit, press X", new Vector2(Variables.screenWidth / 2 - 100, Variables.screenHeight / 2 + 50), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

                            //Add to the number of games played
                            Variables.gamesPlayed++;

                            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Y) || GamePad.GetState(PlayerIndex.Two).IsButtonDown(Buttons.Y))
                            {
                                Variables.gamesQuit++;
                                
                                Exit();
                            }
                        }

                    }

                    break;
                case gameState.Achievements:
                    if(GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.B))
                    {
                        state = gameState.MainMenu;
                    }

                    spriteBatch.DrawString(font, "B: To Mainmenu", new Vector2(Variables.screenWidth / 2 - 100, Variables.screenHeight / 2 + 50), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
                    menu.CheckPress = false;
                    option = 0;
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Collision() //All objects in game can collide here
        {
            p1.Falsify(); //Resets collision variables for retesting
            p2.Falsify();

            foreach (Environment n in map.Environments) //interates through each tile once
            {
                if (p1.Rect.Intersects(n.Rect)) //compares them to player 1
                {
                    if (p1.Rect.Top > n.Rect.Bottom - 20) //checks for top and bottom first to decide whether or not to fall
                    {
                        p1.Top = true;
                        p1.gravEffect = -1; //if your head hits something, this gives a bounce off effect
                    }
                    else if (p1.Rect.Bottom < n.Rect.Top + 20)
                    {
                        p1.Bottom = true; 
                        p1.Top = false;
                        p1.Position = new Vector2(p1.Position.X, n.Position.Y - p1.Size.Y + 10);
                    }
                    else if (p1.Rect.Left > n.Rect.Right - 20) //then left and right are checked to see if movement that way is possible
                    {
                        p1.Left = true;
                        p1.Right = false;
                        p1.Position = new Vector2(n.Position.X + n.Size.X + 1, p1.Position.Y);
                    }
                    else if (p1.Rect.Right < n.Rect.Left + 20)
                    {
                        p1.Right = true;
                        p1.Left = false;
                        p1.Position = new Vector2(n.Position.X - p1.Size.X - 1, p1.Position.Y);
                    }
                }

                foreach (Shots s in p1.ShotList) //This checks to see if kunai collide with anything
                {
                    if (s.Alive == true) //only checks if theyre active, saves time
                    {
                        if (s.Rect.Intersects(n.Rect)) s.Alive = false; //turns off the kunai
                        if (s.Rect.Intersects(p2.Rect) && p2.Health > 0)    //if it hits a character
                        {
                            s.Alive = false;                            //turns off kunai
                            p2.CharColor = Color.Red;                   //turns hit player red for a sec
                            p2.Health -= 1;                             //decreases their health
                            if (p2.Health == 0) p1.KillCount += 1;      //if you kill them it increases your kill count
                            if (p2.Health <= 0) p2.Health = 0;
                        }
                    }
                }

                foreach (Shots s in p2.ShotList) //same as previous
                {
                    if (s.Alive == true)
                    {
                        if (s.Rect.Intersects(n.Rect)) s.Alive = false;
                        if (s.Rect.Intersects(p1.Rect) && p1.Health > 0) 
                        {
                            s.Alive = false;
                            p1.CharColor = Color.Red;
                            p1.Health -= 1;
                            if (p1.Health == 0) p2.KillCount += 1;
                            if (p1.Health <= 0) p1.Health = 0;
                        }
                    }
                }

                if (p2.Rect.Intersects(n.Rect)) //same as previous
                {

                    if (p2.Rect.Top > n.Rect.Bottom - 20)
                    {
                        p2.Top = true;
                        p2.gravEffect = -1;
                    }
                    else if (p2.Rect.Bottom < n.Rect.Top + 20)
                    {
                        p2.Bottom = true;
                        p2.Top = false;
                        p2.Position = new Vector2(p2.Position.X, n.Position.Y - p2.Size.Y + 10);
                    }
                    else if (p2.Rect.Left > n.Rect.Right - 20)
                    {
                        p2.Left = true;
                        p2.Right = false;
                        p2.Position = new Vector2(n.Position.X + n.Size.X + 1, p2.Position.Y);
                    }
                    else if (p2.Rect.Right < n.Rect.Left + 20)
                    {
                        p2.Right = true;
                        p2.Left = false;
                        p2.Position = new Vector2(n.Position.X - p2.Size.X - 1, p2.Position.Y);
                    }

                }
            }
        }

        public void ExtraSprites(SpriteBatch spriteBatch)   //this prints all fonts and health and score
        {                                                   //in one area for easier reading
            spriteBatch.Draw(heart, new Rectangle(0, 0, 48, 48), Color.Blue);
            spriteBatch.Draw(heart, new Rectangle(Variables.screenWidth - 48, 0, 48, 48), Color.White);

            spriteBatch.DrawString(font, "" + p1.Health, new Vector2(15, 10), Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "SCORE:", new Vector2(0, 50), Color.White, 0, Vector2.Zero, .6f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "" + p1.KillCount, new Vector2(5, 60), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            spriteBatch.DrawString(font, "" + p2.Health, new Vector2(Variables.screenWidth - 33, 10), Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "SCORE:", new Vector2(Variables.screenWidth - 48, 50), Color.White, 0, Vector2.Zero, .6f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "" + p2.KillCount, new Vector2(Variables.screenWidth - 43, 60), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            if (p1.KillCount >= 5)
            {
                spriteBatch.Draw(speed, new Rectangle(48, 0, 48, 48), Color.White);
                if (p1.KillCount >= 10)
                {
                    spriteBatch.Draw(jump, new Rectangle(96, 0, 48, 48), Color.White);
                }
            }
            if (p2.KillCount >= 5)
            {
                spriteBatch.Draw(speed, new Rectangle(Variables.screenWidth - 96, 0, 48, 48), Color.White);
                if (p2.KillCount >= 10)
                {
                    spriteBatch.Draw(jump, new Rectangle(Variables.screenWidth - 144, 0, 48, 48), Color.White);
                }
            }
        }

        public void WinCondition()
        {
            if (p1.KillCount >= 15 || p2.KillCount >= 15)
            {
                Variables.gameOver = true;
                Variables.isPaused = true;
            }
        }
    }
}
