using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient.HandleInClient
{
    public static class GetInformationComputer
    {
        public static string getMacAddress()
        {
            string DanhSachMAC = "";
            NetworkInterface[] DanhSachCardMang = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < DanhSachCardMang.Length; i++)
            {
                PhysicalAddress DiaChiMAC = DanhSachCardMang[i].GetPhysicalAddress();
                DanhSachMAC += DanhSachCardMang[i].Name + " : ";
                byte[] ByteDiaChi = DiaChiMAC.GetAddressBytes();
                for (int j = 0; j < ByteDiaChi.Length; j++)
                {
                    DanhSachMAC += ByteDiaChi[j].ToString("X2");
                    if (j != ByteDiaChi.Length - 1)
                    {
                        DanhSachMAC += "-";
                    }
                }
                DanhSachMAC += "\r\n";
            }
            return DanhSachMAC;
        }
    }
}
