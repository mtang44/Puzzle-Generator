
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
public class Puzzle_Generator
{
    public static void Main(string[] args)
    {
        int PUZZLE_WIDTH = 24;
        int PUZZLE_HEIGHT = 10;
        
        
        
         
         for(int index = 1; index < 11; index ++)
        {
           
            Random rand = new Random();
            int randomBoxCount = rand.Next(1,4);
            Console.WriteLine("Generating Puzzle #" + index + " with " + randomBoxCount + " boxes");
            Console.WriteLine();
            char[,] thisPuzzle = new char[PUZZLE_HEIGHT,PUZZLE_WIDTH];
            createPuzzle(thisPuzzle, PUZZLE_HEIGHT,PUZZLE_WIDTH);
            fillPuzzle(thisPuzzle, PUZZLE_HEIGHT,PUZZLE_WIDTH,randomBoxCount);
            printPuzzle(thisPuzzle, PUZZLE_HEIGHT,PUZZLE_WIDTH);

        }
    }
    public static void printPuzzle(char[,]array, int height, int width)
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width ; j++)
            {
                Console.Write(array[i,j]);
            }
            Console.WriteLine();    
        }
        Console.WriteLine();
    }
    public static void createPuzzle(char[,]array ,int height, int width)
    {
        for(int row = 0; row < height ; row++)
        {
            for(int col = 0; col < width; col++)
            {
                if(row == 0 || row == height -1 || col == 0 || col == width -1) // create matrix border
                {
                    array[row,col] = '#';
                }
                else
                {  
                    array[row,col] = ' ';
                }
            }
        }
    }
    public static void fillPuzzle(char[,]array, int height, int width, int switchCount)
    {
        Random random = new Random();
        int randomWallY = random.Next(1,height -1);
        int randomDoorX = random.Next(1,width -1);
       
        int playerX = random.Next(1,width -1);
        int playerY = random.Next(1,height -1);
        int playerSide; 
        
        while(playerY == randomWallY) // make sure player is not on the wall
        {
            playerY = random.Next(1,height -1);
        }
        // test which side player spawns on
        if(playerY > randomWallY)
        {
            playerSide = 1;
        }
        else
        {
            playerSide = -1;
        }
        // Console.WriteLine(width+ " " + height);
        // Console.WriteLine(randomWallY);
        // Console.WriteLine(randomDoorX);
       
        // Console.WriteLine(playerX);
        // Console.WriteLine(playerY);
        
        /// build random wall with a door
        for(int i = 1; i < width -1; i++) 
        {
            if(i == randomDoorX)
            {
                array[randomWallY,i] = 'D';
            }
            else
            {
                array[randomWallY,i] = '=';
            }
           
        }
        // place player
        array[playerY,playerX] = '@'; 
        

        // place switches in the room with the player
        for(int i = 0; i < switchCount; i++)
        {
            int switchX = random.Next(1, width -1); 
            int switchY = random.Next(1, height-1);
            int boxX = random.Next(1,width -1);
            int boxY = random.Next(1,height - 1);
            while(switchY == randomWallY)
            {
                switchY = random.Next(1, height-1);
            }
        if(playerSide == 1)
        {
            while(switchY < randomWallY) // keep generating switch until in same room as player
            {
                switchY = random.Next(1, height -1);
            }
            while(boxY < randomWallY) // keep generating box until in same room as player
            {
                boxY = random.Next(1, height -1);
            }
        }
        else if(playerSide == -1)
        {
            while(switchY > randomWallY) // keep generating switch unti in same room as player
            {
                switchY = random.Next(1, height -1);
            }
            while(boxY > randomWallY) // keep generating switch unti in same room as player
            {
                boxY = random.Next(1, height -1);
            }
        }   
        while(array[boxY, boxX]!= ' ')
        {
            boxX = random.Next(1, width -1);
            boxY = random.Next(1, height -1);
        }
        array[boxY, boxX] = 'B';
        array[switchY,switchX] = 'S';
        }
    }
    
}
