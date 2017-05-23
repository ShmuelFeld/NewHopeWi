using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
        public override void connect(string command)
        {
            client = new TcpClient();
            client.Connect(ep);
            bool isExecuted = true;
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            {
                string feedback = "";
                while (!endOfCommunication)
                {
                    feedback = "";
                    writer.WriteLine(command);
                    writer.Flush();
                    while (true)
                    {
                        feedback += reader.ReadLine();
                        if (reader.Peek() == '@')
                        {
                            feedback.TrimEnd('\n');
                            this.endOfCommunication = true;
                            break;
                        }
                    }
                    reader.ReadLine();
                    client.Close();
                }
                stream.Dispose();
                writer.Dispose();
                reader.Dispose();
                FromJSON(feedback);

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
        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
   
}

