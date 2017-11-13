using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing_QLThuVien.Models
{
    public class GioHang
    {
        QLThuVien db = new QLThuVien();
        public String iMaSach { get; set; }
        public string sTenSach { get; set; }
        //public string sAnhBia { get; set; }
        //public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public string sHinhAnh { get; set; }
        public decimal sDonGia { get; set; }
        //public double ThanhTien
        //{
        //    get { return iSoLuong * dDonGia; }
        //}
        //Hàm tạo cho giỏ hàng
        public GioHang(String MaSach)
        {
            iMaSach = MaSach;
            Sach sach = db.Saches.Single(n => n.IDSach == iMaSach);
            sTenSach = sach.TenSach;
            sHinhAnh = sach.HinhAnh;
            sDonGia = sach.TriGia.Value;
            //sAnhBia = sach.AnhBia;
            //dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}