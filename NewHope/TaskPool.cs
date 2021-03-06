﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHope
{
    /// <summary>
    /// holds pool of tasks.
    /// </summary>
    class TaskPool
    {
        /// <summary>
        /// The tasks
        /// </summary>
        private List<Task> tasks;
        /// <summary>
        /// The stop
        /// </summary>
        private bool stop;
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskPool"/> class.
        /// </summary>
        public TaskPool()
        {
            tasks = new List<Task>();
            stop = false;
            DoTasks();
        }
        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="t">The t.</param>
        public void AddTask(Task t) { tasks.Add(t); }
        /// <summary>
        /// Does the tasks.
        /// </summary>
        public void DoTasks()
        {
            while (!stop)
            {
                if (tasks.Any())
                {
                    Task t = tasks.First();
                    tasks.Remove(t);
                    t.Start();
                }
            }
        }
        /// <summary>
        /// Terminates this instance.
        /// </summary>
        public void Terminate()
        {
            stop = true;
        }
    }
}
