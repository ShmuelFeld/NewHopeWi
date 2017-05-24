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
using System.Windows.Forms;

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
        public EventHandler CloseEve;
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
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            this.endOfCommunication = false;
            this.close = false;
            client = new TcpClient();
            try
            {
                client.Connect(ep);
            }
            catch (ArgumentNullException e)
            {
                ConnectionErrorMessage();
            }
            catch (ArgumentOutOfRangeException e)
            {
                ConnectionErrorMessage();
            }
            catch(SocketException e)
            {
                ConnectionErrorMessage();
            }
        }
        private void ConnectionErrorMessage()
        {
            string message = "Error connecting to server, please return to main window";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
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
                if (!command.Contains("play") && !command.Contains("close"))
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
                if (command.Contains("close"))
                {
                    endOfCommunication = true;
                }
                return;
            }
            return;

        }
        private void ListenTask(StreamReader reader)
        {

            Task listenTask = new Task(() =>
            {
                bool close = false;
                string feedback ="";
                while (!close)
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
                    if (feedback == "close") //contains?
                    {
                        if(CloseEve != null)
                        {
                            this.CloseEve(this, new EventArgs());
                        }
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
