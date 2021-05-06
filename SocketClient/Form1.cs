using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using Common;
using SocketClient.HandleInClient;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isConnected = false;
        Socket client;
        IPEndPoint ipeServer; //IP Endpoint of Server
        Thread thdClient;

        public void InitIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily.ToString() == "InterNetwork")
                {
                    tbHost.Text = addr.ToString();
                }
            }

        }

        private void ChangeItemsWhenConnect()
        {
            //btnConnect.Text = "Ngắt kết nối";
            //btnConnect.BackColor = Color.Silver;
            //tbHost.Enabled = false;
            //rtxbInputMessage.Enabled = true;
            isConnected = true;
            //pMessage.Show();
            //pSend.Show();
        }

        private void ChangeItemsWhenDisconnect()
        {
            btnConnect.Text = "Kết nối";
            btnConnect.BackColor = Color.LimeGreen;
            tbHost.Enabled = true;
            rtbMsg.Enabled = false;
            isConnected = false;
            //pMessage.Hide();
            //pSend.Hide();
        }

        private bool Connect(IPAddress ip, int port)
        {
            try
            {

                ipeServer = new IPEndPoint(ip, port);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ipeServer);

            }
            catch (SocketException e)
            {
                return false;
            }
            return true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool isExcept = false;
            if (!isConnected)
            {
                //Start check exception
                IPAddress ipDesc;
                int portDesc;
                if (!IPAddress.TryParse(tbHost.Text, out ipDesc))
                {
                    isExcept = true;
                    MessageBox.Show("Địa chỉ IP chưa đúng. Vui lòng kiểm tra lại");
                }

                if (int.TryParse(tbPort.Text, out portDesc))
                {
                    if (portDesc <= 0 || portDesc >= 65535)
                    {
                        isExcept = true;
                        MessageBox.Show("Port chưa đúng. Vui lòng kiểm tra lại");
                    }
                }
                else
                {
                    isExcept = true;
                    MessageBox.Show("Port chưa đúng. Vui lòng kiểm tra lại");
                }
                //end check exception

                //Connect
                if (!isExcept)
                {
                    if (Connect(ipDesc, portDesc))
                    {
                        isConnected = true;
                        //DiffieHellman = new ECDiffieHellmanCng();
                        //DiffieHellman.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                        //DiffieHellman.HashAlgorithm = CngAlgorithm.Sha256;
                        thdClient = new Thread(listenFromServer);
                        thdClient.IsBackground = true;
                        thdClient.Start(client);
                    }
                }
            }
            else
            {
                //Disconnect
                ChangeItemsWhenDisconnect();
                CloseConnect();
            }
        }

        public void listenFromServer(object obj)
        {
            Socket sk = (Socket)obj;
            try
            {
                MessageProcessing.SendMessage(sk, Command.RequestToConnect, 0);
                while (true)
                {
                    ReceiveMessage(sk);
                }
            }
            catch (SocketException)
            {
                ChangeItemsWhenDisconnect();
                CloseConnect();
                return;
            }

        }

        private void CloseConnect()
        {
            isConnected = false;
            thdClient.Abort();
            client.Close();

        }

        private void AddMessage(string msg, MessageProcessing.Adder adder)
        {
            rtbMsg.Invoke(new MethodInvoker(delegate ()
            {
                if (adder == MessageProcessing.Adder.Client)
                {
                    rtbMsg.SelectionColor = Color.Blue;
                }
                else
                {
                    rtbMsg.SelectionColor = Color.Red;
                }
                rtbMsg.AppendText("[" + DateTime.Now + "] " + msg);
                rtbMsg.SelectionColor = Color.Gray;
                rtbMsg.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                rtbMsg.ScrollToCaret();
            }));
        }

        private void ReceiveMessage(Socket sk)
        {
            byte[] buff;
            MsgStruct msgStr;
            try
            {
                buff = new byte[1024];
                int recv = sk.Receive(buff);
                if (recv == 0) return;
                msgStr = Packet.Deserialize(buff) as MsgStruct;
            }
            catch
            {
                buff = new byte[1024 * 5000];
                int recv = sk.Receive(buff);
                if (recv == 0) return;
                msgStr = Packet.Deserialize(buff) as MsgStruct;
            }
            switch (msgStr.mode)
            {
                case 0:
                    if (msgStr.GetString().ToUpper().Equals(Command.AcceptToConnect))
                    {
                        //send information
                        MessageProcessing.SendMessage(client, HandleInClient.GetInformationComputer.getMacAddress(), 2);
                    }
                    else if (msgStr.GetString().ToUpper().Equals(Command.NoAcceptToConnect))
                    {
                        CloseConnect();
                    }
                    else
                    {

                    }
                    break;

                //receive message
                case 1:
                    //while (key == null) ;
                    //msgStr.Decrypt(key);
                    AddMessage(msgStr.GetString(), MessageProcessing.Adder.Server);
                    break;

                //receive command
                case 3:
                    string message = msgStr.GetString();
                    if (message.Equals(Command.GetInfomation))
                    {
                        MessageProcessing.SendMessage(client, Command.PostInformation + GetInformationComputer.getMacAddress(), 3);
                    }
                    else if (message.Equals(Command.BlockPortUSB))
                    {
                        bool result = Port.BlockPort();
                        if (result == true)
                            MessageProcessing.SendMessage(client, Command.BlockPortUSB + Command.Success, 3);
                        else
                            MessageProcessing.SendMessage(client, Command.BlockPortUSB + Command.Unsuccess, 3);
                    }
                    else if (message.Equals(Command.UnBlockPortUSB))
                    {
                        bool result = Port.UnBlockPort();
                        if (result == true)
                            MessageProcessing.SendMessage(client, Command.UnBlockPortUSB + Command.Success, 3);
                        else
                            MessageProcessing.SendMessage(client, Command.UnBlockPortUSB + Command.Unsuccess, 3);
                    }
                    else if (message.Equals(Command.Shutdown))
                    {
                        TurnOnorOffComputer.Shutdown();
                    }
                    else if (message.Equals(Command.Restart))
                    {
                        TurnOnorOffComputer.Restart();
                    }
                    else if (message.Equals(Command.LogOff))
                    {
                        TurnOnorOffComputer.LogOff();
                    }
                    else if (message.Equals(Command.ForceLogOff))
                    {
                        TurnOnorOffComputer.Force_LogOff();
                    }
                    else
                    {

                    }
                    break;
                case 4:
                    string filename = MessageProcessing.ReceiveFile(msgStr.msg);
                    if (filename != "")
                    {
                        rtbMsg = MessageProcessing.AddMessage(rtbMsg, filename, MessageProcessing.Adder.Server);
                    }
                    break;
            }
        }

        private void rtxbInputMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lbOnline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = "Client: " + txbInputMessage.Text + Environment.NewLine;
            MessageProcessing.SendMessage(client, msg);
            AddMessage(msg, MessageProcessing.Adder.Client);
            txbInputMessage.Text = String.Empty; //reset textbox message send
        }

        private void txbInputMessage_KeyDown(object sender, KeyEventArgs e)
        {
            //catch press Enter to send message
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

            InitIP(); //auto load local IP Address
            ChangeItemsWhenDisconnect();

        }

        private void txbInputMessage_Enter(object sender, EventArgs e)
        {
            txbInputMessage.Text = "";
        }

        private void txbInputMessage_Leave(object sender, EventArgs e)
        {
            txbInputMessage.Text = "Nhập tin nhắn vào đây";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TurnOnorOffComputer.Shutdown();
        }
    }
}
