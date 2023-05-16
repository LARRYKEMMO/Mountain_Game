// list of imports
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoPractice
{
    internal class Rocks
    {

        // ***************************************************************************************************************************************************************************************
        // Class                   :    Rocks
        //
        // Class  parameters       :    none 
        // 
        // Method return           :    void
        //
        // Synopsis                :    This class has all methods, parameters relevant to the rocks in the game
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

        public Rectangle rect;  // rect variable declaration
        private float Speed;     // Speed variable declaration
        private Texture2D texture;   // texture variable declaration
        private Random random;  // random variable declaration
        private Random rand;    // rand variable declaration


        public Rocks(Rectangle rect, float speed, Texture2D texture2D)
        {
            // ***************************************************************************************************************************************************************************************
            // Class                   :    Rocks (Constructor)
            //
            // Class  parameters       :    none 
            // 
            // Method return           :    void
            //
            // Synopsis                :    This is responsible for the creation of rocks with all their attributes and parameters
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


            this.rect = rect; // rect variable instantiation
            this.texture = texture2D;   // texture variable instantiation
            Speed = speed;  // Speed variable instantiation
            random = new Random(); // random variable instantiation
            rand = new Random();    // rand variable instantiation
        }
   
        public void Update(GameTime gameTime, int ScreenHeight)
        {

            // ***************************************************************************************************************************************************************************************
            // Class                   :    update
            //
            // Class  parameters       :    gameTime, ScreenHeight 
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class has all methods, parameters relevant to the rocks in the game
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


            rect.Y += (int)Speed; // rock position Y increment by speed variable

            if (rect.Y > ScreenHeight)  //  conditional that handles boundaries in the y direction
            {
                rect.Y = rand.Next(-100, -50); // rect.y Instantiation to a random number between the range -100 to -50
                rect.X = random.Next(0, 1100); // rect.x Instantiation to a random number between the range 0 to 1100
            }   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // ***************************************************************************************************************************************************************************************
            // Class                   :    Draw
            //
            // Class  parameters       :    spriteBatch 
            // 
            // Method return           :    void
            //
            // Synopsis                :    This class draws rocks in the game
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


            spriteBatch.Draw(texture, rect, Color.White);   // Draw rock texture
        }







    }

   

}




