using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Command
    {
        public static string RequestToConnect = "REQUEST_TO_CONNECT";
        public static string RequestToCloseConnect = "REQUEST_TO_DISCONNECT";
        public static string AcceptToConnect = "ACCEPT_TO_CONNECT";
        public static string NoAcceptToConnect = "NO_ACCEPT_TO_CONNECT";

        //mode 3
        public static string GetInfomation = "GET_INFORMATION_CLIENT";
        public static string PostInformation = "POST_INFORMATION_TO_SERVER";
        public static string BlockPortUSB = "BLOCK_PORT_USB";
        public static string UnBlockPortUSB = "UN_BLOCK_PORT_USB";
        //turn on or off client
        public static string Shutdown = "SHUTDOWN_CLIENT";
        public static string Restart = "RESTART_CLIENT";
        public static string LogOff = "LOG_OFF_CLIENT";
        public static string ForceLogOff = "FORCE_LOG_OFF_CLIENT";
        public static string Hibernate = "HIBERNATE_CLIENT";
        
        //message to display the results of the command
        public static string Success = "SUCCESSFUL";
        public static string Unsuccess = "UNSUCCESSFUL";
    }
}
