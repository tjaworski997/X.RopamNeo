// Type: X.RopamNeo.Lib.Model.TcpConnectException

using System;

namespace X.RopamNeo.Lib.Model
{
    public class TcpConnectException : Exception
    {
        public TcpConnectException()
        {
        }

        public TcpConnectException(string message)
          : base(message)
        {
        }

        public TcpConnectException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}