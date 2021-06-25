// Type: X.RopamNeo.Lib.Model.NeoModel

using X.RopamNeo.Lib.Model.Beans;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace X.RopamNeo.Lib.Model
{
    public class NeoModel
    {
        public byte Reason;
        public byte ByteRet;
        public Access Access;
        public List<User> Users;
        public ThermostatProfile ThermostatProfile;
        public DateTime ModuleTime;
        public string FirmwareVersion;
        public int FirmwareIntVersion;
        public List<Input> Inputs;
        public List<Output> Outputs;
        public List<Zone> Zones;
        public List<TempSensor> TempSensors;
        public List<AnalogInput> AnalogInputs;
        public List<WirelessSensor> WiredHumSensors;
        public string SupplyVoltage;
        public int NetworkStatus;
        public int WifiNetworkStatus;
        public ulong ModFailCodeBinary;
        public bool[] ModFailCodes;
        public bool ModuleAcOk;
        public string DeviceLang;
        public byte DeviceMode;
        public bool UsingBridge;
        public bool UsingBridgeGprs;
        public bool UsingBridgeWifi;
        public bool UsingLocalPort1;
        public bool UsingLocalPort2;
        public bool UsingRms;
        public bool UsingRmsGprs;
        public bool UsingRmsWifi;
        public bool DuringSms;
        public bool DuringEmail;
        public bool DuringIncomingCall;
        public bool DuringOutgoingCall;
        public bool DuringVar1U;
        public byte RollerShutterCnt;

        public NeoModel()
        {
            this.Access = new Access();
            this.Inputs = new List<Input>();
            for (int index = 0; index < 32; ++index)
                this.Inputs.Add(new Input()
                {
                    No = index,
                    State = (byte)11
                });
            this.Outputs = new List<Output>();
            for (int index = 0; index < 32; ++index)
                this.Outputs.Add(new Output()
                {
                    No = index,
                    State = (byte)0
                });
            this.Zones = new List<Zone>();
            for (int index = 0; index < 2; ++index)
                this.Zones.Add(new Zone()
                {
                    No = index,
                    IsAlarm = false,
                    IsTamper = false,
                    IsReady = false,
                    IsArmed = false,
                    IsNightArmed = false,
                    OnEntrance = false,
                    OnDeparture = false,
                    Selected = false
                });
            this.TempSensors = new List<TempSensor>();
            for (int index = 0; index < 2; ++index)
                this.TempSensors.Add(new TempSensor()
                {
                    No = index,
                    State = (byte)0
                });
            this.AnalogInputs = new List<AnalogInput>();
            for (int index = 0; index < 1; ++index)
                this.AnalogInputs.Add(new AnalogInput()
                {
                    No = index
                });
            this.ModFailCodes = new bool[39];
            this.ModFailCodeBinary = ulong.Parse("00000000", NumberStyles.HexNumber);
            BitArray bitArray = new BitArray(BitConverter.GetBytes(this.ModFailCodeBinary));
            for (int index = 0; index < 39; ++index)
                this.ModFailCodes[index] = bitArray.Get(index);
            for (int index = 0; index < 2; ++index)
                this.WiredHumSensors.Add(new WirelessSensor()
                {
                    No = index,
                    Available = false
                });
            this.DeviceLang = "pl";
        }

        public NeoModel(string content)
        {
            try
            {
                this.Access = new Access();
                int index1 = 0;
                if (content[index1] != '#')
                    throw new ParseStatusException("Bad prefix");
                int index2 = index1 + 1;
                if (content[index2] != '7')
                    throw new ParseStatusException("Bad hardware version");
                int startIndex1 = index2 + 1;
                this.FirmwareVersion = string.Format("{0},{1}", (object)content.Substring(startIndex1, 1), (object)content.Substring(startIndex1 + 1, 1));
                this.FirmwareIntVersion = Convert.ToInt32(content.Substring(startIndex1, 2));
                int startIndex2 = startIndex1 + 2;
                string str = content.Substring(startIndex2, 1);
                this.DeviceLang = str == "p" ? "pl" : (str == "e" ? "en" : "pl");
                int startIndex3 = startIndex2 + 1;
                this.ModuleTime = !(content.Substring(startIndex3, 2) == "00") ? DateTime.ParseExact(content.Substring(startIndex3, 10), "yyMMddHHmm", (IFormatProvider)CultureInfo.InvariantCulture) : DateTime.ParseExact("0101010000", "yyMMddHHmm", (IFormatProvider)CultureInfo.InvariantCulture);
                int num1 = startIndex3 + 10;
                this.Inputs = new List<Input>();
                for (byte index3 = 0; index3 < (byte)32; ++index3)
                {
                    Input input = new Input();
                    input.No = (int)index3;
                    switch (content[num1 + (int)index3])
                    {
                        case '!':
                            input.State = (byte)2;
                            break;

                        case '0':
                            input.State = (byte)0;
                            break;

                        case '1':
                            input.State = (byte)1;
                            break;

                        case '?':
                            input.State = (byte)10;
                            break;

                        case 'A':
                            input.State = (byte)7;
                            break;

                        case 'B':
                        case 'b':
                            input.State = (byte)4;
                            break;

                        case 'F':
                        case 'f':
                            input.State = (byte)5;
                            break;

                        case 'W':
                            input.State = (byte)9;
                            break;

                        case 'X':
                            input.State = (byte)3;
                            break;

                        case 'a':
                            input.State = (byte)6;
                            break;

                        case 'i':
                            input.State = (byte)12;
                            break;

                        case 'w':
                            input.State = (byte)8;
                            break;

                        default:
                            input.State = (byte)11;
                            break;
                    }
                    this.Inputs.Add(input);
                }
                int num2 = num1 + 32;
                this.Outputs = new List<Output>();
                for (byte index3 = 0; index3 < (byte)32; ++index3)
                {
                    Output output = new Output();
                    output.No = (int)index3;
                    switch (content[num2 + (int)index3])
                    {
                        case '0':
                            output.State = (byte)0;
                            break;

                        case '1':
                            output.State = (byte)1;
                            break;

                        case 'F':
                            output.State = (byte)2;
                            break;

                        case 'N':
                            output.State = (byte)6;
                            break;

                        case 'X':
                            output.State = (byte)4;
                            break;

                        case 'f':
                            output.State = (byte)3;
                            break;

                        case 'n':
                            output.State = (byte)7;
                            break;

                        case 'x':
                            output.State = (byte)5;
                            break;

                        default:
                            output.State = (byte)8;
                            break;
                    }
                    this.Outputs.Add(output);
                }
                int startIndex4 = num2 + 32;
                this.Zones = new List<Zone>();
                for (byte index3 = 0; index3 < (byte)2; ++index3)
                {
                    Zone zone = new Zone();
                    zone.No = (int)index3;
                    byte num3 = byte.Parse(content.Substring(startIndex4, 2), NumberStyles.HexNumber);
                    zone.IsArmed = ((uint)num3 & 1U) > 0U;
                    zone.IsNightArmed = (uint)((int)num3 >> 1 & 1) > 0U;
                    zone.OnDeparture = (uint)((int)num3 >> 2 & 1) > 0U;
                    zone.OnEntrance = (uint)((int)num3 >> 3 & 1) > 0U;
                    zone.IsAlarm = (uint)((int)num3 >> 4 & 1) > 0U;
                    zone.IsTamper = (uint)((int)num3 >> 5 & 1) > 0U;
                    zone.IsReady = (uint)((int)num3 >> 6 & 1) > 0U;
                    this.Zones.Add(zone);
                    startIndex4 += 2;
                }
                for (int index3 = 0; index3 < 2; ++index3)
                {
                    ushort num3 = ushort.Parse(content.Substring(startIndex4, 4), NumberStyles.HexNumber);
                    this.Zones[index3].Timer = num3;
                    startIndex4 += 4;
                }
                this.TempSensors = new List<TempSensor>();
                for (int index3 = 0; index3 < 2; ++index3)
                {
                    TempSensor tempSensor = new TempSensor();
                    tempSensor.No = index3;
                    string s = content.Substring(startIndex4, 4);
                    if ("!!!!".Equals(s))
                        tempSensor.State = (byte)1;
                    else if ("xxxx".Equals(s))
                    {
                        tempSensor.State = (byte)2;
                    }
                    else
                    {
                        tempSensor.State = (byte)0;
                        tempSensor.Value = Convert.ToSingle((short)int.Parse(s, NumberStyles.HexNumber)) / 10f;
                    }
                    this.TempSensors.Add(tempSensor);
                    startIndex4 += 4;
                }
                this.ModuleAcOk = content.Substring(startIndex4, 1) == "0";
                int startIndex5 = startIndex4 + 1;
                this.SupplyVoltage = ((float)long.Parse(content.Substring(startIndex5, 2), NumberStyles.HexNumber) / 10f).ToString().Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                int startIndex6 = startIndex5 + 2;
                this.NetworkStatus = Convert.ToInt32(content.Substring(startIndex6, 1));
                int startIndex7 = startIndex6 + 1;
                this.WifiNetworkStatus = Convert.ToInt32(content.Substring(startIndex7, 1));
                int startIndex8 = startIndex7 + 1;
                this.ModFailCodes = new bool[39];
                this.ModFailCodeBinary = ulong.Parse(content.Substring(startIndex8, 16), NumberStyles.HexNumber);
                BitArray bitArray = new BitArray(BitConverter.GetBytes(this.ModFailCodeBinary));
                for (int index3 = 0; index3 < 39; ++index3)
                    this.ModFailCodes[index3] = bitArray.Get(index3);
                int num4 = startIndex8 + 16;
                this.AnalogInputs = new List<AnalogInput>();
                for (int index3 = 0; index3 < 1; ++index3)
                {
                    float single = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(num4 + index3 * 10, 8), NumberStyles.HexNumber)), 0);
                    this.AnalogInputs.Add(new AnalogInput()
                    {
                        No = index3,
                        Value = single,
                        Unit = content.Substring(num4 + 8 + index3 * 10, 2).Trim()
                    });
                }
                int index4 = num4 + 10;
                switch (content[index4])
                {
                    case 'd':
                        this.DeviceMode = (byte)2;
                        break;

                    case 'n':
                        this.DeviceMode = (byte)1;
                        break;

                    case 's':
                        this.DeviceMode = (byte)0;
                        break;
                }
                int startIndex9 = index4 + 1;
                byte num5 = byte.Parse(content.Substring(startIndex9, 2), NumberStyles.HexNumber);
                this.UsingBridge = ((uint)num5 & 1U) > 0U;
                this.UsingBridgeGprs = (uint)((int)num5 >> 1 & 1) > 0U;
                this.UsingBridgeWifi = ((int)num5 >> 1 & 1) == 0;
                this.UsingLocalPort1 = (uint)((int)num5 >> 2 & 1) > 0U;
                this.UsingLocalPort2 = (uint)((int)num5 >> 3 & 1) > 0U;
                this.UsingRms = (uint)((int)num5 >> 4 & 1) > 0U;
                this.UsingRmsGprs = (uint)((int)num5 >> 5 & 1) > 0U;
                this.UsingRmsWifi = ((int)num5 >> 5 & 1) == 0;
                int startIndex10 = startIndex9 + 2;
                this.WiredHumSensors = new List<WirelessSensor>();
                for (int index3 = 0; index3 < 2; ++index3)
                {
                    byte num3 = byte.Parse(content.Substring(startIndex10, 2), NumberStyles.HexNumber);
                    WirelessSensor wirelessSensor = new WirelessSensor();
                    wirelessSensor.No = index3;
                    switch (num3)
                    {
                        case 254:
                            wirelessSensor.Available = false;
                            wirelessSensor.Connected = false;
                            break;

                        case byte.MaxValue:
                            wirelessSensor.Available = true;
                            wirelessSensor.Connected = false;
                            break;

                        default:
                            wirelessSensor.Available = true;
                            wirelessSensor.Connected = true;
                            wirelessSensor.Humidity = num3;
                            break;
                    }
                    this.WiredHumSensors.Add(wirelessSensor);
                    startIndex10 += 2;
                }
                byte num6 = byte.Parse(content.Substring(startIndex10, 2), NumberStyles.HexNumber);
                this.DuringSms = ((uint)num6 & 1U) > 0U;
                this.DuringEmail = (uint)((int)num6 >> 1 & 1) > 0U;
                this.DuringIncomingCall = (uint)((int)num6 >> 2 & 1) > 0U;
                this.DuringOutgoingCall = (uint)((int)num6 >> 3 & 1) > 0U;
                this.DuringVar1U = (uint)((int)num6 >> 4 & 1) > 0U;
                int startIndex11 = startIndex10 + 2;
                if (this.FirmwareIntVersion < 13)
                    return;
                this.RollerShutterCnt = byte.Parse(content.Substring(startIndex11, 2), NumberStyles.HexNumber);
                int startIndex12 = startIndex11 + 2;
                for (int index3 = 0; index3 < (int)this.RollerShutterCnt; ++index3)
                {
                    int num3 = (int)byte.Parse(content.Substring(startIndex12, 2), NumberStyles.HexNumber);
                    startIndex12 += 2;
                }
                for (int index3 = 0; index3 < 4; ++index3)
                {
                    int num3 = (int)byte.Parse(content.Substring(startIndex12, 1), NumberStyles.HexNumber);
                    ++startIndex12;
                }
            }
            catch (ParseStatusException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ParseStatusException(ex.Message);
            }
        }

        public string ToStatus()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("#5");
            stringBuilder.Append(this.ModuleTime.ToString("yyMMddHHmm"));
            if (this.FirmwareVersion != null && this.FirmwareVersion.Length > 1)
                stringBuilder.Append((int)this.FirmwareVersion[0] + (int)this.FirmwareVersion[2]);
            else
                stringBuilder.Append("00");
            foreach (Input input in this.Inputs)
            {
                switch (input.State)
                {
                    case 0:
                        stringBuilder.Append('0');
                        continue;
                    case 1:
                        stringBuilder.Append('1');
                        continue;
                    case 2:
                        stringBuilder.Append('!');
                        continue;
                    case 3:
                        stringBuilder.Append('X');
                        continue;
                    case 4:
                        stringBuilder.Append('b');
                        continue;
                    case 6:
                        stringBuilder.Append('a');
                        continue;
                    case 7:
                        stringBuilder.Append('A');
                        continue;
                    case 8:
                        stringBuilder.Append('w');
                        continue;
                    case 9:
                        stringBuilder.Append('W');
                        continue;
                    case 10:
                        stringBuilder.Append('?');
                        continue;
                    case 11:
                        stringBuilder.Append('-');
                        continue;
                    case 12:
                        stringBuilder.Append('i');
                        continue;
                    default:
                        stringBuilder.Append('-');
                        continue;
                }
            }
            foreach (Output output in this.Outputs)
            {
                switch (output.State)
                {
                    case 0:
                        stringBuilder.Append('0');
                        continue;
                    case 1:
                        stringBuilder.Append('1');
                        continue;
                    case 2:
                        stringBuilder.Append('F');
                        continue;
                    case 3:
                        stringBuilder.Append('f');
                        continue;
                    case 4:
                        stringBuilder.Append('X');
                        continue;
                    case 5:
                        stringBuilder.Append('x');
                        continue;
                    case 6:
                        stringBuilder.Append('N');
                        continue;
                    case 7:
                        stringBuilder.Append('n');
                        continue;
                    case 8:
                        stringBuilder.Append('-');
                        continue;
                    default:
                        stringBuilder.Append('-');
                        continue;
                }
            }
            foreach (Zone zone in this.Zones)
            {
                BitArray bitArray = new BitArray(8, false);
                bitArray.Set(0, zone.IsArmed);
                bitArray.Set(1, zone.IsNightArmed);
                bitArray.Set(2, zone.OnDeparture);
                bitArray.Set(3, zone.OnEntrance);
                bitArray.Set(4, zone.IsAlarm);
                bitArray.Set(5, zone.IsTamper);
                bitArray.Set(6, zone.IsReady);
                byte num = 0;
                if (zone.IsArmed)
                    ++num;
                if (zone.IsNightArmed)
                    num += (byte)2;
                if (zone.OnDeparture)
                    num += (byte)4;
                if (zone.OnEntrance)
                    num += (byte)8;
                if (zone.IsAlarm)
                    num += (byte)16;
                if (zone.IsTamper)
                    num += (byte)32;
                if (zone.IsReady)
                    num += (byte)64;
                stringBuilder.Append(string.Format("{0:X}", (object)num).PadLeft(2, '0'));
            }
            foreach (TempSensor tempSensor in this.TempSensors)
            {
                if (tempSensor.State == (byte)1)
                    stringBuilder.Append("!!!!");
                else if (tempSensor.State == (byte)2)
                {
                    stringBuilder.Append("xxxx");
                }
                else
                {
                    int int16 = (int)Convert.ToInt16(tempSensor.Value * 2f);
                    stringBuilder.Append(string.Format("{0:X}", (object)int16).PadLeft(4, '0'));
                }
            }
            if (this.SupplyVoltage != null)
            {
                long num = (long)((double)Convert.ToSingle(this.SupplyVoltage.Replace(',', '.')) * 10.0);
                stringBuilder.Append(string.Format("{0:X}", (object)num).PadLeft(2, '0'));
            }
            else
                stringBuilder.Append("00");
            stringBuilder.Append("--");
            stringBuilder.Append(this.NetworkStatus.ToString());
            stringBuilder.Append(this.WifiNetworkStatus.ToString());
            stringBuilder.Append(string.Format("{0:X}", (object)this.ModFailCodeBinary).PadLeft(8, '0'));
            foreach (AnalogInput analogInput in this.AnalogInputs)
            {
                long int32 = (long)BitConverter.ToInt32(BitConverter.GetBytes(analogInput.Value), 0);
                stringBuilder.Append(string.Format("{0:X}", (object)int32).PadLeft(8, '0'));
                stringBuilder.Append(analogInput.Unit != null ? analogInput.Unit.PadLeft(2) : "  ");
            }
            return stringBuilder.ToString();
        }

        public enum DeviceModes : byte
        {
            Service,
            Work,
            Programming,
        }
    }
}