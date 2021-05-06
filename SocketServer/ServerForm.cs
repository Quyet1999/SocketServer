using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using Common;
using SocketServer.Model;
using System.Linq;

namespace SocketServer
{
    public partial class ServerForm : Form
    {
        public enum Adder { Client, Server };

        private bool isConnected = false;
        private bool isAccepted = false;
        Socket server;
        IPEndPoint ipe; //my IP endpoint

        List<Socket> listClient;
        List<ClientInformation> listInfoClient = new List<ClientInformation>();

        List<ClientInformation> listClientOnClick = new List<ClientInformation>();
        Socket ClientOnClick;

        List<Button> listBtn = new List<Button>();
        List<Label> listLb = new List<Label>();
        List<CheckBox> listChb = new List<CheckBox>();

        bool modeMultySelect = false;

        public ServerForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            DrawListComputer();
            timeLoadListCpt.Start();
        }

        #region design
        Button BtnComputer(bool Status, int ComputerID, Point location)
        {
            Button btn = new Button();
            if (Status == true)
            {
                btn.BackgroundImage = global::SocketServer.Properties.Resources.monitor;
            }
            else
            {
                btn.BackgroundImage = global::SocketServer.Properties.Resources.black;
            }
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn.Location = location;
            btn.Name = "btn" + ComputerID;
            btn.Size = new System.Drawing.Size(SIZE_BUTTON_X, SIZE_BUTTON_Y);
            btn.UseVisualStyleBackColor = true;
            return btn;
        }
        Label LbComputerName(int ComputerID, Point location)
        {
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lb.Location = location;
            lb.Name = "lb" + ComputerID.ToString();
            lb.Size = new System.Drawing.Size(77, 20);
            lb.Text = "Máy số " + ComputerID.ToString();
            return lb;
        }
        CheckBox checkSelection(int ComputerID, Point location)
        {
            CheckBox chb = new CheckBox();
            chb.AutoSize = true;
            chb.Location = location;
            chb.Name = "chb" + ComputerID.ToString();
            chb.Size = new System.Drawing.Size(18, 17);
            chb.UseVisualStyleBackColor = true;
            return chb;
        }
        private void ChangeStatusComputerOn(int ComputerID)
        {
            Button btn_change = new Button();
            foreach (Button btn in listBtn)
            {
                if (btn.Name.Equals("btn" + ComputerID))
                {
                    btn_change = btn;
                    break;
                }
            }
            btn_change.BackgroundImage = global::SocketServer.Properties.Resources.monitor;
        }
        private void ChangeStatusComputerOff(int ComputerID)
        {
            Button btn_change = new Button();
            foreach (Button btn in listBtn)
            {
                if (btn.Name.Equals("btn" + ComputerID))
                {
                    btn_change = btn;
                    break;
                }
            }
            btn_change.BackgroundImage = global::SocketServer.Properties.Resources.black;
        }
        private void ResetColorAllLable()
        {
            foreach (Label item in listLb)
            {
                item.BackColor = System.Drawing.SystemColors.Control;
            }
        }
        private void ResetColorLabel(int ComputerID)
        {
            foreach (Label item in listLb)
            {
                if (item.Name.Equals("Máy số " + ComputerID.ToString()))
                {
                    item.BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }
        private void LabelWhenButtonClick(int ComputerID)
        {
            foreach (Label lb in listLb)
            {
                if (lb.Text.Equals("Máy số " + ComputerID.ToString()))
                {
                    //lb.BorderStyle = BorderStyle.Fixed3D;
                    lb.BackColor = System.Drawing.Color.Blue;
                    return;
                }
            }
        }
        private int NUM_IN_ROW = 7;
        private int START_LOCATION_X = 10;
        private int START_LOCATION_Y = 10;
        private int SIZE_BUTTON_X = 60;
        private int SIZE_BUTTON_Y = 50;
        private int SPACE_X = 25;
        private int SPACE_Y = 40;
        void DrawListComputer()
        {
            Models db = new Models();
            List<Computer> listComputer = db.Computers.OrderBy(xy => xy.ComputerID).ToList();
            if (listComputer == null)
                return;
            int numberComputer = listComputer.Count;
            int NUM_COL;
            if (numberComputer % NUM_IN_ROW == 0)
                NUM_COL = numberComputer / NUM_IN_ROW;
            else
                NUM_COL = numberComputer / NUM_IN_ROW + 1;
            int index = 0;
            int x = START_LOCATION_X, y = START_LOCATION_Y;
            for (int i = 0; i < NUM_COL; i++)
            {
                int _NumLoop = 0;
                if ((numberComputer - i * NUM_IN_ROW) > NUM_IN_ROW)
                    _NumLoop = NUM_IN_ROW;
                else if ((numberComputer - i * NUM_IN_ROW) == 0)
                    break;
                else
                    _NumLoop = numberComputer - i * NUM_IN_ROW;
                for (int j = 0; j < _NumLoop; j++)
                {
                    Computer cpt = listComputer[index];
                    Button btn = BtnComputer(cpt.Status, cpt.ComputerID, new Point(x, y));
                    listBtn.Add(btn);
                    Label lb = LbComputerName(cpt.ComputerID, new Point(x, y + 54));
                    listLb.Add(lb);
                    CheckBox chb = checkSelection(cpt.ComputerID, new Point(x + 20, y + 76));
                    listChb.Add(chb);
                    pnListComputer.Controls.Add(btn);
                    pnListComputer.Controls.Add(lb);
                    pnListComputer.Controls.Add(chb);
                    chb.Visible = false;
                    chb.CheckedChanged += Chb_CheckedChanged;
                    btn.Click += Btn_Click;
                    x += SIZE_BUTTON_X + SPACE_X;
                    index++;
                }
                x = START_LOCATION_X;
                y += SIZE_BUTTON_Y + SPACE_Y;
            }
        }

        private void Chb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chb = sender as CheckBox;
            string chbName = chb.Name;
            int ComputerID = Int32.Parse(chbName.Replace("chb", string.Empty));
            if (chb.Checked)
            {
                ClientInformation client = listInfoClient.Where(x => x.ComputerID == ComputerID).FirstOrDefault();
                if (client == null)
                {
                    MessageBox.Show("Client đang tắt. Không thể thực hiện được thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chb.Checked = false;
                    return;
                }
                listClientOnClick.Add(client);
                LabelWhenButtonClick(ComputerID);
            }
            else
            {
                ClientInformation client = listInfoClient.Where(x => x.ComputerID == ComputerID).FirstOrDefault();
                if (client == null)
                {
                    chb.Checked = false;
                    ResetColorLabel(ComputerID);
                    return;
                }
                else
                {
                    ResetColorLabel(ComputerID);
                    listClientOnClick.Remove(client);
                }
            }
        }

        void ClearListComputer()
        {
            if (listBtn == null)
                return;
            foreach (Button btn in listBtn)
            {
                pnListComputer.Controls.Remove(btn);
            }
            listBtn = new List<Button>();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name;
            int ID = Int32.Parse(name.Substring(3));
            if (listChb.First().Visible == true)
            {
                CheckBox chb = listChb.Where(x => x.Name == "chb" + ID.ToString()).First();
                ClientInformation client = listInfoClient.Where(y => y.ComputerID == ID).FirstOrDefault();
                if (chb.Checked)
                {
                    chb.Checked = false;
                    listClientOnClick.Remove(client);
                    ResetColorLabel(ID);
                }
                else
                {
                    if (client == null)
                    {
                        MessageBox.Show("Client đang tắt. Không thể thực hiện được thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chb.Checked = false;
                        ResetColorLabel(ID);
                        return;
                    }
                    listClientOnClick.Add(client);
                    LabelWhenButtonClick(ID);
                }
            }
            else
            {
                listClientOnClick = new List<ClientInformation>();
                ClientInformation client = listInfoClient.Where(x => x.ComputerID == ID).FirstOrDefault();
                if (client == null)
                {
                    return;
                }
                else
                {
                    ResetColorAllLable();
                    LabelWhenButtonClick(ID);
                    listClientOnClick.Add(client);
                    LoadPanelMessage(client);
                }
            }
        }

        #endregion

        #region design message
        int CURREN_POSION_Y = 0;
        int START_POSION_Y = 0;
        int MSG_SPACE_Y = 10;
        int MAX_WIDTH_MESSAGE = 30;
        Color COLOR_SENDER = Color.Green;
        Color COLOR_RECEIVE = Color.Aqua;
        Color COLOR_TEXT_SENDER = Color.Black;
        Color COLOR_TEXT_RECEIVE = Color.Black;
        int MSG_SPACE_LEFT_SENDER = 10;
        int MSG_SPACE_RIGHT_RECEIVE = 20;

        Button getMessageSender(DateTime timeSend, string message, Point location)
        {
            Button btn = new Button();
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = location;
            int width = 0;
            if (message.Length <= 21)
            {
                width = 150 + message.Length * 5;
            }
            else
            {
                width = MAX_WIDTH_MESSAGE;
            }
            btn.Size = new Size(width,46);
            btn.TabIndex = 0;
            btn.Text = "[" + timeSend.ToString() + "] " + message;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = true;
            return btn;
        }
        Button getMessageReceive(DateTime timeSend, string message, Point location)
        {
            Button btn = new Button();
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = location;
            int width = 0;
            if (message.Length <= 21)
            {
                width = 150 + message.Length * 5;
            }
            else
            {
                width = MAX_WIDTH_MESSAGE;
            }
            btn.Size = new Size(width, 46);
            btn.TabIndex = 0;
            btn.Text = "[" + timeSend.ToString() + "] " + message;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btn.UseVisualStyleBackColor = true;
            return btn;
        }
        Panel AddMessageToPanel(Panel pnMessage, DateTime timeSend, string message, bool SendOrReceive)
        {
            Button btnMsg = new Button();
            if (!SendOrReceive)
            {
                btnMsg = getMessageSender(timeSend, message, new Point(MSG_SPACE_LEFT_SENDER, CURREN_POSION_Y));
            }
            else
            {
                btnMsg = getMessageReceive(timeSend, message, new Point(pnMessage.Width - MSG_SPACE_RIGHT_RECEIVE, CURREN_POSION_Y));
                btnMsg.Location = new Point(btnMsg.Location.X - btnMsg.Size.Width, btnMsg.Location.Y);
            }
            pnMessage.Controls.Add(btnMsg);
            CURREN_POSION_Y += btnMsg.Height + MSG_SPACE_Y;
            return pnMessage;
        }
        void LoadPanelMessage(ClientInformation client)
        {
            CURREN_POSION_Y = START_POSION_Y;
            pnMessage.Controls.Clear();
            Models db = new Models();
            List<Model.Message> listMsg = new List<Model.Message>();
            listMsg = db.Messages.Where(x => x.Sender == client.ComputerID || x.Receive == client.ComputerID).ToList();
            foreach(Model.Message item in listMsg)
            {
                //0 is receive
                if (item.Type_Message == 0)
                {
                    pnMessage = AddMessageToPanel(pnMessage, item.TimeSend, item.Message1, false);
                }
                //1 is sender
                else
                {
                    pnMessage = AddMessageToPanel(pnMessage, item.TimeSend, item.Message1, true);
                }
            }
        }
        #endregion

        #region 
        public void initIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    cbHost.Items.Add(addr.ToString());
                }
            }

        }

        #endregion

        #region Server Listening
        private bool Listen()
        {
            try
            {
                IPAddress ip;
                int port;
                try
                {
                    cbHost.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Vui lòng chọn IP", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!IPAddress.TryParse(cbHost.SelectedItem.ToString(), out ip))
                {
                    MessageBox.Show("IP không hợp lệ hoặc sai");
                    return false;
                }

                if (!Int32.TryParse(txbPort.Text.Trim(), out port))
                {
                    MessageBox.Show("Port không hợp lệ");
                    return false;
                }

                if (port <= 0 || port >= 65535)
                {
                    MessageBox.Show("Port không hợp lệ");
                    return false;
                }

                ipe = new IPEndPoint(ip, port);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipe);
                server.Listen(3);
                for (int i = 0; i < 10; i++)
                {
                    new Thread(ListenOneIP).Start();
                }
            }
            catch (SocketException)
            {
                return false;
            }
            return true;
        }
        public void ListenOneIP()
        {
            try
            {
                while (true)
                {
                    if (isAccepted == false)
                    {
                        Socket client = server.Accept();
                        listClient.Add(client);
                        rTxbLog = MessageProcessing.AddLog(rTxbLog, "Đã chấp nhận kết nối từ " + client.RemoteEndPoint.ToString());
                        Thread clientProccess = new Thread(threadClient);
                        clientProccess.IsBackground = true;
                        clientProccess.Start(client);
                    }
                }
            }
            catch
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
        }

        public void threadClient(Object obj)
        {
            if (!isConnected) return;
            Socket skClient = (Socket)obj;
            bool isWhile = true;
            Models db = new Models();

            try
            {
                while (isWhile)
                {
                    byte[] buff = new byte[1024];
                    int recv = skClient.Receive(buff);
                    string msg;
                    if (recv == 0)
                    {
                        rTxbLog = MessageProcessing.AddLog(rTxbLog, skClient.RemoteEndPoint.ToString() + " đã ngắt kết nối.");
                        isAccepted = false;
                        break;
                    }
                    MsgStruct msgStr = Packet.Deserialize(buff) as MsgStruct;
                    switch (msgStr.mode)
                    {
                        case 0:
                            if (msgStr.GetString().ToUpper().Equals(Command.RequestToConnect))
                            {
                                DialogResult result = MessageBox.Show("Máy " + skClient.RemoteEndPoint.ToString() + " yêu cầu kết nối!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.No)
                                {
                                    MessageProcessing.SendMessage(skClient, Command.NoAcceptToConnect, 0);
                                    skClient.Close();
                                }
                                else
                                {
                                    MessageProcessing.SendMessage(skClient, Command.AcceptToConnect, 0);
                                }
                            }
                            break;

                        //send message
                        case 1:
                            //rtbMessage = MessageProcessing.AddMessage(rtbMessage, msgStr.GetString(), MessageProcessing.Adder.Client);
                            Model.Message newMsg = new Model.Message();
                            if (db.Messages.ToList().Count == 0)
                            {
                                newMsg.ID_Message = 1;
                            }
                            else
                            {
                                newMsg.ID_Message = db.Messages.OrderByDescending(x => x.ID_Message).First().ID_Message + 1;
                            }
                            newMsg.Message1 = msgStr.GetString();
                            newMsg.Receive = 0;
                            newMsg.Sender = listInfoClient.Where(x => x.client == skClient).First().ComputerID;
                            newMsg.TimeSend = DateTime.Now;
                            newMsg.Type_Message = 0;
                            db.Messages.Add(newMsg);
                            db.SaveChanges();
                            //pnMessage = AddMessageToPanel(pnMessage, newMsg.TimeSend, newMsg.Message1, false);
                            LoadPanelMessage(listInfoClient.Where(x=>x.client==skClient).First());
                            break;
                        //send information
                        case 2:
                            ClientInformation clientinfo = new ClientInformation(skClient);
                            string _info = skClient.RemoteEndPoint.ToString();
                            string[] _arrinfo = _info.Split(':');
                            string _ipAddress = _arrinfo[0];
                            Computer cpt = db.Computers.Where(x => x.IP_Address == _ipAddress).FirstOrDefault();
                            if (cpt == null)
                            {
                                Computer newCpt = new Computer();
                                if (db.Computers.ToList().Count == 0)
                                {
                                    newCpt.ComputerID = 1;
                                }
                                else
                                {
                                    newCpt.ComputerID = db.Computers.OrderByDescending(x => x.ComputerID).First().ComputerID + 1;
                                }
                                newCpt.ComputerID = 11;
                                newCpt.IP_Address = _arrinfo[0];
                                newCpt.Status = true;
                                newCpt.Name = "abc";
                                newCpt.Mac_Address = "123";
                                newCpt.StudentID = 1;
                                newCpt.TimeStart = DateTime.Now;
                                db.SaveChanges();
                                db.Computers.Add(newCpt);
                                db.SaveChanges();
                                clientinfo.ComputerID = newCpt.ComputerID;
                            }
                            else
                            {
                                cpt.Status = true;
                                db.SaveChanges();
                                ChangeStatusComputerOn(cpt.ComputerID);
                                clientinfo.ComputerID = cpt.ComputerID;
                            }
                            listInfoClient.Add(clientinfo);
                            break;
                        case 3:
                            if (msgStr.GetString().ToUpper().Contains(Command.PostInformation))
                            {
                                string message = msgStr.GetString();
                                message = message.Replace(Command.PostInformation, string.Empty);
                                MessageBox.Show(message);
                            }
                            break;
                    }
                }
            }
            catch (SocketException)
            {
                rTxbLog = MessageProcessing.AddLog(rTxbLog, skClient.RemoteEndPoint.ToString() + " đã ngắt kết nối.");
                isAccepted = false;
                isWhile = false;
                return;
            }

        }
        #endregion
        //start server mode listen


        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                if (Listen())
                {
                    btnStartServer.Enabled = false;
                    isConnected = true;
                    cbHost.Enabled = false;
                    txbPort.Enabled = false;
                    btnStartServer.Text = "Đang lắng nghe";
                    rTxbLog = MessageProcessing.AddLog(rTxbLog, "Đã mở cổng " + txbPort.Text);
                    listInfoClient = new List<ClientInformation>();
                    listClient = new List<Socket>();
                }
                else
                {
                    MessageBox.Show("Không thể mở kết nối");
                }
            }
            else
            {
                isConnected = false;
                btnStartServer.Text = "Mở kết nối";
                cbHost.Enabled = true;
                txbPort.Enabled = true;
                //thdListener.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Disconnect(false);
                server.Close();
            }
        }

        private void rtxbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void ServerForm_Load(object sender, EventArgs e)
        {
            initIP();
            //pSend.Hide();
            //pMessage.Hide();
        }

        private void timeLoadListCpt_Tick(object sender, EventArgs e)
        {
            ClearListComputer();
            DrawListComputer();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (listClientOnClick.Count == 0)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            MsgStruct msgStr = new MsgStruct();
            //string msg = "Server: " + tbInputMess.Text + Environment.NewLine;
            //foreach (ClientInformation client in listClientOnClick)
            //{
            //    MessageProcessing.SendMessage(client.client, msg);
            //}
            //rtbMessage = MessageProcessing.AddMessage(rtbMessage, msg, MessageProcessing.Adder.Server);
            if (listClientOnClick.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn 1 client để chat!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            MessageProcessing.SendMessage(listClientOnClick.First().client, tbInputMess.Text);
            Models db = new Models();
            Model.Message newMsg = new Model.Message();
            if (db.Messages.ToList().Count == 0)
            {
                newMsg.ID_Message = 1;
            }
            else
            {
                newMsg.ID_Message = db.Messages.OrderByDescending(x => x.ID_Message).First().ID_Message + 1;
            }
            newMsg.Message1 = tbInputMess.Text;
            newMsg.Receive = listClientOnClick.First().ComputerID;
            newMsg.Sender = 0;
            newMsg.TimeSend = DateTime.Now;
            newMsg.Type_Message = 1;
            db.Messages.Add(newMsg);
            db.SaveChanges();
            pnMessage = AddMessageToPanel(pnMessage, newMsg.TimeSend, newMsg.Message1, true);
            tbInputMess.Text = string.Empty;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            new NewClient(new Computer(), "NEW_INFO").Show();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Models db = new Models();
            List<Computer> listCpt = new List<Computer>();
            listCpt = db.Computers.ToList();
            foreach (Computer item in listCpt)
            {
                item.Status = false;
            }
            db.SaveChanges();
        }

        private void btShowInfo_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            MessageProcessing.SendMessage(ClientOnClick, Command.GetInfomation, 3);
        }

        private void btShutdownClient_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            MessageProcessing.SendMessage(ClientOnClick, Command.Shutdown, 3);
        }

        private void btSleepClient_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btRestartClient_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            MessageProcessing.SendMessage(ClientOnClick, Command.Restart, 3);
        }

        private void btUnBlockUSBPort_Click(object sender, EventArgs e)
        {
            if (listClientOnClick.Count == 0)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            foreach(ClientInformation _client in listClientOnClick)
            {
                MessageProcessing.SendMessage(_client.client, Command.UnBlockPortUSB, 3);
            }
        }

        private void btBlockUSBPort_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            MessageProcessing.SendMessage(ClientOnClick, Command.BlockPortUSB, 3);
        }

        private void btOpenNetwork_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btCloseNetwork_Click(object sender, EventArgs e)
        {
            if (ClientOnClick == null)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btMultySelection_Click(object sender, EventArgs e)
        {
            if (listChb.First().Visible == true)
            {
                btMultySelection.Text = "Chọn nhiều máy";
                foreach (CheckBox item in listChb)
                {
                    item.Visible = false;
                }
            }
            else
            {
                btMultySelection.Text = "Bỏ chọn nhiều máy";
                foreach (CheckBox item in listChb)
                {
                    item.Visible = true;
                }
            }
        }

        private void btSendFile_Click(object sender, EventArgs e)
        {
            if (listClientOnClick.Count == 0)
            {
                MessageBox.Show("Client đang tắt hoặc bạn chưa chọn client!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (ClientInformation item in listClientOnClick)
                {
                    MessageProcessing.SendFile(item.client, fd.FileName, 4);
                }
            }
        }
    }
}
