// Type: X.RopamNeo.Lib.Model.BadFrameException

using System;

namespace X.RopamNeo.Lib.Model
{
    public class BadFrameException : Exception
    {
        public BadFrameException()
        {
        }

        public BadFrameException(string message)
          : base(message)
        {
        }

        public BadFrameException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}