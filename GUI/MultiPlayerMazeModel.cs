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
    class MultiPlayerMazeModel : Model
    {
        public Maze MazeVM
        {
            get { return maze; }
            set
            {
                maze = value;
            }
        }
        private string movement;
        public EventHandler Move;
        public string Movement {
            get
            { return movement; }
            set
            {
                this.movement = value;
                this.Move(this, new EventArgs());
            }
        }
        private Maze maze;
        /// <summary>
        /// The communication protocol.
        /// </summary>
        private TcpClient client;
        /// <summary>
        /// flag for end of communication.
        /// </summary>
        private bool endOfCommunication;
        /// <summary>
        /// The IPEndPoint.
        /// </summary>
        IPEndPoint ep;
        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// 
        private bool close;
        public MultiPlayerMazeModel()
        {
            ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
            this.endOfCommunication = false;
            this.close = false;
            client = new TcpClient();
            client.Connect(ep);
            // connect("0");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public override void connect(string command)
        {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            while (!endOfCommunication)
            {
                writer.WriteLine(command);
                writer.Flush();
                string feedback = "";
                if (!command.Contains("play"))
                {
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
                    if (command.Contains("start") || command.Contains("join"))
                    {
                        MazeVM = Maze.FromJSON(feedback);
                        ListenTask(reader);
                        return;
                    }
                }
                return;
            }

        }
        private void ListenTask(StreamReader reader)
        {

            Task listenTask = new Task(() =>
            {
                string feedback ="";
                while (true)
                {
                    feedback += reader.ReadLine();
                    if (reader.Peek() == '@' && (feedback.Contains("up") || feedback.Contains("down")
                    || feedback.Contains("left") || feedback.Contains("right")))
                    {
                        {
                            if ((feedback != "close") && (feedback != "close your server"))
                            {
                                FromJson(feedback);
                                feedback = "";
                            }
                        }
                        //break;
                    }
                    //reader.ReadLine();
                    if (feedback.Contains("other") || feedback.Contains("@"))
                    {
                        feedback = "";
                    }
                    if (feedback == "close")
                    {
                        close = true;
                    }
                }
                
            });
            listenTask.Start();
        }
        private void FromJson(string str)
        {
            string ret = "";
            JObject moveObj = JObject.Parse(str); ;
            ret += moveObj["Name"];
            ret += " ";
            ret += moveObj["Direction"];
            string[] arg = ret.Split(' ');
            Movement = arg[1];
        }

    }
}
