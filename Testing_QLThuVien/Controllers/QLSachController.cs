using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;

namespace Testing_QLThuVien.Controllers
{
    public class QLSachController : Controller
    {
        QLThuVien db = new QLThuVien();

        [HttpGet]
        public ActionResult Sach()
        {
            return View(db.Saches.ToList());
        }
   
        [HttpGet]
        public ActionResult ThemSach()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSach([Bind(Include = "MaSach, MaTacGia, MaNhaXuatBan, MaTheLoai, TenSach, HinhAnh, NamXuatBan, SoLuong, SoLuongTon, TriGia, TinhTrang")] Sach sach)
        {
            sach.MaSach = "";
            sach.MaTacGia = "a2";
            sach.MaNhaXuatBan = "a1";
            sach.MaTheLoai = "a4";
            sach.HinhAnh = "asd";
            sach.SoLuongTon = 10;
            sach.TinhTrang = 1;        
            db.Saches.Add(sach);
            db.SaveChanges();
            return View("Sach");
        }
    }
}