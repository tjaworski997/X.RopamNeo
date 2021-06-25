// Type: X.RopamNeo.Lib.Model.NotLoggedException

using System;

namespace X.RopamNeo.Lib.Model
{
    public class NotLoggedException : Exception
    {
        public NotLoggedException()
        {
        }

        public NotLoggedException(string message)
          : base(message)
        {
        }

        public NotLoggedException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}