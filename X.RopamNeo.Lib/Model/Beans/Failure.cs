// Type: X.RopamNeo.Lib.Model.Beans.Failure

using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Failure : INotifyPropertyChanged
    {
        private string name;
        private string image = "Assets/uwaga40.png";

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

        public string Image
        {
            get => this.image;
            set
            {
                if (!(this.image != value))
                    return;
                this.image = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }
    }
}