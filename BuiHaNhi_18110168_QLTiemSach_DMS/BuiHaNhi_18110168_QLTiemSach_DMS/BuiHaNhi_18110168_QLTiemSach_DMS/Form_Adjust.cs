using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuiHaNhi_18110168_QLTiemSach_DMS.BSLayer;

namespace BuiHaNhi_18110168_QLTiemSach_DMS
{
    public partial class Form_Adjust : Form
    {
        private Form_Menu frm_Menu;
        private int MAKH;
        string err;

        DataTable dtAKH = null;
        DataTable dtKH = null;
        BLAccount_KH dbKH = new BLAccount_KH();

        public Form_Adjust()
        {
            InitializeComponent();
        }
        public void getForm(Form_Menu frmMenu, int makh)
        {
            this.frm_Menu = frmMenu;
            this.MAKH = makh;
        }
        void LoadData()
        {
            try
            {
                //Lấy thông tin khách hàng
                dtAKH = new DataTable();
                dtAKH.Clear();
                DataSet dsAKH = dbKH.LayAKH();
                dtAKH = dsAKH.Tables[0];

                dtKH = new DataTable();
                dtKH.Clear();
                DataSet dsKH = dbKH.LayKH();
                dtKH = dsKH.Tables[0];

                int i = 0;
                while (i < dtAKH.Rows.Count && (int)dtAKH.Rows[i][2] != MAKH) i++;
                txtUsername.Text = dtAKH.Rows[i][0].ToString();
                txtPassword.Text = dtAKH.Rows[i][1].ToString();

                int j = 0;
                while (j < dtKH.Rows.Count && (int)dtKH.Rows[j][0] != MAKH) j++;
                txtHoTen.Text = dtKH.Rows[j][1].ToString();
                txtEmail.Text = dtKH.Rows[j][2].ToString();
                txtTuoi.Text = dtKH.Rows[j][3].ToString();
                txtSDT.Text = dtKH.Rows[j][4].ToString();
                txtDiaChi.Text = dtKH.Rows[j][5].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Xảy ra lỗi: Không lấy được nội dung trong table.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dbKH.CapNhatKH(MAKH, txtHoTen.Text, txtEmail.Text, int.Parse(txtTuoi.Text), txtSDT.Text, txtDiaChi.Text, ref err);
            dbKH.CapNhatAKH(txtUsername.Text, txtPassword.Text, MAKH, ref err);
            MessageBox.Show("Đã cập nhật!");
            LoadData();
        }

        private void Form_Adjust_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form_Adjust_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Menu.LoadData();
            frm_Menu.Show();
        }
    }
}
