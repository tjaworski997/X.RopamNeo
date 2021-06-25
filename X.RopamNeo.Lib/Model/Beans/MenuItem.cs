// Type: X.RopamNeo.Lib.Model.Beans.MenuItem

using System;
using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class MenuItem
    {
        public int Id { get; set; }

        public int Site { get; set; }

        public string Name { get; set; }

        public int InputNo { get; set; }

        public int OutputNo { get; set; }

        public int AnalogNo { get; set; }

        public int TempSensorNo { get; set; }

        public int WirelessSensorNo { get; set; }

        public int ThresholdNo { get; set; }

        public int OutputSetId { get; set; }

        public int InputSetId { get; set; }

        public int ZoneSetId { get; set; }

        public int TempSensorSetId { get; set; }

        public int WirelessSensorSetId { get; set; }

        public int AnalogInputSetId { get; set; }

        public bool ShowZoneScreen { get; set; }

        public bool ShowRollerShutterScreen { get; set; }

        public bool CodeRequired { get; set; }

        public bool AllowLock { get; set; }

        public bool ExitLogout { get; set; }

        public bool Var1U { get; set; }

        public byte NoOfDecimalPlaces { get; set; }

        public ushort SleepTime { get; set; }

        public string VoiceSequence { get; set; }

        public int Place { get; set; }

        public int PageNo { get; set; }

        public int Column { get; set; }

        public int ColumnSpan { get; set; }

        public int Row { get; set; }

        public int RowSpan { get; set; }

        public string Image { get; set; }

        public string ClickImage { get; set; }

        public string SrcImage { get; set; }

        public byte Type { get; set; }

        public MenuItem.ImageSet[] Images { get; set; }

        public string TypeName { get; set; }

        public int Icon { get; set; }

        public int WidgetWidth { get; set; }

        public int WidgetHeight { get; set; }

        public Input Input { get; set; }

        public InputSet InputSet { get; set; }

        public TempSensor TempSensor { get; set; }

        public TempSensorSet TempSensorSet { get; set; }

        public WirelessSensorSet WirelessSensorSet { get; set; }

        public AnalogInput AnalogInput { get; set; }

        public AnalogInputSet AnalogInputSet { get; set; }

        public Output Output { get; set; }

        public OutputSet OutputSet { get; set; }

        public Zone Zone { get; set; }

        public ZoneSet ZoneSet { get; set; }

        public List<MenuItem> Actions { get; set; }

        public Action OnClick { get; set; }

        public Action<X.RopamNeo.Lib.Model.Site, Message> OnMessage { get; set; }

        public Action<X.RopamNeo.Lib.Model.Site, Config> OnConfig { get; set; }

        public Action<X.RopamNeo.Lib.Model.Site, List<Contact>> OnPhones { get; set; }

        public object Binding { get; set; }

        public object Binding2 { get; set; }

        public int IntBinding { get; set; }

        public int IntBinding2 { get; set; }

        public DateTime? DateBinding { get; set; }

        public string StringBinding { get; set; }

        public bool BoolBinding { get; set; }

        public MenuItem Clone() => new MenuItem()
        {
            Id = this.Id,
            Site = this.Site,
            Name = this.Name,
            InputNo = this.InputNo,
            OutputNo = this.OutputNo,
            AnalogNo = this.AnalogNo,
            TempSensorNo = this.TempSensorNo,
            WirelessSensorNo = this.WirelessSensorNo,
            ThresholdNo = this.ThresholdNo,
            OutputSetId = this.OutputSetId,
            InputSetId = this.InputSetId,
            ZoneSetId = this.ZoneSetId,
            TempSensorSetId = this.TempSensorSetId,
            WirelessSensorSetId = this.WirelessSensorSetId,
            AnalogInputSetId = this.AnalogInputSetId,
            ShowZoneScreen = this.ShowZoneScreen,
            ShowRollerShutterScreen = this.ShowRollerShutterScreen,
            CodeRequired = this.CodeRequired,
            AllowLock = this.AllowLock,
            ExitLogout = this.ExitLogout,
            Var1U = this.Var1U,
            NoOfDecimalPlaces = this.NoOfDecimalPlaces,
            SleepTime = this.SleepTime,
            VoiceSequence = this.VoiceSequence,
            Place = this.Place,
            PageNo = this.PageNo,
            Column = this.Column,
            ColumnSpan = this.ColumnSpan,
            Row = this.Row,
            RowSpan = this.RowSpan,
            Image = this.Image,
            ClickImage = this.ClickImage,
            Type = this.Type,
            TypeName = this.TypeName,
            Icon = this.Icon,
            WidgetWidth = this.WidgetWidth,
            WidgetHeight = this.WidgetHeight,
            Input = this.Input != null ? this.Input.Clone() : (Input)null,
            InputSet = this.InputSet != null ? this.InputSet.Clone() : (InputSet)null,
            AnalogInput = this.AnalogInput != null ? this.AnalogInput.Clone() : (AnalogInput)null,
            AnalogInputSet = this.AnalogInputSet != null ? this.AnalogInputSet.Clone() : (AnalogInputSet)null,
            Output = this.Output != null ? this.Output.Clone() : (Output)null,
            OutputSet = this.OutputSet != null ? this.OutputSet.Clone() : (OutputSet)null,
            Zone = this.Zone != null ? this.Zone.Clone() : (Zone)null,
            ZoneSet = this.ZoneSet != null ? this.ZoneSet.Clone() : (ZoneSet)null,
            Actions = this.Actions != null ? new List<MenuItem>((IEnumerable<MenuItem>)this.Actions) : (List<MenuItem>)null,
            TempSensor = this.TempSensor != null ? this.TempSensor.Clone() : (TempSensor)null,
            WirelessSensorSet = this.WirelessSensorSet != null ? this.WirelessSensorSet.Clone() : (WirelessSensorSet)null,
            TempSensorSet = this.TempSensorSet != null ? this.TempSensorSet.Clone() : (TempSensorSet)null
        };

        public void CopyTo(MenuItem dest)
        {
            dest.Id = this.Id;
            dest.Site = this.Site;
            dest.Name = this.Name;
            dest.InputNo = this.InputNo;
            dest.OutputNo = this.OutputNo;
            dest.AnalogNo = this.AnalogNo;
            dest.TempSensorNo = this.TempSensorNo;
            dest.WirelessSensorNo = this.WirelessSensorNo;
            dest.ThresholdNo = this.ThresholdNo;
            dest.OutputSetId = this.OutputSetId;
            dest.InputSetId = this.InputSetId;
            dest.ZoneSetId = this.ZoneSetId;
            dest.TempSensorSetId = this.TempSensorSetId;
            dest.WirelessSensorSetId = this.WirelessSensorSetId;
            dest.AnalogInputSetId = this.AnalogInputSetId;
            dest.ShowZoneScreen = this.ShowZoneScreen;
            dest.ShowRollerShutterScreen = this.ShowRollerShutterScreen;
            dest.CodeRequired = this.CodeRequired;
            dest.AllowLock = this.AllowLock;
            dest.ExitLogout = this.ExitLogout;
            dest.Var1U = this.Var1U;
            dest.NoOfDecimalPlaces = this.NoOfDecimalPlaces;
            dest.SleepTime = this.SleepTime;
            dest.VoiceSequence = this.VoiceSequence;
            dest.Place = this.Place;
            dest.PageNo = this.PageNo;
            dest.Column = this.Column;
            dest.ColumnSpan = this.ColumnSpan;
            dest.Row = this.Row;
            dest.RowSpan = this.RowSpan;
            dest.Image = this.Image;
            dest.ClickImage = this.ClickImage;
            dest.SrcImage = this.SrcImage;
            dest.Type = this.Type;
            dest.TypeName = this.TypeName;
            dest.Icon = this.Icon;
            dest.WidgetWidth = this.WidgetWidth;
            dest.WidgetHeight = this.WidgetHeight;
            dest.Input = this.Input != null ? this.Input.Clone() : (Input)null;
            dest.InputSet = this.InputSet != null ? this.InputSet.Clone() : (InputSet)null;
            dest.AnalogInput = this.AnalogInput != null ? this.AnalogInput.Clone() : (AnalogInput)null;
            dest.AnalogInputSet = this.AnalogInputSet != null ? this.AnalogInputSet.Clone() : (AnalogInputSet)null;
            dest.Output = this.Output != null ? this.Output.Clone() : (Output)null;
            dest.OutputSet = this.OutputSet != null ? this.OutputSet.Clone() : (OutputSet)null;
            dest.Zone = this.Zone != null ? this.Zone.Clone() : (Zone)null;
            dest.ZoneSet = this.ZoneSet != null ? this.ZoneSet.Clone() : (ZoneSet)null;
            this.Actions = this.Actions != null ? new List<MenuItem>((IEnumerable<MenuItem>)this.Actions) : (List<MenuItem>)null;
            dest.TempSensor = this.TempSensor != null ? this.TempSensor.Clone() : (TempSensor)null;
            dest.WirelessSensorSet = this.WirelessSensorSet != null ? this.WirelessSensorSet.Clone() : (WirelessSensorSet)null;
            dest.TempSensorSet = this.TempSensorSet != null ? this.TempSensorSet.Clone() : (TempSensorSet)null;
        }

        public enum Types : byte
        {
            Empty = 0,
            Arm = 1,
            ArmNight = 2,
            Disarm = 3,
            Outputs = 4,
            Input = 5,
            Temperature = 6,
            Inputs = 7,
            InputMap = 8,
            Thermostat = 9,
            Users = 10, // 0x0A
            Settings = 11, // 0x0B
            Events = 12, // 0x0C
            Failures = 13, // 0x0D
            Analog = 14, // 0x0E
            OnOff = 15, // 0x0F
            OneZero = 16, // 0x10
            Bulb = 17, // 0x11
            BlindUp = 18, // 0x12
            BlindDown = 19, // 0x13
            Gate = 20, // 0x14
            Garage = 21, // 0x15
            Down = 22, // 0x16
            Up = 23, // 0x17
            Left = 24, // 0x18
            Right = 25, // 0x19
            Fan = 26, // 0x1A
            Plug = 27, // 0x1B
            Radiator = 28, // 0x1C
            Sprinkler = 29, // 0x1D
            GardenLight = 30, // 0x1E
            PowerOnOff = 31, // 0x1F
            Switch = 32, // 0x20
            Wicket = 33, // 0x21
            OutputGroupOn = 34, // 0x22
            OutputGroupOff = 35, // 0x23
            WirelessSensors = 36, // 0x24
            Information = 37, // 0x25
            Fire = 38, // 0x26
            Panic = 39, // 0x27
            Prepaid = 40, // 0x28
            Messages = 41, // 0x29
            Exit = 42, // 0x2A
            Next = 43, // 0x2B
            Prev = 44, // 0x2C
            AnalogThresholds = 45, // 0x2D
            Humidity = 46, // 0x2E
            HumidityThresholds = 47, // 0x2F
            RollerShutter = 93, // 0x5D
            Logs = 94, // 0x5E
            Sleep = 95, // 0x5F
            LockInputs = 96, // 0x60
            UnlockInputs = 97, // 0x61
            Macro = 98, // 0x62
            Configurable = 99, // 0x63
        }

        public struct ImageSet
        {
            public ImageSet(string image, string clickImage)
            {
                this.Image = image;
                this.ClickImage = clickImage;
            }

            public bool Equals(MenuItem.ImageSet set) => !(set.Image != this.Image) && !(set.ClickImage != this.ClickImage);

            public string Image { get; set; }

            public string ClickImage { get; set; }
        }
    }
}