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
        Texture2D playerSprite; // sprite for player object
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
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = Variables.screenWidth;
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
            environment1 = Content.Load<Texture2D>("tile1");
            map = new Map(environment1);
            playerSprite = Content.Load<Texture2D>("sheet");
            p1 = new Player(new Vector2(120, GraphicsDevice.Viewport.Height - 186), new Point(10, 10), playerSprite, 1); // instantiate the player 1 object
            p2 = new Player(new Vector2(GraphicsDevice.Viewport.Width - 150, GraphicsDevice.Viewport.Height - 186), new Point(10, 10), playerSprite, 2); // instantiate the player 2 object

            //p1 = new Player(new Vector2(0, 45), new Point(10, 10), playerSprite); // instantiate the player 1 object
            //p2 = new Player(new Vector2(GraphicsDevice.Viewport.Width - 550, GraphicsDevice.Viewport.Height - 186), new Point(10, 10), playerSprite); // instantiate the player 2 object

            //Menu object
            menuSprite = Content.Load<Texture2D>("Menu");
            menu = new Menu(menuSprite, new Vector2(0, 0));

            map.LoadMap("map.txt");
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

            kState = Keyboard.GetState();
            // TODO: Add your update logic here
            p1.Update(kState); // update player 1
            p2.Update(kState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Update(gameTime);

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
    }
}
