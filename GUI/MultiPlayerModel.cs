using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    class MultiPlayerModel : Model
    {
        /// <summary>
        /// The client
        /// </summary>
        private TcpClient client;
        /// <summary>
        /// The end of communication
        /// </summary>
        private bool endOfCommunication;
        /// <summary>
        /// The games
        /// </summary>
        private List<string> games;
        /// <summary>
        /// The ep
        /// </summary>
        IPEndPoint ep;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerModel"/> class.
        /// </summary>
        public MultiPlayerModel()
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            this.endOfCommunication = false;
        }
        /// <summary>
        /// Saves the settings.
        /// </summary>
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

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
        public override void connect(string command)
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
                FromJSON(feedback);
                return;
            }
        }
        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="str">The string.</param>
        private void FromJSON(string str)
        {
            JArray array = JArray.Parse(str);
            FromStringToList(array);
            
        }
        /// <summary>
        /// Froms the string to list.
        /// </summary>
        /// <param name="array">The array.</param>
        private void FromStringToList(JArray array)
        {
            List<string> list = new List<string>();
            foreach (string item in array)
            {
                list.Add(item);
            }
            ListOfGames = list;
        }
        /// <summary>
        /// Gets or sets the list of games.
        /// </summary>
        /// <value>
        /// The list of games.
        /// </value>
        public List<string> ListOfGames
        {
            get
            {
                return games;
            }
            set
            {
                games = value;
                NotifyPropertyChanged("ListOfGames");
            }
        }
        /// <summary>
        /// Gets or sets the maze cols.
        /// </summary>
        /// <value>
        /// The maze cols.
        /// </value>
        public int MazeCols
        {
            get { return Properties.Settings.Default.MazeCols; }
            set { Properties.Settings.Default.MazeCols = value; }
        }
        /// <summary>
        /// Gets or sets the maze rows.
        /// </summary>
        /// <value>
        /// The maze rows.
        /// </value>
        public int MazeRows
        {
            get { return Properties.Settings.Default.MazeRows; }
            set { Properties.Settings.Default.MazeRows = value; }
        }
        /// <summary>
        /// Gets or sets the name of the maze.
        /// </summary>
        /// <value>
        /// The name of the maze.
        /// </value>
        public string MazeName
        {
            get { return Properties.Settings.Default.MazeName; }
            set { Properties.Settings.Default.MazeName = value; }
        }
    }
   
}

