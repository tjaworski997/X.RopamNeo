using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.RopamNeo.Lib.Model;

namespace X.RopamNeo.Service.Helpers
{
    public class InputHelper
    {
        public void InputsInit()
        {
            Log.L.Trace("Inicjuję wejścia.");

            foreach (var input in Config.Settings.ComunicationParameters.Inputs)
            {
                ShellAction(input.OnDeactivate);
            }
        }

        public void InputsStatesHandler(List<Input> neoInputs)
        {
            Log.L.Trace("states:" + string.Join("", neoInputs.Select(p => p.State)));

            foreach (var input in Config.Settings.ComunicationParameters.Inputs)
            {
                var neoInput = neoInputs.FirstOrDefault(p => p.Seq == input.Id);

                if (neoInput != null)
                {
                    var neoState = GetNeoState(neoInput.State);

                    if (neoState != input.State)
                    {
                        Log.L.Trace($"Wykryto zmianę stanu na wejściu ID: {input.Id}");
                        input.State = neoState;
                        SendNotification(input);
                    }
                }
            }
        }

        private void SendNotification(BO.Comunication.Input input)
        {
            if (input.State)
            {
                ShellAction(input.OnActivate);
            }
            else
            {
                ShellAction(input.OnDeactivate);
            }
        }

        private void ShellAction(string notifyAction)
        {
            if (string.IsNullOrWhiteSpace(notifyAction))
            {
                Log.L.Trace("Brak zdefiniowanej akcji");
                return;
            }

            notifyAction = notifyAction.Trim();

            var info = new ProcessStartInfo();

            var argPosition = notifyAction.IndexOf(" ");

            if (argPosition > 0)
            {
                info.FileName = notifyAction.Substring(0, argPosition);
                info.Arguments = notifyAction.Substring(argPosition + 1);
            }
            else
            {
                info.FileName = notifyAction;
            }

            Log.L.Trace($"Uruchamiam: prog:[{info.FileName}] arg:[{info.Arguments}]");

            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;

            var process = new Process();
            process.StartInfo = info;
            process.OutputDataReceived += (s, e) => Log.L.Debug(e.Data);
            // process.ErrorDataReceived += (s, e) => Log.L.Error(e.Data);

            process.Start();
            process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
            process.WaitForExit();
        }

        private bool GetNeoState(byte state)
        {
            if (GetBit(state, 0) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int GetBit(int value, int bitNumber)
        {
            return (value >> bitNumber) & 1;
        }
    }
}