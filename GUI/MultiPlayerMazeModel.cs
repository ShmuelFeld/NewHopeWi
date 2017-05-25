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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GUI.Model" />
    class MultiPlayerMazeModel : Model
    {
        /// <summary>
        /// Gets or sets the maze vm.
        /// </summary>
        /// <value>
        /// The maze vm.
        /// </value>
        public Maze MazeVM
        {
            get { return maze; }
            set
            {
                maze = value;
            }
        }
        /// <summary>
        /// The movement
        /// </summary>
        private string movement;
        /// <summary>
        /// The move
        /// </summary>
        public EventHandler Move;
        /// <summary>
        /// The close eve
        /// </summary>
        public EventHandler CloseEve;
        /// <summary>
        /// Gets or sets the movement.
        /// </summary>
        /// <value>
        /// The movement.
        /// </value>
        public string Movement {
            get
            { return movement; }
            set
            {
                this.movement = value;
                this.Move(this, new EventArgs());
            }
        }
        /// <summary>
        /// The maze
        /// </summary>
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
        private bool close;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerMazeModel"/> class.
        /// </summary>
        public MultiPlayerMazeModel()
        {
            ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
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
        /// <summary>
        /// Connections the error message.
        /// </summary>
        private void ConnectionErrorMessage()
        {
            string message = "Error connecting to server, please return to main window";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
        }
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Connects the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
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
        /// <summary>
        /// Listens the task.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void ListenTask(StreamReader reader)
        {

            Task listenTask = new Task(() =>
            {
                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream);
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
                    }
                    if (feedback.Contains("other") || feedback.Contains("@"))
                    {
                        feedback = "";
                    }
                    if (feedback == "close your server") 
                    {
                        if(CloseEve != null)
                        {
                            this.CloseEve(this, new EventArgs());
                        }
                        writer.WriteLine(feedback);
                        writer.Flush();
                        close = true;
                        close = true;
                    }
                }
                
            });
            listenTask.Start();

        }

        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="str">The string.</param>
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
