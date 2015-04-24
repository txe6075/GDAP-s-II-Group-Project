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

#endregion

namespace Huntr
{
    /* Pedro DelaCuadra */


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {

        KeyboardState kState = new KeyboardState();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D environment1;
        Texture2D environment2;
        Texture2D playerSprite; // sprite for player object
        Texture2D kunai;
        Player p1; // player 1 object
        Player p2; // player 2 object
        Map map;
        //Menu related attributes
        Menu menu;
        Texture2D menuSprite;
        public enum gameState { MainMenu, SinglePlayer, Multiplayer, Achievements };
        gameState state;
        int option = 2;


        public Game1()
            : base()
        {
            Variables.playerNums = 0;
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
            Window.SetPosition(new Point(0, 0));
            // TODO: Add your initialization logic here
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            environment1 = Content.Load<Texture2D>("tile2"); //loading in the different tiles
            environment2 = Content.Load<Texture2D>("tile2"); //loading in the different tiles
            kunai = Content.Load<Texture2D>("Kunai"); //loading in the different tiles
            map = new Map(environment1, environment2);
            playerSprite = Content.Load<Texture2D>("sheet"); //loads the character sheets
            p1 = new Player(new Vector2(120, GraphicsDevice.Viewport.Height - 250), new Point(30, 64), playerSprite, kunai, 1); // instantiate the player 1 object
            p2 = new Player(new Vector2(GraphicsDevice.Viewport.Width - 150, GraphicsDevice.Viewport.Height - 250), new Point(30, 64), playerSprite, kunai, 2); // instantiate the player 2 object


            //Menu object
            menuSprite = Content.Load<Texture2D>("Menu");
            menu = new Menu(menuSprite, new Vector2(0, 0));

            map.LoadMap("testMap.txt");
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            kState = Keyboard.GetState(); //registers button pushes

            p1.Update(kState); // update players
            p2.Update(kState);

            // update character images
            p1.UpdateImg(gameTime, kState);
            p2.UpdateImg(gameTime, kState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Update(gameTime);

            Collision();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            switch (state)
            {
                case gameState.MainMenu://if the correct menu selection is selected and enter is pressed, switch to the correct game state
                    //menu.CheckGameState(state);
                    //state = (gameState) menu.Navigate(state);

                    //This is what keeps track of the highlighted menu option (0,1,2,3 are acceptable values)
                    menu.Draw(gameTime, spriteBatch);
                    menu.DrawButton(gameTime, spriteBatch, option);
                    if (Keyboard.GetState().IsKeyDown(Keys.W)) //pressed up, move the cursor up (decrease option)
                    {
                        GraphicsDevice.Clear(Color.Gainsboro);
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
                        //if option is 2, don't increase it
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
                            case 0: //this.state = gameState.SinglePlayer; //set the gameState to singleplayer
                                GraphicsDevice.Clear(Color.Gold);//debug to make sure it's going to the right place
                                break;
                            case 1: this.state = gameState.Achievements; //set the gameState to achievement
                                GraphicsDevice.Clear(Color.Red);
                                break;
                            case 2: this.state = gameState.Multiplayer; //set the gameState to multiplayer
                                GraphicsDevice.Clear(Color.Green);
                                break;
                        }
                    }
                    menu.Draw(gameTime, spriteBatch); //draw the menu
                    break;

                case gameState.SinglePlayer:
                    break;
                case gameState.Multiplayer:
                    map.Draw(gameTime, spriteBatch);

                    p1.Draw(gameTime, spriteBatch); // draw player 1
            
                    p2.Draw(gameTime, spriteBatch); // draw player 2


                    break;
                case gameState.Achievements:
                    break;

            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Collision()
        {
            p1.Falsify();
            p2.Falsify();
            foreach (Environment n in map.Environments)
            {
                if (p1.Rect.Intersects(n.Rect))
                {
                    if (p1.Rect.Top > n.Rect.Bottom - 20)
                    {
                        p1.top = true;
                        p1.gravEffect = -1;
                    }
                    else if (p1.Rect.Bottom < n.Rect.Top + 20)
                    {
                        p1.bottom = true; 
                        p1.top = false;
                        p1.Position = new Vector2(p1.Position.X, n.Position.Y - p1.Size.Y + 10);
                    }
                    else if (p1.Rect.Left > n.Rect.Right - 20)
                    {
                        p1.left = true;
                        p1.right = false;
                        p1.Position = new Vector2(n.Position.X + n.Size.X + 1, p1.Position.Y);
                    }
                    else if (p1.Rect.Right < n.Rect.Left + 20)
                    {
                        p1.right = true;
                        p1.left = false;
                        p1.Position = new Vector2(n.Position.X - p1.Size.X - 1, p1.Position.Y);
                    }
                }

                foreach (Shots s in p1.ShotList)
                {
                    if (s.alive == true)
                    {
                        if (s.Rect.Intersects(n.Rect)) s.alive = false;
                        if (s.Rect.Intersects(p2.Rect) && p2.Health > 0)
                        {
                            s.alive = false;
                            p2.charColor = Color.Red;
                            p2.Health -= 1;
                        }
                    }
                }

                foreach (Shots s in p2.ShotList)
                {
                    if (s.alive == true)
                    {
                        if (s.Rect.Intersects(n.Rect)) s.alive = false;
                        if (s.Rect.Intersects(p1.Rect) && p2.Health > 0) 
                        {
                            s.alive = false;
                            p1.charColor = Color.Red;
                            p1.Health -= 1;
                        }
                    }
                }

                if (p2.Rect.Intersects(n.Rect))
                {

                    if (p2.Rect.Top > n.Rect.Bottom - 20)
                    {
                        p2.top = true;
                        p2.gravEffect = -1;
                    }
                    else if (p2.Rect.Bottom < n.Rect.Top + 20)
                    {
                        p2.bottom = true;
                        p2.top = false;
                        p2.Position = new Vector2(p2.Position.X, n.Position.Y - p2.Size.Y + 10);
                    }
                    else if (p2.Rect.Left > n.Rect.Right - 20)
                    {
                        p2.left = true;
                        p2.right = false;
                        p2.Position = new Vector2(n.Position.X + n.Size.X + 1, p2.Position.Y);
                    }
                    else if (p2.Rect.Right < n.Rect.Left + 20)
                    {
                        p2.right = true;
                        p2.left = false;
                        p2.Position = new Vector2(n.Position.X - p2.Size.X - 1, p2.Position.Y);
                    }

                }
            }
        }
    }
}
