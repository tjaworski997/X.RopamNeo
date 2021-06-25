using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.RopamNeo.Service.BO
{
    public class Settings
    {
        //Na zaś
        public bool RunAsService { get; set; }

        public string NeoGsmDeviceIp { get; set; }
        public int NeoGsmDevicePort { get; set; }
        public string NeoGsmTcpCode { get; set; }
        public string NeoGsmUserCode { get; set; }

        public string NeoGsmDeviceId { get; set; }

        public Comunication.Parameters ComunicationParameters { get; set; }

        public override string ToString()
        {
            return $@"Ustawienia:
NeoGsmDeviceIp:     {NeoGsmDeviceIp}
NeoGsmDevicePort:   {NeoGsmDevicePort}
NeoGsmDeviceId:     {NeoGsmDeviceId}
NeoGsmTcpCode:      {NeoGsmTcpCode}
NeoGsmUserCode:     {NeoGsmUserCode}
";
        }
    }
}