using PhanMemQuanLyKhoThietBi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhoThietBi.Controllers
{
    public class HangHoaControllers
    {
        public DataTable HienThi(string TenHH)
        {
            string Query = "select * from HangHoa WHERE TenHH LIKE N'%" + TenHH + "%'";
            return ConnectSQL.Load(Query);
        }
        public DataTable HienThiHangHoaXuatKho(string TenHH)
        {
            string sqlString = "select MaHH,TenHH,MaLHH,TonKho,DonGia,MaNCC from HangHoa WHERE TenHH LIKE N'%" + TenHH + "%'";
            return ConnectSQL.Load(sqlString);
        }
        public void Them(string MaHH, string TenHH, decimal TonKho, decimal DonGia,string MaLHH, string MaNCC)
        {
            string Query = "INSERT INTO HangHoa(MaHH,TenHH,MaLHH,MaNCC,TonKho,DonGia)  VALUES ( '" + MaHH + "',N'" + TenHH + "','" + MaNCC + "','" + MaLHH + "'," + TonKho + "," + DonGia + ")";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Sua(string MaHH, string TenHH, decimal TonKho, decimal DonGia, string MaLHH, string MaNCC)
        {
            string Query = "UPDATE HangHoa SET MaHH = '" + MaHH + "',TenHH=N'" + TenHH + "',MaLHH = '" + MaLHH + "',MaNCC = '" + MaNCC + "',DonGia = " + DonGia + ",TonKho = " + TonKho + " WHERE MaHH = '" + MaHH + "'";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Xoa(string MaHH)
        {
            string Query = string.Format(@"DELETE HangHoa WHERE MaHH = '" + MaHH + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public int CheckExits(string MaHH)
        {
            int i = 0;
            string Querys = "SELECT * FROM HangHoa WHERE MaHH = '" + MaHH + "'";
            DataTable dt = ConnectSQL.Load(Querys);
            if (dt != null || dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
    }
}
