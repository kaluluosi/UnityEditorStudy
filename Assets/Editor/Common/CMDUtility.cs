using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TestTool.Common
{
    public static class CMDUtility
    {
        public static string[] GetAllNetworkNames()
        {
            string[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Select(n => n.Name).ToArray();
            return interfaces;
        }

        public static void SetNetworkAdapter(string networkName, bool enable)
        {
            string cmd = enable ? string.Format("interface set interface {0} enable ", networkName) : string.Format("interface set interface {0} disable ", networkName);

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", cmd);
            psi.CreateNoWindow = true;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }

        public static void ProcessCommand(string command, string argument)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(command);
            info.Arguments = argument;
            info.CreateNoWindow = false;
            info.ErrorDialog = true;
            info.UseShellExecute = true;

            if (info.UseShellExecute)
            {
                info.RedirectStandardOutput = false;
                info.RedirectStandardError = false;
                info.RedirectStandardInput = false;
            }
            else
            {
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.RedirectStandardInput = true;
                info.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
                info.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
            }

            System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);

            if (!info.UseShellExecute)
            {
                Debug.Log(process.StandardOutput);
                Debug.Log(process.StandardError);
            }

            process.WaitForExit();
            process.Close();
        }

    }
}
