// Type: X.RopamNeo.Lib.Model.ParseHardwareException

using System;

namespace X.RopamNeo.Lib.Model
{
    public class ParseHardwareException : Exception
    {
        public ParseHardwareException()
        {
        }

        public ParseHardwareException(string message)
          : base(message)
        {
        }

        public ParseHardwareException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}