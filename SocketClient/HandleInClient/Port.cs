using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient.HandleInClient
{
    public static class Port
    {
        public static bool BlockPort()
        {
            string Regpath = "System\\CurrentControlSet\\Services\\USBSTOR";

            RegistryKey Regkey;
            try
            {
                Regkey = Registry.LocalMachine.OpenSubKey(Regpath, true);
                Regkey.SetValue("Start", 4);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UnBlockPort()
        {
            string Regpath = "System\\CurrentControlSet\\Services\\USBSTOR";

            RegistryKey Regkey;
            try
            {
                Regkey = Registry.LocalMachine.OpenSubKey(Regpath, true);
                Regkey.SetValue("Start", 3);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
