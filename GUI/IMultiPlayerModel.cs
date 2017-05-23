using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    interface IMultiPlayerModel
    {
        List<string> ListOfGames { get; set; }
        string connect(string command);
    }
}
