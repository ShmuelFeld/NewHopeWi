﻿using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelCL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <returns></returns>
        Maze GenerateMaze(string name, int rows, int cols);
        /// <summary>
        /// Solves the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns></returns>
        MazeSolution SolveMaze(string name, int algorithm);
        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="tcp">The TCP.</param>
        /// <returns></returns>
        Maze StartGame(string name, int rows, int cols, string tcp);
        /// <summary>
        /// Gets the list of available games.
        /// </summary>
        /// <returns></returns>
        List<Maze> GetListOfAvailableGames();
        /// <summary>
        /// Joins the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tcp">The TCP.</param>
        /// <returns></returns>
        Maze Join(string name, string tcp);
        /// <summary>
        /// Plays the specified move.
        /// </summary>
        /// <param name="move">The move.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        MultiPlayerGame Play(string move, string client);
        /// <summary>
        /// Closes the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        string Close(string client);
    }
}
