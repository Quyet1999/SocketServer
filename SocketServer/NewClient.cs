using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketServer.Model;
using System.Net;

namespace SocketServer
{
    public partial class NewClient : Form
    {
        private Computer MyCpt;
        string mode;
        public NewClient(Computer _Computer, string _mode)
        {
            InitializeComponent();
            MyCpt = _Computer;
            mode = _mode;
            if (mode.ToUpper().Equals("VIEW_INFO"))
            {
                LoadData();
            }
            else if (mode.ToUpper().Equals("NEW_INFO"))
            {
                NewData();
            }
            else
            {

            }
        }
        void LoadData()
        {
            btSave.Text = "Lưu thay đổi";
            txbID.Text = MyCpt.ComputerID.ToString();
            txbHostName.Text = MyCpt.Name;
            txbMAC.Text = MyCpt.Mac_Address;
            txbIPAddress.Text = MyCpt.IP_Address;
            if (MyCpt.Status == true)
            {
                txbStatus.Text = "Đang sử dụng";
                Models db = new Models();
                //Account acc=db.Accounts.Where(x=>x.ID==MyCpt.ComputerID)
                //txbUser.Text = MyCpt.Account.FullName;
                txbStartTime.Text = MyCpt.TimeStart.ToString();
            }
            else
            {
                txbStatus.Text = "Đang tắt";
                txbUser.Text = txbStartTime.Text = "";
            }
        }
        void NewData()
        {
            btSave.Text = "Lưu";
            txbID.Text = "";
            txbHostName.Text = "";
            txbMAC.Text = "";
            txbIPAddress.Text = "";
            txbStatus.Text = "Đang tắt";
            txbUser.Text = "";
            txbStartTime.Text = "";
            txbUser.Enabled = false;
            txbStartTime.Enabled = false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Models db = new Models();
            if (btSave.Text=="Lưu thay đổi")
            {
                if (txbID.Text.Equals(MyCpt.ComputerID.ToString()) == false)
                {
                    MessageBox.Show("Bạn không thể sửa đổi ID", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IPAddress _ip;
                if(IPAddress.TryParse(txbIPAddress.Text,out _ip) == false)
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Computer cpt = db.Computers.Where(x => x.ComputerID == MyCpt.ComputerID).FirstOrDefault();
                if (cpt == null)
                {
                    MessageBox.Show("Có thể máy này đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cpt.Name = txbHostName.Text;
                cpt.Mac_Address = txbMAC.Text;
                cpt.IP_Address = txbIPAddress.Text;
                db.SaveChanges();
                MyCpt = cpt;
            }
            else if (btSave.Text == "Lưu")
            {
                int ID;
                if (Int32.TryParse(txbID.Text, out ID) == false)
                {
                    MessageBox.Show("ID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (db.Computers.Where(x=>x.ComputerID == ID).FirstOrDefault()!=null)
                {
                    MessageBox.Show("ID đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IPAddress _ip;
                if (IPAddress.TryParse(txbIPAddress.Text, out _ip) == false)
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MyCpt.ComputerID = ID;
                MyCpt.Name = txbHostName.Text;
                MyCpt.Mac_Address = txbMAC.Text;
                MyCpt.IP_Address = txbIPAddress.Text;
                db.Computers.Add(MyCpt);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void btreLoad_Click(object sender, EventArgs e)
        {
            if (mode.ToUpper().Equals("VIEW_INFO"))
            {
                LoadData();
            }
            else if (mode.ToUpper().Equals("NEW_INFO"))
            {
                NewData();
            }
            else
            {

            }
        }
    }
}
