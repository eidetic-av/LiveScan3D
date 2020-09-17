﻿using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System;

namespace KinectServer
{
    public class TransferServer
    {
        public List<float> lVertices = new List<float>();
        public List<byte> lColors = new List<byte>();

        public bool useSpout = true;
        public static int spoutTransferThreads = 1;

        TcpListener oListener;
        List<TransferSocket> lClientSockets = new List<TransferSocket>();

        object oClientSocketLock = new object();
        bool bServerRunning = false;

        SpoutManager spoutManager = new SpoutManager();

        ~TransferServer()
        {
            StopServer();
        }

        public void StartServer()
        {
            if (!bServerRunning)
            {
                oListener = new TcpListener(IPAddress.Any, 48002);
                oListener.Start();

                bServerRunning = true;
                Thread listeningThread = new Thread(this.ListeningWorker);
                listeningThread.Start();
                Thread receivingThread = new Thread(this.ReceivingWorker);
                receivingThread.Start();
            }
        }

        public void StopServer()
        {
            if (bServerRunning)
            {
                bServerRunning = false;

                oListener.Stop();
                lock (oClientSocketLock)
                    lClientSockets.Clear();
            }
        }

        private void ListeningWorker()
        {
            while (bServerRunning)
            {
                try
                {
                    TcpClient newClient = oListener.AcceptTcpClient();

                    lock (oClientSocketLock)
                    {
                        lClientSockets.Add(new TransferSocket(newClient));
                    }
                }
                catch (SocketException)
                {
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        private void ReceivingWorker()
        {
            System.Timers.Timer checkConnectionTimer = new System.Timers.Timer();
            checkConnectionTimer.Interval = 1000;

            checkConnectionTimer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
            {
                lock (oClientSocketLock)
                {
                    for (int i = 0; i < lClientSockets.Count; i++)
                    {                      
                        if (!lClientSockets[i].SocketConnected())
                        {
                            lClientSockets.RemoveAt(i);
                            i--;
                        }
                    }
                }
            };

            checkConnectionTimer.Start();

            while (bServerRunning)
            {
                lock (oClientSocketLock)
                {
                    if (useSpout)
                    {
                        lock (lVertices)
                        {
                            spoutManager.SendFrame(lVertices, lColors);
                            continue;
                        }
                    }

                    for (int i = 0; i < lClientSockets.Count; i++)
                    {
                        Console.WriteLine("Send Frame: " + i);
                        byte[] buffer = lClientSockets[i].Receive(1);

                        while (buffer.Length != 0)
                        {
                            if (buffer[0] == 0)
                            {
                                lock (lVertices)
                                {
                                    lClientSockets[i].SendFrame(lVertices, lColors);
                                }
                            }

                            buffer = lClientSockets[i].Receive(1);
                        }
                    }
                }

                Thread.Sleep(10);
            }

            checkConnectionTimer.Stop();
        }
    }
}
