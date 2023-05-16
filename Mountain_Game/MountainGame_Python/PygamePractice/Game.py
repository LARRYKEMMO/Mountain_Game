'''
Created on Nov. 9, 2022

@author: larry
'''
## List of imports
import pygame as p  ## importing pygame as variable p
from pygame import event, K_RIGHT, K_LEFT   ## importing left and right key from pygame
import rocks    ## importing rocks class
##from pygame._sprite import pygame   
from math import floor ## importing floor method
import sys  ## importing system

p.init()    ## pygame initialization

p.font.init() ## you have to call this at the start, 

p.display.set_caption("Pygame Example") ## Setting caption
screen = p.display.set_mode(size=(1200, 700)) ## Setting screen
clock = p.time.Clock() ## initialization of clock variable
current_time = 0    ## current time instantiation
highScore = 0
my_font = p.font.SysFont('Comic Sans MS', 60) ## my_font Instantiation
my_font2 = p.font.SysFont('Comic Sans MS', 30)  ## my_font2 Instantiation
my_font3 = p.font.SysFont('Comic Sans MS', 15)  ## my_font3 Instantiation
background = p.image.load('Assets/back.png')    ## background Instantiation
Player = p.image.load('Assets/Sasuke1.png') ## Player Instantiation
PlayerRectangle = Player.get_rect() ## PlayerRectangle Instantiation
PlayerRectangle.x = 600  ## playerRectangle.x Instantiation to 600
PlayerRectangle.y = 640  ## PlayerRectangle.y Instantiation to 640
rocklist = []   ## rocklist array Instantiation
text_gameover = my_font.render('GAMEOVER', False, (255, 0, 0))  ## text_gameover Instantiation
text_welcome = my_font2.render('Welcome to my game', False, (0, 0, 0))  ## text_welcome Instantiation
textposx = 10   ## textposx Instantiation to 10
running = True  ## running Instantiation to true
gameon = True   ## gameon Instantiation to true
## key_pressed = False
pressed = {}    ## pressed dictionary Instantiation

def main():
    
    ## ***************************************************************************************************************************************************************************************
    ## Class                   :    main
    ##
    ## Class  parameters       :    void
    ## 
    ## Method return           :    void
    ##
    ## Synopsis                :    This class calls all methods for the proper functioning of the game
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
    
    init() ## calling of init method
    fileReader()
    update(running, gameon, Player, PlayerRectangle, textposx, rocklist) ## calling update method


def init():
    
    ## ***************************************************************************************************************************************************************************************
    ## Class                   :    init
    ##
    ## Class  parameters       :    void 
    ## 
    ## Method return           :    void
    ##
    ## Synopsis                :    This class is responsible for the production of the rocks in the game
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
    
    ## for loop that ensures the instantiation of 13 rocks 
    for x in range(0, 13):
        import random   ## importing the random method
        
        rock = rocks.Rocks()    ## rock variable Instantiation to the Rock class
        rock.rockrect.x = random.randint(0, 1100) ## rockrect.x instantiation to random number between the range 0 to 900
        rock.rockrect.y = random.randint(-500, -100)    ## rockrect.y Instantiation to a random number between the range -500 to -100
        rocklist.append(rock)   ## add rock to rocklist array 


def update(running, gameon, Player, PlayerRectangle, textposx, rocklist):
    
    ## ***************************************************************************************************************************************************************************************
    ## Class                   :    update
    ##
    ## Class  parameters       :    running, gameon, Player, PlayerRectangle, textposx, rocklist
    ## 
    ## Method return           :    void
    ##
    ## Synopsis                :    This class takes care of all entity movement, collision handling and timer increment
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
    global highScore
    while(running): ## while loop that runs while running variable is true
        for event in p.event.get(): ## for loop that takes care of event in p.event list 
                if (event.type == p.QUIT): ## conditional that runs if event.type is equal to p.QUIT
                    sys.exit()  ## system exits
                
                elif (event.type == p.KEYDOWN): ## conditional that runs if event.type is equal to p.KEYDOWN
                    pressed[event.key] = True ## pressed dictionary activated
                
                elif (event.type == p.KEYUP): ## conditional that runs if event.type is equal to p.KEYUP
                    pressed[event.key] = False ## pressed dictionary not activated
                        
        
        if(gameon): ## condition that works only if gameon variable is True
            textposx += 1 ## textposx position increment by 1
            if(textposx > screen.get_width()):
                textposx = 0
            
            draw(Player, PlayerRectangle, textposx, rocklist)
            
            for counter in range(len(rocklist)): ## for loop that ensures the movement of rocks and collision handling
                rocklist[counter].update(screen.get_width()) ## movement of rocks
                collide = rocklist[counter].rockrect.colliderect(PlayerRectangle)   ## collide variable instantiation
                if (collide == True): ## condition that handles collision handling
                    screen.blit(text_gameover, (450,300)) ## Apply text_gameover to screen
                    gameon = False    ## gameon variable instantiation False
                    if(current_time > highScore):
                        highScore = current_time
                        fileWriter()
            
            if(pressed.get(p.K_RIGHT) and PlayerRectangle.x < screen.get_width() - Player.get_width()): ## conditional that handles player movement in the right direction and ensures player is in bounds
                Player = p.image.load('Assets/SasukeR.png') ## player sprite change
                PlayerRectangle.x += 2 ## player x position increment by 2
            
            elif(pressed.get(p.K_LEFT) and PlayerRectangle.x > 0): ## conditional that handles player movement in the left direction and ensures player is in bounds
                 Player = p.image.load('Assets/SasukeL.png') ## player sprite change
                 PlayerRectangle.x -= 2    ##  Player x position decrement
            
            p.display.flip() ## Update screen
            
            
            
            clock.tick(220) ## frame rate
            
            
                    
def fileWriter():
    
        ## ***************************************************************************************************************************************************************************************
        ## Method                   :   WriteToFile
        ##
        ## Class  parameters       :    void
        ## 
        ## Method return           :    void
        ##
        ## Synopsis                :    This class calls all methods peculiar for file writing
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

    
    title = open("file1.txt", "w")  ## file opening 
    title.write(str(highScore)) ## write highscore in file
    title.close()   ## file closing

def fileReader():
    
        ## ***************************************************************************************************************************************************************************************
        ## Method                   :   ReadFile
        ##
        ## Class  parameters       :    void
        ## 
        ## Method return           :    void
        ##
        ## Synopsis                :    This class calls all methods peculiar for file writing
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

    
    global highScore ## enable highscore editing in this method
    title = open("file1.txt", "r")  ## reads file
    highScore = int( title.read() ) ## stores file content in high score data member 
    title.close() ## file closing

                   
def draw(Player, PlayerRectangle, textposx, rocklist):
    
            ## ***************************************************************************************************************************************************************************************
            ## Class                   :    Draw
            ##
            ## Class  parameters       :    gameTime
            ## 
            ## Method return           :    void
            ##
            ## Synopsis                :    This class draws all textures in the game
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

    
    global current_time ## Enable current_time editing in this method
    screen.blit(background, (0,0))  ## Apply background image to screen
    screen.blit(text_welcome, (textposx,10))    ## Apply welcome text to screen
    screen.blit(Player, PlayerRectangle)    ## Apply player image to screen
    current_time = floor(p.time.get_ticks() / 1000) ## Current time instantiation to seconds
    text_score = my_font3.render('Your Score is: ' + str(current_time), False, (0, 0, 0))   ## text_score instantiation
    screen.blit(text_score, (50,50))    ## Apply text_score to screen
    
    text_highscore = my_font3.render('HighScore: ' + str(highScore), False, (0, 0, 0))   ## text_score instantiation
    screen.blit(text_highscore, (50,80))    ## Apply text_score to screen
    
    
    for counter in range(len(rocklist)):    ## for loop that Applies rock image to screen
                screen.blit(rocklist[counter].rockimage, rocklist[counter].rockrect) ## Apply rock image to screen
            
                        
                    
if __name__ == '__main__':
    main() ## main method call
                    
                                