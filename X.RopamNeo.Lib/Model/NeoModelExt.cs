// Type: X.RopamNeo.Lib.Model.NeoModelExt

using X.RopamNeo.Lib.Model.Beans;
using System;
using System.Globalization;

namespace X.RopamNeo.Lib.Model
{
    public class NeoModelExt
    {
        public float ThermostatSetPoint;
        public byte ThermostatMode;
        public bool ThermostatRealState;
        public bool ThermostatWindowOpened;
        public byte[] ThermostatHistogram;
        public WirelessSensor[] WirelessSensors;

        public NeoModelExt()
        {
            this.ThermostatHistogram = new byte[24];
            this.WirelessSensors = new WirelessSensor[4];
        }

        public NeoModelExt(string content)
        {
            try
            {
                int num1 = 0;
                if (!content.StartsWith("!7"))
                    throw new ParseStatusException("Bad prefix");
                int num2 = num1 + 2;
                while (content.Length > num2)
                {
                    char ch = content[num2];
                    ++num2;
                    switch (ch)
                    {
                        case '1':
                            this.ThermostatSetPoint = BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(long.Parse(content.Substring(num2, 8), NumberStyles.HexNumber))), 0);
                            int num3 = num2 + 8;
                            string str1 = content;
                            int startIndex = num3;
                            int num4 = startIndex + 1;
                            this.ThermostatMode = byte.Parse(str1.Substring(startIndex, 1));
                            string str2 = content;
                            int index1 = num4;
                            int num5 = index1 + 1;
                            this.ThermostatRealState = str2[index1] == '1';
                            string str3 = content;
                            int index2 = num5;
                            num2 = index2 + 1;
                            this.ThermostatWindowOpened = str3[index2] == '1';
                            this.ThermostatHistogram = new byte[24];
                            for (int index3 = 0; index3 < 24; ++index3)
                            {
                                this.ThermostatHistogram[index3] = byte.Parse(content.Substring(num2, 2), NumberStyles.HexNumber);
                                num2 += 2;
                            }
                            continue;
                        case '2':
                            this.WirelessSensors = new WirelessSensor[4];
                            for (int index3 = 0; index3 < this.WirelessSensors.Length; ++index3)
                            {
                                this.WirelessSensors[index3] = new WirelessSensor(content.Substring(num2, 9));
                                this.WirelessSensors[index3].No = index3;
                                num2 += 9;
                            }
                            continue;
                        default:
                            continue;
                    }
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
    }
}