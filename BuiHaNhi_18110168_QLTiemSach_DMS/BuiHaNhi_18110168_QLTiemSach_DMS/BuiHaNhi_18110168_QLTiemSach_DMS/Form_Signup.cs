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
    public partial class Form_Signup : Form
    {
        private int MAKH;
        private Form_Login frm_Login;

        DataTable dtKH = null;
        BLAccount_KH dbAKH = new BLAccount_KH();

        string err;

        public Form_Signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        internal void getForm(Form_Login form_Login)
        {
            this.frm_Login = form_Login;
            //throw new NotImplementedException();
        }

        private void Form_Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login.LoadData();
            frm_Login.Show();
        }

        void LoadData()
        {
            try
            {
                //Lấy account khách hàng
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet dsAKH = dbAKH.LayAKH();
                dtKH = dsAKH.Tables[0];

                this.txtUsername.ResetText();
                this.txtPassword.ResetText();

                //Tạo tự động mã khách hàng
                int i = dtKH.Rows.Count + 1;
                MAKH = i;
                //if (i < 10)
                //{
                //    MAKH = "KH0" + i.ToString();
                //}
                //else
                //{
                //    MAKH = "KH" + i.ToString();
                //}
            }
            catch (SqlException)
            {
                MessageBox.Show("Xảy ra lỗi: Không lấy được nội dung trong table.");
            }
        }

        private void Form_Signup_Load(object sender, EventArgs e)
        {
            LoadData();
            txtUsername.Focus();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                BLAccount_KH bLAccount_KH = new BLAccount_KH();
                bLAccount_KH.ThemKH(MAKH, txtHoTen.Text, txtEmail.Text, int.Parse(txtTuoi.Text), txtSDT.Text, txtDiaChi.Text, 0, 0, ref err);
                bLAccount_KH.ThemAKH(txtUsername.Text, txtPassword.Text, MAKH, ref err);
                // Thông báo
                LoadData();
                MessageBox.Show("Tạo tài khoản thành công.");
            }
            catch (SqlException)
            {
                MessageBox.Show("Tạo tài khoản thất bại.");
            }
        }
    }
}
