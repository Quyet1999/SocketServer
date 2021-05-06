using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class MessageProcessing
    {
        public enum Adder { Client, Server };
        public static void SendMessage(Socket socket, string msg, int mode = 1)
        {
            MsgStruct msgStr = new MsgStruct(msg);

            msgStr.mode = mode;
            byte[] buffer = new byte[ConfigAll.MAX_BUFFER];
            buffer = Packet.Serialize(msgStr, ConfigAll.MAX_BUFFER);
            socket.Send(buffer);
        }
        public static bool SendFile(Socket socket, string filename, int mode = 1)
        {
            try
            {
                string path = "";
                filename = filename.Replace("\\", "/");
                while (filename.IndexOf("/") > -1)
                {
                    path += filename.Substring(0, filename.IndexOf("/") + 1);
                    filename = filename.Substring(filename.IndexOf("/") + 1);
                }
                byte[] fNameByte = Encoding.ASCII.GetBytes(filename);

                byte[] fileData = File.ReadAllBytes(path + filename);
                byte[] clientData = new byte[4 + fNameByte.Length + fileData.Length];
                byte[] fNameLen = BitConverter.GetBytes(fNameByte.Length);
                fNameLen.CopyTo(clientData, 0);
                fNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fNameByte.Length);
                MsgStruct msgStr = new MsgStruct();
                msgStr.msg = clientData;
                msgStr.mode = 4;
                byte[] buffer = new byte[1024 * 5000];
                buffer = Packet.Serialize(msgStr, 1024 * 5000);
                socket.Send(buffer);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static string ReceiveFile(byte[] clientData)
        {
            try
            {
                string path = "C:/Users/admin/Desktop/ReceiveFile_SocketServer";
                int fNameLen = BitConverter.ToInt32(clientData, 0);
                string fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);
                BinaryWriter write = new BinaryWriter(File.Open(path + "/" + fName, FileMode.Append));
                write.Write(clientData, 4 + fNameLen, clientData.Length - 4 - fNameLen);
                write.Close();
                return fName;
            }
            catch
            {
                return "";
            }
        }
        public static RichTextBox AddMessage(RichTextBox rtbMessage, string msg, Adder adder)
        {
            rtbMessage.Invoke(new MethodInvoker(delegate ()
            {
                if (adder == Adder.Client)
                {
                    rtbMessage.SelectionColor = Color.Blue;
                }
                else
                {
                    rtbMessage.SelectionColor = Color.Red;
                }
                rtbMessage.AppendText("[" + DateTime.Now + "] " + msg);
                rtbMessage.SelectionColor = Color.Gray;
                rtbMessage.AppendText("----------------------------------------------------------------------------------------------" + Environment.NewLine);
                rtbMessage.ScrollToCaret();
            }));
            return rtbMessage;
        }
        public static RichTextBox AddLog(RichTextBox rTxbLog, string msg)
        {
            rTxbLog.Invoke(new MethodInvoker(delegate ()
            {

                rTxbLog.AppendText("[" + DateTime.Now + "]" + Environment.NewLine + msg + Environment.NewLine + "--------------------------------------------------------------" + Environment.NewLine);
                rTxbLog.ScrollToCaret();
            }));
            return rTxbLog;
        }
    }
}
