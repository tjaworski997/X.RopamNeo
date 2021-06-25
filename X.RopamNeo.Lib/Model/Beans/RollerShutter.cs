// Type: X.RopamNeo.Lib.Model.Beans.RollerShutter

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class RollerShutter : INotifyPropertyChanged
    {
        private string name;
        private int mod;

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

        public int Mod
        {
            set
            {
                if (this.mod == value)
                    return;
                this.mod = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Mod)));
            }
            get => this.mod;
        }
    }
}