// Type: X.RopamNeo.Lib.Model.ParseStatusException

using System;

namespace X.RopamNeo.Lib.Model
{
    public class ParseStatusException : Exception
    {
        public ParseStatusException()
        {
        }

        public ParseStatusException(string message)
          : base(message)
        {
        }

        public ParseStatusException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}