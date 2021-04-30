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
using BuiHaNhi_18110168_QLTiemSach_DMS.ShareVarrr;

namespace BuiHaNhi_18110168_QLTiemSach_DMS
{
    public partial class Form_Login : Form
    {
        private Form_Signup frm_Signup;
        private Form_Menu frm_Menu;
        private Form_Manage frm_Manage;

        bool beQL;
        bool beNV;
        bool beKH;

        DataTable dtQL = null;
        DataTable dtNV = null;
        DataTable dtKH = null;

        BLAccount dbA = new BLAccount();

        //ShareVar.cs
        //public static string MaNQL_TK;
        //public static string TenTK_TK;
        //public static bool setNV = false;

        public Form_Login()
        {
            InitializeComponent();
        }
        //public System.Windows.Forms.Form GetForm();
        public void LoadData()
        {
            try
            {
                //Lấy account quản lý
                dtQL = new DataTable();
                dtQL.Clear();
                DataSet dsAQL = dbA.LayAQL();
                dtQL = dsAQL.Tables[0];

                //Lấy account nhân viên
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet dsANV = dbA.LayANV();
                dtNV = dsANV.Tables[0];

                //Lấy account khách hàng
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet dsAKH = dbA.LayAKH();
                dtKH = dsAKH.Tables[0];

                if (beQL)
                {
                    // Xóa trống các đối tượng trong Panel
                    this.txtUsername.ResetText();
                    this.txtPassword.ResetText();
                    // Không cho thao tác trên các nút đăng ký
                    this.btnSignup.Enabled = false;
                }
                else if (beNV)
                {
                    // Xóa trống các đối tượng trong Panel
                    this.txtUsername.ResetText();
                    this.txtPassword.ResetText();
                    // Không cho thao tác trên các nút đăng ký
                    this.btnSignup.Enabled = false;
                }
                else if (beKH)
                {
                    // Xóa trống các đối tượng trong Panel
                    this.txtUsername.ResetText();
                    this.txtPassword.ResetText();
                    //Cho phép thao tác trên nút đăng ký
                    //this.btnSignup.Enabled = true;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đăng nhập thành công.");//Mess:Xuất Hiện Lỗi: Không lấy được nội dung trong table.
            }
        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            LoadData();
            btnKH.PerformClick();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            frm_Signup = new Form_Signup();
            frm_Signup.getForm(this); //ignore GETFORM CANT USE
            frm_Signup.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (beQL)
            {
                int i = 0;
                for (; i < dtQL.Rows.Count; i++)
                {
                    if (txtUsername.Text == dtQL.Rows[i][0].ToString() && txtPassword.Text == dtQL.Rows[i][1].ToString())
                    {
                        ShareVar.MaNQL_TK = dtQL.Rows[i][2].ToString();
                        ShareVar.TenTK_TK = dtQL.Rows[i][0].ToString();
                        frm_Manage = new Form_Manage();
                        frm_Manage.getForm(this, dtQL.Rows[i][2].ToString(), txtUsername.Text.ToString(), txtPassword.Text.ToString());
                        frm_Manage.Show();

                        this.Hide();
                        break;
                    }
                }
                if (i == dtQL.Rows.Count) MessageBox.Show("Tài khoản quản lý không đúng!");
                //frm_Manage = new Form_Manage();
                //frm_Manage.getForm(this, dtNV.Rows[i][2].ToString());
                //frm_Manage.Show();
                //this.Hide();
            }
            else if (beNV)
            {
                int i = 0;
                for (; i < dtNV.Rows.Count; i++)
                {
                    if (txtUsername.Text == dtNV.Rows[i][0].ToString() && txtPassword.Text == dtNV.Rows[i][1].ToString())
                    {
                        ShareVar.setNV = true;
                        frm_Manage = new Form_Manage();
                        frm_Manage.getForm(this, dtNV.Rows[i][2].ToString(), txtUsername.Text.ToString(), txtPassword.Text.ToString());
                        frm_Manage.Show();
                        this.Hide();
                        break;
                    }
                }
                if (i == dtNV.Rows.Count) MessageBox.Show("Tài khoản nhân viên không đúng!");
                //frm_Manage = new Form_Manage();
                //frm_Manage.getForm(this, dtNV.Rows[i][2].ToString());
                //frm_Manage.Show();
                //this.Hide();
            }
            else if (beKH)
            {
                int i = 0;
                for (; i < dtKH.Rows.Count; i++)
                {
                    if (txtUsername.Text == dtKH.Rows[i][0].ToString() && txtPassword.Text == dtKH.Rows[i][1].ToString())
                    {
                        frm_Menu = new Form_Menu();
                        frm_Menu.getForm(this, (int)dtKH.Rows[i][2]);
                        frm_Menu.Show();
                        this.Hide();
                        break;
                    }
                }
                if (i == dtKH.Rows.Count) MessageBox.Show("Tài khoản khách hàng không đúng. Đăng ký =>>");
            }
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            btnSignup.Enabled = false;
            beQL = true;
            //beNV = true;
            beNV = false;
            beKH = false;
            btnQL.BackColor = Color.Yellow;
            btnNV.BackColor = DefaultBackColor;
            btnKH.BackColor = DefaultBackColor;
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtUsername.Focus();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            btnSignup.Enabled = false;
            beQL = false;
            beNV = true;
            beKH = false;
            btnNV.BackColor = Color.Yellow;
            btnKH.BackColor = DefaultBackColor;
            btnQL.BackColor = DefaultBackColor;
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtUsername.Focus();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            btnSignup.Enabled = true;
            beKH = true;
            beNV = false;
            btnKH.BackColor = Color.Yellow;
            btnNV.BackColor = DefaultBackColor;
            btnQL.BackColor = DefaultBackColor;
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtUsername.Focus();
        }

        private void btnXemMenu_Click(object sender, EventArgs e)
        {
            frm_Menu = new Form_Menu();
            frm_Menu.getForm(this, 0); //ignore GETFORM CANT USE
            frm_Menu.Show();
            this.Hide();
        }

        private void Form_Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
