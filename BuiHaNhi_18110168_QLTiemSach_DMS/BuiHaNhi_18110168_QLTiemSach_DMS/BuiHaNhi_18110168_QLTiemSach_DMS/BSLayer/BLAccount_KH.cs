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
    class BLAccount_KH
    {
        DBMain2 db = null;
        public BLAccount_KH()
        {
            db = new DBMain2();
        }
        public DataSet LayAKH()
        {
            return db.ExecuteQueryDataSet("select * from TAIKHOANKH", CommandType.Text);
        }
        public DataSet LayMenu()
        {
            return db.ExecuteQueryDataSet("select * from MENU", CommandType.Text);
        }
        public DataSet LayKH()
        {
            return db.ExecuteQueryDataSet("select * from KHACHHANG", CommandType.Text);
        }
        public bool ThemAKH(string username, string password, int makh, ref string err)
        {
            //string sqlString = "Insert Into TAIKHOANKH Values(" + "N'" +
            //username + "',N'" +
            //password + "',N'" +
            //makh + "')";
            string sqlString = "Exec ThemTaiKhoanKhachHang '" + username + "','" +
            password + "'," +
            makh;

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool ThemKH(int makh, string tenkh, string email, int tuoi, string sdt, string diachi, int Tongchitieu, int capthanhvien, ref string err)
        {
            //string sqlString = "Insert Into KHACHHANG Values(" + "N'" +
            //makh + "',N'" +
            //tenkh + "',N'" +
            //email + "',N'" +
            //tuoi + "',N'" +
            //sdt + "',N'" +
            //diachi + "',N'" +
            //Tongchitieu + "',N'" +
            //capthanhvien +"')";
            string sqlString = "Exec ThemKhachHang " + makh + ",N'" +
            tenkh + "','" +
            email + "'," +
            tuoi + "," +
            sdt + ",N'" +
            diachi + "'," +
            Tongchitieu + "," +
            capthanhvien;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaKH(ref string err, string MaKH)
        {
            string sqlString = "Delete From KHACHHANG Where MaKH='" + MaKH + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatAKH(string username, string password, int makh, ref string err)
        {
            string sqlString = "Update TAIKHOANKH Set UserName=N'" +
            username + "'," + "Pass=N'" + password + "' Where MaKH=" + makh;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatKH(int makh, string tenkh, string email, int tuoi, string sdt, string diachi, ref string err)
        {
            string sqlString = "Update KHACHHANG Set TenKH=N'" +
            tenkh + "'," + "Email=N'" +
            email + "'," + "Tuoi=N'" +
            tuoi + "'," + "SDT=N'" +
            sdt + "'," + "DiaChi=N'" +
            diachi + "' Where MaKH=" + makh;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatTien(int makh, int tongchitieu, ref string err)
        {
            string sqlString = "Update KHACHHANG Set TongChiTieu='" +
            tongchitieu + "' Where MaKH=N'" + makh + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatCapThanhVien(int makh, int capthanhvien, ref string err)
        {
            string sqlString = "Update KHACHHANG Set CapThanhVien='" +
            capthanhvien + "' Where MaKH=N'" + makh + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        //public bool CapNhatKM(int makh, int km, ref string err)
        //{
        //    string sqlString = "Update KHACHHANG Set KhuyenMai='" +
        //    km + "' Where MaKH=N'" + makh + "'";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}

        public DataSet TimKH(string SearchStyle, string var)
        {
            if (SearchStyle == "TongCTDuoi")
            {
                string sqlString = "Exec TimKhachHangCoTongChiTieuDuoi" + "'" + var + "'";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            else if (SearchStyle == "TongCTTren")
            {
                string sqlString = "Exec TimKhachHangCoTongChiTieuTren" + "'" + var + "'";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            //else if (SearchStyle == "MaKH")
            //{
            //    string sqlString = "Select * from dbo.f_ThongTinKhachHangTheoMaKhachHang(N'" + var + "')";
            //    return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            //}
            else if (SearchStyle == "TenKH")
            {
                string sqlString = "Select * from dbo.f_ThongTinKhachHangTheoTenKhachHang(N'" + var + "')";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            else if (SearchStyle == "Email")
            {
                string sqlString = "Select * from dbo.f_ThongTinKhachHangTheoEmailKhachHang(N'" + var + "')";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            //else if (SearchStyle == "SDT")
            //{
            //    //string sqlString = "Select * from dbo.f_ThongTinKhachHangTheoSDTKhachHang(N'" + var + "')";
            //    //return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
                
            //}
            else if (SearchStyle == "DiaChi")
            {
                string sqlString = "Select * from dbo.timkiemKH_DiaChi(N'" + var + "')";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
            else
            {
                string sqlString = "Select * from KHACHHANG Where " + SearchStyle + " LIKE N'%" + var + "%'";
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            }
        }

        public DataSet Top3KH()
        {
            string sqlString = "Select * from dbo.f_Top3KhachHangThanThiet()";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet Top10Sells()
        {
            string sqlString = "Select * from dbo.f_Top10BestSellers()";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet DSCTHoaDon(int MaKH)
        {
            string sqlString = "Execute XuatHoaDob" + MaKH;
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}
