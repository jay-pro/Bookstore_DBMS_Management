using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuiHaNhi_18110168_QLTiemSach_DMS.DBLayer;
using System.Data;
using System.Data.SqlClient;

namespace BuiHaNhi_18110168_QLTiemSach_DMS.BSLayer
{
    class BLAccount_NV
    {
        DBMain db = null;
        public BLAccount_NV(string ID, string Pass)
        {
            db = new DBMain(ID, Pass);
        }
        public DataSet LayANV()
        {
            return db.ExecuteQueryDataSet("select * from TAIKHOANNV", CommandType.Text);
        }
        public DataSet LayNV()
        {
            return db.ExecuteQueryDataSet("select * from NHANVIEN", CommandType.Text);
        }
        public DataSet LayMenu()
        {
            return db.ExecuteQueryDataSet("select * from MENU", CommandType.Text);
        }
        public bool ThemSanPham(int MaLoai, string MaSP, string TenSP, int Gia, string MaTacGia, int sldaban, ref string err)
        {
            string sqlString = "Insert Into MENU Values(" + "'" +
            MaLoai + "',N'" +
            MaSP + "',N'" +
            TenSP + "',N'" +
            Gia + "',N'" +
            MaTacGia + "',N'" +
            sldaban + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaSP(ref string err, string MaSP)
        {
            string sqlString = "Delete From MENU Where MaSP='" + MaSP + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatSP(int MaLoai, string MaSP, string TenSP, int Gia, string MaTacGia, int sldaban, ref string err)
        {
            string sqlString = "Update MENU Set MaLoai=N'" + MaLoai + "',"
            + "TenSP=N'" + TenSP + "',"
            + "Gia=N'" + Gia + "',"
            + "SoLuongDaBan=N'" + sldaban + "' Where TenSP='" + TenSP + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaNV(ref string err, string MaNV)
        {
            string sqlString = "Delete From NHANVIEN Where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatNV(int MaNV, string TenNV, string email, int Tuoi, string ChucVu, string SDT, string DiaChi, int MaCN, int Luong, ref string err)
        {
            string sqlString = "Update NHANVIEN Set TenNV=N'" + TenNV + "',"
            + "Email=N'" + email + "',"
            + "Tuoi=N'" + Tuoi + "',"
            + "ChucVu=N'" + ChucVu + "',"
            + "SDT=N'" + SDT + "',"
            + "DiaChi=N'" + DiaChi + "',"
            + "MaCN=N'" + MaCN + "',"
            + "Luong=N'" + Luong + "' Where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool ThemNV(int MaNV, string TenNV, string email, int Tuoi, string ChucVu, string SDT, string DiaChi, int MaCN, int Luong, ref string err)
        {
            string sqlString = "Insert Into NHANVIEN Values(N'"
            + MaNV + "',N'"
            + TenNV + "',N'"
            + email + "',N'"
            + Tuoi + "',N'"
            + ChucVu + "',N'"
            + SDT + "',N'"
            + DiaChi + "',N'"
            + MaCN + "',N'"
            + Luong + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet TimNV(string SearchStyle, string var)
        {
            if (SearchStyle == "LuongDuoi")
            {
                string sqlString = "Exec TimNhanVienCoLuongDuoi" + "'" + var + "'";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            else if (SearchStyle == "LuongTren")
            {
                string sqlString = "Exec TimNhanVienCoLuongTren" + "'" + var + "'";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            else
            {
                string sqlString = "Select * from NHANVIEN Where " + SearchStyle + " LIKE N'%" + var + "%'";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
        }

        public DataSet TimSP(string SearchStyle, string var)
        {
            string sqlString = "Select * from MENU Where " + SearchStyle + " LIKE N'%" + var + "%'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimSP_Gia(int gia)
        {
            string sqlString = "Select * from MENU Where Gia <= '" + gia + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimSP_GiaNhoHon(int gia)
        {
            string sqlString = "Select * from MENU Where Gia <= '" + gia + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet TimSP_GiaLonHon(int gia)
        {
            string sqlString = "Select * from MENU Where Gia >= '" + gia + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet Top10SP()
        {
            string sqlString = "Select * from dbo.f_Top10BestSellers()";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}
