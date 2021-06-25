using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.RopamNeo.Service
{
    public static class Log
    {
        public static NLog.Logger L = NLog.LogManager.GetCurrentClassLogger();
    }
}