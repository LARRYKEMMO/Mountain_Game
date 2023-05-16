'''
Created on Nov. 15, 2022

@author: larry
'''

## List of imports
import pygame as p  ## importing pygame as variable p
import random   ## importing the random method

## Rocks class creation
class Rocks(p.sprite.Sprite):
    
    ## ***************************************************************************************************************************************************************************************
    ## Class                   :    Rocks
    ##
    ## Class  parameters       :    pygame.sprite.Sprite 
    ## 
    ## Method return           :    void
    ##
    ## Synopsis                :    This class has all methods, parameters relevant to the rocks in the game
    ##                              
    ## Modifications           :    
    ##                              Date           Developer              Notes
    ##                             ------         -----------            -------
    ##                            2022-11-17      LARRY KEMMO           Initial setup   
    ##                              Date           Developer              Notes
    ##                             ------         -----------            ------- 
    ##                            2022-11-17      LARRY KEMMO           Addition of side comments
    ##
    ## *****************************************************************************************************************************************************************************************
    
    def __init__(self):
        
    ## ***************************************************************************************************************************************************************************************
    ## Class                   :    init
    ##
    ## Class  parameters       :    self 
    ## 
    ## Method return           :    void
    ##
    ## Synopsis                :    This class instantiates all Rocks parameters in the game
    ##                              
    ## Modifications           :    
    ##                              Date           Developer              Notes
    ##                             ------         -----------            -------
    ##                            2022-11-17      LARRY KEMMO           Initial setup   
    ##                              Date           Developer              Notes
    ##                             ------         -----------            ------- 
    ##                            2022-11-17      LARRY KEMMO           Addition of side comments
    ##
    ## *****************************************************************************************************************************************************************************************
        
        super().__init__() ## super class constructor called
        self.speed = random.randint(1, 2) ## importing the random method
        self.rockimage = p.image.load('Assets/asteroidR1.png')  ## rockimage instantiation
        self.rockrect = self.rockimage.get_rect()   ## rockrect variable instantiation to rockimage rectangle
        

    def update(self, screen_width):
    ## ***************************************************************************************************************************************************************************************
    ## Class                   :    update
    ##
    ## Class  parameters       :    self, screen_width 
    ## 
    ## Method return           :    void
    ##
    ## Synopsis                :    This class handles rock movement and collision
    ##                              
    ## Modifications           :    
    ##                              Date           Developer              Notes
    ##                             ------         -----------            -------
    ##                            2022-11-17      LARRY KEMMO           Initial setup   
    ##                              Date           Developer              Notes
    ##                             ------         -----------            ------- 
    ##                            2022-11-17      LARRY KEMMO           Addition of side comments
    ##
    ## *****************************************************************************************************************************************************************************************
        
        self.rockrect.y += self.speed; ## rockrect.y y position increment by speed variable

        if(self.rockrect.y > screen_width): ## conditional that handles boundaries in the y direction
            self.rockrect.y = random.randint(-50, -25); ## rockrect.y Instantiation to a random number between the range -50 to -25
            self.rockrect.x = random.randint(0, 1100); ## rockrect.x Instantiation to a random number between the range 0 to 1100
