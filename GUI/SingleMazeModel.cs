using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class SingleMazeModel : Model
    {
        public Maze MazeVM
        {
            get { return maze; }
            set
            {
                maze = value;
            }
        }
        public string SolveVM
        {
            get { return solveString; }
            set
            {
                solveString = value;
                NotifyPropertyChanged("SolveVM");
            }
        }
        private string solveString;
        private Maze maze;
        /// <summary>
        /// The communication protocol.
        /// </summary>
        private TcpClient client;
        /// <summary>
        /// The IPEndPoint.
        /// </summary>
        IPEndPoint ep;
        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// 
        public SingleMazeModel()
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void connect(string command)
        {
            
            client = new TcpClient();
            client.Connect(ep);

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(command);
                writer.Flush();
                string feedback = "";
                while (true)
                {
                    feedback += reader.ReadLine();
                    if (reader.Peek() == '@')
                    {
                        feedback.TrimEnd('\n');
                        break;
                    }
                }
                reader.ReadLine();
                feedback += "\n";
                if (command.Contains("generate"))
                {
                    this.MazeVM = Maze.FromJSON(feedback);
                }
                else if (command.Contains("solve"))
                {
                    FromJSON(feedback);
                }
            }
            client.Close();
        }
        private void FromJSON(string str)
        {
            JObject solveObj = JObject.Parse(str);
            this.SolveVM = (string)solveObj["solution"];
        }
    }
}