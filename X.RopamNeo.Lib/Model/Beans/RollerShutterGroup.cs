// Type: X.RopamNeo.Lib.Model.Beans.RollerShutterGroup

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class RollerShutterGroup : INotifyPropertyChanged
    {
        private string name;
        private ushort mask;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ushort Mask
        {
            set
            {
                if ((int)this.mask == (int)value)
                    return;
                this.mask = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Mask)));
            }
            get => this.mask;
        }
    }
}