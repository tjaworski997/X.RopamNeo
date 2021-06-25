// Type: X.RopamNeo.Lib.Model.Beans.Message

using System;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Message : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public int Site { get; set; }

        private byte channel { get; set; }

        private byte type { get; set; }

        private string text { get; set; }

        private DateTime time { get; set; }

        public string Text
        {
            set
            {
                if (!(this.text != value))
                    return;
                this.text = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Text)));
            }
            get => this.text;
        }

        public DateTime Time
        {
            set
            {
                if (!(this.time != value))
                    return;
                this.time = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Time)));
            }
            get => this.time;
        }

        public byte Channel
        {
            set
            {
                if ((int)this.channel == (int)value)
                    return;
                this.channel = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Channel)));
            }
            get => this.channel;
        }

        public byte Type
        {
            set
            {
                if ((int)this.type == (int)value)
                    return;
                this.type = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Type)));
            }
            get => this.type;
        }

        public Message Clone() => new Message()
        {
            Id = this.Id,
            Text = this.Text,
            Time = this.Time,
            Type = this.Type,
            Site = this.Site,
            Channel = this.Channel
        };

        public enum Channels : byte
        {
            VirtualSms,
            Push,
            Email,
            Sms,
        }

        public enum Classes : byte
        {
            SecurityAlarm = 0,
            TechnicalAlarm = 1,
            ArmDisarm = 2,
            Failure = 3,
            Information = 4,
            SmsVirtual = 90, // 0x5A
            Ussd = 91, // 0x5B
            Busy = 92, // 0x5C
            All = 100, // 0x64
            Unknown = 101, // 0x65
        }
    }
}