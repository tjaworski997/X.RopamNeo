// Type: X.RopamNeo.Lib.Model.Beans.Event

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Event : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private byte type { get; set; }

        private string name { get; set; }

        private string time { get; set; }

        public string Name
        {
            set
            {
                if (!(this.name != value))
                    return;
                this.name = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Name)));
            }
            get => this.name;
        }

        public string Time
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

        public string Image
        {
            get
            {
                string str;
                switch (this.Type)
                {
                    case 0:
                        str = "Assets/red50.png";
                        break;

                    case 1:
                        str = "Assets/bordo50.png";
                        break;

                    case 2:
                        str = "Assets/green50.png";
                        break;

                    case 3:
                        str = "Assets/orange50.png";
                        break;

                    case 4:
                        str = "Assets/white50.png";
                        break;

                    case 101:
                        str = "Assets/gray50.png";
                        break;

                    default:
                        str = "Assets/gray50.png";
                        break;
                }
                return str;
            }
        }
    }
}