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
    public partial class Form_Manage : Form
    {
        private Form_Login frm_Login;
        private string MA;

        DataTable dtMenu = null;
        DataTable dtNV = null;
        DataTable dtKH = null;
        DataTable dtQL = null;

        BLAccount_QL dbQL;
        BLAccount_NV dbNV;
        BLAccount_KH dbKH = new BLAccount_KH();

        //các biến bool
        bool Them;
        bool Sua;
        bool TimMa;
        bool TimGia;
        bool TimTen;
        bool TimChuc;
        bool TimSDT;
        bool TimDiaChi;
        bool TimCapBac;
        bool TimLuong;
        bool TimTongCT;

        //biến dùng cho hàm search
        string style, var;
        string err;

        //ShareVar.cs
        //public static string MaNQL_TK;
        //public static string TenTK_TK;
        //public static bool setNV = false;


        public Form_Manage()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Lọc Menu
            DataTable dtTemp = new DataTable();
            if (TimMa)
            {
                style = "MaMon";
                var = txtMaSP.Text;
            }
            else if (TimTen)
            {
                style = "TenMon";
                var = txtTenSP.Text;
            }
            else if (TimGia)
            {
                var = txtGiaNhoHon.Text;
            }

            if (!TimGia)
            {
                dtTemp.Clear();
                DataSet dstemp = dbNV.TimSP(style, var);
                dtTemp = dstemp.Tables[0];
            }
            else
            {
                dtTemp.Clear();
                DataSet dstemp = dbNV.TimSP_Gia(int.Parse(var));
                dtTemp = dstemp.Tables[0];
            }

            if (dtTemp.Rows.Count == 0) MessageBox.Show("Không tìm thấy.");
            else
            {
                // Đưa dữ liệu lên DataGridView
                dgvQLMenu.DataSource = dtTemp;
                // Thay đổi độ rộng cột
                dgvQLMenu.AutoResizeColumns();

                dgvQLMenu_CellClick(null, null);

                //reset text
                txtMaSP.ResetText();
                txtMaLoai.ResetText();
                txtTenSP.ResetText();
                txtGia.ResetText();
                txtMaTacGia.ResetText();
                txtSLBan.ResetText();
                txtGia.Enabled = false;
            }
        }

        internal void getForm(Form_Login form_Login, string Ma, string id, string pass)
        {
            //đổi internal sang public
            frm_Login = form_Login;
            MA = Ma;
            dbQL = new BLAccount_QL(id, pass);
            dbNV = new BLAccount_NV(id, pass);
            //throw new NotImplementedException();
        }

        void LoadData()
        {
            try
            {
                //Lấy Menu
                DataTable dtMenu = new DataTable();
                dtMenu.Clear();
                DataSet ds = dbNV.LayMenu();
                dtMenu = ds.Tables[0];

                //Lấy thông tin nhân viên
                DataTable dtNV = new DataTable();
                dtNV.Clear();
                DataSet dsNV = dbNV.LayNV();
                dtNV = dsNV.Tables[0];

                //Lấy thông tin Khách hàng
                DataTable dtKH = new DataTable();
                dtKH.Clear();
                DataSet dsKH = dbKH.LayKH();
                dtKH = dsKH.Tables[0];

                // Đưa dữ liệu lên DataGridView
                dgvQLNV.DataSource = dtNV;
                dgvQLKH.DataSource = dtKH;
                dgvQLMenu.DataSource = dtMenu;

                // Thay đổi độ rộng cột
                dgvQLNV.AutoResizeColumns();
                dgvQLKH.AutoResizeColumns();
                dgvQLMenu.AutoResizeColumns();

                dgvQLKH_CellClick(null, null);
                dgvQLMenu_CellClick(null, null);
                dgvQLNV_CellClick(null, null);
                dgvQLNV2_CellClick(null, null);

                if (ShareVar.setNV == true)
                {
                    panel_ControlNV.Enabled = false;
                    panel_QLTKQL.Enabled = false;
                    panel_QLNV_CN.Enabled = false;
                }
                else
                {
                    panel_ControlNV.Enabled = true;
                    panel_QLTKQL.Enabled = true;
                    panel_QLNV_CN.Enabled = true;
                }

                //
                panel_ThongTinNV.Enabled = false;
                panel_ThongTinSP.Enabled = false;
                panel_ThongTinKH.Enabled = false;

                dgvQLKH_CellClick(null, null);
                dgvQLMenu_CellClick(null, null);
                dgvQLNV_CellClick(null, null);
                dgvQLNV2_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Xuất Hiện Lỗi: Không lấy được nội dung trong table.");
            }
        }

        private void Form_Manage_Load(object sender, EventArgs e)
        {
            LoadData();
            panel_SearchNV.Enabled = false;
            btnLuuNV.Enabled = false;

            panel_SearchSP.Enabled = false;
            btnLuuSP.Enabled = false;

            panel_SearchKH.Enabled = false;
            btnLuuKH.Enabled = false;

            panel_LuongNV.Enabled = false;
            lbMaQL.Text = ShareVar.MaNQL_TK;
            lbTaiKhoanQL.Text = ShareVar.TenTK_TK;
        }

        private void dgvQLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thứ tự dòng/CỘT hiện lên datagridview
            int r = dgvQLNV.CurrentCell.RowIndex;
            txtTenNV.Text = dgvQLNV.Rows[r].Cells[1].Value.ToString();
            txtEmailNV.Text = dgvQLNV.Rows[r].Cells[2].Value.ToString();
            txtTuoiNV.Text = dgvQLNV.Rows[r].Cells[3].Value.ToString();
            txtChucVuNV.Text = dgvQLNV.Rows[r].Cells[4].Value.ToString();
            txtSdtNV.Text = dgvQLNV.Rows[r].Cells[5].Value.ToString();
            txtDiaChiNV.Text = dgvQLNV.Rows[r].Cells[6].Value.ToString();
            txtMaChiNhanhNV.Text = dgvQLNV.Rows[r].Cells[7].Value.ToString();
            txtLuongNV.Text = dgvQLNV.Rows[r].Cells[8].Value.ToString();
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            panel_SearchNV.Enabled = !panel_SearchNV.Enabled;
            panel_ThongTinNV.Enabled = panel_SearchNV.Enabled;

            btnThemNV.Enabled = btnSuaNV.Enabled = btnXoaNV.Enabled = !panel_SearchNV.Enabled;
            btnLuuNV.Enabled = txtLuongNV.Enabled = false;

            //
            radChucVuNV.Checked = panel_SearchNV.Enabled;
            radDiaChiNV.Checked = panel_SearchNV.Enabled;
            radSdtNV.Checked = panel_SearchNV.Enabled;
            radTenNV.Checked = panel_SearchNV.Enabled;
            radLuongNV.Checked = panel_SearchNV.Enabled;
            //reset text
            txtTenNV.ResetText();
            txtEmailNV.ResetText();
            txtTuoiNV.ResetText();
            txtChucVuNV.ResetText();
            txtDiaChiNV.ResetText();
            txtSdtNV.ResetText();
            txtMaChiNhanhNV.ResetText();
            txtLuongNV.ResetText();

            //focus vào tên
            txtTenNV.Focus();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            Them = true;
            Sua = false;
            btnLuuNV.Enabled = true;
            panel_ThongTinNV.Enabled = true;
            txtLuongNV.Enabled = true;

            //reset toàn bộ text
            txtTenNV.ResetText();
            txtEmailNV.ResetText();
            txtTuoiNV.ResetText();
            txtChucVuNV.ResetText();
            txtDiaChiNV.ResetText();
            txtSdtNV.ResetText();
            txtMaChiNhanhNV.ResetText();
            txtLuongNV.ResetText();

            //focus ô Tên NV
            txtTenNV.Focus();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            Sua = true;
            Them = false;
            btnLuuNV.Enabled = true;
            panel_ThongTinNV.Enabled = true;
            txtLuongNV.Enabled = true;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                int r = dgvQLNV.CurrentCell.RowIndex;
                string manv = dgvQLNV.Rows[r].Cells[0].Value.ToString();
                dbNV.XoaNV(ref err, manv);
            }
            LoadData();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                //tự tạo mã NV
                int manv;
                int count = dtNV.Rows.Count + 1;
                manv = 1000 + count;
                //if (count < 10)
                //{
                //    manv = manv + "0" + count.ToString();
                //}
                //else
                //{
                //    manv += count.ToString();
                //}

                dbNV.ThemNV(manv, txtTenNV.Text, txtEmailNV.Text, int.Parse(txtTuoiNV.Text), txtChucVuNV.Text, txtSdtNV.Text, txtDiaChiNV.Text, int.Parse(txtMaChiNhanhNV.Text), int.Parse(txtLuongNV.Text), ref err);
            }
            else if (Sua)
            {
                int r = dgvQLNV.CurrentCell.RowIndex;
                int manv = (int)dgvQLNV.Rows[r].Cells[0].Value;
                dbNV.CapNhatNV(manv, txtTenNV.Text, txtEmailNV.Text, int.Parse(txtTuoiNV.Text), txtChucVuNV.Text, txtSdtNV.Text, txtDiaChiNV.Text, int.Parse(txtMaChiNhanhNV.Text), int.Parse(txtLuongNV.Text), ref err);
            }
            MessageBox.Show("Đã lưu");
            LoadData();
        }

        private void radTenNV_CheckedChanged(object sender, EventArgs e)
        {
            TimTen = true;
            TimLuong = TimChuc = TimDiaChi = TimSDT = false;

            txtTenNV.Enabled = true;
            panel_LuongNV.Enabled = txtEmailNV.Enabled = txtTuoiNV.Enabled = txtMaChiNhanhNV.Enabled = txtChucVuNV.Enabled = txtDiaChiNV.Enabled = txtSdtNV.Enabled = !radTenNV.Checked;

            txtTenNV.Focus();
        }

        private void radChucVuNV_CheckedChanged(object sender, EventArgs e)
        {
            TimChuc = true;
            TimLuong = TimTen = TimDiaChi = TimSDT = false;

            txtChucVuNV.Enabled = true;
            panel_LuongNV.Enabled = txtEmailNV.Enabled = txtTuoiNV.Enabled = txtMaChiNhanhNV.Enabled = txtDiaChiNV.Enabled = txtTenNV.Enabled = txtSdtNV.Enabled = !radChucVuNV.Checked;

            txtChucVuNV.Focus();
        }

        private void radDiaChiNV_CheckedChanged(object sender, EventArgs e)
        {
            TimDiaChi = true;
            TimLuong = TimChuc = TimTen = TimSDT = false;

            txtDiaChiNV.Enabled = true;
            panel_LuongNV.Enabled = txtEmailNV.Enabled = txtTuoiNV.Enabled = txtMaChiNhanhNV.Enabled = txtChucVuNV.Enabled = txtTenNV.Enabled = txtSdtNV.Enabled = !radDiaChiNV.Checked;

            txtDiaChiNV.Focus();
        }

        private void radSdtNV_CheckedChanged(object sender, EventArgs e)
        {
            TimSDT = true;
            TimLuong = TimChuc = TimDiaChi = TimTen = false;

            txtSdtNV.Enabled = true;
            panel_LuongNV.Enabled = txtEmailNV.Enabled = txtTuoiNV.Enabled = txtMaChiNhanhNV.Enabled = txtChucVuNV.Enabled = txtTenNV.Enabled = txtDiaChiNV.Enabled = !radSdtNV.Checked;

            txtSdtNV.Focus();
        }

        private void radLuongNV_CheckedChanged(object sender, EventArgs e)
        {
            TimLuong = true;
            TimTen = TimDiaChi = TimSDT = TimChuc = false;

            panel_LuongNV.Enabled = true;
            txtChucVuNV.Enabled = txtEmailNV.Enabled = txtTuoiNV.Enabled = txtMaChiNhanhNV.Enabled = txtDiaChiNV.Enabled = txtTenNV.Enabled = txtSdtNV.Enabled = !radLuongNV.Checked;

            //trbMucLuong.Value = 0;
            //txtLuongNhoHon.Text = null;
            //txtLuongLonHon.Text = null;
        }

        private void btnLoadNV_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvQLMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thứ tự dòng / CỘT hiện lên datagridview
            int r = dgvQLMenu.CurrentCell.RowIndex;
            txtMaLoai.Text = dgvQLMenu.Rows[r].Cells[0].Value.ToString();
            txtMaSP.Text = dgvQLMenu.Rows[r].Cells[1].Value.ToString();
            txtTenSP.Text = dgvQLMenu.Rows[r].Cells[2].Value.ToString();
            txtGia.Text = dgvQLMenu.Rows[r].Cells[3].Value.ToString();
            txtMaTacGia.Text = dgvQLMenu.Rows[r].Cells[4].Value.ToString();
            txtSLBan.Text = dgvQLMenu.Rows[r].Cells[5].Value.ToString();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            Them = true;
            Sua = false;
            btnLuuSP.Enabled = true;
            panel_ThongTinSP.Enabled = true;
            txtGia.Enabled = true;

            //reset toàn bộ text
            txtMaSP.ResetText();
            txtMaLoai.ResetText();
            txtTenSP.ResetText();
            txtGia.ResetText();
            txtMaTacGia.ResetText();
            txtSLBan.ResetText();
            txtGia.Enabled = false;
            //focus ô Tên NV
            txtMaSP.Focus();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            Sua = true;
            Them = false;
            btnLuuSP.Enabled = true;
            panel_ThongTinSP.Enabled = true;
            txtGia.Enabled = true;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                int r = dgvQLMenu.CurrentCell.RowIndex;
                string masp = dgvQLMenu.Rows[r].Cells[0].Value.ToString();
                dbNV.XoaSP(ref err, masp);
            }
            LoadData();
        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                dbNV.ThemSanPham(int.Parse(txtMaLoai.Text), txtMaSP.Text, txtTenSP.Text, int.Parse(txtGia.Text), txtMaTacGia.Text, int.Parse(txtSLBan.Text), ref err);
            }
            else if (Sua)
            {
                int r = dgvQLMenu.CurrentCell.RowIndex;
                string masp = dgvQLMenu.Rows[r].Cells[1].Value.ToString();
                dbNV.CapNhatSP(int.Parse(txtMaLoai.Text), masp, txtTenSP.Text, int.Parse(txtGia.Text), txtMaTacGia.Text, int.Parse(txtSLBan.Text), ref err);
            }
            MessageBox.Show("Đã lưu.");
            LoadData();
        }

        private void radMaSP_CheckedChanged(object sender, EventArgs e)
        {
            TimMa = true;
            TimTen = TimGia = false;

            txtMaSP.Enabled = true;
            txtMaLoai.Enabled = txtSLBan.Enabled = txtTenSP.Enabled = txtGia.Enabled = !radMaSP.Checked;

            txtMaSP.Focus();
        }

        private void radTenSP_CheckedChanged(object sender, EventArgs e)
        {
            TimTen = true;
            TimMa = TimGia = false;

            txtTenSP.Enabled = true;
            txtMaLoai.Enabled = txtSLBan.Enabled = txtMaSP.Enabled = txtGia.Enabled = !radTenSP.Checked;

            txtTenSP.Focus();
        }

        private void radGia_CheckedChanged(object sender, EventArgs e)
        {
            TimGia = true;
            TimMa = TimTen = false;

            panel_TimSPTheoGia.Enabled = radGia.Checked;
            panel_ThongTinSP.Enabled = !panel_TimSPTheoGia.Enabled;
            //trbMucGia.Value = 0;
            //txtGiaNhoHon.Text = null;
            //txtGiaLonHon.Text = null;
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            panel_SearchSP.Enabled = !panel_SearchSP.Enabled;
            panel_ThongTinSP.Enabled = panel_SearchSP.Enabled;

            btnThemSP.Enabled = btnSuaSP.Enabled = btnXoaSP.Enabled = !panel_SearchSP.Enabled;
            btnLuuSP.Enabled = txtGia.Enabled = false;

            //
            radTenSP.Checked = panel_SearchSP.Enabled;
            radGia.Checked = panel_SearchSP.Enabled;
            radMaSP.Checked = panel_SearchSP.Enabled;

            //reset text
            txtMaSP.ResetText();
            txtMaLoai.ResetText();
            txtTenSP.ResetText();
            txtGia.ResetText();
            txtMaTacGia.ResetText();
            txtSLBan.ResetText();
            txtGia.Enabled = false;

            //focus vào họ tên
            txtMaSP.Focus();
        }

        private void btnLoadSP_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvQLKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thứ tự dòng/CỘT hiện lên datagridview
            int r = dgvQLKH.CurrentCell.RowIndex;
            txtTenKH.Text = dgvQLKH.Rows[r].Cells[1].Value.ToString();
            txtEmailKH.Text = dgvQLKH.Rows[r].Cells[2].Value.ToString();
            txtTuoiKH.Text = dgvQLKH.Rows[r].Cells[3].Value.ToString();
            txtSdtKH.Text = dgvQLKH.Rows[r].Cells[4].Value.ToString();
            txtDiaChiKH.Text = dgvQLKH.Rows[r].Cells[5].Value.ToString();
            txtTongChiTieuKH.Text = dgvQLKH.Rows[r].Cells[6].Value.ToString();
            txtCapThanhVienKH.Text = dgvQLKH.Rows[r].Cells[7].Value.ToString();
        }

        private void btnTimNVtheoCN_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            int search = 0;
            search = Convert.ToInt32(cbbMaCN.Text);
            dtTemp.Clear();
            DataSet dstemp = dbQL.TimNV_chiNhanh(search);
            DataSet Tong = dbQL.Tinh_TongLuongCN(search);
            DataSet AVG = dbQL.Tinh_LuongTB_CN(search);
            dtTemp = dstemp.Tables[0];

            if (dtTemp.Rows.Count == 0) MessageBox.Show("Không tìm thấy.");
            else
            {
                // Đưa dữ liệu lên DataGridView (CÁI THỨ 4)
                dgvQLNV2.DataSource = dtTemp;
                // Thay đổi độ rộng cột
                dgvQLNV2.AutoResizeColumns();

                dgvQLNV2_CellClick(null, null);

                //reset text
                txtTenNV.ResetText();
                txtEmailNV.ResetText();
                txtTuoiNV.ResetText();
                txtChucVuNV.ResetText();
                txtDiaChiNV.ResetText();
                txtSdtNV.ResetText();
                txtMaChiNhanhNV.ResetText();
                txtLuongNV.ResetText();
            }
            txtTongLuongCN.Text = Tong.Tables[0].Rows[0][0].ToString();
            txtAVGLuongCN.Text = AVG.Tables[0].Rows[0][0].ToString();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            //button5
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                int r = dgvQLKH.CurrentCell.RowIndex;
                string mamon = dgvQLKH.Rows[r].Cells[0].Value.ToString();
                dbKH.XoaKH(ref err, mamon);
            }
            LoadData();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            Them = true;
            Sua = false;
            btnLuuKH.Enabled = true;
            panel_ThongTinKH.Enabled = true;


            //reset toàn bộ text
            txtTenKH.ResetText();
            txtEmailKH.ResetText();
            txtTuoiKH.ResetText();
            txtDiaChiKH.ResetText();
            txtSdtKH.ResetText();
            txtTongChiTieuKH.ResetText();
            txtCapThanhVienKH.ResetText();

            //focus ô Tên NV
            txtTenKH.Focus();
            txtTongChiTieuKH.Enabled = false;
            txtCapThanhVienKH.Enabled = false;
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            Sua = true;
            Them = false;
            btnLuuKH.Enabled = true;
            panel_ThongTinKH.Enabled = true;
            txtTongChiTieuKH.Enabled = false;
            txtCapThanhVienKH.Enabled = false;
            //txtGia.Enabled = true;
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                //tự tạo mã NV
                int makh;
                int count = dtKH.Rows.Count + 1;
                makh = count;
                //if (count < 10)
                //{
                //    manv = manv + "0" + count.ToString();
                //}
                //else
                //{
                //    manv += count.ToString();
                //}

                dbKH.ThemKH(makh, txtTenKH.Text, txtEmailKH.Text, int.Parse(txtTuoiKH.Text), txtSdtKH.Text, txtDiaChiKH.Text, 0, 1, ref err);
            }
            else if (Sua)
            {
                int r = dgvQLKH.CurrentCell.RowIndex;
                int makh = (int)dgvQLKH.Rows[r].Cells[0].Value;
                dbKH.CapNhatKH(makh, txtTenKH.Text, txtEmailKH.Text, int.Parse(txtTuoiKH.Text), txtSdtKH.Text, txtDiaChiKH.Text, ref err);
            }
            MessageBox.Show("Đã lưu!");
            LoadData();
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            panel_SearchKH.Enabled = !panel_SearchKH.Enabled;
            panel_ThongTinKH.Enabled = panel_SearchKH.Enabled;

            btnThemKH.Enabled = btnSuaKH.Enabled = btnXoaKH.Enabled = !panel_SearchNV.Enabled;
            btnLuuKH.Enabled = false;

            //
            radTenKH.Checked = panel_SearchNV.Enabled;
            radCapThanhVienKH.Checked = panel_SearchNV.Enabled;
            radDiaChiKH.Checked = panel_SearchNV.Enabled;
            radSdtKH.Checked = panel_SearchNV.Enabled;
            radTongChiTieuKH.Checked = panel_SearchNV.Enabled;
            //reset text
            txtTenKH.ResetText();
            txtEmailKH.ResetText();
            txtTuoiKH.ResetText();
            txtDiaChiKH.ResetText();
            txtSdtKH.ResetText();
            txtTongChiTieuKH.ResetText();
            txtCapThanhVienKH.ResetText();

            //focus vào họ tên
            txtTenKH.Focus();
        }

        private void radTenKH_CheckedChanged(object sender, EventArgs e)
        {
            TimTen = true;
            TimTongCT = TimCapBac = TimDiaChi = TimSDT = false;

            txtTenKH.Enabled = true;
            panel_ChiTieuKH.Enabled = txtEmailKH.Enabled = txtTuoiKH.Enabled = txtDiaChiKH.Enabled = txtSdtKH.Enabled = txtTongChiTieuKH.Enabled = txtCapThanhVienKH.Enabled = !radTenKH.Checked;

            txtTenKH.Focus();
        }

        private void radCapThanhVienKH_CheckedChanged(object sender, EventArgs e)
        {
            TimCapBac = true;
            TimTongCT = TimTen = TimDiaChi = TimSDT = false;

            txtCapThanhVienKH.Enabled = true;
            panel_ChiTieuKH.Enabled = txtEmailKH.Enabled = txtTuoiKH.Enabled = txtDiaChiKH.Enabled = txtSdtKH.Enabled = txtTongChiTieuKH.Enabled = txtTenKH.Enabled = !radCapThanhVienKH.Checked;

            txtCapThanhVienKH.Focus();
        }

        private void radDiaChiKH_CheckedChanged(object sender, EventArgs e)
        {
            TimDiaChi = true;
            TimTongCT = TimCapBac = TimTen = TimSDT = false;

            txtDiaChiKH.Enabled = true;
            panel_ChiTieuKH.Enabled = txtEmailKH.Enabled = txtTuoiKH.Enabled = txtTenKH.Enabled = txtSdtKH.Enabled = txtTongChiTieuKH.Enabled = txtCapThanhVienKH.Enabled = !radDiaChiKH.Checked;

            txtDiaChiKH.Focus();
        }

        private void radSdtKH_CheckedChanged(object sender, EventArgs e)
        {
            TimSDT = true;
            TimTongCT = TimCapBac = TimDiaChi = TimTen = false;

            txtSdtKH.Enabled = true;
            panel_ChiTieuKH.Enabled = txtEmailKH.Enabled = txtTuoiKH.Enabled = txtDiaChiKH.Enabled = txtTenKH.Enabled = txtTongChiTieuKH.Enabled = txtCapThanhVienKH.Enabled = !radSdtKH.Checked;

            txtSdtKH.Focus();
        }

        private void radTongChiTieuKH_CheckedChanged(object sender, EventArgs e)
        {
            TimTongCT = true;
            TimTen = TimCapBac = TimDiaChi = TimSDT = false;

            panel_ChiTieuKH.Enabled = true;
            txtTenKH.Enabled = txtEmailKH.Enabled = txtTuoiKH.Enabled = txtDiaChiKH.Enabled = txtSdtKH.Enabled = txtTongChiTieuKH.Enabled = txtCapThanhVienKH.Enabled = !radTongChiTieuKH.Checked;
            //trbMucChiTieu.Value = 0;
            //txtChiTieuNhoHon.Text = null;
            //txtChiTieuLonHon.Text = null;
        }

        private void btnSearchKH_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            if (TimTen)
            {
                style = "TenKH";
                var = txtTenKH.Text;
            }
            else if (TimCapBac)
            {
                style = "CapThanhVien";
                var = txtCapThanhVienKH.Text;
            }
            else if (TimDiaChi)
            {
                style = "DiaChi";
                var = txtDiaChiKH.Text;
            }
            else if (TimSDT)
            {
                style = "SDT";
                var = txtSdtKH.Text;
            }
            else if (TimTongCT)
            {
                style = "TongChiTieu";
                var = txtChiTieuLonHon.Text;
            }

            dtTemp.Clear();
            DataSet dstemp = dbKH.TimKH(style, var);
            dtTemp = dstemp.Tables[0];

            if (dtTemp.Rows.Count == 0) MessageBox.Show("Không tìm thấy!");
            else
            {
                // Đưa dữ liệu lên DataGridView
                dgvQLKH.DataSource = dtTemp;
                // Thay đổi độ rộng cột
                dgvQLKH.AutoResizeColumns();

                dgvQLKH_CellClick(null, null);

                //reset text
                txtTenKH.ResetText();
                txtEmailKH.ResetText();
                txtTuoiKH.ResetText();
                txtDiaChiKH.ResetText();
                txtSdtKH.ResetText();
                txtTongChiTieuKH.ResetText();
                txtCapThanhVienKH.ResetText();
            }
        }

        private void btnXemNVTheoLuong_Click(object sender, EventArgs e)
        {

        }

        private void btnXemKHTheoChiTieu_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaNQL_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                int r = dgvQLNV.CurrentCell.RowIndex;
                dbQL.XoaQL(ref err, Convert.ToInt32(ShareVar.MaNQL_TK));
                frm_Login.LoadData();
                frm_Login.Show();
                this.Close();
            }
            LoadData();
        }

        private void btnTop3KHThanThiet_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Clear();
            DataSet dstemp = dbKH.Top3KH();
            dtTemp = dstemp.Tables[0];

            if (dtTemp.Rows.Count == 0) MessageBox.Show("Không tìm thấy.");
            else
            {
                // Đưa dữ liệu lên DataGridView
                dgvQLKH.DataSource = dtTemp;
                // Thay đổi độ rộng cột
                dgvQLKH.AutoResizeColumns();

                dgvQLKH_CellClick(null, null);

                //reset text
                txtTenKH.ResetText();
                txtEmailKH.ResetText();
                txtTuoiKH.ResetText();
                txtDiaChiKH.ResetText();
                txtSdtKH.ResetText();
                txtTongChiTieuKH.ResetText();
                txtCapThanhVienKH.ResetText();
            }
        }

        private void BtnLoadKH_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvQLNV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvQLNV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thứ tự dòng/CỘT hiện lên datagridview
            int r = dgvQLNV.CurrentCell.RowIndex;
            txtTenNV.Text = dgvQLNV.Rows[r].Cells[1].Value.ToString();
            txtEmailNV.Text = dgvQLNV.Rows[r].Cells[2].Value.ToString();
            txtTuoiNV.Text = dgvQLNV.Rows[r].Cells[3].Value.ToString();
            txtChucVuNV.Text = dgvQLNV.Rows[r].Cells[4].Value.ToString();
            txtSdtNV.Text = dgvQLNV.Rows[r].Cells[5].Value.ToString();
            txtDiaChiNV.Text = dgvQLNV.Rows[r].Cells[6].Value.ToString();
            txtMaChiNhanhNV.Text = dgvQLNV.Rows[r].Cells[7].Value.ToString();
            txtLuongNV.Text = dgvQLNV.Rows[r].Cells[8].Value.ToString();
        }

        private void Form_Manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login.LoadData();
            frm_Login.Show();
            ShareVar.setNV = false;
        }

        private void btnTop10BestSellers_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Clear();
            //DataSet dstemp = dbQL.Top10SP();
            DataSet dstemp = dbKH.Top10Sells();
            dtTemp = dstemp.Tables[0];

            if (dtTemp.Rows.Count == 0) MessageBox.Show("Không tìm thấy!");
            else
            {
                // Đưa dữ liệu lên DataGridView
                dgvQLMenu.DataSource = dtTemp;
                // Thay đổi độ rộng cột
                dgvQLMenu.AutoResizeColumns();

                dgvQLMenu_CellClick(null, null);

                //reset text
                txtMaSP.ResetText();
                txtMaLoai.ResetText();
                txtTenSP.ResetText();
                txtGia.ResetText();
                txtMaTacGia.ResetText();
                txtSLBan.ResetText();
                txtGia.Enabled = false;
            }

        }






    }
}
