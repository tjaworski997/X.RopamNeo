// Type: X.RopamNeo.Lib.Model.Beans.Parameter

using System;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Parameter
    {
        public string Key { get; set; }

        public int Vali { get; set; }

        public string Vals { get; set; }

        public DateTime Vald { get; set; }

        public Parameter Clone() => new Parameter()
        {
            Key = this.Key,
            Vals = this.Vals,
            Vali = this.Vali,
            Vald = this.Vald
        };
    }
}