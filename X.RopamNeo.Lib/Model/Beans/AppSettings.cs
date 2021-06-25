// Type: X.RopamNeo.Lib.Model.Beans.AppSettings

using System;
using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class AppSettings
    {
        public DateTime CreateTime { get; set; }

        public string Key { get; set; }

        public List<Site> Sites { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}