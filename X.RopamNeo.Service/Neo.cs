using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.RopamNeo.Lib.Model;
using X.RopamNeo.Lib.Model.Beans;
using X.RopamNeo.Service.Helpers;

namespace X.RopamNeo.Service
{
    public class Neo
    {
        private InputHelper inputHelper = new InputHelper();

        public void Start()
        {
            Console.WriteLine("RopamNeo integator (homeassistant/domoticz/openhab)\r\n");
            Console.WriteLine(Config.Settings.ToString());

            Proces().Wait();
        }

        private async Task Proces()
        {
            inputHelper.InputsInit();

            var site = new Site
            {
                TcpCode = Config.Settings.NeoGsmTcpCode,
                Code = Config.Settings.NeoGsmUserCode,
                Ip = Config.Settings.NeoGsmDeviceIp,
                Port = Config.Settings.NeoGsmDevicePort,
                DeviceId = Config.Settings.NeoGsmDeviceId,
            };

            var con = new SiteConnection();

            con.Site = site;

            con.OnStatus = OnStatus;
            con.OnConfig = OnConfig;

            while (true)
            {
                bool viaBridge;
                var conOk = con.Connect(false, out viaBridge);

                Log.L.Trace("Loguję...");
                var l1 = con.Login(viaBridge);

                con.Start();
                con.Close(1);
            }
        }

        private void OnConfig(Site site, Lib.Model.Beans.Config config)
        {
        }

        private void OnStatus(Site site, NeoModel neoModel)
        {
            inputHelper.InputsStatesHandler(neoModel.Inputs);
        }
    }
}