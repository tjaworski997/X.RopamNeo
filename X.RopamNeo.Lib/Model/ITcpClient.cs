// Type: X.RopamNeo.Lib.Model.ITcpClient

namespace X.RopamNeo.Lib.Model
{
    internal interface ITcpClient
    {
        int ConnectionTimeout { get; set; }

        int ReceiveTimeout { get; set; }

        int Available { get; }

        int SendTimeout { get; set; }

        void ClearReadBuffer();

        void Connect(string host, int port);

        void Disconnect();

        void Write(byte[] data, int idx, int len);

        void Flush();

        void Read(byte[] buffer, int idx, int len);

        void WriteByte(byte data);
    }
}