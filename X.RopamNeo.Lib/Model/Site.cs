// Type: X.RopamNeo.Lib.Model.Site

using X.RopamNeo.Lib.Model.Beans;

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model
{
    public class Site : INotifyPropertyChanged
    {
        private bool isDemo;
        private string name;
        private string ip;
        private int port;
        private string ip2;
        private int port2;
        private string ssid;
        private bool saveCode;
        private bool viaBridge;
        private bool securityAlarm;
        private bool technicalAlarm;
        private bool armDisarm;
        private bool failure;
        private bool information;
        private short notificationCheckSum;
        private bool notificationCfgChanged = true;
        private string mobileKey;
        private bool canEditMenu;
        private string deviceId;
        private string deviceId2;
        private int userNo = -1;
        private string code;
        private string tcpCode;
        private string phone;
        private string devicePhone;
        private string deviceLang;
        private byte mobileOperator;
        private string checkPattern;
        private string prepaidPattern;
        private DateTime lastLoginTime;
        private bool connWasOk;

        public event PropertyChangedEventHandler PropertyChanged;

        public Site Clone() => new Site()
        {
            IsDemo = this.IsDemo,
            Code = this.Code,
            TcpCode = this.TcpCode,
            ConnWasOk = this.ConnWasOk,
            DeviceId = this.DeviceId,
            DeviceId2 = this.DeviceId2,
            UserNo = this.UserNo,
            Id = this.Id,
            Ip = this.Ip,
            Ip2 = this.Ip2,
            Ssid = this.Ssid,
            LastLoginTime = this.LastLoginTime,
            Name = this.Name,
            Phone = this.Phone,
            Port = this.Port,
            Port2 = this.Port2,
            SecurityAlarm = this.SecurityAlarm,
            TechnicalAlarm = this.TechnicalAlarm,
            ArmDisarm = this.ArmDisarm,
            Failure = this.Failure,
            Information = this.Information,
            NotificationCheckSum = this.NotificationCheckSum,
            NotificationCfgChanged = this.NotificationCfgChanged,
            MobileKey = this.MobileKey,
            ViaBridge = this.ViaBridge,
            CanEditMenu = this.CanEditMenu,
            DevicePhone = this.DevicePhone,
            DeviceLang = this.DeviceLang,
            PrepaidPattern = this.PrepaidPattern,
            SaveCode = this.SaveCode,
            MobileOperator = this.MobileOperator,
            CheckPattern = this.CheckPattern,
            prepaidPattern = this.prepaidPattern
        };

        public int Id { get; set; }

        public bool IsDemo
        {
            set
            {
                if (this.isDemo == value)
                    return;
                this.isDemo = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(IsDemo)));
            }
            get => this.isDemo;
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

        public string Ip
        {
            set
            {
                if (!(this.ip != value))
                    return;
                this.ip = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Ip)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.ip;
        }

        public int Port
        {
            set
            {
                if (this.port == value)
                    return;
                this.port = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Port)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.port;
        }

        public string Ip2
        {
            set
            {
                if (!(this.ip2 != value))
                    return;
                this.ip2 = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Ip2)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.ip2;
        }

        public int Port2
        {
            set
            {
                if (this.port2 == value)
                    return;
                this.port2 = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Port2)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.port2;
        }

        public string Ssid
        {
            set
            {
                if (!(this.ssid != value))
                    return;
                this.ssid = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Ssid)));
            }
            get => this.ssid;
        }

        public bool SaveCode
        {
            set
            {
                if (this.saveCode == value)
                    return;
                this.saveCode = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(SaveCode)));
            }
            get => this.saveCode;
        }

        public bool SecurityAlarm
        {
            set
            {
                if (this.securityAlarm == value)
                    return;
                this.securityAlarm = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(SecurityAlarm)));
            }
            get => this.securityAlarm;
        }

        public bool TechnicalAlarm
        {
            set
            {
                if (this.technicalAlarm == value)
                    return;
                this.technicalAlarm = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(TechnicalAlarm)));
            }
            get => this.technicalAlarm;
        }

        public bool ArmDisarm
        {
            set
            {
                if (this.armDisarm == value)
                    return;
                this.armDisarm = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(ArmDisarm)));
            }
            get => this.armDisarm;
        }

        public bool Failure
        {
            set
            {
                if (this.failure == value)
                    return;
                this.failure = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Failure)));
            }
            get => this.failure;
        }

        public bool Information
        {
            set
            {
                if (this.information == value)
                    return;
                this.information = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Information)));
            }
            get => this.information;
        }

        public short NotificationCheckSum
        {
            set
            {
                if ((int)this.notificationCheckSum == (int)value)
                    return;
                this.notificationCheckSum = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(NotificationCheckSum)));
            }
            get => this.notificationCheckSum;
        }

        public bool NotificationCfgChanged
        {
            set
            {
                if (this.notificationCfgChanged == value)
                    return;
                this.notificationCfgChanged = value;
                if (this.notificationCfgChanged)
                    this.NotificationCheckSum = (short)new Random().Next();
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(NotificationCfgChanged)));
            }
            get => this.notificationCfgChanged;
        }

        public string MobileKey
        {
            set
            {
                if (!(this.mobileKey != value))
                    return;
                this.mobileKey = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(MobileKey)));
            }
            get => this.mobileKey;
        }

        public bool ViaBridge
        {
            set
            {
                if (this.viaBridge == value)
                    return;
                this.viaBridge = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(ViaBridge)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("NotViaBridge"));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("Image"));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.viaBridge;
        }

        public bool NotViaBridge => !this.viaBridge;

        public bool CanEditMenu
        {
            set
            {
                if (this.canEditMenu == value)
                    return;
                this.canEditMenu = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(CanEditMenu)));
            }
            get => this.canEditMenu;
        }

        public string DeviceId
        {
            set
            {
                if (!(this.deviceId != value))
                    return;
                this.deviceId = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(DeviceId)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.deviceId;
        }

        public string DeviceId2
        {
            set
            {
                if (!(this.deviceId2 != value))
                    return;
                this.deviceId2 = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(DeviceId2)));
            }
            get => this.deviceId2;
        }

        public int UserNo
        {
            set
            {
                if (this.userNo == value)
                    return;
                this.userNo = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(UserNo)));
            }
            get => this.userNo;
        }

        public string Code
        {
            set
            {
                if (!(this.code != value))
                    return;
                this.code = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Code)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.code;
        }

        public string TcpCode
        {
            set
            {
                if (!(this.tcpCode != value))
                    return;
                this.tcpCode = value;
                this.connWasOk = false;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(TcpCode)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("ConnWasOk"));
            }
            get => this.tcpCode;
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

        public string DevicePhone
        {
            set
            {
                if (!(this.devicePhone != value))
                    return;
                this.devicePhone = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(DevicePhone)));
            }
            get => this.devicePhone;
        }

        public string DeviceLang
        {
            set
            {
                if (!(this.deviceLang != value))
                    return;
                this.deviceLang = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(DeviceLang)));
            }
            get => this.deviceLang;
        }

        public byte MobileOperator
        {
            set
            {
                if ((int)this.mobileOperator == (int)value)
                    return;
                this.mobileOperator = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(MobileOperator)));
            }
            get => this.mobileOperator;
        }

        public string PrepaidPattern
        {
            set
            {
                if (!(this.prepaidPattern != value))
                    return;
                this.prepaidPattern = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(PrepaidPattern)));
            }
            get => this.prepaidPattern;
        }

        public string CheckPattern
        {
            set
            {
                if (!(this.checkPattern != value))
                    return;
                this.checkPattern = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(CheckPattern)));
            }
            get => this.checkPattern;
        }

        public DateTime LastLoginTime
        {
            set
            {
                if (!(this.lastLoginTime != value))
                    return;
                this.lastLoginTime = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(LastLoginTime)));
                this.PropertyChanged((object)this, new PropertyChangedEventArgs("LastLogin"));
            }
            get => this.lastLoginTime;
        }

        public string LastLoginLocal
        {
            get
            {
                DateTime lastLoginTime = this.lastLoginTime;
                return !(this.lastLoginTime > DateTime.MinValue) ? string.Empty : TimeZone.CurrentTimeZone.ToLocalTime(this.lastLoginTime).ToString();
            }
        }

        public bool ConnWasOk
        {
            set
            {
                if (this.connWasOk == value)
                    return;
                this.connWasOk = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(ConnWasOk)));
            }
            get => this.connWasOk;
        }

        public List<Input> Inputs { get; set; }

        public List<Output> Outputs { get; set; }

        public List<Zone> Zones { get; set; }

        public List<TempSensor> TempSensors { get; set; }

        public List<WirelessSensor> WirelessSensors { get; set; }

        public List<AnalogInput> AnalogInputs { get; set; }

        public List<PageItem> PageItems { get; set; }

        public enum Operators : byte
        {
            Orange = 1,
            Plus = 2,
            Tmobile = 3,
            Play = 4,
            Wrodzinie = 5,
            Nju = 6,
            Heyah = 7,
            SamiSwoi = 8,
        }
    }
}