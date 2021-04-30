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
    class BLAccount
    {
        DBMain2 db = null;
        public BLAccount()
        {
            db = new DBMain2();
        }
        public DataSet LayAKH()
        {
            return db.ExecuteQueryDataSet("select * from TAIKHOANKH", CommandType.Text);
        }
        public DataSet LayAQL()
        {
            return db.ExecuteQueryDataSet("select * from TAIKHOANQL", CommandType.Text);
        }
        public DataSet LayANV()
        {
            return db.ExecuteQueryDataSet("select * from TAIKHOANNV", CommandType.Text);
        }
    }
}
