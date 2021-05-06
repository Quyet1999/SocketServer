
namespace SocketServer
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rTxbLog = new System.Windows.Forms.RichTextBox();
            this.cbHost = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýMáyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnListComputer = new System.Windows.Forms.Panel();
            this.btMultySelection = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btSendFile = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbInputMess = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btCloseNetwork = new System.Windows.Forms.Button();
            this.btOpenNetwork = new System.Windows.Forms.Button();
            this.btBlockUSBPort = new System.Windows.Forms.Button();
            this.btUnBlockUSBPort = new System.Windows.Forms.Button();
            this.btRestartClient = new System.Windows.Forms.Button();
            this.btSleepClient = new System.Windows.Forms.Button();
            this.btShowInfo = new System.Windows.Forms.Button();
            this.btShutdownClient = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCptName_btnClick = new System.Windows.Forms.Label();
            this.timeLoadListCpt = new System.Windows.Forms.Timer(this.components);
            this.pnMessage = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnListComputer.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // rTxbLog
            // 
            this.rTxbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxbLog.Location = new System.Drawing.Point(0, 139);
            this.rTxbLog.Name = "rTxbLog";
            this.rTxbLog.Size = new System.Drawing.Size(261, 607);
            this.rTxbLog.TabIndex = 1;
            this.rTxbLog.Text = "";
            // 
            // cbHost
            // 
            this.cbHost.FormattingEnabled = true;
            this.cbHost.Location = new System.Drawing.Point(111, 14);
            this.cbHost.Name = "cbHost";
            this.cbHost.Size = new System.Drawing.Size(121, 24);
            this.cbHost.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cổng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Địa chỉ IP";
            // 
            // txbPort
            // 
            this.txbPort.Location = new System.Drawing.Point(111, 54);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(121, 22);
            this.txbPort.TabIndex = 2;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(111, 100);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Bắt đầu";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýMáyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1483, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýMáyToolStripMenuItem
            // 
            this.quảnLýMáyToolStripMenuItem.Name = "quảnLýMáyToolStripMenuItem";
            this.quảnLýMáyToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.quảnLýMáyToolStripMenuItem.Text = "Quản lý máy";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rTxbLog);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 746);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbHost);
            this.panel2.Controls.Add(this.btnStartServer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txbPort);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 139);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnListComputer);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(261, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1222, 746);
            this.panel3.TabIndex = 8;
            // 
            // pnListComputer
            // 
            this.pnListComputer.BackColor = System.Drawing.Color.Lavender;
            this.pnListComputer.Controls.Add(this.btMultySelection);
            this.pnListComputer.Controls.Add(this.btnAddClient);
            this.pnListComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListComputer.Location = new System.Drawing.Point(0, 0);
            this.pnListComputer.Name = "pnListComputer";
            this.pnListComputer.Size = new System.Drawing.Size(836, 746);
            this.pnListComputer.TabIndex = 3;
            // 
            // btMultySelection
            // 
            this.btMultySelection.Location = new System.Drawing.Point(615, 673);
            this.btMultySelection.Name = "btMultySelection";
            this.btMultySelection.Size = new System.Drawing.Size(93, 69);
            this.btMultySelection.TabIndex = 35;
            this.btMultySelection.Text = "Chọn nhiều máy";
            this.btMultySelection.UseVisualStyleBackColor = true;
            this.btMultySelection.Click += new System.EventHandler(this.btMultySelection_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackgroundImage = global::SocketServer.Properties.Resources.monitor;
            this.btnAddClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddClient.Location = new System.Drawing.Point(731, 671);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(81, 71);
            this.btnAddClient.TabIndex = 33;
            this.btnAddClient.Text = "Add";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnMessage);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(836, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 746);
            this.panel5.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 250);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(386, 32);
            this.panel9.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chat";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btSendFile);
            this.panel7.Controls.Add(this.btnSend);
            this.panel7.Controls.Add(this.tbInputMess);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 662);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(386, 84);
            this.panel7.TabIndex = 3;
            // 
            // btSendFile
            // 
            this.btSendFile.BackgroundImage = global::SocketServer.Properties.Resources.attach;
            this.btSendFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSendFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSendFile.Location = new System.Drawing.Point(5, 3);
            this.btSendFile.Name = "btSendFile";
            this.btSendFile.Size = new System.Drawing.Size(33, 34);
            this.btSendFile.TabIndex = 2;
            this.btSendFile.UseVisualStyleBackColor = true;
            this.btSendFile.Click += new System.EventHandler(this.btSendFile_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackgroundImage = global::SocketServer.Properties.Resources.Send;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.Location = new System.Drawing.Point(342, 40);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(40, 40);
            this.btnSend.TabIndex = 1;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbInputMess
            // 
            this.tbInputMess.Location = new System.Drawing.Point(5, 41);
            this.tbInputMess.Multiline = true;
            this.tbInputMess.Name = "tbInputMess";
            this.tbInputMess.Size = new System.Drawing.Size(331, 39);
            this.tbInputMess.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(386, 250);
            this.panel6.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btCloseNetwork);
            this.panel8.Controls.Add(this.btOpenNetwork);
            this.panel8.Controls.Add(this.btBlockUSBPort);
            this.panel8.Controls.Add(this.btUnBlockUSBPort);
            this.panel8.Controls.Add(this.btRestartClient);
            this.panel8.Controls.Add(this.btSleepClient);
            this.panel8.Controls.Add(this.btShowInfo);
            this.panel8.Controls.Add(this.btShutdownClient);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 38);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(386, 212);
            this.panel8.TabIndex = 7;
            // 
            // btCloseNetwork
            // 
            this.btCloseNetwork.BackgroundImage = global::SocketServer.Properties.Resources.icons8_wi_fi_disconnected_48;
            this.btCloseNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCloseNetwork.Location = new System.Drawing.Point(268, 160);
            this.btCloseNetwork.Name = "btCloseNetwork";
            this.btCloseNetwork.Size = new System.Drawing.Size(50, 46);
            this.btCloseNetwork.TabIndex = 11;
            this.btCloseNetwork.UseVisualStyleBackColor = true;
            this.btCloseNetwork.Click += new System.EventHandler(this.btCloseNetwork_Click);
            // 
            // btOpenNetwork
            // 
            this.btOpenNetwork.BackgroundImage = global::SocketServer.Properties.Resources.icons8_wi_fi_connected_48;
            this.btOpenNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btOpenNetwork.Location = new System.Drawing.Point(185, 160);
            this.btOpenNetwork.Name = "btOpenNetwork";
            this.btOpenNetwork.Size = new System.Drawing.Size(50, 46);
            this.btOpenNetwork.TabIndex = 10;
            this.btOpenNetwork.UseVisualStyleBackColor = true;
            this.btOpenNetwork.Click += new System.EventHandler(this.btOpenNetwork_Click);
            // 
            // btBlockUSBPort
            // 
            this.btBlockUSBPort.BackgroundImage = global::SocketServer.Properties.Resources.icons8_usb_disconnected_48;
            this.btBlockUSBPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBlockUSBPort.Location = new System.Drawing.Point(101, 160);
            this.btBlockUSBPort.Name = "btBlockUSBPort";
            this.btBlockUSBPort.Size = new System.Drawing.Size(50, 46);
            this.btBlockUSBPort.TabIndex = 9;
            this.btBlockUSBPort.UseVisualStyleBackColor = true;
            this.btBlockUSBPort.Click += new System.EventHandler(this.btBlockUSBPort_Click);
            // 
            // btUnBlockUSBPort
            // 
            this.btUnBlockUSBPort.BackgroundImage = global::SocketServer.Properties.Resources.icons8_usb_connected_48;
            this.btUnBlockUSBPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btUnBlockUSBPort.Location = new System.Drawing.Point(18, 160);
            this.btUnBlockUSBPort.Name = "btUnBlockUSBPort";
            this.btUnBlockUSBPort.Size = new System.Drawing.Size(50, 46);
            this.btUnBlockUSBPort.TabIndex = 8;
            this.btUnBlockUSBPort.UseVisualStyleBackColor = true;
            this.btUnBlockUSBPort.Click += new System.EventHandler(this.btUnBlockUSBPort_Click);
            // 
            // btRestartClient
            // 
            this.btRestartClient.BackgroundImage = global::SocketServer.Properties.Resources.restart;
            this.btRestartClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btRestartClient.Location = new System.Drawing.Point(184, 83);
            this.btRestartClient.Name = "btRestartClient";
            this.btRestartClient.Size = new System.Drawing.Size(50, 46);
            this.btRestartClient.TabIndex = 7;
            this.btRestartClient.UseVisualStyleBackColor = true;
            this.btRestartClient.Click += new System.EventHandler(this.btRestartClient_Click);
            // 
            // btSleepClient
            // 
            this.btSleepClient.BackgroundImage = global::SocketServer.Properties.Resources.sleep_mode;
            this.btSleepClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSleepClient.Location = new System.Drawing.Point(101, 83);
            this.btSleepClient.Name = "btSleepClient";
            this.btSleepClient.Size = new System.Drawing.Size(50, 46);
            this.btSleepClient.TabIndex = 6;
            this.btSleepClient.UseVisualStyleBackColor = true;
            this.btSleepClient.Click += new System.EventHandler(this.btSleepClient_Click);
            // 
            // btShowInfo
            // 
            this.btShowInfo.BackgroundImage = global::SocketServer.Properties.Resources.info;
            this.btShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btShowInfo.Location = new System.Drawing.Point(18, 6);
            this.btShowInfo.Name = "btShowInfo";
            this.btShowInfo.Size = new System.Drawing.Size(50, 46);
            this.btShowInfo.TabIndex = 3;
            this.btShowInfo.UseVisualStyleBackColor = true;
            this.btShowInfo.Click += new System.EventHandler(this.btShowInfo_Click);
            // 
            // btShutdownClient
            // 
            this.btShutdownClient.BackgroundImage = global::SocketServer.Properties.Resources.shutdown;
            this.btShutdownClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btShutdownClient.Location = new System.Drawing.Point(18, 83);
            this.btShutdownClient.Name = "btShutdownClient";
            this.btShutdownClient.Size = new System.Drawing.Size(50, 46);
            this.btShutdownClient.TabIndex = 5;
            this.btShutdownClient.UseVisualStyleBackColor = true;
            this.btShutdownClient.Click += new System.EventHandler(this.btShutdownClient_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lbCptName_btnClick);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 38);
            this.panel4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(16, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Client:";
            // 
            // lbCptName_btnClick
            // 
            this.lbCptName_btnClick.AutoSize = true;
            this.lbCptName_btnClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCptName_btnClick.Location = new System.Drawing.Point(121, 14);
            this.lbCptName_btnClick.Name = "lbCptName_btnClick";
            this.lbCptName_btnClick.Size = new System.Drawing.Size(0, 20);
            this.lbCptName_btnClick.TabIndex = 1;
            // 
            // timeLoadListCpt
            // 
            this.timeLoadListCpt.Interval = 10000;
            this.timeLoadListCpt.Tick += new System.EventHandler(this.timeLoadListCpt_Tick);
            // 
            // pnMessage
            // 
            this.pnMessage.AutoScroll = true;
            this.pnMessage.BackColor = System.Drawing.Color.White;
            this.pnMessage.Controls.Add(this.button2);
            this.pnMessage.Controls.Add(this.button1);
            this.pnMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMessage.Location = new System.Drawing.Point(0, 282);
            this.pnMessage.Name = "pnMessage";
            this.pnMessage.Size = new System.Drawing.Size(386, 380);
            this.pnMessage.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "[12:30:22 12/12/2021]xin chafo banj chunsg tooi laf ai do hahaha chao ban nha ban" +
    " yeu dau";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(83, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "xin chafo banj chunsg tooi laf ai do hahaha chao ban nha ban yeu dau";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 774);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnListComputer.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.RichTextBox rTxbLog;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýMáyToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbCptName_btnClick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btSendFile;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbInputMess;
        private System.Windows.Forms.Panel pnListComputer;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Timer timeLoadListCpt;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btRestartClient;
        private System.Windows.Forms.Button btSleepClient;
        private System.Windows.Forms.Button btShowInfo;
        private System.Windows.Forms.Button btShutdownClient;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btBlockUSBPort;
        private System.Windows.Forms.Button btUnBlockUSBPort;
        private System.Windows.Forms.Button btCloseNetwork;
        private System.Windows.Forms.Button btOpenNetwork;
        private System.Windows.Forms.Button btMultySelection;
        private System.Windows.Forms.Panel pnMessage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

