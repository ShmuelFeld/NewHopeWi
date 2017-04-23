using MazeGeneratorLib;
using MazeLib;
using SearchAlgoritmLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            compareSolvers();
        }
        /// <summary>
        /// crete test for search algorithm lib dll
        /// </summary>
        static void compareSolvers()
        {
            DFSMazeGenerator dfsMaze = new DFSMazeGenerator();
            Maze maze = dfsMaze.Generate(500, 500);
            Console.WriteLine(maze.ToString());
            MazeAdapter ism = new MazeAdapter(maze);
            BFS<Position> bfs = new BFS<Position>();
            Solution<Position> sol = bfs.Search(ism);

            Console.WriteLine(ism.GetEvauatedNodes());
            MazeAdapter ma = new MazeAdapter(maze);
            DFS<Position> dfs = new DFS<Position>();
            dfs.Search(ma);
            Console.WriteLine(ma.GetEvauatedNodes());
        }
    }
}
