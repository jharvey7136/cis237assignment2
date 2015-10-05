using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {

        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int windowheight = 60;
            int windowwidth = 160;
            Console.BufferHeight = 100;
            Console.BufferWidth = 100;
            Console.SetWindowSize(windowwidth, windowheight);

            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { 
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', 'E' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            //made another maze to avoid transposed mazed already being solved
            char[,] maze1orig = 
            { 
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', 'E' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };



            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            mazeSolver.Print(maze1);
            Console.WriteLine("----------PRESS ANY KEY TO SOLVE MAZE----------");
            Console.ReadKey();

            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// </summary>
            /// 
            

            mazeSolver.SolveMaze(maze1, X_START, Y_START);
            Console.WriteLine("----------------- MAZE SOLVED------------------\n");
            Console.WriteLine("--------PRESS ANY KEY TO TRANSPOSE MAZE--------\n");
            Console.ReadKey();

            
            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1orig);
            mazeSolver.Print(maze2);

            Console.WriteLine("----PRESS ANY KEY TO SOLVE TRANSPOSED MAZE-----");
            
            Console.ReadKey();

            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);
            Console.WriteLine("-------------PRESS ANY KEY TO EXIT-------------");
            Console.ReadKey();
            Environment.Exit(0);

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        /// 
        //method to transpose the maze copy 
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            char[,] transposed = new char[mazeToTranspose.GetLength(0), mazeToTranspose.GetLength(1)];
            
            for (int i = 0; i < mazeToTranspose.GetLength(0); i++)
            {
                for (int j = 0; j < mazeToTranspose.GetLength(1); j++)
                {
                    transposed[j, i] = mazeToTranspose[i, j];
                }
            }
            return transposed;
            //Write code her to create a transposed maze.            
        }
    }
}
