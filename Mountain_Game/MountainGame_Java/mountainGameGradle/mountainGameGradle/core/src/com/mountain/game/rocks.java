package com.mountain.game;
// List of imports
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g3d.particles.influencers.ColorInfluencer.Random;
import com.badlogic.gdx.math.Rectangle;

public class rocks {

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

	public Rectangle rockRectangle;	// rockRectangle data member declaration
    private int Speed;     // Speed data member declaration
    public Texture texture;   // texture data member declaration
    private java.util.Random random;  // random data member declaration
    private java.util.Random rand;    // rand data member declaration
	
	public rocks( int TempRockXPosition, int TempRockYPosition, int TempSpeed, Texture TempTexture) {
		
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

		
		this.rockRectangle = new Rectangle();	// rockRectangle data member instantiation 
		this.rockRectangle.x = TempRockXPosition;	// rockRectangle x-axis position instantiation
		this.rockRectangle.y = TempRockYPosition;	// rockRectangle y-axis position instantiation
		this.rockRectangle.width = TempTexture.getWidth();	// rockRectangle width instantiation
		this.rockRectangle.height = TempTexture.getHeight();	// rockRectangle Height instantiation
		this.Speed = TempSpeed;	// Speed data member instantiation
		this.texture = TempTexture;	// texture data member instantiation
		this.random = new java.util.Random();	// random data member instantiation
		this.rand = new java.util.Random();	// rand data member instantiation
	}
	
	public void update() {
		
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

		rockRectangle.y -= Speed;	// reduces rocks position
		
		if (rockRectangle.y < 0) { // condition that checks if rock is not out of bounds (Not visible on screen)
			rockRectangle.y = random.nextInt(900, 1000);	// sets rock to a random y-axis position
			rockRectangle.x = rand.nextInt(0, 1100);	// sets rock to a random x-axis position
		}
		
	}
	
	public void Draw(SpriteBatch batch, Texture TempTexture) {
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

		batch.draw(TempTexture, rockRectangle.x, rockRectangle.y); // Draws texture at these positions
	}
}
