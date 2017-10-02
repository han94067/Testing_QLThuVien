using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    public class DocGiaController : Controller
    {

        QLThuVien db = new QLThuVien();

        public ActionResult DSDocGia()
        {
            return View(db.DocGias.ToList());
        }

        [HttpGet]
        public ActionResult ThemDocGia()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDocGia([Bind(Include = "MaDocGia, TenDocGia, DiaChi, NgaySinh, SDT, Email, CMND, NgayLap, TinhTrang, TongTienPhat")] DocGia dg)
        {
            dg.MaDocGia = "";
            dg.TinhTrang = 1;
            dg.TongTienPhat = 0;
            dg.NgayLap = DateTime.Today;
            db.DocGias.Add(dg);
            db.SaveChanges();
            return RedirectToAction("DSDocGia");
        }
    }
}