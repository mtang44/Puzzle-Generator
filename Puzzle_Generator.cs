
using System;
public class Puzzle_Generator
{
    public static void Main(string[] args)
    {
        int PUZZLE_WIDTH = 24;
        int PUZZLE_HEIGHT = 10;
        
        
         char[,] thisPuzzle = new char[PUZZLE_HEIGHT,PUZZLE_WIDTH];
         
            createPuzzle(thisPuzzle, PUZZLE_HEIGHT,PUZZLE_WIDTH);

            fillPuzzle(thisPuzzle, PUZZLE_HEIGHT,PUZZLE_WIDTH,3);
            

        for(int i = 0; i < PUZZLE_HEIGHT ; i++)
        {
            for(int j = 0; j < PUZZLE_WIDTH ; j++)
            {
                Console.Write(thisPuzzle[i,j]);
            }
            Console.WriteLine();    
        }
        




        
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

        if(playerY == randomWallY) // make sure player is not on the wall
        {
            playerY = random.Next(1,height -1);
        }
        Console.WriteLine(width+ " " + height);
        Console.WriteLine(randomWallY);
        Console.WriteLine(randomDoorX);
       
        Console.WriteLine(playerX);
        Console.WriteLine(playerY);
        for(int i = 1; i < width -1; i++) // build random wall with a door
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
        array[playerY,playerX] = '@'; // place player

        int switchX = random.Next(1, width -1); 
        int switchY = random.Next(1, height-1);
        
        if(playerY > randomWallY)
        {
            while(switchY < randomWallY) // keep generating switch unti in same room as player
            {
                switchY = random.Next(1, height -1);
            }
        }
        else if(playerY < randomWallY)
        {
            while(switchY > randomWallY) // keep generating switch unti in same room as player
            {
                switchY = random.Next(1, height -1);
            }
        }   
        array[switchY,switchX] = 'S';
    }
}
