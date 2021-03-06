﻿namespace SearchAlgoritmLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ex1.Isercher{T}" />
    public abstract class Searcher<T> : Isercher<T>
    {
        /// <summary>
        /// The evaluated nodes
        /// </summary>
        protected int evaluatedNodes;
        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{T}"/> class.
        /// </summary>
        public Searcher()
        {
            evaluatedNodes = 0;
        }
        //ISearcher’s methods:
        /// <summary>
        /// Gets the number of nodes evaluated.
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        /// <summary>
        /// Searches the specified isearchable.
        /// </summary>
        /// <param name="isearchable">The isearchable.</param>
        /// <returns></returns>
        public abstract Solution<T> Search(ISearchable<T> isearchable);

        /// <summary>
        /// Backs the trace.
        /// </summary>
        /// <param name="init">The initialize.</param>
        /// <param name="goal">The goal.</param>
        /// <returns></returns>
        public Solution<T> BackTrace(State<T> init, State<T> goal, int evaluatedNodes)
        {
            Solution<T> solution = new Solution<T>(evaluatedNodes);
            while (!goal.Equals(init))
            {
                solution.Add(goal);
                goal = goal.CameFrom;
            }
            //add the initial state
            solution.Add(goal);
            return solution;
        }

    }
}