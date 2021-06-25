// Type: X.RopamNeo.Lib.Model.Beans.Contact

using System.Collections.Generic;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ushort idx { get; set; }

        private string name { get; set; }

        private char group { get; set; }

        private string phone { get; set; }

        private byte action { get; set; }

        public string ToLine() => this.idx.ToString() + "," + (this.name != null ? (object)this.name.Replace(",", "") : (object)"") + "," + (this.phone != null ? (object)this.phone.Replace(",", "") : (object)"") + "," + this.group.ToString() + "," + (this.action == (byte)0 ? (object)"+" : (this.action == (byte)1 ? (object)"-" : (object)">")) + "\n";

        public Contact Clone() => new Contact()
        {
            idx = this.idx,
            name = this.name,
            phone = this.phone,
            group = this.group
        };

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Contact contact = obj as Contact;
            return (int)contact.Group == (int)this.group && (int)contact.Idx == (int)this.idx && (!(contact.Name != this.name) && !(contact.Phone != this.phone));
        }

        //public override int GetHashCode() => (((((((((-804043712 * -1521134295 + this.idx.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.name)) * -1521134295 + this.group.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.phone)) * -1521134295 + this.action.GetHashCode()) * -1521134295 + this.Idx.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Name)) * -1521134295 + this.Group.GetHashCode()) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Phone)) * -1521134295 + this.Action.GetHashCode();

        public ushort Idx
        {
            set
            {
                if ((int)this.idx == (int)value)
                    return;
                this.idx = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Idx)));
            }
            get => this.idx;
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

        public char Group
        {
            set
            {
                if ((int)this.group == (int)value)
                    return;
                this.group = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Group)));
            }
            get => this.group;
        }

        public string Phone
        {
            set
            {
                if (!(this.phone != value))
                    return;
                this.phone = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Phone)));
            }
            get => this.phone;
        }

        public byte Action
        {
            set
            {
                if ((int)this.action == (int)value)
                    return;
                this.action = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Action)));
            }
            get => this.action;
        }

        public enum Actions : byte
        {
            Add,
            Delete,
            Edit,
        }
    }
}