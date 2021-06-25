// Type: X.RopamNeo.Lib.Model.Beans.ZoneSet

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class ZoneSet : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private bool zone0;
        private bool zone1;

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

        public bool Zone0
        {
            set
            {
                if (this.zone0 == value)
                    return;
                this.zone0 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Zone0)));
            }
            get => this.zone0;
        }

        public bool Zone1
        {
            set
            {
                if (this.zone1 == value)
                    return;
                this.zone1 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Zone1)));
            }
            get => this.zone1;
        }

        public void CopyState(ZoneSet set)
        {
            set.Zone0 = this.Zone0;
            set.Zone1 = this.Zone1;
        }

        public bool Get(int no)
        {
            if (no == 0)
                return this.zone0;
            return no == 1 && this.zone1;
        }

        public void Set(int no, bool value)
        {
            if (no != 0)
            {
                if (no != 1)
                    return;
                this.zone1 = value;
            }
            else
                this.zone0 = value;
        }

        public ZoneSet Clone() => new ZoneSet()
        {
            Id = this.Id,
            Site = this.Site,
            Zone0 = this.Zone0,
            Zone1 = this.Zone1
        };
    }
}