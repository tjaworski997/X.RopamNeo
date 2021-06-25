// Type: X.RopamNeo.Lib.Model.Beans.User

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        private byte no;
        private bool isFree;
        private bool selected;

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

        public byte No
        {
            set
            {
                if ((int)this.no == (int)value)
                    return;
                this.no = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(No)));
            }
            get => this.no;
        }

        public bool IsFree
        {
            set
            {
                if (this.isFree == value)
                    return;
                this.isFree = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsFree)));
            }
            get => this.isFree;
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
    }
}