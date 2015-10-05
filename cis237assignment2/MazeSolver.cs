using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        const int maze_size = 12;
        static int[] allowed_move_row = { 0, -1, 0, 1 };
        static int[] allowed_move_col = { 1, 0, -1, 0 };
        const int max_moves = 4;
        


        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            if (mazeTraversal(xStart, yStart, 'X'))
                Print(maze);
            else
                Console.WriteLine("No Result");


            //Do work needed to use mazeTraversal recursive call and solve the maze.
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        /// 
        //bool method used to check for possible moves
        private bool mazeTraversal(int prev_row, int prev_col, char x_mark)
        {
            for (int i = 0; i < max_moves; i++)
            {
                int col = prev_col + allowed_move_col[i];
                int row = prev_row + allowed_move_row[i];
                if (col < 0 || col >= maze_size)
                    continue;
                if (row < 0 || row >= maze_size)
                    continue;
                //had to change the ending point in the maze to an E so it knows when to end. Couldnt figure out how to use the value of an array index.
                if (maze[row, col] == 'E')
                {
                    maze[row, col] = x_mark;
                    return true;
                }
                if (maze[row, col] != '.')
                    continue;
                if (maze[row, col] == 'X')
                {
                    maze[row, col] = '0';
                    continue;
                }

                maze[row, col] = x_mark;

                if (mazeTraversal(row, col, x_mark))
                    return true;
                else maze[row, col] = '0';
            }
            return false;
        }
            //Implement maze traversal recursive call        
        //method used to print maze
        public void Print(char[,] maze)
        {
            Console.WriteLine();
            for (int i = 0; i < maze.GetLength(0); i++)                
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(" " + string.Format("{0,3}", maze[i, j] + " "));
                }
                Console.WriteLine();
                Console.WriteLine();
            }            
        }
    }
}
