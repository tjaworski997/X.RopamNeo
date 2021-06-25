// Type: X.RopamNeo.Lib.Model.Beans.TempSensor

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class TempSensor : INotifyPropertyChanged
    {
        private int id;
        private int no;
        private int site;
        private byte state;
        private float val;
        private string name;
        private float tha;
        private float thb;
        private bool selected;

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
            }
            get => this.state;
        }

        public float Value
        {
            set
            {
                if ((double)this.val == (double)value)
                    return;
                this.val = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Value)));
            }
            get => this.val;
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

        public float Tha
        {
            set
            {
                if ((double)this.tha == (double)value)
                    return;
                this.tha = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Tha)));
            }
            get => this.tha;
        }

        public float Thb
        {
            set
            {
                if ((double)this.thb == (double)value)
                    return;
                this.thb = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Thb)));
            }
            get => this.thb;
        }

        public TempSensor Clone() => new TempSensor()
        {
            Id = this.Id,
            No = this.No,
            Site = this.Site,
            State = this.State,
            Value = this.Value,
            Name = this.Name,
            Tha = this.Tha,
            Thb = this.Thb,
            Selected = this.Selected
        };

        public enum States : byte
        {
            Ok,
            Fail,
            Absence,
        }
    }
}