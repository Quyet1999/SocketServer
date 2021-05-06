using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient.HandleInClient
{
    public static class TurnOnorOffComputer
    {
		[DllImport("user32.dll")]
		public static extern void LockWorkStation();
		[DllImport("user32.dll")]
		public static extern int ExitWindowsEx(int uFlags, int dwReason);
		public static void Shutdown()
        {
			//System.Diagnostics.Process.Start("shutdown", "-s -t 0");
			System.Diagnostics.Process.Start("shutdown", "/s /t 0");
			//ExitWindowsEx(1, 0);
		}
        public static void Restart()
        {
            System.Diagnostics.Process.Start("shutdown", "/r /t 0");
        }
		public static void LogOff()
        {
			ExitWindowsEx(0, 0);
		}
		public static void Force_LogOff()
        {
			ExitWindowsEx(4, 0);
		}
		public static void Hibernate()
        {
			Application.SetSuspendState(PowerState.Hibernate, true, true);
		}
		public static void LockComp()
        {
			LockWorkStation();
        }
	}
}
