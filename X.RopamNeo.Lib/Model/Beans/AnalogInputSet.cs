// Type: X.RopamNeo.Lib.Model.Beans.AnalogInputSet

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class AnalogInputSet : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private bool analogInput0;
        private bool analogInput1;

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

        public bool AnalogInput0
        {
            set
            {
                if (this.analogInput0 == value)
                    return;
                this.analogInput0 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(AnalogInput0)));
            }
            get => this.analogInput0;
        }

        public bool AnalogInput1
        {
            set
            {
                if (this.analogInput1 == value)
                    return;
                this.analogInput1 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(AnalogInput1)));
            }
            get => this.analogInput1;
        }

        public void CopyState(AnalogInputSet set)
        {
            set.AnalogInput0 = this.AnalogInput0;
            set.AnalogInput1 = this.AnalogInput1;
        }

        public bool Get(int no)
        {
            if (no == 0)
                return this.analogInput0;
            return no == 1 && this.analogInput1;
        }

        public void Set(int no, bool value)
        {
            if (no != 0)
            {
                if (no != 1)
                    return;
                this.analogInput1 = value;
            }
            else
                this.analogInput0 = value;
        }

        public AnalogInputSet Clone() => new AnalogInputSet()
        {
            Id = this.Id,
            Site = this.Site,
            AnalogInput0 = this.AnalogInput0,
            AnalogInput1 = this.AnalogInput1
        };
    }
}