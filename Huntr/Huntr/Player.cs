/*
 * Team: Elimmination Platform
 * 
 * The instantiation for both players
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

namespace Huntr
{
    /*Pedro DelaCuadra*/


    class Player: Lifers
    {
        //Variables

        private int playerNum;
        SpriteEffects effect = SpriteEffects.None;

        //Contains all own kunai
        private Shots[] shots = new Shots[5];

        //For Keyboard controlling diff characters
        Keys leftKey;
        Keys rightKey;
        Keys upKey;
        Keys downKey;
        Keys fireKey;

        //controls color of character when hit
        private Color charColor;
        private int colorCount;

        //collision detection variables
        private bool left;
        private bool right;
        private bool bottom;
        private bool top;
        private bool jumpPress;
        private bool firePress;

        //effect of gravity for jumping
        public int gravEffect;

        //misc counters
        private int gravCounter;
        private int deathCounter;

        //obvious by name
        private int direction;
        private int health;
        private int killCount;
        Rectangle charRect;

        private int playerSpeed;
        private int gravEffectVar;
        private int powerup;
        private int ccCount;

        //animation
        private int frame;
        private int framesElapsed;
        private int numFrames;
        private double timePerFrame;

        //PROPERTIES

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int KillCount
        {
            get { return killCount; }
            set { killCount = value; }
        }

        public bool Top
        {
            get { return top; }
            set { top = value; }
        }

        public bool Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        public bool Left
        {
            get { return left; }
            set { left = value; }
        }

        public bool Right
        {
            get { return right; }
            set { right = value; }
        }

        public Color CharColor
        {
            get { return charColor; }
            set { charColor = value; }
        }


        public Shots[] ShotList 
        { 
            get { return shots; } 
        }


        // enumeration
        enum CharState { runLeft, runRight, faceForward, jump, dead}
        CharState charState = CharState.faceForward;



        public Player(Vector2 pos, Point s, Texture2D ti, Texture2D kunai, int num) //Constructor (takes texture for Shinai because it holds its own)
            : base(pos, s, ti)
        {
            playerNum = num;    //sets the keys
            if (playerNum == 1) //different buttons based on character num
            {
                rightKey = Keys.D;
                leftKey = Keys.A;
                upKey = Keys.W;
                downKey = Keys.S;
                fireKey = Keys.F;
                direction = 2; //starts them in diff directions as well
            }
            else
            {
                rightKey = Keys.L;
                leftKey = Keys.J;
                upKey = Keys.I;
                downKey = Keys.K;
                fireKey = Keys.H;
                direction = 1;
            }

            //surrounding area collisions
            right = false;
            left = false;
            bottom = false;
            top = false;

            //maintains single jump and fire
            jumpPress = false;
            firePress = false;

            //intialize other variables
            gravEffect = 0;
            gravCounter = 0;
            colorCount = 0;
            deathCounter = 0;
            health = 5;
            timePerFrame = 60;
            numFrames = 10;
            charColor = Color.White;

            //initialize all kunai
            for (int i = 0; i < 5; i++)
            {
                shots[i] = new Shots(new Vector2(0,0), new Point(8, 32), kunai);
            }


            charRect = new Rectangle(0, 463, 60, 128);

            
            playerSpeed = Variables.playerSpeed;
            gravEffectVar = 5;
            powerup = 5;
            ccCount = 10;
        }

        // updates the player image depending on key presses
        public override void UpdateImg(GameTime gameTime, KeyboardState kState, GamePadState gState)
        {
            // Calculate the frame to draw based on the time
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
            frame = framesElapsed % numFrames;

            if (charState == CharState.dead) // Goes to this mode when player has no health left
            {
                frame = ((int)((deathCounter+=3) / timePerFrame)) % numFrames; //makes sure the death animation plays through fully

                charRect = new Rectangle(5 + frame * Variables.DEAD_WIDTH, Variables.DEAD_Y, Variables.DEAD_WIDTH, Variables.DEAD_HEIGHT);

                if (direction == 1)     //falls in diff directions based on which way the character was facing
                    effect = SpriteEffects.FlipHorizontally;
                else if (direction == 2)
                    effect = SpriteEffects.None;

                if (frame >= 9) //respawns the player with full health
                {
                    health = 5;
                    charState = CharState.faceForward;
                    deathCounter = 0;
                    if (playerNum == 1) Position = new Vector2(120, Variables.screenHeight - 250);
                    else if (playerNum == 2) Position = new Vector2(Variables.screenWidth - 150, Variables.screenHeight - 250);
                }

            }
            else
            {
                // character is running right
                if (gState.ThumbSticks.Left.X >= .5)
                {
                    charState = CharState.runRight;
                }
                // character is running left
                else if (gState.ThumbSticks.Left.X <= -.5)
                {
                    charState = CharState.runLeft;
                }
                // character is jumping
                else if (gState.IsButtonUp(Buttons.A))
                {
                    charState = CharState.jump;
                }
                // character is not moving
                else if (gState.ThumbSticks.Left.X < .5 && gState.ThumbSticks.Left.X > -.5 && gState.IsButtonUp(Buttons.A))
                {
                    charState = CharState.faceForward;
                }

                // character is running left
                if (charState == CharState.runLeft && left == false)
                {
                    charRect = new Rectangle(5 + frame * Variables.RUN_WIDTH, Variables.RUNNING_Y, Variables.RUN_WIDTH, Variables.RUN_HEIGHT);
                    direction = 1;
                    effect = SpriteEffects.FlipHorizontally;
                }

                // character is running right
                if (charState == CharState.runRight && right == false)
                {
                    charRect = new Rectangle(5 + frame * Variables.RUN_WIDTH, Variables.RUNNING_Y, Variables.RUN_WIDTH, Variables.RUN_HEIGHT);
                    direction = 2;
                    effect = SpriteEffects.None;
                }

                // character is jumping left
                if (charState == CharState.jump && gState.ThumbSticks.Left.X <= -.5 && left == false)
                {
                    charRect = new Rectangle(0 + frame * Variables.JUMP_WIDTH, Variables.JUMPING_Y, Variables.JUMP_WIDTH, Variables.JUMP_HEIGHT);
                    direction = 1;
                    effect = SpriteEffects.FlipHorizontally;
                }
                // character is jumping right
                else if (charState == CharState.jump && gState.ThumbSticks.Left.X >= .5)
                {
                    charRect = new Rectangle(0 + frame * Variables.JUMP_WIDTH, Variables.JUMPING_Y, Variables.JUMP_WIDTH, Variables.JUMP_HEIGHT);
                    direction = 2;
                    effect = SpriteEffects.None;
                }
                // character is jumping straight up
                else if (charState == CharState.jump)
                {
                    charRect = new Rectangle(0 + frame * Variables.JUMP_WIDTH, Variables.JUMPING_Y, Variables.JUMP_WIDTH, Variables.JUMP_HEIGHT);
                }

                // character is not moving
                if (charState == CharState.faceForward)
                {
                    charRect = new Rectangle(0 + frame * Variables.STAND_WIDTH, Variables.STANDING_Y, Variables.STAND_WIDTH, Variables.STAND_HEIGHT);
                }

                // makes sure jump animation doesnt happen when on the ground
                if (charState == CharState.jump && bottom == true)
                {
                    charRect = new Rectangle(0 + frame * Variables.STAND_WIDTH, Variables.STANDING_Y, Variables.STAND_WIDTH, Variables.STAND_HEIGHT);
                    // running animations play even while the jump key is held down
                    if (gState.ThumbSticks.Left.X <= -.5) // running left
                    {
                        charRect = new Rectangle(5 + frame * Variables.RUN_WIDTH, Variables.RUNNING_Y, Variables.RUN_WIDTH, Variables.RUN_HEIGHT);
                        direction = 1;
                        effect = SpriteEffects.FlipHorizontally;
                    }
                    else if (gState.ThumbSticks.Left.X >= .5) // running right
                    {
                        charRect = new Rectangle(5 + frame * Variables.RUN_WIDTH, Variables.RUNNING_Y, Variables.RUN_WIDTH, Variables.RUN_HEIGHT);
                        direction = 2;
                        effect = SpriteEffects.None;
                    }
                }

                // checks to see if character is falling
                if (bottom == false)
                {
                    charRect = new Rectangle(0 + frame * Variables.JUMP_WIDTH, Variables.JUMPING_Y, Variables.JUMP_WIDTH, Variables.JUMP_HEIGHT); // cycle through jump animation
                }
            }

            //character flashes red when damaged
            if (charColor != Color.White) colorCount++;
            if (charColor != Color.White && colorCount >= ccCount)
            {
                charColor = Color.White;
                colorCount = 0;
                ccCount = 10;
            }
        }

        public override void Update(KeyboardState kState, GamePadState gState)
        {
            Gravity();//Gravity happens first
            if (killCount == powerup) Upgrade();

            if (health <= 0) //dead  player with null controls
            {
                charState = CharState.dead;
            }
            else
            {
                if (Position.Y <= 36) Position = new Vector2(Position.X, 37);       //keeps the player within the map

                if (gState.ThumbSticks.Left.X >= .5 && right == false)                   //lets you move right when there is no tile
                {
                    left = false; timePerFrame = 40;                                //increases the speed of run animation

                    Position = new Vector2(Position.X + playerSpeed, Position.Y);
                }
                if (gState.ThumbSticks.Left.X <= -.5 && left == false)                     //lets you move left when there is no tile
                {
                    right = false; timePerFrame = 40;                               //increases speed of run animation

                    Position = new Vector2(Position.X - playerSpeed, Position.Y);
                }
                if (gState.IsButtonDown(Buttons.A) && top == false && jumpPress == false)  //jumps and checks for object above
                {
                    top = true;             
                    bottom = false;
                    jumpPress = true;                                               //single jump

                    timePerFrame = 100;                                             //slower animation

                    Position = new Vector2(Position.X, Position.Y - 10);

                    gravEffect = gravEffectVar;                                                 //this grav effect throws the player up
                }
                else if (gState.IsButtonUp(Buttons.A)) jumpPress = false;               //resets jump ability if not pressed

                if (gState.IsButtonDown(Buttons.X) && firePress == false)                //single kunai throw
                {
                    foreach (Shots s in shots)
                    {
                        if (s.Alive == false)                                       //finds first unactive kunai
                        {
                            s.Set(new Vector2(Position.X + Size.X / 2, Position.Y + Size.Y / 3), direction);
                            Variables.thrownKunai++; //increase thrown kunai by one
                            Console.WriteLine("ThrownKunai: " + Variables.thrownKunai);
                            break;
                        }
                    }
                    firePress = true;               
                }
                else if (gState.IsButtonUp(Buttons.X) && firePress == true) firePress = false;    //resets throw ability
            }

            Rect = new Rectangle { X = (int)Position.X, Y = (int)Position.Y, Width = Size.X, Height = Size.Y }; //updates rectangle
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) //draw function
        {
            spriteBatch.Draw(
                TextureImage, // spritesheet
                Position, // where to draw in window
                charRect, // pick out a section of spritesheet
                charColor, // dont change image color
                0, // don't rotate the image
                Vector2.Zero, // rotation center (not used)
                .5f, // scaling factor - scale image down to .4
                effect, // no effects
                0  // default layer
            );

            foreach (Shots s in shots)                              //calls draw for all owned shots if they are active
            {
                if (s.Alive == true)
                {
                    if (Variables.isPaused == false)
                    {
                        s.Update(); //updates position and rotation before draw
                    }
                    s.Draw(gameTime, spriteBatch);
                }
            }
        }

        public void Gravity()   //Keeps the player falling when nothing is below them
        {
            if (bottom == false)            //if nothing is below the player
            {
                Position = new Vector2(Position.X, Position.Y - gravEffect); //lowered by gravity amount

                gravCounter++;
                if (gravCounter % 10 == 0)
                {
                    if(gravEffect > -10)        //keeps the gravity from getting too drastic, which could 
                        gravEffect -= 1;        //throw players through objects and skip rectangle collision
                    gravCounter = 0;

                }
            }
            else
            {
                gravCounter = 0;                //if on top of something, there is no grav effect
                gravEffect = 0;
            }

        }

        public void Falsify()                   //resets collision variables so they can be revarified
        {
            bottom = false;
            left = false;
            right = false;
        }

        public void Upgrade()
        {
            if (killCount == 5)
            {
                playerSpeed += 1;
                powerup = 10;
                charColor = Color.Gold;
                ccCount = 100;
            }
            else if (KillCount == 10)
            {
                gravEffectVar += 2;
                powerup = 100;
                charColor = Color.Gold;
                ccCount = 100;
            }
        }
    }
}
