// Type: X.RopamNeo.Lib.Model.Output

using System;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model
{
    public class Output : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private int no;
        private string name;
        private byte state;
        private bool selected;
        private DateTime changeAfter = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        public Output()
        {
            this.state = (byte)1;
            this.selected = this.state == (byte)1 || this.state == (byte)2 || this.state == (byte)4 || this.state == (byte)6;
        }

        public Output(byte state)
        {
            this.state = state;
            this.selected = state == (byte)1 || state == (byte)2 || state == (byte)4 || state == (byte)6;
        }

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

        public int Site
        {
            set
            {
                if (this.site == value)
                    return;
                this.site = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Site)));
            }
            get => this.site;
        }

        public int No
        {
            set
            {
                if (this.no == value)
                    return;
                this.no = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(No)));
            }
            get => this.no;
        }

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

        public byte State
        {
            set
            {
                if ((int)this.state == (int)value)
                    return;
                this.state = value;
                bool flag = this.state == (byte)1 || this.state == (byte)2 || this.state == (byte)4 || this.state == (byte)6;
                if (this.selected != flag)
                    this.selected = flag;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(State)));
            }
            get => this.state;
        }

        public bool IsOn => this.state == (byte)2 || this.state == (byte)6 || this.state == (byte)4 || this.state == (byte)1;

        public bool NoControl => this.state == (byte)8 || this.state == (byte)4 || (this.state == (byte)5 || this.state == (byte)6) || this.state == (byte)7;

        public bool AllowChange => this.state != (byte)4 && this.state != (byte)5 && (this.state != (byte)6 && this.state != (byte)7) && this.state != (byte)8;

        public bool Selected
        {
            set
            {
                if (this.selected == value)
                    return;
                this.selected = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Selected)));
            }
            get => this.selected;
        }

        public string Image
        {
            get
            {
                string str = "Assets/green30.png";
                switch (this.state)
                {
                    case 0:
                        str = "Assets/claret30.png";
                        break;

                    case 1:
                        str = "Assets/red30.png";
                        break;

                    case 2:
                        str = "Assets/gray30.png";
                        break;

                    case 3:
                        str = "Assets/gray30.png";
                        break;

                    case 4:
                        str = "Assets/red30.png";
                        break;

                    case 5:
                        str = "Assets/claret30.png";
                        break;

                    case 6:
                        str = "Assets/red30.png";
                        break;

                    case 7:
                        str = "Assets/claret30.png";
                        break;

                    case 8:
                        str = "Assets/gray30.png";
                        break;
                }
                return str;
            }
        }

        public DateTime ChangeAfter
        {
            set
            {
                if (!(this.changeAfter != value))
                    return;
                this.changeAfter = value;
            }
            get => this.changeAfter;
        }

        public Output Clone() => new Output()
        {
            ChangeAfter = this.ChangeAfter,
            No = this.No,
            Name = this.Name,
            Id = this.Id,
            Selected = this.Selected,
            Site = this.Site,
            State = this.State
        };

        public enum States : byte
        {
            Off,
            On,
            FailOn,
            FailOff,
            NoControlOn,
            NoControlOff,
            NoControlFailOn,
            NoControlFailOff,
            NoOutput,
        }
    }
}