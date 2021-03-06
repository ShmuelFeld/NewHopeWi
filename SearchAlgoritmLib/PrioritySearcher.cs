﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmLib
{
    /// <summary>
    /// this abstract class defins the algorithms that using priority queues.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ex1.Searcher{T}" />
    public abstract class PrioritySearcher<T> : Searcher<T>
    {
        /// <summary>
        /// everey state that just got discoverd.
        /// </summary>
        protected Priority_Queue.SimplePriorityQueue<State<T>> open;
        /// <summary>
        /// Initializes a new instance of the <see cref="PrioritySearcher{T}"/> class.
        /// </summary>
        public PrioritySearcher()
        {
            open = new Priority_Queue.SimplePriorityQueue<State<T>>();
        }
        /// <summary>
        /// Pops from the open list.
        /// </summary>
        /// <returns></returns>
        protected State<T> PopOpenList()
        {
            evaluatedNodes++;
            return open.Dequeue();
        }
        // a property of openList
        /// <summary>
        /// Gets the size of the open list.
        /// </summary>
        /// <value>
        /// The size of the open list.
        /// </value>
        public int OpenListSize
        { // it is a read-only property :)
            get { return open.Count; }
        }
        //ISearcher’s methods:
        public virtual int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        /// <summary>
        /// Adds to open list.
        /// </summary>
        /// <param name="s">The s.</param>
        public void AddToOpenList(State<T> s)
        {
            open.Enqueue(s, (float)s.CostOfState);
        }

    }
}
