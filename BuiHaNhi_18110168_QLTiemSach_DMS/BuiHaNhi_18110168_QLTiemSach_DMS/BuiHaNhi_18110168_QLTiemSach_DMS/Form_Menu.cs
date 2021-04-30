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
    public partial class Form_Menu : Form
    {
        private Form_Login frm_Login;
        private Form_Adjust frm_Adjust;
        //private Form_ChiTietHoaDon frm_CTHD;//newww
        private int MAKH;

        DataTable dtMenu = null;
        DataTable dtKH = null;

        BLAccount_KH dbKH = new BLAccount_KH();

        string err;

        public Form_Menu()
        {
            InitializeComponent();
        }

        /*internal*/public void getForm(Form_Login form_Login, int MaKH)
        {
            this.frm_Login = frm_Login;
            MAKH = MaKH;
            //throw new NotImplementedException();
        }

        /*internal*/public void LoadData()
        {
            //throw new NotImplementedException();
            try
            {
                //Lấy Menu
                dtMenu = new DataTable();
                dtMenu.Clear();
                DataSet ds = dbKH.LayMenu();
                dtMenu = ds.Tables[0];

                //Lấy thông tin khách hàng
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet dsKH = dbKH.LayKH();
                dtKH = dsKH.Tables[0];

                //Tạo list view hóa đơn
                livHoaDon.View = View.Details;
                livHoaDon.Columns.Add("Tên Sản Phẩm", 140);
                livHoaDon.Columns.Add("SL", 30);
                livHoaDon.Columns.Add("Giá", 45);
                livHoaDon.GridLines = true;
                livHoaDon.FullRowSelect = true;

                txtTong.Text = "0";

                if (MAKH != 0)
                {
                    int i = 0;
                    while (i < dtKH.Rows.Count && (int)dtKH.Rows[i][0] != MAKH) i++;
                    txtHoTen.Text = dtKH.Rows[i][1].ToString();
                    txtRank.Text = dtKH.Rows[i][7].ToString();
                }

                // Đưa dữ liệu lên DataGridView
                dgvMenu.DataSource = dtMenu;
                // Thay đổi độ rộng cột
                dgvMenu.AutoResizeColumns();

                dgvMenu_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Xảy ra lỗi: Không lấy được nội dung trong table.");
            }
        }

        private void Form_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login.Show();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            LoadData();
            if (MAKH == 0) btnChange.Enabled = false;
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện lên datagridview
            int r = dgvMenu.CurrentCell.RowIndex;
            txtTenSP.Text = dgvMenu.Rows[r].Cells[2].Value.ToString();
            nuSoluong.Value = 1;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < dtMenu.Rows.Count && dtMenu.Rows[i][2].ToString() != txtTenSP.Text) i++;
            //thêm item
            ListViewItem item = new ListViewItem();
            item.Text = txtTenSP.Text;
            item.SubItems.Add(nuSoluong.Value.ToString());
            item.SubItems.Add(dtMenu.Rows[i][3].ToString());
            livHoaDon.Items.Add(item);

            //tính tổng tiền
            int tong = int.Parse(txtTong.Text) + int.Parse(dtMenu.Rows[i][3].ToString()) * int.Parse(nuSoluong.Value.ToString());
            txtTong.Text = tong.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (livHoaDon.Items.Count == 0)
            {
                MessageBox.Show("Trong Category không có sản phẩm nào.");
                return;
            }
            if (livHoaDon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn hãy chọn sản phẩm muốn xóa.");
                return;
            }

            //tính sl sản phẩm cùng loại bị xóa
            int sl = int.Parse(livHoaDon.Items[livHoaDon.SelectedIndices[0]].SubItems[1].Text);
            //lấy giá của sản phẩm
            int gia = int.Parse(livHoaDon.Items[livHoaDon.SelectedIndices[0]].SubItems[2].Text);
            //tính tổng tiền
            int tong = int.Parse(txtTong.Text) - sl * gia;
            txtTong.Text = tong.ToString();
            //xóa sản phẩm
            livHoaDon.Items.RemoveAt(livHoaDon.SelectedIndices[0]);
            if (livHoaDon.Items.Count != 0) 
                livHoaDon.Items[0].Selected = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (MAKH != 0)
            {
                int i = 0;
                while (i < dtKH.Rows.Count && (int)dtKH.Rows[i][0] != MAKH) i++;

                int tongchi = int.Parse(dtKH.Rows[i][4].ToString());
                int tong = tongchi + int.Parse(txtTong.Text);
                dbKH.CapNhatTien(MAKH, tong, ref err);
                int rank = tong / 1000000;
                if (rank != int.Parse(dtKH.Rows[i][5].ToString()))
                {
                    dbKH.CapNhatCapThanhVien(MAKH, rank, ref err);
                }
                txtRank.Text = dtKH.Rows[i][7].ToString();

                //int khuyenmai = int.Parse(dtKH.Rows[i][6].ToString());
                //if (khuyenmai < 50)
                //{
                //    int km = rank * 5;
                //    dbKH.CapNhatKM(MAKH, km, ref err);
                //}
            }
            MessageBox.Show("Thanh toán hoàn thành. Xin cảm ơn quý khách.");
            //frm_CTHD = new Form_ChiTietHoaDon();
            //frm_CTHD.getForm(this, MAKH);
            //frm_CTHD.Show();
            //this.Hide();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frm_Adjust = new Form_Adjust();
            frm_Adjust.getForm(this, MAKH);
            frm_Adjust.Show();
            this.Hide();
        }
    }
}
