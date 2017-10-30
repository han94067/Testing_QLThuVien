using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using System.Data;
using System.Data.Entity;

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
        public ActionResult ThemDocGia([Bind(Include = "IDDocGia, TenDocGia, DiaChi, NgaySinh, SoDienThoai, Email, CMND, NgayLap, TinhTrang, TongTienPhat")] DocGia dg)
        {
            dg.IDDocGia = "";
            dg.TinhTrang = 1;
            dg.TongTienPhat = 0;
            dg.NgayLap = DateTime.Today;
            db.DocGias.Add(dg);
            db.SaveChanges();
            return RedirectToAction("DSDocGia");
        }

        [HttpGet]
        public ActionResult ThongTin(string ma)
        {
            DocGia dg = db.DocGias.Find(ma);
            if (dg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", Book.MaTheLoai);
            return PartialView(dg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThongTin([Bind(Include = "IDDocGia, TenDocGia, DiaChi, NgaySinh, SoDienThoai, Email, CMND, NgayLap, TinhTrang, TongTienPhat")] DocGia dg)
        {
            db.Entry(dg).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DSDocGia");
        }

        [HttpGet]
        public ActionResult Delete(string ma)
        {
            DocGia dg = db.DocGias.Find(ma);
            if (dg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(dg);
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "IDDocGia, TenDocGia, DiaChi, NgaySinh, SoDienThoai, Email, CMND, NgayLap, TinhTrang, TongTienPhat")] DocGia dg)
        {
            DocGia s = db.DocGias.Find(dg.IDDocGia);
            db.DocGias.Remove(s);
            db.SaveChanges();
            return RedirectToAction("DSDocGia");
        }
    }
}