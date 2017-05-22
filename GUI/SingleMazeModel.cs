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
    class SingleMazeModel : ViewModel
    {
        public Maze MazeVM
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("maze");
            }
        }
        public string SolveVM
        {
            get { return solveString; }
            set
            {
                solveString = value;
                NotifyPropertyChanged("solve");
            }
        }
        private string solveString;

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
        public SingleMazeModel()
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            client = new TcpClient();
            client.Connect(ep);
            this.endOfCommunication = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void connect(string command)
        {
            client = new TcpClient();
            client.Connect(ep);
            bool isExecuted = true;
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            {
                while (!endOfCommunication)
                {
                    bool isMulti = false;

                    isExecuted = true;
                    if (!client.Connected)
                    {
                        client = new TcpClient();
                        client.Connect(ep);
                        stream = client.GetStream();
                        reader = new StreamReader(stream);
                        writer = new StreamWriter(stream);
                    }
                    if ((command.Contains("start")) || (command.Contains("join")))
                    {
                        isMulti = true;
                    }
                    writer.WriteLine(command);
                    writer.Flush();
                    string feedback = "";
                    while (true)
                    {
                        feedback += reader.ReadLine();
                        if (reader.Peek() == '@')
                        {
                            // Console.WriteLine("{0}", feedback);
                            feedback.TrimEnd('\n');
                            break;
                        }
                        //  Console.WriteLine("{0}", feedback);
                    }
                    reader.ReadLine();
                    feedback += "\n";
                    if (command.Contains("generate"))
                    {
                        this.MazeVM = Maze.FromJSON(feedback);
                        return;
                    }
                    else if (command.Contains("solve"))
                    {
                        FromJSON(feedback);
                        return;
                    }
                    if (isMulti)
                    {
                        bool close = false;
                        Task sendTask = new Task(() =>
                        {
                            while (!close)
                            {
                                command = Console.ReadLine();
                                if (command.Contains("close")) { close = true; }
                                writer.WriteLine(command);
                                writer.Flush();
                            }
                        });
                        Task listenTask = new Task(() =>
                        {
                            while (!close)
                            {
                                while (true)
                                {
                                    feedback = reader.ReadLine();
                                    if (reader.Peek() == '@')
                                    {
                                        {
                                            if ((feedback != "close") && (feedback != "close your server"))
                                            {
                                                Console.WriteLine("{0}", feedback);
                                            }
                                        }
                                        feedback.TrimEnd('\n');
                                        break;
                                    }
                                    Console.WriteLine("{0}", feedback);
                                }
                                reader.ReadLine();
                                if (feedback == "close")
                                {
                                    close = true;
                                }
                                else if (feedback == "close your server")
                                {
                                    writer.WriteLine(feedback);
                                    writer.Flush();
                                    close = true;
                                    isExecuted = false;
                                }
                            }
                        });
                        sendTask.Start();
                        listenTask.Start();
                        sendTask.Wait();
                        listenTask.Wait();
                    }
                    client.Close();
                }
                stream.Dispose();
                writer.Dispose();
                reader.Dispose();
            }
        }
        private void FromJSON(string str)
        {
            JObject solveObj = JObject.Parse(str);
            this.solveString = (string)solveObj["solution"];
        }
    }
}