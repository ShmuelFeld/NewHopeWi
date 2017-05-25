using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// the multiPlaerModel interface
    /// </summary>
    interface IMultiPlayerModel
    {
        /// <summary>
        /// Gets or sets the list of games.
        /// </summary>
        /// <value>
        /// The list of games.
        /// </value>
        List<string> ListOfGames { get; set; }
        /// <summary>
        /// Connects the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        string connect(string command);
    }
}
