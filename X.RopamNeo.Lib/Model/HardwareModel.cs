// Type: X.RopamNeo.Lib.Model.HardwareModel

using System;
using System.Globalization;
using System.Text;

namespace X.RopamNeo.Lib.Model
{
    public class HardwareModel
    {
        public byte Temp0AMode { get; set; }

        public byte Temp0BMode { get; set; }

        public byte Temp1AMode { get; set; }

        public byte Temp1BMode { get; set; }

        public byte AnalogAMode { get; set; }

        public byte AnalogBMode { get; set; }

        public byte Hum0AMode { get; set; }

        public byte Hum0BMode { get; set; }

        public byte Hum1AMode { get; set; }

        public byte Hum1BMode { get; set; }

        public float Temp0A { get; set; }

        public float Temp0B { get; set; }

        public float Temp1A { get; set; }

        public float Temp1B { get; set; }

        public float AnalogA { get; set; }

        public float AnalogB { get; set; }

        public byte Hum0A { get; set; }

        public byte Hum0B { get; set; }

        public byte Hum1A { get; set; }

        public byte Hum1B { get; set; }

        public HardwareModel()
        {
        }

        public HardwareModel(string content)
        {
            try
            {
                int index = 0;
                if (content[index] != '*')
                    throw new ParseHardwareException("Bad prefix");
                int startIndex1 = 30;
                this.Temp0A = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(startIndex1, 8), NumberStyles.HexNumber)), 0);
                int startIndex2 = startIndex1 + 8;
                this.Temp0B = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(startIndex2, 8), NumberStyles.HexNumber)), 0);
                int startIndex3 = startIndex2 + 8;
                this.Temp1A = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(startIndex3, 8), NumberStyles.HexNumber)), 0);
                int startIndex4 = startIndex3 + 8;
                this.Temp1B = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(startIndex4, 8), NumberStyles.HexNumber)), 0);
                int startIndex5 = startIndex4 + 8;
                this.AnalogA = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(startIndex5, 8), NumberStyles.HexNumber)), 0);
                int startIndex6 = startIndex5 + 8;
                this.AnalogB = BitConverter.ToSingle(BitConverter.GetBytes((int)long.Parse(content.Substring(startIndex6, 8), NumberStyles.HexNumber)), 0);
                int startIndex7 = startIndex6 + 8;
                this.Hum0A = byte.Parse(content.Substring(startIndex7, 2), NumberStyles.HexNumber);
                int startIndex8 = startIndex7 + 2;
                this.Hum0B = byte.Parse(content.Substring(startIndex8, 2), NumberStyles.HexNumber);
                int startIndex9 = startIndex8 + 2;
                this.Hum1A = byte.Parse(content.Substring(startIndex9, 2), NumberStyles.HexNumber);
                int startIndex10 = startIndex9 + 2;
                this.Hum1B = byte.Parse(content.Substring(startIndex10, 2), NumberStyles.HexNumber);
                int startIndex11 = startIndex10 + 2;
                this.Temp0AMode = Convert.ToByte(content.Substring(startIndex11, 1));
                int startIndex12 = startIndex11 + 1;
                this.Temp0BMode = Convert.ToByte(content.Substring(startIndex12, 1));
                int startIndex13 = startIndex12 + 1;
                this.Temp1AMode = Convert.ToByte(content.Substring(startIndex13, 1));
                int startIndex14 = startIndex13 + 1;
                this.Temp1BMode = Convert.ToByte(content.Substring(startIndex14, 1));
                int startIndex15 = startIndex14 + 1;
                this.Hum0AMode = Convert.ToByte(content.Substring(startIndex15, 1));
                int startIndex16 = startIndex15 + 1;
                this.Hum0BMode = Convert.ToByte(content.Substring(startIndex16, 1));
                int startIndex17 = startIndex16 + 1;
                this.Hum1AMode = Convert.ToByte(content.Substring(startIndex17, 1));
                int startIndex18 = startIndex17 + 1;
                this.Hum1BMode = Convert.ToByte(content.Substring(startIndex18, 1));
                int startIndex19 = startIndex18 + 1;
                this.AnalogAMode = Convert.ToByte(content.Substring(startIndex19, 1));
                int startIndex20 = startIndex19 + 1;
                this.AnalogBMode = Convert.ToByte(content.Substring(startIndex20, 1));
                int num = startIndex20 + 1;
            }
            catch (ParseHardwareException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ParseHardwareException(ex.Message);
            }
        }

        public string ToHardware()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("*11111");
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes(this.Temp0A), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes(this.Temp0B), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes(this.Temp1A), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes(this.Temp1B), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes(this.AnalogA), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes(this.AnalogB), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes((short)this.Hum0A), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes((short)this.Hum0B), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes((short)this.Hum1A), 0)).PadLeft(8, '0'));
            stringBuilder.Append(string.Format("{0:X}", (object)(long)BitConverter.ToInt32(BitConverter.GetBytes((short)this.Hum1B), 0)).PadLeft(8, '0'));
            stringBuilder.Append(this.Temp0AMode);
            stringBuilder.Append(this.Temp0BMode);
            stringBuilder.Append(this.Hum0AMode);
            stringBuilder.Append(this.Hum0BMode);
            stringBuilder.Append(this.Hum1AMode);
            stringBuilder.Append(this.Hum1BMode);
            stringBuilder.Append(this.AnalogAMode);
            stringBuilder.Append(this.AnalogBMode);
            return stringBuilder.ToString();
        }

        public enum Modes : byte
        {
            Up,
            Down,
            None,
        }
    }
}