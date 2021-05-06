using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // Check if user is NOT admin
            //if (!IsRunningAsAdministrator())
            //{
            //    // Mở thêm chương trình hiện tại
            //    ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);
            //    // chạy proccess với quyền Administrator chạy bằng lệnh shell của window
            //    // ProcessStartInfo.Verb để chạy “runas administrator”
            //    processStartInfo.UseShellExecute = true;
            //    processStartInfo.Verb = "runas";
            //    // Chạy process đã cấp quyền
            //    Process.Start(processStartInfo);
            //    // đóng ứng dụng cũ
            //    System.Windows.Forms.Application.Exit();
            //}
        }

        ///<summary>
        /// Kiểm tra tài khoản hiện tại có quyền Adnistrator khôg
        /// </summary>

        /// <returns>True nếu có quyền Administrator</returns>
        public static bool IsRunningAsAdministrator()
        {
            // Lấy tài khoản hiện tại
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            // Sử dụng hệ thống tài khoản của hệ điều hành window hiện tại
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            // Kiểm tra quyền quan trị "Administrator"
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
