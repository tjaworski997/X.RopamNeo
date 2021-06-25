// Type: X.RopamNeo.Lib.Model.Beans.LogItem

using System;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class LogItem : INotifyPropertyChanged
    {
        private int id;
        private DateTime time;
        private string place;
        private string message;
        private byte type = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public object Color { get; set; }

        public int Id
        {
            set
            {
                if (this.id == value)
                    return;
                this.id = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Id)));
            }
            get => this.id;
        }

        public DateTime Time
        {
            set
            {
                if (!(this.time != value))
                    return;
                this.time = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Time)));
            }
            get => this.time;
        }

        public string Place
        {
            set
            {
                if (!(this.place != value))
                    return;
                this.place = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Place)));
            }
            get => this.place;
        }

        public string Message
        {
            set
            {
                if (!(this.message != value))
                    return;
                this.message = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Message)));
            }
            get => this.message;
        }

        public byte Type
        {
            set
            {
                if ((int)this.type == (int)value)
                    return;
                this.type = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Type)));
            }
            get => this.type;
        }

        public string TypeDesc
        {
            get
            {
                string str = "";
                switch (this.type)
                {
                    case 0:
                        str = "Debug";
                        break;

                    case 1:
                        str = "Info";
                        break;

                    case 2:
                        str = "Warning";
                        break;

                    case 3:
                        str = "Error";
                        break;

                    case 4:
                        str = "Transaction";
                        break;
                }
                return str;
            }
        }

        public enum Types : byte
        {
            Debug,
            Info,
            Warning,
            Error,
            Transaction,
            Trace,
        }
    }
}