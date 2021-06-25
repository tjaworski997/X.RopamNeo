// Type: X.RopamNeo.Lib.Model.Beans.WirelessSensor

using System.ComponentModel;
using System.Globalization;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class WirelessSensor : INotifyPropertyChanged
    {
        private int id;
        private int site;
        private int no;
        private string name;
        private float temperature;
        private byte humidity;
        private float vbat;
        private bool available;
        private bool connected;
        private bool selected;

        public event PropertyChangedEventHandler PropertyChanged;

        public WirelessSensor()
        {
        }

        public WirelessSensor(string data)
        {
            this.Humidity = byte.Parse(data.Substring(4, 2), NumberStyles.HexNumber);
            this.Vbat = (float)((int)byte.Parse(data.Substring(6, 2), NumberStyles.HexNumber) / 10);
            this.Temperature = (float)short.Parse(data.Substring(0, 4), NumberStyles.HexNumber) / 10f;
            string str = data.Substring(8, 1);
            if (str == "0")
            {
                this.available = false;
                this.connected = false;
            }
            else if (str == "1")
            {
                this.available = true;
                this.connected = true;
                if ((double)this.temperature >= -998.0)
                    return;
                this.connected = false;
            }
            else if (str == "2")
            {
                this.available = true;
                this.connected = false;
            }
            else
            {
                this.available = false;
                this.connected = false;
            }
        }

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

        public float Temperature
        {
            set
            {
                if ((double)this.temperature == (double)value)
                    return;
                this.temperature = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Temperature)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("TemperatureStr"));
            }
            get => this.temperature;
        }

        public string TemperatureStr => !this.connected ? "" : this.temperature.ToString("0.0") + " °C";

        public byte Humidity
        {
            set
            {
                if ((int)this.humidity == (int)value)
                    return;
                this.humidity = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Humidity)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("HumidityStr"));
            }
            get => this.humidity;
        }

        public string HumidityStr => !this.connected ? "" : this.humidity.ToString() + " %";

        public float Vbat
        {
            set
            {
                if ((double)this.vbat == (double)value)
                    return;
                this.vbat = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Vbat)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("VbatStr"));
            }
            get => this.vbat;
        }

        public string VbatStr => !this.connected ? "" : this.humidity.ToString() + " V";

        public bool Available
        {
            set
            {
                if (this.available == value)
                    return;
                this.available = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Available)));
            }
            get => this.available;
        }

        public bool Connected
        {
            set
            {
                if (this.connected == value)
                    return;
                this.connected = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Connected)));
            }
            get => this.connected;
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

        public void Copy(WirelessSensor sensor)
        {
            sensor.Available = this.Available;
            sensor.Connected = this.Connected;
            sensor.Humidity = this.Humidity;
            sensor.Temperature = this.Temperature;
            sensor.Vbat = this.vbat;
        }
    }
}