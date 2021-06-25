// Type: X.RopamNeo.Lib.Model.Beans.Command

using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Command
    {
        private string lang = "en";
        public bool ManualSend;

        public string Lang
        {
            get => this.lang;
            set => this.lang = value;
        }

        public string Key { get; set; }

        public Dictionary<string, string> Format { get; set; }

        public Dictionary<string, string> FormatShort { get; set; }

        public Dictionary<string, string> Description { get; set; }

        public Dictionary<string, string> Hint { get; set; }

        public override string ToString() => this.Description[this.Lang];

        public Command SetLang(string lang)
        {
            this.Lang = lang;
            return this;
        }
    }
}