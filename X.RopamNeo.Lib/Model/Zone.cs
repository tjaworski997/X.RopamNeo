// Type: X.RopamNeo.Lib.Model.Zone

using System;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model
{
    public class Zone : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private int no;
        private string name;
        private bool isArmed;
        private bool isNightArmed;
        private bool isAlarm;
        private bool isTamper;
        private bool isReady;
        private bool onEntrance;
        private bool onDeparture;
        private ushort timer;
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

        public bool IsAlarm
        {
            set
            {
                if (this.isAlarm == value)
                    return;
                this.isAlarm = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsAlarm)));
            }
            get => this.isAlarm;
        }

        public bool IsTamper
        {
            set
            {
                if (this.isTamper == value)
                    return;
                this.isTamper = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsTamper)));
            }
            get => this.isTamper;
        }

        public bool IsReady
        {
            set
            {
                if (this.isReady == value)
                    return;
                this.isReady = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsReady)));
            }
            get => this.isReady;
        }

        public bool OnEntrance
        {
            set
            {
                if (this.onEntrance == value)
                    return;
                this.onEntrance = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(OnEntrance)));
            }
            get => this.onEntrance;
        }

        public bool OnDeparture
        {
            set
            {
                if (this.onDeparture == value)
                    return;
                this.onDeparture = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(OnDeparture)));
            }
            get => this.onDeparture;
        }

        public bool IsArmed
        {
            set
            {
                if (this.isArmed == value)
                    return;
                this.isArmed = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsArmed)));
            }
            get => this.isArmed;
        }

        public bool IsNightArmed
        {
            set
            {
                if (this.isNightArmed == value)
                    return;
                this.isNightArmed = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsNightArmed)));
            }
            get => this.isNightArmed;
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

        public ushort Timer
        {
            set
            {
                if ((int)this.timer == (int)value)
                    return;
                this.timer = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Timer)));
            }
            get => this.timer;
        }

        public Zone Clone() => new Zone()
        {
            ChangeAfter = this.ChangeAfter,
            No = this.No,
            Name = this.Name,
            Id = this.Id,
            Selected = this.Selected,
            Site = this.Site,
            IsArmed = this.IsArmed,
            IsNightArmed = this.IsNightArmed,
            IsAlarm = this.IsAlarm,
            IsTamper = this.IsTamper,
            isReady = this.IsReady,
            OnEntrance = this.OnEntrance,
            OnDeparture = this.OnDeparture
        };
    }
}