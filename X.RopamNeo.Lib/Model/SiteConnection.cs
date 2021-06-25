// Type: X.RopamNeo.Lib.Model.SiteConnection

using Newtonsoft.Json;

using X.RopamNeo.Lib.Model.Beans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.RopamNeo.Lib.Model
{
    public class SiteConnection
    {
        public static string BridgeHost = "iropam.com";
        public static int BridgePort = 8080;
        public static int DefaultPort = 9999;
        public static string DemoHost = "ropam.net";
        public static int DemoPort = 9999;
        public static string DemoTcpCode = "9999999999999999";
        public static string DemoDeviceId = "9999999999999999";
        public static string DemoDevicePhone = "";
        public static string DemoCode = "5555";

        private static byte[] OperatorVector = new byte[16]
        {
      (byte) 103,
      (byte) 82,
      (byte) 187,
      (byte) 28,
      (byte) 161,
      (byte) 237,
      (byte) 191,
      (byte) 65,
      (byte) 115,
      (byte) 43,
      (byte) 151,
      (byte) 95,
      (byte) 187,
      (byte) 36,
      (byte) 205,
      (byte) 32
        };

        private static SiteConnection con;
        private ITcpClient Client;
        public bool Logged;
        public bool Connected;
        public bool IsNeoLicence;
        public byte LicenseType;
        public DateTime LicenseTime;
        public string LicenseId;
        public SiteConnection.Channels Channel;
        public Access Access = new Access();
        private Frame frame = new Frame();
        private static int BUFFER_SIZE = 65536 + (int)Frame.HeaderSize;
        private byte[] buffer = new byte[SiteConnection.BUFFER_SIZE];
        public DateTime LoginTime;
        private DateTime lastPingTime = DateTime.Now;
        private DateTime lastFrame = DateTime.Now;
        private bool isBadFrame;
        private bool working = true;
        private int sleep;
        public bool LongTakingAction;

        public static Dictionary<string, Command> Commands = new Dictionary<string, Command>()
    {
      {
        "addphone",
        new Command()
        {
          Key = "addphone",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} dodajtel {1}"
            },
            {
              "en",
              "{0} addphone {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "dodajtel {tel}"
            },
            {
              "en",
              "addphone {phone}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "dodajtel "
            },
            {
              "en",
              "addphone "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Dodaj telefon"
            },
            {
              "en",
              "Add phone"
            }
          }
        }
      },
      {
        "delphone",
        new Command()
        {
          Key = "delphone",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} usuntel {1}"
            },
            {
              "en",
              "{0} delphone {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "usuntel {tel}"
            },
            {
              "en",
              "delphone {phone}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "usuntel "
            },
            {
              "en",
              "delphone "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Usuń telefon"
            },
            {
              "en",
              "Delete phone"
            }
          }
        }
      },
      {
        "time",
        new Command()
        {
          Key = "time",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} czas {1}"
            },
            {
              "en",
              "{0} time {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "czas {czas w postaci yy, MM, dd, HH, mm}"
            },
            {
              "en",
              "time {time in format yy, MM, dd, HH, mm}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "czas "
            },
            {
              "en",
              "time "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Ustaw czas"
            },
            {
              "en",
              "Set time"
            }
          }
        }
      },
      {
        "code",
        new Command()
        {
          Key = "code",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} kod {1}"
            },
            {
              "en",
              "{0} code {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "kod {nowy kod}"
            },
            {
              "en",
              "code {new code}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "kod "
            },
            {
              "en",
              "code "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Ustaw kod"
            },
            {
              "en",
              "Set code"
            }
          }
        }
      },
      {
        "restart",
        new Command()
        {
          Key = "restart",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} restart"
            },
            {
              "en",
              "{0} restart"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "restart"
            },
            {
              "en",
              "restart"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "restart"
            },
            {
              "en",
              "restart"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Restart"
            },
            {
              "en",
              "Restart"
            }
          }
        }
      },
      {
        "hardware",
        new Command()
        {
          Key = "hardware",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} hardware"
            },
            {
              "en",
              "{0} hardware"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "hardware"
            },
            {
              "en",
              "hardware"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "hardware"
            },
            {
              "en",
              "hardware"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Hardware"
            },
            {
              "en",
              "Hardware"
            }
          }
        }
      },
      {
        "doorlock",
        new Command()
        {
          Key = "doorlock",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} rygiel"
            },
            {
              "en",
              "{0} doorlock"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "rygiel"
            },
            {
              "en",
              "doorlock"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "rygiel"
            },
            {
              "en",
              "doorlock"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Otwórz rygiel"
            },
            {
              "en",
              "Open doorlock"
            }
          }
        }
      },
      {
        "arm",
        new Command()
        {
          Key = "arm",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} zal {1} {2}"
            },
            {
              "en",
              "{0} arm {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "zal {1/2/1,2} {/noc}"
            },
            {
              "en",
              "arm {1/2/1,2} {/night}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "zal"
            },
            {
              "en",
              "arm"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Załącz czuwanie"
            },
            {
              "en",
              "Arm"
            }
          }
        }
      },
      {
        "disarm",
        new Command()
        {
          Key = "disarm",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} wyl {1}"
            },
            {
              "en",
              "{0} disarm {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "wyl {1/2/1,2}"
            },
            {
              "en",
              "disarm {1/2/1,2}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "wyl"
            },
            {
              "en",
              "disarm"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Wyłącz czuwanie"
            },
            {
              "en",
              "Disarm"
            }
          }
        }
      },
      {
        "status",
        new Command()
        {
          Key = "status",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} stan"
            },
            {
              "en",
              "{0} status"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "stan"
            },
            {
              "en",
              "status"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "stan"
            },
            {
              "en",
              "status"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Status systemu"
            },
            {
              "en",
              "System status"
            }
          }
        }
      },
      {
        "zones",
        new Command()
        {
          Key = "zones",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} wejscia"
            },
            {
              "en",
              "{0} zones"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "wejscia"
            },
            {
              "en",
              "zones"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "wejscia"
            },
            {
              "en",
              "zones"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Stan wejść"
            },
            {
              "en",
              "Zones status"
            }
          }
        }
      },
      {
        "resettest",
        new Command()
        {
          Key = "resettest",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} resettest"
            },
            {
              "en",
              "{0} resettest"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "resettest"
            },
            {
              "en",
              "resettest"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "resettest"
            },
            {
              "en",
              "resettest"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Reset"
            },
            {
              "en",
              "Reset"
            }
          }
        }
      },
      {
        "smscenter",
        new Command()
        {
          Key = "smscenter",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} centrum"
            },
            {
              "en",
              "{0} smscenter"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "centrum {tel centrum}"
            },
            {
              "en",
              "smscenter {center phone}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "centrum "
            },
            {
              "en",
              "smscenter "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Centrum SMS"
            },
            {
              "en",
              "SMS Center"
            }
          }
        }
      },
      {
        "echo",
        new Command()
        {
          Key = "smscenter",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} echo"
            },
            {
              "en",
              "{0} echo"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "echo {0/1}"
            },
            {
              "en",
              "echo {0/1}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "echo "
            },
            {
              "en",
              "echo "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Echo"
            },
            {
              "en",
              "Echo"
            }
          }
        }
      },
      {
        "downloading",
        new Command()
        {
          Key = "downloading",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} downloading"
            },
            {
              "en",
              "{0} downloading"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "downloading {0/1}"
            },
            {
              "en",
              "downloading {0/1}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "downloading "
            },
            {
              "en",
              "downloading "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Downloading"
            },
            {
              "en",
              "Downloading"
            }
          }
        }
      },
      {
        "email",
        new Command()
        {
          Key = "email",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} email {1} {2}"
            },
            {
              "en",
              "{0} email {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "email {pozycja} {email}"
            },
            {
              "en",
              "email {position} {email}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "email "
            },
            {
              "en",
              "email "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Email"
            },
            {
              "en",
              "Email"
            }
          }
        }
      },
      {
        "replysms",
        new Command()
        {
          Key = "replysms",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} odeslijsms"
            },
            {
              "en",
              "{0} replysms"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "odeslijsms {0/1}"
            },
            {
              "en",
              "replysms {0/1}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "odeslijsms "
            },
            {
              "en",
              "replysms "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Odeślij SMS"
            },
            {
              "en",
              "Reply SMS"
            }
          }
        }
      },
      {
        "tempmonit",
        new Command()
        {
          Key = "tempmonit",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} tempmonit"
            },
            {
              "en",
              "{0} tempmonit"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "tempmonit {0/1}"
            },
            {
              "en",
              "tempmonit {0/1}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "tempmonit "
            },
            {
              "en",
              "tempmonit "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Monit temperatury"
            },
            {
              "en",
              "Temperature monit"
            }
          }
        }
      },
      {
        "tempa",
        new Command()
        {
          Key = "tempa",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} tempa {1} {2}"
            },
            {
              "en",
              "{0} tempa {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "tempa {nr czujnika} {wartość}"
            },
            {
              "en",
              "tempa {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "tempa "
            },
            {
              "en",
              "tempa "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg A temperatury"
            },
            {
              "en",
              "Threshold A of temp. sensor "
            }
          }
        }
      },
      {
        "androidtempa",
        new Command()
        {
          Key = "androidtempa",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} androidtempa {1} {2}"
            },
            {
              "en",
              "{0} androidtempa {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidtempa {nr czujnika} {wartość}"
            },
            {
              "en",
              "androidtempa {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidtempa "
            },
            {
              "en",
              "androidtempa "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg A temperatury"
            },
            {
              "en",
              "Threshold A of temp. sensor "
            }
          }
        }
      },
      {
        "tempb",
        new Command()
        {
          Key = "tempb",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} tempb {1} {2}"
            },
            {
              "en",
              "{0} tempb {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "tempb {nr czujnika} {wartość}"
            },
            {
              "en",
              "tempb {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "tempb "
            },
            {
              "en",
              "tempb "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg B temperatury"
            },
            {
              "en",
              "Threshold B of temp. sensor"
            }
          }
        }
      },
      {
        "androidtempb",
        new Command()
        {
          Key = "androidtempb",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} androidtempb {1} {2}"
            },
            {
              "en",
              "{0} androidtempb {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidtempb {nr czujnika} {wartość}"
            },
            {
              "en",
              "androidtempb {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidtempb "
            },
            {
              "en",
              "androidtempb "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg B temperatury"
            },
            {
              "en",
              "Threshold B of temp. sensor"
            }
          }
        }
      },
      {
        "huma",
        new Command()
        {
          Key = "huma",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} huma {1} {2}"
            },
            {
              "en",
              "{0} huma {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "huma {nr czujnika} {wartość}"
            },
            {
              "en",
              "huma {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "huma "
            },
            {
              "en",
              "huma "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg A wilgotności"
            },
            {
              "en",
              "Threshold A of huminity sensor "
            }
          }
        }
      },
      {
        "androidhuma",
        new Command()
        {
          Key = "androidhuma",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} androidhuma {1} {2}"
            },
            {
              "en",
              "{0} androidhuma {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidhuma {nr czujnika} {wartość}"
            },
            {
              "en",
              "androidhuma {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidhuma "
            },
            {
              "en",
              "androidhuma "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg A wilgotności"
            },
            {
              "en",
              "Threshold A of huminity sensor "
            }
          }
        }
      },
      {
        "humb",
        new Command()
        {
          Key = "humb",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} humb {1} {2}"
            },
            {
              "en",
              "{0} humb {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "humb {nr czujnika} {wartość}"
            },
            {
              "en",
              "humb {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "humb "
            },
            {
              "en",
              "humb "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg B wilgotności"
            },
            {
              "en",
              "Threshold B of huminity sensor"
            }
          }
        }
      },
      {
        "androidhumb",
        new Command()
        {
          Key = "androidhumb",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} androidhumb {1} {2}"
            },
            {
              "en",
              "{0} androidhumb {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidhumb {nr czujnika} {wartość}"
            },
            {
              "en",
              "androidhumb {sensor no} {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidhumb "
            },
            {
              "en",
              "androidhumb "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg B wilgotności"
            },
            {
              "en",
              "Threshold B of huminity sensor"
            }
          }
        }
      },
      {
        "aia",
        new Command()
        {
          Key = "aia",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} aia {1}"
            },
            {
              "en",
              "{0} aia {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "aia {wartość}"
            },
            {
              "en",
              "aia {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "aia "
            },
            {
              "en",
              "aia "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg A wejścia"
            },
            {
              "en",
              "Threshold A of input"
            }
          }
        }
      },
      {
        "androidaia",
        new Command()
        {
          Key = "androidaia",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} androidaia {1}"
            },
            {
              "en",
              "{0} androidaia {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidaia {wartość}"
            },
            {
              "en",
              "androidaia {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidaia "
            },
            {
              "en",
              "androidaia "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg A wejścia"
            },
            {
              "en",
              "Threshold A of input"
            }
          }
        }
      },
      {
        "aib",
        new Command()
        {
          Key = "aib",
          ManualSend = true,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} aib {1}"
            },
            {
              "en",
              "{0} aib {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "aib {wartość}"
            },
            {
              "en",
              "aib {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "aib "
            },
            {
              "en",
              "aib "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg B wejścia"
            },
            {
              "en",
              "Threshold B of input"
            }
          }
        }
      },
      {
        "androidaib",
        new Command()
        {
          Key = "androidaib",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} androidaib {1}"
            },
            {
              "en",
              "{0} androidaib {1}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidaib {wartość}"
            },
            {
              "en",
              "androidaib {value}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "androidaib "
            },
            {
              "en",
              "androidaib "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Próg B wejścia"
            },
            {
              "en",
              "Threshold B of input"
            }
          }
        }
      },
      {
        "events",
        new Command()
        {
          Key = "events",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} historia"
            },
            {
              "en",
              "{0} events"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "historia"
            },
            {
              "en",
              "events"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "historia"
            },
            {
              "en",
              "events"
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Historia zdarzeń"
            },
            {
              "en",
              "Events history"
            }
          }
        }
      },
      {
        "sendsms",
        new Command()
        {
          Key = "sendsms",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} wyslij {1} {2}"
            },
            {
              "en",
              "{0} sendsms {1} {2}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "wyslij {tel} {tekst}"
            },
            {
              "en",
              "sendsms {phone} {text}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "wyslij "
            },
            {
              "en",
              "sendsms "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Wyślij SMS"
            },
            {
              "en",
              "Send SMS"
            }
          }
        }
      },
      {
        "wifi",
        new Command()
        {
          Key = "wifi",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} wifi {1} {2} {3}"
            },
            {
              "en",
              "{0} wifi {1} {2} {3}"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "wifi {tryb} {ssid} {wpa}"
            },
            {
              "en",
              "wifi {mode} {ssid} {wpa}"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "wifi "
            },
            {
              "en",
              "wifi "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Status/ustawienia WiFi"
            },
            {
              "en",
              "WiFi status/settings"
            }
          }
        }
      },
      {
        "restartwifi",
        new Command()
        {
          Key = "restartwifi",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} restartwifi"
            },
            {
              "en",
              "{0} restartwifi"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "restartwifi"
            },
            {
              "en",
              "restartwifi"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "restartwifi "
            },
            {
              "en",
              "restartwifi "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Restart WiFi"
            },
            {
              "en",
              "WiFi restart"
            }
          }
        }
      },
      {
        "lanstat",
        new Command()
        {
          Key = "lanstat",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} lanstat"
            },
            {
              "en",
              "{0} lanstat"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "lanstat"
            },
            {
              "en",
              "lanstat"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "lanstat "
            },
            {
              "en",
              "lanstat "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Status modułu lan"
            },
            {
              "en",
              "Lan module status"
            }
          }
        }
      },
      {
        "heating",
        new Command()
        {
          Key = "heating",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} grzanie"
            },
            {
              "en",
              "{0} heating"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "grzanie"
            },
            {
              "en",
              "heating"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "grzanie "
            },
            {
              "en",
              "heating "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Grzanie"
            },
            {
              "en",
              "Heating"
            }
          }
        }
      },
      {
        "walkon",
        new Command()
        {
          Key = "walkon",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} walkon"
            },
            {
              "en",
              "{0} walkon"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "walkon"
            },
            {
              "en",
              "walkon"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "walkon "
            },
            {
              "en",
              "walkon "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Włączenie testu czujek bezprz."
            },
            {
              "en",
              "Wireless sensors test enabled"
            }
          }
        }
      },
      {
        "walkoff",
        new Command()
        {
          Key = "walkoff",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} walkoff"
            },
            {
              "en",
              "{0} walkoff"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "walkoff"
            },
            {
              "en",
              "walkoff"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "walkoff "
            },
            {
              "en",
              "walkoff "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Wyłączenie testu czujek bezprz."
            },
            {
              "en",
              "Wireless sensors test disabled"
            }
          }
        }
      },
      {
        "setapn",
        new Command()
        {
          Key = "setapn",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} setapn"
            },
            {
              "en",
              "{0} setapn"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "setapn"
            },
            {
              "en",
              "setapn"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "setapn "
            },
            {
              "en",
              "setapn "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Ustawienie APN grps"
            },
            {
              "en",
              "Gprs APN setting"
            }
          }
        }
      },
      {
        "wrltemp",
        new Command()
        {
          Key = "wrltemp",
          ManualSend = false,
          Format = new Dictionary<string, string>()
          {
            {
              "pl",
              "{0} wrltemp"
            },
            {
              "en",
              "{0} wrltemp"
            }
          },
          Hint = new Dictionary<string, string>()
          {
            {
              "pl",
              "wrltemp"
            },
            {
              "en",
              "wrltemp"
            }
          },
          FormatShort = new Dictionary<string, string>()
          {
            {
              "pl",
              "wrltemp "
            },
            {
              "en",
              "wrltemp "
            }
          },
          Description = new Dictionary<string, string>()
          {
            {
              "pl",
              "Odczyty czujek bezprz. temp."
            },
            {
              "en",
              "Wireless temp. sensors reading"
            }
          }
        }
      }
    };

        public Action<Site, NeoModel> OnStatus;
        public Action<Site, NeoModelExt> OnExtStatus;
        public Action<Site, Message> OnMessage;
        public Action<Site, Config> OnConfig;
        public Action<Site, List<Event>> OnEvents;
        public Action<Site, List<Contact>> OnPhones;
        public Action<Site, List<NeoModel>> OnStates;
        public Action<Site, int> OnClosed;

        public static SiteConnection Instance
        {
            get => SiteConnection.con;
            set
            {
                if (SiteConnection.con != null)
                {
                    SiteConnection.con.Logout();
                    SiteConnection.con.Close(0);
                }
                SiteConnection.con = value;
            }
        }

        public int SettingsCrc { get; set; }

        public Site Site { get; set; }

        public NeoModel LastStatus { get; set; }

        public NeoModelExt LastExtStatus { get; set; }

        public Config LastConfig { get; set; }

        public SiteConnection() => this.Client = (ITcpClient)new TcpClientStreamSocket();

        public void DoWork()
        {
            while (this.working)
            {
                try
                {
                    Task.Delay(TimeSpan.FromMilliseconds(200.0)).Wait();
                    if (this.sleep == 1 || this.sleep == 2)
                    {
                        if (this.sleep == 1)
                            this.sleep = 2;
                        Task.Delay(TimeSpan.FromSeconds(1.0)).Wait();
                    }
                    else if (this.lastFrame < DateTime.Now.AddSeconds(this.LongTakingAction ? -60.0 : -15.0))
                    {
                        this.working = false;
                        this.Close(3);
                    }
                    else
                    {
                        if (this.lastPingTime < DateTime.Now.AddSeconds(-30.0))
                        {
                            this.Ping();
                            this.lastPingTime = DateTime.Now;
                        }
                        this.ReceiveFrame();
                        if (this.frame.type == (byte)100)
                            this.Close(4);
                        else if (this.frame.type != (byte)46)
                        {
                            if (this.frame.type != (byte)47)
                            {
                                if (this.frame.type == (byte)16)
                                {
                                    this.LongTakingAction = false;
                                    if (this.OnStatus != null)
                                    {
                                        this.LastStatus = new NeoModel(this.frame.GetString());
                                        if (this.Site.DeviceLang != this.LastStatus.DeviceLang)
                                        {
                                            this.Site.DeviceLang = this.LastStatus.DeviceLang;
                                        }
                                        this.LastStatus.Reason = (byte)16;
                                        this.OnStatus(this.Site, this.LastStatus);
                                    }
                                }
                                else if (this.frame.type == (byte)40)
                                {
                                    this.LongTakingAction = false;
                                    if (this.OnExtStatus != null)
                                    {
                                        this.LastExtStatus = new NeoModelExt(this.frame.GetString());
                                        this.OnExtStatus(this.Site, this.LastExtStatus);
                                    }
                                }
                                else if (this.frame.type == (byte)7)
                                {
                                    this.LongTakingAction = false;
                                    this.LastStatus.Reason = (byte)7;
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)8)
                                {
                                    this.LongTakingAction = false;
                                    this.LastStatus.Reason = (byte)8;
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)12)
                                {
                                    this.LastStatus.Reason = (byte)12;
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)11)
                                {
                                    Message message = new Message()
                                    {
                                        Site = this.Site.Id,
                                        Channel = 0,
                                        Type = this.frame.data[0],
                                        Text = this.frame.GetString().Substring(1),
                                        Time = DateTime.Now
                                    };
                                    if (message.Type == (byte)92)
                                        this.LongTakingAction = true;
                                    if (message.Type != (byte)91 && message.Type != (byte)90 && message.Type != (byte)92)
                                    {
                                        //    Database.Instance.SaveMessage(message);
                                    }

                                    if (this.OnMessage != null)
                                    {
                                        if (this.frame.length > (ushort)1)
                                            this.OnMessage(this.Site, message);
                                    }
                                }
                                else if (this.frame.type == (byte)10)
                                {
                                    if (this.OnEvents != null)
                                    {
                                        string[] strArray1 = this.frame.GetString().Split('\n');
                                        List<Event> eventList = new List<Event>();
                                        for (int index = 0; index < strArray1.Length; ++index)
                                        {
                                            string str = strArray1[index].Trim();
                                            if (!string.IsNullOrEmpty(str))
                                            {
                                                string[] strArray2 = str.Split('#');
                                                Event @event = new Event()
                                                {
                                                    Type = 4,
                                                    Time = strArray2[1],
                                                    Name = strArray2[2]
                                                };
                                                try
                                                {
                                                    @event.Type = Convert.ToByte(strArray2[0]);
                                                }
                                                catch (Exception ex)
                                                {
                                                }
                                                eventList.Add(@event);
                                            }
                                        }
                                        this.OnEvents(this.Site, eventList);
                                    }
                                }
                                else if (this.frame.type == (byte)31)
                                {
                                    string[] strArray = this.frame.GetString().Split('\n');
                                    List<User> userList = new List<User>();
                                    User user = new User();
                                    for (int index = 0; index < strArray.Length; ++index)
                                    {
                                        string str = strArray[index].Trim();
                                        if (index % 2 == 0)
                                        {
                                            user.No = (byte)(index / 2 + 1);
                                            user.Name = str;
                                        }
                                        else
                                        {
                                            user.IsFree = str == "0";
                                            userList.Add(user);
                                            user = new User();
                                        }
                                    }
                                    this.LastStatus.Reason = (byte)31;
                                    this.LastStatus.Users = userList;
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)30)
                                {
                                    this.LastStatus.Reason = (byte)30;
                                    this.LastStatus.Access.UserNo = this.frame.data[0];
                                    byte num = this.frame.data[1];
                                    this.LastStatus.Access.IsZone1 = ((uint)num & 1U) > 0U;
                                    this.LastStatus.Access.IsZone2 = (uint)((int)num >> 1 & 1) > 0U;
                                    this.LastStatus.Access.IsRemote = (uint)((int)num >> 4 & 1) > 0U;
                                    this.LastStatus.Access.CanLockInputs = (uint)((int)num >> 5 & 1) > 0U;
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)45)
                                {
                                    this.LastStatus.Reason = (byte)45;
                                    byte num = this.frame.data[0];
                                    this.LastStatus.Access.IsZone1 = ((uint)num & 1U) > 0U;
                                    this.LastStatus.Access.IsZone2 = (uint)((int)num >> 1 & 1) > 0U;
                                    this.LastStatus.Access.IsRemote = (uint)((int)num >> 4 & 1) > 0U;
                                    this.LastStatus.Access.CanLockInputs = (uint)((int)num >> 5 & 1) > 0U;
                                    this.LastStatus.Access.UserName = this.frame.GetString(1);
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)33)
                                {
                                    int num1 = (int)this.frame.data[0];
                                }
                                else if (this.frame.type == (byte)32)
                                {
                                    this.LastStatus.Reason = (byte)32;
                                    this.LastStatus.ByteRet = this.frame.data[0];
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)34)
                                {
                                    this.LastStatus.Reason = (byte)34;
                                    this.LastStatus.ByteRet = this.frame.data[0];
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type == (byte)44)
                                {
                                    this.LastStatus.Reason = (byte)44;
                                    this.LastStatus.ByteRet = this.frame.data[0];
                                    this.OnStatus(this.Site, this.LastStatus);
                                }
                                else if (this.frame.type != (byte)35)
                                {
                                    if (this.frame.type != (byte)41)
                                    {
                                        if (this.frame.type != (byte)42)
                                        {
                                            if (this.frame.type != (byte)43)
                                            {
                                                if (this.frame.type == (byte)46)
                                                {
                                                    int num2 = (int)this.frame.data[8];
                                                    int num3 = (int)this.frame.data[9];
                                                    int num4 = (int)this.frame.data[10];
                                                    this.frame.GetString(11, 30);
                                                    this.frame.GetString(41);
                                                }
                                                else if (this.frame.type == (byte)47)
                                                    this.frame.GetInt(8);
                                                else if (this.frame.type == (byte)39)
                                                {
                                                    this.LastStatus.ThermostatProfile = ThermostatProfile.FromBytes(this.frame.data);
                                                    this.LastStatus.Reason = (byte)39;
                                                    this.OnStatus(this.Site, this.LastStatus);
                                                }
                                                else if (this.frame.type != (byte)38)
                                                {
                                                    if (this.frame.type == (byte)49)
                                                    {
                                                        Config config = (Config)JsonConvert.DeserializeObject<Config>(this.frame.GetString());
                                                        if (this.LastConfig != null)
                                                        {
                                                            this.LastConfig.shutters = config.shutters;
                                                            this.LastConfig.shutterGroups = config.shutterGroups;
                                                        }
                                                    }
                                                    else if (this.frame.type == (byte)6)
                                                    {
                                                        string str = this.frame.GetString();
                                                        this.LastConfig = (Config)JsonConvert.DeserializeObject<Config>(str);
                                                        this.Site.CanEditMenu = this.LastConfig.canedit;
                                                        if (!string.IsNullOrEmpty(this.LastConfig.phone) && this.LastConfig.phone != this.Site.DevicePhone)
                                                        {
                                                            this.Site.DevicePhone = this.LastConfig.phone;
                                                            //Database.Instance.SaveSiteDevicePhone(this.Site.Id, this.Site.DevicePhone);
                                                        }
                                                        //Database.Instance.SaveSiteInputs(this.Site.Id, this.LastConfig.inputs);
                                                        //Database.Instance.SaveSiteOutputs(this.Site.Id, this.LastConfig.outputs);
                                                        //Database.Instance.SaveSiteZones(this.Site.Id, this.LastConfig.zones);
                                                        //Database.Instance.SaveSiteTempSensors(this.Site.Id, this.LastConfig.temps);
                                                        List<string> wirelessSensors = new List<string>();
                                                        wirelessSensors.AddRange((IEnumerable<string>)this.LastConfig.wiredsens);
                                                        wirelessSensors.AddRange((IEnumerable<string>)this.LastConfig.wirelessSensors);
                                                        //Database.Instance.SaveSiteWirelessSensors(this.Site.Id, wirelessSensors);
                                                        //Database.Instance.SaveSiteAnalogInputs(this.Site.Id, new List<string>()
                                                        //{
                                                        //  this.LastConfig.analog
                                                        //});
                                                        //Database.Instance.SaveSiteCanEditMenu(this.Site.Id, this.LastConfig.canedit);
                                                        //Database.Instance.SaveStringParameter("site." + (object)this.Site.Id + ".settings", str);
                                                        //Database.Instance.SaveIntParameter("site." + (object)this.Site.Id + ".settings.crc", this.SettingsCrc);
                                                        if (this.OnConfig != null)
                                                        {
                                                            if (this.frame.length > (ushort)1)
                                                                this.OnConfig(this.Site, this.LastConfig);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (TimeoutException ex)
                {
                }
                catch (SocketClosedException ex)
                {
                    this.working = false;
                    this.Close(3);
                }
                catch (ParseStatusException ex)
                {
                }
                catch (BadFrameException ex)
                {
                    this.Client.ClearReadBuffer();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Start()
        {
            this.working = true;
            var t1 = Task.Factory.StartNew(new Action(this.DoWork));
            t1.Wait();
        }

        public void Stop() => this.working = false;

        public void Sleep()
        {
            this.sleep = 1;
            while (this.sleep == 1)
                Task.Delay(TimeSpan.FromSeconds(1.0)).Wait();
        }

        public void WakeUp() => this.sleep = 0;

        public bool Connect(bool localPortsBusy, out bool viaBridge)
        {
            bool flag = false;
            viaBridge = false;
            if (!localPortsBusy)
            {
                if (!string.IsNullOrEmpty(this.Site.Ip2))
                {
                    try
                    {
                        this.Client.ConnectionTimeout = 500;
                        flag = this.ConnectEndpoint(this.Site.Ip2, SiteConnection.DefaultPort);
                        if (flag)
                        {
                            viaBridge = false;
                            this.Channel = SiteConnection.Channels.Local;
                        }
                    }
                    catch (TcpConnectException ex)
                    {
                    }
                }
            }
            if (!localPortsBusy && !flag && (!this.Site.ViaBridge && !string.IsNullOrEmpty(this.Site.Ip)))
            {
                if (this.Site.Port > 0)
                {
                    try
                    {
                        this.Client.ConnectionTimeout = 2000;
                        flag = this.ConnectEndpoint(this.Site.Ip, this.Site.Port);
                        if (flag)
                        {
                            viaBridge = false;
                            this.Channel = SiteConnection.Channels.External;
                        }
                    }
                    catch (TcpConnectException ex)
                    {
                    }
                }
            }
            if (!flag && this.IsNeoLicence)
            {
                if (this.Site.ViaBridge)
                {
                    try
                    {
                        this.Client.ConnectionTimeout = 2000;
                        flag = this.ConnectEndpoint(SiteConnection.BridgeHost, SiteConnection.BridgePort);
                        if (flag)
                        {
                            viaBridge = true;
                            this.Channel = SiteConnection.Channels.Bridge;
                        }
                    }
                    catch (TcpConnectException ex)
                    {
                    }
                }
            }
            return flag;
        }

        public bool ConnectEndpoint(string host, int port)
        {
            try
            {
                try
                {
                    this.Close(0);
                }
                catch (Exception ex)
                {
                }
                this.Client.Connect(host, port);
                this.Connected = true;
                return true;
            }
            catch (Exception ex)
            {
                this.Connected = false;
                throw new TcpConnectException("Connect: " + ex.Message);
            }
        }

        public void Close(int reason)
        {
            try
            {
                this.Stop();
                if (this.Logged)
                    this.Logout();
                if (!this.Connected)
                    return;
                if (reason != 2 && reason != 5)
                {
                    Action<Site, int> onClosed = this.OnClosed;
                    if (onClosed != null)
                        onClosed(this.Site, reason);
                }
                this.Client.Disconnect();
                this.Connected = false;
                this.frame.Reset();
                this.LastStatus = (NeoModel)null;
                this.LastExtStatus = (NeoModelExt)null;
                this.LastConfig = (Config)null;
            }
            catch (Exception ex)
            {
            }
        }

        public void SendString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            this.Client.Write(bytes, 0, bytes.Length);
        }

        public void SendLine(string str) => this.SendString(str + "\n");

        public string ReceiveString(int size)
        {
            this.Client.Read(this.buffer, 0, size);
            return Encoding.UTF8.GetString(this.buffer, 0, size);
        }

        public string ReceiveLine()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str;
            do
            {
                str = this.ReceiveString(1);
                if (str != "\n")
                    stringBuilder.Append(str);
            }
            while (str != "\n");
            return stringBuilder.ToString();
        }

        public void SendFrame()
        {
            try
            {
                Frame.LastIndex += (ushort)2;
                this.frame.index = Frame.LastIndex;
                byte[] bytes = this.frame.ToBytes();
                this.Client.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                if (ex.Message == null || !(ex.Message == "The operation is not allowed on non-connected sockets"))
                    return;
                this.Close(3);
            }
        }

        public void ReceiveFrame(int tryCnt, byte type)
        {
            int num = tryCnt;
            while (num > 0)
            {
                try
                {
                    --num;
                    this.ReceiveFrame();
                    if ((int)this.frame.type == (int)type)
                        break;
                }
                catch (TimeoutException ex)
                {
                }
            }
        }

        public void ReceiveFrame()
        {
            try
            {
                this.Client.Read(this.buffer, 0, 4);
                int uint16 = (int)BitConverter.ToUInt16(new byte[2]
                {
          this.buffer[0],
          this.buffer[1]
                }, 0);
                this.Client.Read(this.buffer, 4, (int)BitConverter.ToUInt16(new byte[2]
                {
          this.buffer[2],
          this.buffer[3]
                }, 0) + (int)Frame.HeaderSize - 4);
                this.frame.Load(this.buffer);
                if (this.frame.index != ushort.MaxValue)
                {
                    if (!this.frame.crc1ok)
                        throw new BadFrameException("badcrc1");
                    if (!this.frame.crc2ok)
                        throw new BadFrameException("badcrc2");
                }
                this.lastFrame = DateTime.Now;
            }
            catch (BadFrameException ex)
            {
                throw ex;
            }
            catch (SocketClosedException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                if (ex.Message == null || !(ex.Message == "The operation is not allowed on non-connected sockets.") && !ex.Message.Contains("Network subsystem is down"))
                    throw new TcpConnectException("---" + DateTime.Now.ToString("HH:mm:ss") + " ReceiveFrame: " + ex.Message);
                if (!this.Logged || !this.Connected)
                    return;
                this.Stop();
                Task.Factory.StartNew((Action)(() => this.Reconnect()));
            }
        }

        public void Reconnect()
        {
            bool flag = false;
            for (int index = 0; index < 6; ++index)
            {
                Task.Delay(TimeSpan.FromSeconds(5.0)).Wait();
                this.Logged = false;
                this.Connected = false;
                this.Close(2);
                bool viaBridge;
                flag = this.Connect(false, out viaBridge);
                if (flag)
                {
                    if (this.Login(viaBridge) == 0)
                    {
                        this.Start();
                        flag = true;
                        break;
                    }
                    flag = false;
                }
            }
            if (flag)
                return;
            this.Close(3);
        }

        public int Login(bool viaBridge)
        {
            lock (this)
            {
                this.isBadFrame = false;
                this.Client.ReceiveTimeout = this.Channel != SiteConnection.Channels.Bridge ? 3000 : 12000;
                try
                {
                    int length = 48;
                    byte[] vector = new byte[16]
                    {
            (byte) 34,
            (byte) 52,
            (byte) 68,
            (byte) 162,
            (byte) 244,
            (byte) 205,
            (byte) 91,
            (byte) 85,
            (byte) 33,
            (byte) 52,
            (byte) 67,
            (byte) 18,
            (byte) 152,
            (byte) 173,
            (byte) 36,
            (byte) 236
                    };
                    char[] charArray = this.Site.DeviceId.ToCharArray();
                    byte[] key = new byte[charArray.Length];
                    for (int index = 0; index < charArray.Length; ++index)
                        key[index] = (byte)charArray[index];
                    byte[] numArray2 = new byte[length];
                    for (int index = 0; index < charArray.Length; ++index)
                        numArray2[index] = (byte)charArray[index];
                    Random random = new Random();
                    for (int index = 16; index < length; ++index)
                        numArray2[index] = (byte)(random.Next() % 256);
                    VMPC.Encode(numArray2, 0, length, key, vector);
                    this.Client.Write(numArray2, 0, numArray2.Length);
                    byte[] buffer = new byte[length];
                    this.Client.Read(buffer, 0, length);
                    if (buffer[0] == (byte)0)
                    {
                        this.frame.SetIp(new byte[4]
                        {
              buffer[9],
              buffer[8],
              buffer[7],
              buffer[6]
                        });
                        return this.LoginCentral();
                    }
                    if (buffer[0] == (byte)1)
                        return -100;
                    throw new Exception("Bad Neo server dialog");
                }
                catch (SocketClosedException ex)
                {
                    return -1;
                }
                catch (TcpConnectException ex)
                {
                    return this.isBadFrame ? -3 : -1;
                }
                catch (BadFrameException ex)
                {
                    return -1;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        private int TryLogin()
        {
            try
            {
                this.frame.Reset();
                this.frame.SetTcpKey(this.Site.TcpCode);
                this.frame.type = (byte)0;
                this.frame.AddData(this.Site.Code);
                this.frame.AddData(this.frame.ip);
                byte[] tcpVector = this.frame.AddRandomData(16);
                this.SendFrame();
                this.Client.Flush();
                this.frame.SetTcpVector(tcpVector);
                try
                {
                    this.ReceiveFrame();
                }
                catch (BadFrameException ex)
                {
                    this.isBadFrame = true;
                    this.ReceiveFrame();
                }
                if (this.frame.length != (ushort)53)
                    this.ReceiveFrame();
                return (int)this.frame.type;
            }
            catch (BadFrameException ex)
            {
                this.isBadFrame = true;
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private int LoginCentral()
        {
            bool flag = false;
            for (int index = 0; index < 3; ++index)
            {
                if (this.TryLogin() == 0)
                {
                    flag = true;
                    break;
                }
                Task.Delay(TimeSpan.FromMilliseconds(500.0)).Wait();
            }
            if (!flag)
                return -2;
            if (this.frame.data[0] == (byte)0)
            {
                this.Access.UserNo = this.frame.data[1];
                byte num = this.frame.data[2];
                this.Access.IsZone1 = ((uint)num & 1U) > 0U;
                this.Access.IsZone2 = (uint)((int)num >> 1 & 1) > 0U;
                this.Access.IsRemote = (uint)((int)num >> 4 & 1) > 0U;
                this.Access.CanLockInputs = (uint)((int)num >> 5 & 1) > 0U;
                this.frame.SetTcpVector(this.frame.GetData(3, 16));
                this.SettingsCrc = (int)BitConverter.ToUInt16(new byte[2]
                {
          this.frame.data[19],
          this.frame.data[20]
                }, 0);
                string str1 = this.frame.GetString(21, 16);
                string str2 = this.frame.GetString(37, 16);
                if (this.Channel == SiteConnection.Channels.Bridge)
                {
                    this.Site.DeviceId2 = str1;
                    this.Site.MobileKey = str2;
                }
                this.Site.UserNo = (int)this.Access.UserNo;
                this.Site.LastLoginTime = DateTime.UtcNow;
                //Database.Instance.SaveSite(this.Site);
                this.Client.ReceiveTimeout = 3000;
                this.LoginTime = DateTime.Now;
                this.Logged = true;
            }
            else
                this.Logged = false;
            return (int)this.frame.data[0];
        }

        public void Ping()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(Ping));
                this.frame.ClearData();
                this.frame.type = (byte)2;
                this.SendFrame();
            }
        }

        public void ArmZone(byte mask, bool night)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ArmZone));
                this.frame.ClearData();
                this.frame.type = (byte)7;
                this.frame.AddData(new byte[1] { mask });
                this.frame.AddData(new byte[1]
                {
          night ? (byte) 1 : (byte) 0
                });
                this.frame.AddData(this.Site.Code);
                this.SendFrame();
            }
        }

        public void DisarmZone(byte mask)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(DisarmZone));
                this.frame.ClearData();
                this.frame.type = (byte)8;
                this.frame.AddData(new byte[1] { mask });
                this.frame.AddData(this.Site.Code);
                this.SendFrame();
            }
        }

        public void SetOutputs(string mask)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(SetOutputs));
                this.frame.type = (byte)4;
                this.frame.ClearData();
                this.frame.AddData(mask);
                this.SendFrame();
            }
        }

        public void LockInputs(string mask)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(LockInputs));
                this.frame.type = (byte)12;
                this.frame.ClearData();
                this.frame.AddData(mask);
                this.SendFrame();
            }
        }

        public void SmsVirtualNative(string code, string command)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException("SmsVirtual");
                this.frame.type = (byte)18;
                this.frame.ClearData();
                this.frame.AddData(code + " " + command);
                this.SendFrame();
            }
        }

        public void SmsVirtual(string command, string lang, params object[] args)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(SmsVirtual));
                string datapart = string.Format(SiteConnection.Commands[command].Format[lang], args);
                this.frame.type = (byte)18;
                this.frame.ClearData();
                this.frame.AddData(datapart);
                this.SendFrame();
            }
        }

        public void SendUssd(string command)
        {
            if (!this.Logged)
                throw new NotLoggedException(nameof(SendUssd));
            this.LongTakingAction = true;
            this.frame.type = (byte)19;
            this.frame.ClearData();
            this.frame.AddData(command);
            this.SendFrame();
        }

        public void GetConfig()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(GetConfig));
                this.frame.type = (byte)5;
                this.frame.ClearData();
                this.SendFrame();
            }
        }

        public void GetEvents(short idx, short len, byte type)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(GetEvents));
                this.LongTakingAction = true;
                this.frame.type = (byte)9;
                this.frame.data = new byte[5];
                this.frame.data[0] = BitConverter.GetBytes(idx)[0];
                this.frame.data[1] = BitConverter.GetBytes(idx)[1];
                this.frame.data[2] = BitConverter.GetBytes(len)[0];
                this.frame.data[3] = BitConverter.GetBytes(len)[1];
                this.frame.data[4] = type;
                this.SendFrame();
            }
        }

        public void ServiceConnectRequest()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ServiceConnectRequest));
                this.frame.type = (byte)35;
                this.frame.ClearData();
                this.frame.AddData(this.Site.Code);
                this.SendFrame();
            }
        }

        public void OpenWicket()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(OpenWicket));
                this.frame.type = (byte)41;
                this.frame.ClearData();
                this.SendFrame();
            }
        }

        public void Panic()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(Panic));
                this.frame.type = (byte)42;
                this.frame.ClearData();
                this.SendFrame();
            }
        }

        public void Fire()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(Fire));
                this.frame.type = (byte)43;
                this.frame.ClearData();
                this.SendFrame();
            }
        }

        public void SendMessage(
          byte type,
          byte classe,
          byte mask,
          byte priority,
          byte collapseKey,
          ushort ttl,
          string title,
          string body)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException("v");
                this.frame.type = (byte)46;
                this.frame.ClearData();
                this.frame.AddData(type);
                this.frame.AddData(classe);
                this.frame.AddData(mask);
                this.frame.AddData(priority);
                this.frame.AddData(collapseKey);
                this.frame.AddData(ttl);
                this.frame.AddData(title.PadLeft(30, ' '));
                this.frame.AddData(body);
                this.SendFrame();
            }
        }

        public void CheckAccess(string code)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(CheckAccess));
                this.frame.type = (byte)30;
                this.frame.ClearData();
                this.frame.AddData(code);
                this.SendFrame();
            }
        }

        public void ReadUserNames()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ReadUserNames));
                this.frame.type = (byte)31;
                this.SendFrame();
            }
        }

        public void ChangeUserCode(string newCode)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ChangeUserCode));
                this.frame.type = (byte)33;
                this.frame.ClearData();
                this.frame.AddData(this.Site.Code);
                this.frame.AddData((byte)0);
                this.frame.AddData(newCode);
                this.SendFrame();
            }
        }

        public void DeleteUserCodes(bool[] mask)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(DeleteUserCodes));
                this.frame.type = (byte)32;
                this.frame.ClearData();
                this.frame.AddData(this.Site.Code);
                this.frame.AddData((byte)0);
                int datapart = 0;
                for (int index = 0; index < 32; ++index)
                {
                    if (mask[index])
                        datapart |= 1 << index;
                }
                this.frame.AddData(datapart);
                this.SendFrame();
            }
        }

        public void NewUserCode(
          string newCode,
          string userName,
          bool zone1Access,
          bool zone2Access,
          bool ipSmsAccess,
          bool canLockInputs)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(NewUserCode));
                this.frame.type = (byte)34;
                this.frame.ClearData();
                this.frame.AddData(this.Site.Code);
                this.frame.AddData((byte)0);
                this.frame.AddData(newCode);
                this.frame.AddData((byte)0);
                byte data = 0;
                if (zone1Access)
                    ++data;
                if (zone2Access)
                    data += (byte)2;
                if (ipSmsAccess)
                    data += (byte)16;
                if (canLockInputs)
                    data += (byte)32;
                this.frame.AddData(data);
                this.frame.AddData(userName);
                this.frame.AddData((byte)0);
                this.SendFrame();
            }
        }

        public void UserChange(
          byte codeNo,
          string userName,
          bool zone1Access,
          bool zone2Access,
          bool ipSmsAccess,
          bool canLockInputs)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(UserChange));
                this.frame.type = (byte)44;
                this.frame.ClearData();
                this.frame.AddData(this.Site.Code);
                this.frame.AddData((byte)0);
                this.frame.AddData(codeNo);
                byte data = 0;
                if (zone1Access)
                    ++data;
                if (zone2Access)
                    data += (byte)2;
                if (ipSmsAccess)
                    data += (byte)16;
                if (canLockInputs)
                    data += (byte)32;
                this.frame.AddData(data);
                this.frame.AddData(userName);
                this.frame.AddData((byte)0);
                this.SendFrame();
            }
        }

        public void GetUserMask(byte codeNo)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(GetUserMask));
                this.frame.type = (byte)45;
                this.frame.ClearData();
                this.frame.AddData(this.Site.Code);
                this.frame.AddData((byte)0);
                this.frame.AddData(codeNo);
                this.SendFrame();
            }
        }

        public void ThermostatSetMode(byte mode)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ThermostatSetMode));
                this.frame.type = (byte)36;
                this.frame.ClearData();
                this.frame.AddData(mode);
                this.SendFrame();
            }
        }

        public void ThermostatSetPoint(float setpoint)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ThermostatSetPoint));
                this.frame.type = (byte)37;
                this.frame.ClearData();
                this.frame.AddData(setpoint);
                this.SendFrame();
            }
        }

        public void ThermostatGetProfile()
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ThermostatGetProfile));
                this.frame.type = (byte)39;
                this.frame.ClearData();
                this.SendFrame();
            }
        }

        public void ThermostatSetProfile(ThermostatProfile profile)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException(nameof(ThermostatSetProfile));
                this.frame.type = (byte)38;
                this.frame.ClearData();
                this.frame.AddData(profile.ToBytes());
                this.SendFrame();
            }
        }

        public void SetRollerShutter(
          byte controlType,
          byte action,
          byte target,
          byte comfort,
          ushort mask)
        {
            lock (this)
            {
                if (!this.Logged)
                    throw new NotLoggedException("Shutter");
                this.frame.type = (byte)48;
                this.frame.ClearData();
                this.frame.AddData(controlType);
                this.frame.AddData(action);
                this.frame.AddData(target);
                this.frame.AddData(comfort);
                this.SendFrame();
            }
        }

        public async void Logout()
        {
            if (!this.Logged)
                return;
            this.Logged = false;
            try
            {
                this.frame.type = (byte)13;
                this.frame.ClearData();
                this.SendFrame();
                await Task.Delay(TimeSpan.FromMilliseconds(500.0));
            }
            catch (Exception ex)
            {
            }
        }

        public enum LicenseTypes : byte
        {
            NoLicense,
            SubscriptionYear,
            Durable,
        }

        public enum Channels
        {
            Local,
            External,
            Bridge,
        }

        public enum CloseReasons
        {
            Connect,
            User,
            Reconnect,
            ConnectionLost,
            AnotherUserLogged,
            Exit,
            Error,
        }

        public enum Responses
        {
            BridgeLoginAgain = -206, // 0xFFFFFF32
            BridgeNoLicense = -205, // 0xFFFFFF33
            BridgeBadDeviceType = -204, // 0xFFFFFF34
            BridgeAppVersionNotSupported = -203, // 0xFFFFFF35
            BridgeOtherOperatorBinded = -202, // 0xFFFFFF36
            BridgeDeviceNotFound = -201, // 0xFFFFFF37
            BridgeOtherError = -200, // 0xFFFFFF38
            EspBusy = -100, // 0xFFFFFF9C
            Error = -8, // 0xFFFFFFF8
            ConnectionsProblems = -7, // 0xFFFFFFF9
            UnableConnect = -6, // 0xFFFFFFFA
            GeneralProblems = -5, // 0xFFFFFFFB
            NoConnectData = -4, // 0xFFFFFFFC
            BadTcpKey = -3, // 0xFFFFFFFD
            BadDialog = -2, // 0xFFFFFFFE
            NeoNotAvailable = -1, // 0xFFFFFFFF
            Ok = 0,
            Nok = 1,
            UserNoPermission = 2,
            BadLogin = 3,
            BadPhone = 4,
            NotRady = 5,
            NoNightlines = 6,
            LoginLocked = 7,
        }
    }
}