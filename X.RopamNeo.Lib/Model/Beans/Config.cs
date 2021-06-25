// Type: X.RopamNeo.Lib.Model.Beans.Config

using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Config
    {
        public bool canedit { get; set; }

        public List<RollerShutter> shutters { get; set; }

        public List<RollerShutterGroup> shutterGroups { get; set; }

        public string phone { get; set; }

        public string deviceID { get; set; }

        public List<string> zones { get; set; }

        public List<string> inputs { get; set; }

        public List<string> outputs { get; set; }

        public List<string> wiredsens { get; set; }

        public List<string> temps { get; set; }

        public string wrlsens
        {
            set
            {
                if (value == null)
                    return;
                this.wirelessSensors = new List<string>((IEnumerable<string>)value.Split('\n'));
            }
        }

        public List<string> wirelessSensors { get; set; }

        public string analog { get; set; }

        public bool th_en { get; set; }

        public string th_name { get; set; }

        public int th_isens { get; set; }

        public int th_esens { get; set; }

        public uint inp_s1
        {
            set
            {
                this.Zone1Inputs = new List<bool>((IEnumerable<bool>)new bool[32]);
                for (int index = 0; index < 32; ++index)
                    this.Zone1Inputs[index] = ((ulong)value & (ulong)(1 << index)) > 0UL;
            }
        }

        public uint inp_s2
        {
            set
            {
                this.Zone2Inputs = new List<bool>((IEnumerable<bool>)new bool[32]);
                for (int index = 0; index < 32; ++index)
                    this.Zone2Inputs[index] = ((ulong)value & (ulong)(1 << index)) > 0UL;
            }
        }

        public uint out_s1
        {
            set
            {
                this.Zone1Outputs = new List<bool>((IEnumerable<bool>)new bool[32]);
                for (int index = 0; index < 32; ++index)
                    this.Zone1Outputs[index] = ((ulong)value & (ulong)(1 << index)) > 0UL;
            }
        }

        public uint out_s2
        {
            set
            {
                this.Zone2Outputs = new List<bool>((IEnumerable<bool>)new bool[32]);
                for (int index = 0; index < 32; ++index)
                    this.Zone2Outputs[index] = ((ulong)value & (ulong)(1 << index)) > 0UL;
            }
        }

        public List<bool> Zone1Inputs { get; set; }

        public List<bool> Zone2Inputs { get; set; }

        public List<bool> Zone1Outputs { get; set; }

        public List<bool> Zone2Outputs { get; set; }

        public List<Widget> widgets { get; set; }
    }
}