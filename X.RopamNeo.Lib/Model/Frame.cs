// Type: X.RopamNeo.Lib.Model.Frame

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.RopamNeo.Lib.Model
{
    public class Frame
    {
        private static Encoding encoding = Encoding.GetEncoding("UTF-8");
        public bool log = true;
        public static bool Encrypt = true;
        public bool crc1ok = true;
        public bool crc2ok = true;
        public byte[] tcpKey = Frame.encoding.GetBytes("aaaaaaaaaaaaaaaa");

        public byte[] tcpVector = new byte[16]
        {
      (byte) 4,
      (byte) 90,
      (byte) 118,
      (byte) 67,
      (byte) 90,
      (byte) 234,
      (byte) 45,
      (byte) 11,
      (byte) 123,
      (byte) 90,
      (byte) 87,
      (byte) 43,
      (byte) 98,
      (byte) 23,
      (byte) 123,
      (byte) 89
        };

        public uint ip;
        public static byte HeaderSize = 7;
        public DateTime sendTime;
        public DateTime receiveTime;
        public int sendCnt;
        public static ushort LastIndex = 1;
        public ushort index = 1;
        public ushort length;
        public byte type;
        public byte[] data;
        private byte crc1;
        private byte crc2;

        public void Reset()
        {
            this.tcpKey = Frame.encoding.GetBytes("aaaaaaaaaaaaaaaa");
            this.tcpVector = new byte[16]
            {
        (byte) 4,
        (byte) 90,
        (byte) 118,
        (byte) 67,
        (byte) 90,
        (byte) 234,
        (byte) 45,
        (byte) 11,
        (byte) 123,
        (byte) 90,
        (byte) 87,
        (byte) 43,
        (byte) 98,
        (byte) 23,
        (byte) 123,
        (byte) 89
            };
            this.ClearData();
        }

        public void SetTcpKey(string tcpKey) => this.tcpKey = Frame.encoding.GetBytes(tcpKey);

        public void SetTcpVector(byte[] tcpVector) => this.tcpVector = tcpVector;

        public void SetIp(byte[] bytes) => this.ip = BitConverter.ToUInt32(new byte[4]
        {
      bytes[3],
      bytes[2],
      bytes[1],
      bytes[0]
        }, 0);

        public string GetIp() => string.Join<byte>(".", ((IEnumerable<byte>)BitConverter.GetBytes(this.ip)).Reverse<byte>());

        public void Load(byte[] bytes)
        {
            this.index = BitConverter.ToUInt16(new byte[2]
            {
        bytes[0],
        bytes[1]
            }, 0);
            this.length = BitConverter.ToUInt16(new byte[2]
            {
        bytes[2],
        bytes[3]
            }, 0);
            this.crc2 = bytes[(int)Frame.HeaderSize + (int)this.length - 1];
            this.crc2ok = (int)this.crc2 == (int)Frame.GetCRC(bytes, 0, (int)Frame.HeaderSize + (int)this.length - 1);
            if (this.index != ushort.MaxValue)
            {
                if (Frame.Encrypt)
                {
                    this.tcpVector[0] = bytes[0];
                    this.tcpVector[1] = bytes[1];
                    VMPC.Encode(bytes, 4, (int)Frame.HeaderSize + (int)this.length - 1, this.tcpKey, this.tcpVector);
                }
                this.type = bytes[4];
                this.data = new byte[(int)this.length];
                for (int index = 0; index < (int)this.length; ++index)
                    this.data[index] = bytes[5 + index];
            }
            else
            {
                if (Frame.Encrypt)
                    VMPC.Encode(bytes, 13, (int)Frame.HeaderSize + (int)this.length - 1, this.tcpKey, this.tcpVector);
                this.type = bytes[4];
                this.data = new byte[(int)this.length - 8];
                for (int index = 0; index < (int)this.length - 8; ++index)
                    this.data[index] = bytes[13 + index];
            }
            this.crc1 = bytes[(int)Frame.HeaderSize + (int)this.length - 2];
            this.crc1ok = (int)this.crc1 == (int)Frame.GetCRC(bytes, 4, (int)Frame.HeaderSize + (int)this.length - 2);
        }

        public byte[] ToBytes()
        {
            this.length = this.data != null ? (ushort)this.data.Length : (ushort)0;
            byte[] bytes = new byte[(int)Frame.HeaderSize + (int)this.length];
            bytes[0] = BitConverter.GetBytes(this.index)[0];
            bytes[1] = BitConverter.GetBytes(this.index)[1];
            bytes[2] = BitConverter.GetBytes(this.length)[0];
            bytes[3] = BitConverter.GetBytes(this.length)[1];
            bytes[4] = this.type;
            for (int index = 0; index < (int)this.length; ++index)
                bytes[5 + index] = this.data[index];
            bytes[(int)Frame.HeaderSize + (int)this.length - 2] = Frame.GetCRC(bytes, 4, bytes.Length - 2);
            if (Frame.Encrypt)
            {
                this.tcpVector[0] = bytes[0];
                this.tcpVector[1] = bytes[1];
                VMPC.Encode(bytes, 4, (int)Frame.HeaderSize + (int)this.length - 1, this.tcpKey, this.tcpVector);
            }
            bytes[(int)Frame.HeaderSize + (int)this.length - 1] = Frame.GetCRC(bytes, 0, bytes.Length - 1);
            return bytes;
        }

        public bool CheckCRC1() => this.crc1ok;

        public bool CheckCRC2() => this.crc2ok;

        private static byte GetCRC(byte[] bytes, int start, int end)
        {
            byte num1 = 0;
            for (int index1 = start; index1 < end; ++index1)
            {
                byte num2 = bytes[index1];
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    if ((((int)num2 ^ (int)num1) & 1) == 1)
                        num1 = (byte)((uint)(byte)(((int)num1 ^ 24) >> 1) | 128U);
                    else
                        num1 >>= 1;
                    num2 >>= 1;
                }
            }
            return num1;
        }

        public override string ToString() => this.ToString((string)null);

        public string ToString(string id)
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            stringBuilder1.Append("\r\n");
            stringBuilder1.Append("Frame " + (id != null ? "(" + id + ") " : "") + "{\r\n");
            stringBuilder1.Append("  index:    " + (object)this.index + "\r\n");
            stringBuilder1.Append("  length:   " + (object)(ushort)(this.data != null ? (int)(ushort)this.data.Length : 0) + "\r\n");
            switch (this.type)
            {
                case 0:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - LOGIN\r\n");
                    break;

                case 1:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - NSUPPORTED\r\n");
                    break;

                case 2:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - PINGFR\r\n");
                    break;

                case 3:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - SETOUT\r\n");
                    break;

                case 4:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - SETOUTS\r\n");
                    break;

                case 5:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - GETCONFIG\r\n");
                    break;

                case 6:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - CONFIG\r\n");
                    break;

                case 7:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - ARM\r\n");
                    break;

                case 8:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - DISARM\r\n");
                    break;

                case 9:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - GETEVENTS\r\n");
                    break;

                case 10:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - EVENTS\r\n");
                    break;

                case 11:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - MESSAGE\r\n");
                    break;

                case 12:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - LOCKINPUTS\r\n");
                    break;

                case 13:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - LOGOUT\r\n");
                    break;

                case 14:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - ACK\r\n");
                    break;

                case 15:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - NACK\r\n");
                    break;

                case 16:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - STATUS\r\n");
                    break;

                case 17:
                    stringBuilder1.Append("  type:     " + (object)this.type + " - RECONNECT\r\n");
                    break;

                default:
                    stringBuilder1.Append("  type:     " + (object)this.type + "\r\n");
                    break;
            }
            if (this.data != null && this.data.Length != 0)
            {
                StringBuilder stringBuilder2 = new StringBuilder("[");
                for (int index = 0; index < this.data.Length; ++index)
                    stringBuilder2.Append(index == 0 ? this.data[index].ToString() : "," + this.data[index].ToString());
                stringBuilder2.Append("] ");
                stringBuilder1.Append("  data:     " + stringBuilder2.ToString() + "\r\n");
            }
            stringBuilder1.Append("}");
            return stringBuilder1.ToString();
        }

        public Frame Clone() => new Frame()
        {
            index = this.index,
            length = this.length,
            type = this.type,
            data = this.data,
            crc1 = this.crc1,
            crc2 = this.crc2
        };

        public Frame CloneWithoutData()
        {
            Frame frame = this.Clone();
            frame.length = (ushort)0;
            frame.data = (byte[])null;
            return frame;
        }

        public void SetString(string data)
        {
            this.data = new byte[data.Length];
            for (int index = 0; index < this.data.Length; ++index)
                this.data[index] = (byte)data[index];
        }

        public byte[] SetRandomData(int len)
        {
            Random random = new Random();
            byte[] numArray = new byte[len];
            for (int index = 0; index < len; ++index)
                numArray[index] = (byte)(random.Next() % 256);
            this.data = numArray;
            return numArray;
        }

        public byte[] GetData(int idx)
        {
            int length = this.data.Length - idx;
            byte[] numArray = new byte[length];
            Array.Copy((Array)this.data, idx, (Array)numArray, 0, length);
            return numArray;
        }

        public byte[] GetData(int idx, int len)
        {
            byte[] numArray = new byte[len];
            Array.Copy((Array)this.data, idx, (Array)numArray, 0, len);
            return numArray;
        }

        public ushort GetUshort() => this.GetUshort(0);

        public ushort GetUshort(int idx) => BitConverter.ToUInt16(new byte[2]
        {
      this.data[idx],
      this.data[idx + 1]
        }, 0);

        public int GetInt() => this.GetInt(0);

        public int GetInt(int idx) => BitConverter.ToInt32(new byte[4]
        {
      this.data[idx],
      this.data[idx + 1],
      this.data[idx + 2],
      this.data[idx + 3]
        }, 0);

        public void SetUshort(ushort val)
        {
            this.data = new byte[2];
            this.SetUshort(val, 0);
        }

        public void SetUshort(ushort val, int idx)
        {
            this.data[idx] = BitConverter.GetBytes(val)[0];
            this.data[idx + 1] = BitConverter.GetBytes(val)[1];
        }

        public string GetString() => this.GetString(Frame.encoding);

        public string GetString(Encoding encoding) => Frame.GetString(this.data, 0, this.data.Length, encoding);

        public string GetString(int idx)
        {
            int len = this.data.Length - idx;
            return Frame.GetString(this.data, idx, len, Frame.encoding);
        }

        public string GetString(int idx, Encoding encoding)
        {
            int len = this.data.Length - idx;
            return Frame.GetString(this.data, idx, len, encoding);
        }

        public string GetString(int idx, int len) => Frame.GetString(this.data, idx, len, Frame.encoding);

        public string GetString(int idx, int len, Encoding encoding) => Frame.GetString(this.data, idx, len, encoding);

        public static string GetString(byte[] data, int start, int len, Encoding encoding)
        {
            if (data == null)
                return (string)null;
            int num = -1;
            for (int index = start; index < start + len; ++index)
            {
                if (data[index] == (byte)0)
                {
                    num = index;
                    break;
                }
            }
            return num == -1 ? encoding.GetString(data, start, len) : encoding.GetString(data, start, num - start);
        }

        public void ClearData() => this.data = (byte[])null;

        public void AddData(int datapart) => this.AddData(BitConverter.GetBytes(datapart));

        public void AddData(uint datapart) => this.AddData(BitConverter.GetBytes(datapart));

        public void AddData(ushort datapart) => this.AddData(BitConverter.GetBytes(datapart));

        public void AddData(float datapart) => this.AddData(BitConverter.GetBytes(datapart));

        public byte[] AddRandomData(int len)
        {
            Random random = new Random();
            byte[] datapart = new byte[len];
            for (int index = 0; index < len; ++index)
                datapart[index] = (byte)(random.Next() % 256);
            this.AddData(datapart);
            return datapart;
        }

        public void AddData(string datapart) => this.AddData(Frame.encoding.GetBytes(datapart));

        public void AddData(byte data) => this.AddData(new byte[1]
        {
      data
        });

        public void AddData(byte[] datapart)
        {
            if (datapart == null || datapart.Length == 0)
                return;
            if (this.data == null)
            {
                this.data = datapart;
            }
            else
            {
                byte[] numArray = new byte[this.data.Length + datapart.Length];
                Array.Copy((Array)this.data, 0, (Array)numArray, 0, this.data.Length);
                Array.Copy((Array)datapart, 0, (Array)numArray, this.data.Length, datapart.Length);
                this.data = numArray;
            }
        }

        public enum Types : byte
        {
            Login = 0,
            Nsupported = 1,
            Pingfr = 2,
            SetOut = 3,
            SetOuts = 4,
            GetConfig = 5,
            Config = 6,
            Arm = 7,
            DisArm = 8,
            GetEvents = 9,
            Events = 10, // 0x0A
            Message = 11, // 0x0B
            LockInputs = 12, // 0x0C
            Logout = 13, // 0x0D
            Ack = 14, // 0x0E
            Nack = 15, // 0x0F
            Status = 16, // 0x10
            Reconnect = 17, // 0x11
            SmsVirtual = 18, // 0x12
            Ussd = 19, // 0x13
            CheckAccess = 30, // 0x1E
            ReadUserNames = 31, // 0x1F
            DeleteUserCodes = 32, // 0x20
            ChangeUserCode = 33, // 0x21
            NewUserCode = 34, // 0x22
            ServiceConnectRequest = 35, // 0x23
            ThermostatSetMode = 36, // 0x24
            ThermostatSetPoint = 37, // 0x25
            ThermostatSetProfile = 38, // 0x26
            ThermostatGetProfile = 39, // 0x27
            ExtendedStatus = 40, // 0x28
            OpenWicket = 41, // 0x29
            Panic = 42, // 0x2A
            Fire = 43, // 0x2B
            UserChange = 44, // 0x2C
            GetUserMask = 45, // 0x2D
            SendMessage = 46, // 0x2E
            SyncUserMask = 47, // 0x2F
            Shutter = 48, // 0x30
            ShuttersConfig = 49, // 0x31
            SilentClose = 100, // 0x64
        }
    }
}