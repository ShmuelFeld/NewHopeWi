using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            compareSolvers();
        }
        static void compareSolvers()
        {
            DFSMazeGenerator dfsMaze = new DFSMazeGenerator();
            Maze maze = dfsMaze.Generate(500, 500);
            Console.WriteLine(maze.ToString());
            IsearchableMaze ism = new IsearchableMaze(maze);
            BFS<Position> bfs = new BFS<Position>();
        }
    }
}
