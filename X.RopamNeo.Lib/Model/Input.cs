// Type: X.RopamNeo.Lib.Model.Input

using System;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model
{
    public class Input : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private int no;
        private string name;
        private byte state;
        private int seq;
        private bool selected;
        private DateTime changeAfter = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

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
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(State)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("Image"));
            }
            get => this.state;
        }

        public int Seq
        {
            set
            {
                if (this.seq == value)
                    return;
                this.seq = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Seq)));
            }
            get => this.seq > 0 ? this.seq : this.no + 1;
        }

        public bool IsLowBattery => this.state == (byte)8 || this.state == (byte)9;

        public bool IsFailure => this.state == (byte)5 || this.state == (byte)10;

        public bool IsAlarm => this.state == (byte)6 || this.state == (byte)7;

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
                string str;
                switch (this.state)
                {
                    case 0:
                        str = "Assets/green50.png";
                        break;

                    case 1:
                        str = "Assets/red50.png";
                        break;

                    case 2:
                        str = "Assets/yellow50.png";
                        break;

                    case 3:
                        str = "Assets/gray50.png";
                        break;

                    case 4:
                        str = "Assets/bordo_dark50.png";
                        break;

                    case 5:
                        str = "Assets/uwaga50";
                        break;

                    case 6:
                        str = "Assets/green50.png";
                        break;

                    case 7:
                        str = "Assets/red50.png";
                        break;

                    case 8:
                        str = "Assets/green50.png";
                        break;

                    case 9:
                        str = "Assets/red50.png";
                        break;

                    case 10:
                        str = "Assets/violet50.png";
                        break;

                    case 11:
                        str = "Assets/gray50.png";
                        break;

                    default:
                        str = "Assets/gray50.png";
                        break;
                }
                return str;
            }
        }

        public string AddImage
        {
            get
            {
                if (this.IsLowBattery)
                    return "Assets/bateria20x20.png";
                if (this.IsFailure)
                    return "Assets/uwaga20x20.png";
                return this.IsAlarm ? "Assets/alarm20x20.png" : (string)null;
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

        public Input Clone() => new Input()
        {
            ChangeAfter = this.ChangeAfter,
            Id = this.Id,
            Name = this.Name,
            No = this.No,
            Selected = this.Selected,
            Site = this.Site,
            State = this.State
        };

        public enum States : byte
        {
            Ok,
            Trigger,
            Sabotage,
            Disabled,
            Locked,
            Fail,
            AlarmOk,
            AlarmTrigger,
            BaterryLowOk,
            BaterryLowTrigger,
            LinkFail,
            NoInfo,
            Analog,
        }
    }
}