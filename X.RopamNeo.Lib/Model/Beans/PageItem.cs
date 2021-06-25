// Type: X.RopamNeo.Lib.Model.Beans.PageItem

using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class PageItem
    {
        public int Id { get; set; }

        public int Site { get; set; }

        public int Place { get; set; }

        public int No { get; set; }

        public string Name { get; set; }

        public byte ColumnCount { get; set; }

        public byte RowCount { get; set; }

        public List<MenuItem> Items { get; set; }

        public enum Places : byte
        {
            Main,
            SmsControl,
            Macro,
            Launcher,
        }
    }
}