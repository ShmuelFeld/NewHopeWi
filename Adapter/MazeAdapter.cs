using MazeLib;
using SearchAlgoritmLib;
using System.Collections.Generic;

namespace Adapter
{
    /// <summary>
    /// this class create adapter from a maze to search problem
    /// </summary>
    /// <seealso cref="ex1.ISearchable{MazeLib.Position}" />
    public class MazeAdapter : ISearchable<Position>
    {
        /// <summary>
        /// The maze
        /// </summary>
        private Maze maze;
        /// <summary>
        /// The entery point to the maze
        /// </summary>
        private Position initialPosition;
        /// <summary>
        /// The goal point of the maze.
        /// </summary>
        private Position goalPosition;
        private int numberOfNodesEvaluated;
        /// <summary>
        /// Initializes a new instance of the <see cref="IsearchableMaze"/> class.
        /// </summary>
        /// <param name="maze">The maze.</param>
        public MazeAdapter(Maze maze)
        {
            this.maze = maze;
            this.initialPosition = maze.InitialPos;
            this.goalPosition = maze.GoalPos;
        }
        /// <summary>
        /// Gets all possible states from a specific position.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public Dictionary<State<Position>, double> GetAllPossibleStates(State<Position> s)
        {
            int col = s.Instance.Col;
            int row = s.Instance.Row;
            Dictionary<State<Position>, double> neighbors = new Dictionary<State<Position>, double>();
            Position left = new Position(row, col - 1);
            if (IsValid(left))
            {
                this.numberOfNodesEvaluated++;
                neighbors.Add(new State<Position>(left), 1);
            }
            Position up = new Position(row - 1, col);
            if (IsValid(up))
            {
                this.numberOfNodesEvaluated++;
                neighbors.Add(new State<Position>(up), 1);
            }
            Position right = new Position(row, col + 1);
            if (IsValid(right))
            {
                this.numberOfNodesEvaluated++;
                neighbors.Add(new State<Position>(right), 1);
            }
            Position down = new Position(row + 1, col);
            if (IsValid(down))
            {
                this.numberOfNodesEvaluated++;
                neighbors.Add(new State<Position>(down), 1);
            }
            return neighbors;
        }
        /// <summary>
        /// Determines whether the specified position p is valid.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>
        ///   <c>true</c> if the specified p is valid; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValid(Position p)
        {
            if (p.Col >= this.maze.Cols || p.Col < 0) { return false; }
            if (p.Row >= this.maze.Rows || p.Row < 0) { return false; }
            if (maze[p.Row, p.Col] == CellType.Wall) { return false; }
            return true;
        }
        /// <summary>
        /// Gets the state of the goal.
        /// </summary>
        /// <returns></returns>
        State<Position> ISearchable<Position>.GetGoalState()
        {
            return new State<Position>(this.goalPosition);
        }

        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <returns></returns>
        State<Position> ISearchable<Position>.GetInitialState()
        {
            return new State<Position>(this.initialPosition);
        }
        public int GetEvauatedNodes()
        {
            return this.numberOfNodesEvaluated;
        }
    }
}
