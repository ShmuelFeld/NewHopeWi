using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmLib
{

    /// <summary>
    /// by given an isearchable object the algorithm finds the shortest way from a to b using BFS algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BFS<T> : PrioritySearcher<T>
    {
        /// <summary>
        /// all the states that were evaluated.
        /// </summary>
        private HashSet<State<T>> closed = new HashSet<State<T>>();
        /// <summary>
        /// Searches the specified isearchable.
        /// </summary>
        /// <param name="isearchable">The isearchable.</param>
        /// <returns></returns>
        public override Solution<T> Search(ISearchable<T> isearchable)
        {
            AddToOpenList(isearchable.GetInitialState()); // inherited from Searcher

            while (OpenListSize > 0)
            {
                State<T> n = PopOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(isearchable.GetGoalState()))
                    return BackTrace(isearchable.GetInitialState(), n, isearchable.GetEvauatedNodes()); // private method, back traces through the parents
                                                                                                        // calling the delegated method, returns a list of states with n as a parent
                Dictionary<State<T>, double> succerssors = isearchable.GetAllPossibleStates(n);
                foreach (KeyValuePair<State<T>, double> s in succerssors)
                {
                    if (!(closed.Contains(s.Key)) && !(open.Contains(s.Key)))
                    {
                        s.Key.CameFrom = n;
                        //s.CameFrom = n; // already done by getSuccessors
                        s.Key.CostOfState = s.Value;
                        AddToOpenList(s.Key);
                    }
                    else if (open.Contains(s.Key))
                    {
                        //relief
                        if ((s.Value + n.CostOfState) < s.Key.CostOfState)
                        {
                            s.Key.CameFrom = n;
                            s.Key.CostOfState = s.Value + n.CostOfState;
                            open.UpdatePriority(s.Key, (float)(s.Key.CostOfState));
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// returns the path from a to b.
        /// </summary>
        /// <param name="isearchable">The isearchable.</param>
        /// <returns></returns>
        private Solution<T> BackTrace(ISearchable<T> isearchable)
        {
            Solution<T> solution = new Solution<T>(isearchable.GetEvauatedNodes());
            State<T> state = isearchable.GetGoalState();
            while (!state.Equals(isearchable.GetInitialState()))
            {
                solution.Add(state);
                state = state.CameFrom;
            }
            //add the initial state
            solution.Add(state);
            return solution;
        }
    }
}

