using X.RopamNeo.Lib.Model;
using System;
using System.Net.Sockets;

namespace X.RopamNeo.Lib.Model
{
    public class TcpClientStreamSocket : ITcpClient
    {
        public static int connectionTimeout = 2000;
        private TcpClient client;

        public int Available => this.client.Available;

        public int ConnectionTimeout
        {
            get => TcpClientStreamSocket.connectionTimeout;
            set => TcpClientStreamSocket.connectionTimeout = value;
        }

        public int ReceiveTimeout
        {
            get => this.client.ReceiveTimeout;
            set => this.client.ReceiveTimeout = value;
        }

        public int SendTimeout
        {
            get => this.client.SendTimeout;
            set => this.client.SendTimeout = value;
        }

        public void ClearReadBuffer()
        {
            byte[] buffer = new byte[4096];
            NetworkStream stream = this.client.GetStream();
            while (stream.DataAvailable)
                stream.Read(buffer, 0, buffer.Length);
        }

        public void Connect(string host, int port)
        {
            this.Disconnect();
            Console.WriteLine(string.Format("Try connect {0}:{1} using IPV4", (object)host, (object)port));
            this.client = new TcpClient();
            this.client.BeginConnect(host, port, (AsyncCallback)null, (object)null).AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds((double)TcpClientStreamSocket.connectionTimeout));
            if (!this.client.Connected)
                throw new TimeoutException();
        }

        public void Disconnect()
        {
            if (this.client == null)
                return;
            try
            {
                this.Flush();
                this.client.Dispose();
            }
            catch (Exception ex)
            {
            }
            this.client = (TcpClient)null;
        }

        public void Flush() => this.client.GetStream().Flush();

        public void Read(byte[] buffer, int idx, int len)
        {
            int num1 = len;
            while (num1 > 0)
            {
                int num2 = this.client.GetStream().Read(buffer, idx + (len - num1), len - (len - num1));
                num1 -= num2;
                if (num2 == 0)
                    throw new SocketClosedException();
            }
        }

        public void Write(byte[] data, int idx, int len) => this.client.GetStream().Write(data, idx, len);

        public void WriteByte(byte data) => this.client.GetStream().WriteByte(data);
    }
}