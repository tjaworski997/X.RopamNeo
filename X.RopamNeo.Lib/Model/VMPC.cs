// Type: X.RopamNeo.Lib.Model.VMPC

using System;
using System.Text;

namespace X.RopamNeo.Lib.Model
{
    public class VMPC
    {
        public static void Encode(
          byte[] bytes,
          int startIdx,
          int endIdx,
          byte[] key,
          byte[] vector,
          int vectorLen = 16)
        {
            byte[] numArray = new byte[256];
            if (endIdx - startIdx <= 0)
                return;
            byte num1 = 0;
            for (int index = 0; index < 256; ++index)
                numArray[index] = (byte)index;
            for (int index = 0; index <= 767; ++index)
            {
                byte num2 = (byte)(index % 256);
                num1 = numArray[((int)num1 + (int)numArray[(int)num2] + (int)key[index % key.Length]) % 256];
                byte num3 = numArray[(int)num2];
                numArray[(int)num2] = numArray[(int)num1];
                numArray[(int)num1] = num3;
            }
            for (int index = 0; index <= 767; ++index)
            {
                byte num2 = (byte)(index % 256);
                num1 = numArray[((int)num1 + (int)numArray[(int)num2] + (int)vector[index % vectorLen]) % 256];
                byte num3 = numArray[(int)num2];
                numArray[(int)num2] = numArray[(int)num1];
                numArray[(int)num1] = num3;
            }
            byte num4 = 0;
            for (int index = startIdx; index < endIdx; ++index)
            {
                num1 = numArray[((int)num1 + (int)numArray[(int)num4]) % 256];
                bytes[index] = (byte)((uint)bytes[index] ^ (uint)numArray[((int)numArray[(int)numArray[(int)num1]] + 1) % 256]);
                byte num2 = numArray[(int)num4];
                numArray[(int)num4] = numArray[(int)num1];
                numArray[(int)num1] = num2;
                ++num4;
            }
        }

        public static byte[] StringToByteArray(string text)
        {
            char[] charArray = text.ToCharArray();
            byte[] numArray = new byte[charArray.Length];
            for (int index = 0; index < charArray.Length; ++index)
                numArray[index] = (byte)charArray[index];
            return numArray;
        }

        public static string ByteArrayToString(byte[] data) => Encoding.UTF8.GetString(data, 0, data.Length);

        public static string EncodeString(string str, string key, string vec)
        {
            if (str == null || string.IsNullOrEmpty(str))
                return str;
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            char[] charArray1 = key.ToCharArray();
            byte[] key1 = new byte[charArray1.Length];
            for (int index = 0; index < charArray1.Length; ++index)
                key1[index] = (byte)charArray1[index];
            char[] charArray2 = vec.ToCharArray();
            byte[] vector = new byte[charArray2.Length];
            for (int index = 0; index < charArray2.Length; ++index)
                vector[index] = (byte)charArray2[index];
            VMPC.Encode(bytes, 0, bytes.Length, key1, vector, vector.Length);
            return Convert.ToBase64String(bytes);
        }

        public static string DecodeString(string str, string key, string vec)
        {
            if (str == null || string.IsNullOrEmpty(str))
                return str;
            byte[] bytes = Convert.FromBase64String(str);
            char[] charArray1 = key.ToCharArray();
            byte[] key1 = new byte[charArray1.Length];
            for (int index = 0; index < charArray1.Length; ++index)
                key1[index] = (byte)charArray1[index];
            char[] charArray2 = vec.ToCharArray();
            byte[] vector = new byte[charArray2.Length];
            for (int index = 0; index < charArray2.Length; ++index)
                vector[index] = (byte)charArray2[index];
            VMPC.Encode(bytes, 0, bytes.Length, key1, vector, vector.Length);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}