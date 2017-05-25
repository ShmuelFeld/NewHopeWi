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
    class SingleMazeModel : Model
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
        /// Gets or sets the solve vm.
        /// </summary>
        /// <value>
        /// The solve vm.
        /// </value>
        public string SolveVM
        {
            get { return solveString; }
            set
            {
                solveString = value;
                NotifyPropertyChanged("SolveVM");
            }
        }
        /// <summary>
        /// The solve string
        /// </summary>
        private string solveString;
        /// <summary>
        /// The maze
        /// </summary>
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
        public SingleMazeModel()
        {
            ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
        }

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Connections the error message.
        /// </summary>
        private void ConnectionErrorMessage()
        {
            string message = "Error connecting to server, please return to main window";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
        }

        /// <summary>
        /// Connects the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public override void sendToServer(string command)
        {
            client = new TcpClient();
            try
            {
                client.Connect(ep);
            }
            catch (ArgumentNullException e)
            {
                ConnectionErrorMessage();
                ConnectionError.isError = true;
                return;
            }
            catch (ArgumentOutOfRangeException e)
            {
                ConnectionErrorMessage();
                ConnectionError.isError = true;
                return;
            }
            catch (SocketException e)
            {
                ConnectionErrorMessage();
                ConnectionError.isError = true;
                return;
            }

            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
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
            return;
        }
        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="str">The string.</param>
        private void FromJSON(string str)
        {
            JObject solveObj = JObject.Parse(str);
            this.SolveVM = (string)solveObj["solution"];
        }
    }
}