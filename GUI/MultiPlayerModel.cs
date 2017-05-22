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
    class MultiPlayerModel : IMultiPlayerModel
    {
        public List<string> ListOfGames
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        private TcpClient client;
        private bool endOfCommunication;
        IPEndPoint ep;
        public MultiPlayerModel()
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            client = new TcpClient();
            client.Connect(ep);
            this.endOfCommunication = false;
        }
        public void connect(string command)
        {
            bool isExecuted = true;
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            {
                while (!endOfCommunication)
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
                    client.Close();

                }
                stream.Dispose();
                writer.Dispose();
                reader.Dispose();
            }
        }
    }
}
}
