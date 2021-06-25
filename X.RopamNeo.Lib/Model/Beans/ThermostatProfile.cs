// Type: X.RopamNeo.Lib.Model.Beans.ThermostatProfile

using System;
using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class ThermostatProfile
    {
        public byte Id { get; set; }

        public float[] Presents { get; set; }

        public ThermostatProfile.TermostatDay[] Days { get; set; }

        public static ushort GetLength() => 105;

        public byte[] ToBytes()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add(this.Id);
            for (int index = 0; index < this.Presents.Length; ++index)
                byteList.AddRange((IEnumerable<byte>)BitConverter.GetBytes(this.Presents[index]));
            for (int index1 = 0; index1 < this.Days.Length; ++index1)
            {
                ThermostatProfile.TermostatDay day = this.Days[index1];
                for (int index2 = 0; index2 < day.TimesOfDay.Length; ++index2)
                {
                    ThermostatProfile.TermostatTimeOfDay termostatTimeOfDay = day.TimesOfDay[index2];
                    byteList.Add(termostatTimeOfDay.Present);
                    byteList.Add(termostatTimeOfDay.Hour);
                    byteList.Add(termostatTimeOfDay.Minute);
                }
            }
            return byteList.ToArray();
        }

        public static ThermostatProfile FromBytes(byte[] bytes)
        {
            ThermostatProfile thermostatProfile = new ThermostatProfile();
            thermostatProfile.Id = bytes[0];
            thermostatProfile.Presents = new float[5];
            for (int index = 0; index < thermostatProfile.Presents.Length; ++index)
                thermostatProfile.Presents[index] = BitConverter.ToSingle(bytes, 1 + index * 4);
            thermostatProfile.Days = new ThermostatProfile.TermostatDay[7];
            for (int index1 = 0; index1 < thermostatProfile.Days.Length; ++index1)
            {
                thermostatProfile.Days[index1] = new ThermostatProfile.TermostatDay();
                thermostatProfile.Days[index1].Id = (byte)index1;
                thermostatProfile.Days[index1].TimesOfDay = new ThermostatProfile.TermostatTimeOfDay[4];
                for (int index2 = 0; index2 < thermostatProfile.Days[index1].TimesOfDay.Length; ++index2)
                    thermostatProfile.Days[index1].TimesOfDay[index2] = new ThermostatProfile.TermostatTimeOfDay()
                    {
                        No = (byte)index2,
                        Present = bytes[21 + index1 * 12 + index2 * 3],
                        Hour = bytes[21 + index1 * 12 + index2 * 3 + 1],
                        Minute = bytes[21 + index1 * 12 + index2 * 3 + 2]
                    };
            }
            return thermostatProfile;
        }

        public enum PresentTypes : byte
        {
            HiTemp,
            MidTemp,
            NightTemp,
            AwayTemp,
            AntiFrozeTemp,
            ScheduleTemp,
            ManualTemp,
        }

        public enum TimeOfDayTypes : byte
        {
            WakingUp,
            Exit,
            Return,
            Sleeping,
        }

        public class TermostatDay
        {
            public ThermostatProfile.TermostatTimeOfDay[] TimesOfDay;

            public byte Id { get; set; }
        }

        public class TermostatTimeOfDay
        {
            public byte Present { get; set; }

            public byte No { get; set; }

            public byte Hour { get; set; }

            public byte Minute { get; set; }
        }
    }
}