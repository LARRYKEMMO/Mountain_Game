// List of imports
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;  // include the System.IO namespace

namespace MonoPractice
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics; // graphics variable declaration
        private SpriteBatch spriteBatch;    // spriteBatch variable declaration
        private SpriteFont font;    // font variable declaration
        private const string Message = "Welcome to My Game";    // message variable declaration and instantiation
        private const string EndMessage = "GAMEOVER !!!";   // EndMessage declaration and instantiation
        private const string Score = "Your Score is: "; // Score declaration and instantiation 
        private float Timer; // EndMessage Timer
        private float FinalTimer;   // FinalTimer declaration
        private Vector2 TextPosition; // TextPosition declaration
        private Vector2 TimerPosition;  // TimerPosition declaration
        private Vector2 HighScorePosition;  // TimerPosition declaration
        private Vector2 EndTextPosition;    // EndTextPosition declaration
        private const int ScreenWidth = 1200; // ScreenWidth declaration and instantiation to 1200
        private const int ScreenHeight = 800;   // ScreenHeight declaration and instantiation to 800
        private Texture2D background; // Background declaration
        private Rectangle rectangleBackground; // rectangleBackground declaration
        private Texture2D Player; // Player declaration
        private Rectangle PlayerRectangle; // PlayerRectangle declaration
        private KeyboardState Kb; // kb declaration
        private Texture2D RockTexture; // RockTexture declaration
        private Vector2 ScorePosition;  // scorePosition declaration
        private const int Speed = 2; // Speed declaration and instantiation to 2
        private ArrayList RockArray = new ArrayList(); // RockArray declaration and instantiation
        private bool GameOver = false; // GameOver declaration and instantiation to false
        private int Highscore = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); // graphics variable instantiation
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = ScreenWidth; // graphics.PreferredBackBufferWidth instantiation
            graphics.PreferredBackBufferHeight = ScreenHeight; //  graphics.PreferredBackBufferHeight instantiation
            graphics.ApplyChanges(); // Applying changes to the screen


            Timer = 0; // Timer instantiation to 0

            base.Initialize(); 
            
        }

        protected override void LoadContent()
        {
            // ***************************************************************************************************************************************************************************************
            // Class                   :    LoadContent
            //
            // Class  parameters       :    None
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class is responsible for parameter instantiation of player, screen, textures and rectangles
            //                              
            // Modifications           :    
            //                              Date           Developer              Notes
            //                             ------         -----------            -------
            //                            2022-11-17      LARRY KEMMO           Initial setup   
            //                              Date           Developer              Notes
            //                             ------         -----------            ------- 
            //                            2022-11-17      LARRY KEMMO           Addition of side comments
            //
            // *****************************************************************************************************************************************************************************************

            Read();
            spriteBatch = new SpriteBatch(GraphicsDevice); // spriteBatch instantiation
            font = Content.Load<SpriteFont>("Fonts/TextFont");  // font instantiation
            TextPosition = new Vector2(10, 10); // TextPosition instantiation
            TimerPosition = new Vector2(140, 60);   // TimerPosition instantiation
            HighScorePosition = new Vector2(10, 90);   // TimerPosition instantiation
            EndTextPosition = new Vector2(350, 350);    // EndTextPosition instantiation
            ScorePosition = new Vector2(10, 60);    // ScorePosition instantiation

            background = Content.Load<Texture2D>("Textures/back");  // background instantiation
            rectangleBackground = new Rectangle(0, 0, ScreenWidth, ScreenHeight);   // rectangleBackground instantiation

            Player = Content.Load<Texture2D>("Sprites/Sasuke1");    // Player instantiation
            PlayerRectangle = new Rectangle(550, 740, Player.Width, Player.Height); // PlayerRectangle instantiation
            RockTexture = Content.Load<Texture2D>("Sprites/asteroidR1");    // RockTexture instantiation
            Random random = new Random(); // random variable declaration and instantiation
            Random random1 = new Random();  // random1 variable declaration and instantiation

            // For loop that is responsible for rock production
            for (int i = 0; i < 10; i++)
            {
                Rectangle rectangle = new Rectangle(random.Next(0, 900), random1.Next(-500, -100), RockTexture.Width, RockTexture.Height); // rectangle variable declaration and instantiation
                Rocks Rock = new Rocks(rectangle, new Random().Next(5, 8), RockTexture);    // Rock variable declaration and instantiation
                RockArray.Add(Rock);    // // Rock variable addition to RockArray
            }

           
        }

        protected override void Update(GameTime gameTime)
        {

            // ***************************************************************************************************************************************************************************************
            // Class                   :    Update
            //
            // Class  parameters       :    gameTime
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class takes care of all entity movement, collision handling and timer increment
            //                              
            // Modifications           :    
            //                              Date           Developer              Notes
            //                             ------         -----------            -------
            //                            2022-11-17      LARRY KEMMO           Initial setup   
            //                              Date           Developer              Notes
            //                             ------         -----------            ------- 
            //                            2022-11-17      LARRY KEMMO           Addition of side comments
            //
            // *****************************************************************************************************************************************************************************************



            /*Condition that activates is when escape button is activated or when gamepad*/
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit(); // calling of exit method

            // TODO: Add your update logic here

            if (GameOver == false) // Condition that activates while gameover is false
            {
                TextPosition.X += Speed;    // Textposition x position increment by speed variable

                if (TextPosition.X > ScreenWidth) // condition that activates when textPosition > screenwidth variable
                {
                    TextPosition.X = 0; // setting TextPosition to 0

                }

                Timer += (float)gameTime.ElapsedGameTime.TotalSeconds; // Timer increment by actual number of seconds


                Kb = Keyboard.GetState();   // kb variable getting keyboard state

                if (Kb.IsKeyDown(Keys.Left)) // condition that activates only if key pressed is left
                {

                    Player = Content.Load<Texture2D>("Sprites/SasukeL"); // sprite change
                    PlayerRectangle.X -= Speed + 4; // Player x position decrement by speed value + 4
                    if (PlayerRectangle.X < 0) // condition that handles boundaries left
                        PlayerRectangle.X = 0; // sets player position to 0 when it position tends to be less than 0

                }

                if (Kb.IsKeyDown(Keys.Right))   // condition that activates only if key pressed is right
                {
                    Player = Content.Load<Texture2D>("Sprites/SasukeR");    // sprite change
                    PlayerRectangle.X += Speed + 4;  // Player x position increment by speed value + 4
                    if (PlayerRectangle.X > ScreenWidth - 46)   // condition that handles boundaries right
                        PlayerRectangle.X = ScreenWidth - 46;   // sets player position to ScreenWidth - 46 when it position tends to be less than 0
                }
                
                //for loop that hanles collision
                foreach (Rocks rock in RockArray)
                {
                    rock.Update(gameTime, ScreenHeight); // calls update method from Rocks class
                    if (rock.rect.Intersects(PlayerRectangle)) // Condition that activates only after collision between the rock and the player
                    {
                        GameOver = true; // sets GameoOver to true
                        FinalTimer = Timer; // FinalTimer instantiation to timer
                        
                        if(Highscore < (int)Math.Floor(Timer))
                        {
                            Highscore = (int)Math.Floor(Timer);
                            Write();
                        }

                        
                    }

                }
            }
           
            base.Update(gameTime); // Applies changes to screen
        }

        protected override void Draw(GameTime gameTime)
        {

            // ***************************************************************************************************************************************************************************************
            // Class                   :    Draw
            //
            // Class  parameters       :    gameTime
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class draws all textures in the game
            //                              
            // Modifications           :    
            //                              Date           Developer              Notes
            //                             ------         -----------            -------
            //                            2022-11-17      LARRY KEMMO           Initial setup   
            //                              Date           Developer              Notes
            //                             ------         -----------            ------- 
            //                            2022-11-17      LARRY KEMMO           Addition of side comments
            //
            // *****************************************************************************************************************************************************************************************


            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(); // Start drawing

            spriteBatch.Draw(background, rectangleBackground, Color.White); // Draw background

            spriteBatch.Draw(Player, PlayerRectangle, Color.White); // Draw Player

            foreach (Rocks rock in RockArray)   // Loop that draws each rock in the RockArray
            {
                rock.Draw(spriteBatch); // draw rocks
            }

            spriteBatch.DrawString(font, Math.Floor(Timer).ToString(), TimerPosition, Color.Black); // Draw Timer String
            spriteBatch.DrawString(font, "HighScore " + Highscore.ToString(), HighScorePosition, Color.Black);    // Draws score

            Vector2 tempVector = new Vector2(0, 0);
            Vector2 tempScaleVector = new Vector2(2, 2);
            spriteBatch.DrawString(font, Message, TextPosition, Color.Black, 0f, tempVector, tempScaleVector, SpriteEffects.None, 0f); // Draws wlecome text
            spriteBatch.DrawString(font, Score, ScorePosition, Color.Black); // Draws score


            if (GameOver == true)   // condition that activates while gameover is true
            {
                 tempVector = new Vector2(0, 0);
                 tempScaleVector = new Vector2(4, 4);
                spriteBatch.DrawString(font, EndMessage, EndTextPosition, Color.Red, 0f, new Vector2(0, 0), new Vector2(4,4), SpriteEffects.None, 0f);  
                spriteBatch.DrawString(font, Math.Floor(FinalTimer).ToString(), TimerPosition, Color.Black);    // Draws score
                spriteBatch.DrawString(font, "HighScore " + Highscore.ToString(), HighScorePosition, Color.Black);    // Draws score
            } 


            spriteBatch.End(); // Stops drawing


            base.Draw(gameTime);

        }

        public void Write()
        {
            // ***************************************************************************************************************************************************************************************
            // Method                   :   WriteToFile
            //
            // Class  parameters       :    void
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class calls all methods peculiar for file writing
            //                              
            // Modifications           :    
            //                              Date           Developer              Notes
            //                             ------         -----------            -------
            //                            2022-11-17      LARRY KEMMO           Initial setup   
            //                              Date           Developer              Notes
            //                             ------         -----------            ------- 
            //                            2022-11-17      LARRY KEMMO           Addition of side comments
            //
            // *****************************************************************************************************************************************************************************************


            string writeText = Highscore.ToString();  // Create a text string
            File.WriteAllText("file1.txt", writeText);  // Create a file and write the content of writeText to it
        }

        public void Read()
        {

            // ***************************************************************************************************************************************************************************************
            // Method                   :   ReadFile
            //
            // Class  parameters       :    void
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class calls all methods peculiar for file writing
            //                              
            // Modifications           :    
            //                              Date           Developer              Notes
            //                             ------         -----------            -------
            //                            2022-11-17      LARRY KEMMO           Initial setup   
            //                              Date           Developer              Notes
            //                             ------         -----------            ------- 
            //                            2022-11-17      LARRY KEMMO           Addition of side comments
            //
            // *****************************************************************************************************************************************************************************************


            string readText = File.ReadAllText("file1.txt");  // Read the contents of the file
            Highscore = (int)Convert.ToInt64(readText);  // Output the content
        }

    }
}