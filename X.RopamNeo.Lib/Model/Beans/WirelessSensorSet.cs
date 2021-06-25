// Type: X.RopamNeo.Lib.Model.Beans.WirelessSensorSet

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class WirelessSensorSet : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private bool wired0;
        private bool wired1;
        private bool wireless0;
        private bool wireless1;
        private bool wireless2;
        private bool wireless3;

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

        public bool Wired0
        {
            set
            {
                if (this.wired0 == value)
                    return;
                this.wired0 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Wired0)));
            }
            get => this.wired0;
        }

        public bool Wired1
        {
            set
            {
                if (this.wired1 == value)
                    return;
                this.wired1 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Wired1)));
            }
            get => this.wired1;
        }

        public bool Wireless0
        {
            set
            {
                if (this.wireless0 == value)
                    return;
                this.wireless0 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Wireless0)));
            }
            get => this.wireless0;
        }

        public bool Wireless1
        {
            set
            {
                if (this.wireless1 == value)
                    return;
                this.wireless1 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Wireless1)));
            }
            get => this.wireless1;
        }

        public bool Wireless2
        {
            set
            {
                if (this.wireless2 == value)
                    return;
                this.wireless2 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Wireless2)));
            }
            get => this.wireless2;
        }

        public bool Wireless3
        {
            set
            {
                if (this.wireless3 == value)
                    return;
                this.wireless3 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Wireless3)));
            }
            get => this.wireless3;
        }

        public void CopyState(WirelessSensorSet set)
        {
            if (set == null)
                return;
            set.Wired0 = this.Wired0;
            set.Wired1 = this.Wired1;
            set.Wireless0 = this.Wireless0;
            set.Wireless1 = this.Wireless1;
            set.Wireless2 = this.Wireless2;
            set.Wireless3 = this.Wireless3;
        }

        public bool Get(int no)
        {
            switch (no)
            {
                case 0:
                    return this.wired0;

                case 1:
                    return this.wired1;

                case 2:
                    return this.wireless0;

                case 3:
                    return this.wireless1;

                case 4:
                    return this.wireless2;

                case 5:
                    return this.wireless3;

                default:
                    return false;
            }
        }

        public void Set(int no, bool value)
        {
            switch (no)
            {
                case 0:
                    this.wired0 = value;
                    break;

                case 1:
                    this.wired1 = value;
                    break;

                case 2:
                    this.wireless0 = value;
                    break;

                case 3:
                    this.wireless1 = value;
                    break;

                case 4:
                    this.wireless2 = value;
                    break;

                case 5:
                    this.wireless3 = value;
                    break;
            }
        }

        public WirelessSensorSet Clone() => new WirelessSensorSet()
        {
            Id = this.Id,
            Site = this.Site,
            Wired0 = this.Wired0,
            Wired1 = this.Wired1,
            Wireless0 = this.Wireless0,
            Wireless1 = this.Wireless1,
            Wireless2 = this.Wireless2,
            Wireless3 = this.Wireless3
        };
    }
}