using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class AnalogInput : INotifyPropertyChanged
    {
        private int id;
        private int no;
        private int site;
        private string name;
        private string unit;
        private float val;
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

        public string Unit
        {
            set
            {
                if (!(this.unit != value))
                    return;
                this.unit = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Unit)));
            }
            get => this.unit;
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

        public string ValueAndUnit => this.val.ToString() + " " + this.unit;

        public AnalogInput Clone() => new AnalogInput()
        {
            Unit = this.Unit,
            Value = this.Value
        };
    }
}