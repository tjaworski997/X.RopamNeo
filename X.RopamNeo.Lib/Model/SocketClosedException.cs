// Type: X.RopamNeo.Lib.Model.SocketClosedException

using System;

namespace X.RopamNeo.Lib.Model
{
    public class SocketClosedException : Exception
    {
        public SocketClosedException()
        {
        }

        public SocketClosedException(string message)
          : base(message)
        {
        }

        public SocketClosedException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}