using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient.HandleInClient
{
    public class StartupWindow
    {
        public static bool SetStartup(string AppName, bool enable)
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey);
            try
            {
                if (enable)
                {
                    if (startupKey.GetValue(AppName) == null)
                    {
                        startupKey.Close();
                        startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                        //startupKey.SetValue(AppName, Assembly.GetExecutingAssembly().Location + " /StartMinimized");
                        startupKey.SetValue(AppName, Application.StartupPath + " /StartMinimized");
                        startupKey.Close();
                    }
                }
                else
                {
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                    startupKey.DeleteValue(AppName, false);
                    startupKey.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SetStartupWindow()
        {
            string path_my_app = Application.StartupPath + "\\SMS Alarm.exe";
            if (File.Exists(path_my_app))
            {
                return SetStartup(path_my_app, true);
                //XtraMessageBox.Show("Đã bật ứng dụng SMS Alarm khởi động cùng Windows!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Application.Exit();
            }
            return false;
        }
        public static bool SetNotStartupWindow()
        {
            string path_my_app = Application.StartupPath + "\\SMS Alarm.exe";
            if (File.Exists(path_my_app))
            {
                return SetStartup(path_my_app, false);
                //XtraMessageBox.Show("Đã tắt ứng dụng SMS Alarm khởi động cùng Windows!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Application.Exit();
            }
            return false;
        }
    }
}
