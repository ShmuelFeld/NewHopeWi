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
    class MultiPlayerModel : Model
    {
        private TcpClient client;
        private bool endOfCommunication;
        private List<string> games;
        IPEndPoint ep;
        public MultiPlayerModel()
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            this.endOfCommunication = false;
        }
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        private void ConnectionErrorMessage()
        {
            string message = "Error connecting to server, please return to main window";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
        }

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
        private void FromJSON(string str)
        {
            JArray array = JArray.Parse(str);
            FromStringToList(array);
            
        }
        private void FromStringToList(JArray array)
        {
            List<string> list = new List<string>();
            foreach (string item in array)
            {
                list.Add(item);
            }
            ListOfGames = list;
        }
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
        public int MazeCols
        {
            get { return Properties.Settings.Default.MazeCols; }
            set { Properties.Settings.Default.MazeCols = value; }
        }
        public int MazeRows
        {
            get { return Properties.Settings.Default.MazeRows; }
            set { Properties.Settings.Default.MazeRows = value; }
        }
        public string MazeName
        {
            get { return Properties.Settings.Default.MazeName; }
            set { Properties.Settings.Default.MazeName = value; }
        }
        //public void SaveSettings()
        //{
        //    Properties.Settings.Default.Save();
        //}
    }
   
}

