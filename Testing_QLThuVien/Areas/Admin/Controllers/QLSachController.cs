using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using System.Data;
using System.Data.Entity;
using System.IO;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    [Authorize(Roles = "CV001")]
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
            ViewBag.IDTheLoai = new SelectList(db.TheLoais, "IDTheLoai", "TenTheLoai");
            ViewBag.IDTacGia = new SelectList(db.TacGias, "IDTacGia", "TenTacGia");
            ViewBag.IDNhaXuatBan = new SelectList(db.NhaXuatBans, "IDNhaXuatBan", "TenNhaXuatBan");
            return View();
        }

        [HttpPost]
        public ActionResult ThemSach([Bind(Include = "IDSach, IDTacGia, IDNhaXuatBan, IDTheLoai, TenSach, HinhAnh, NamXuatBan, SoLuong, SoLuongTon, TriGia, TinhTrang, MoTa")] Sach sach, HttpPostedFileBase uploadfile)
        {
            //return Json(sach, JsonRequestBehavior.AllowGet);
            String host = "http://qlthuvien.somee.com/Images/";
            uploadfile = Request.Files[0];

            //if (uploadfile.FileName != "" && uploadfile != null)
            //{
            var fileName = System.IO.Path.GetFileName(uploadfile.FileName);
            var rondom = fileName;
            //var rondom = Guid.NewGuid() + fileName;
            var path = System.IO.Path.Combine(Server.MapPath("~/Images"), rondom);
            var filetext = System.IO.Path.GetExtension(uploadfile.FileName).Substring(1);
            var supportedTypes = new[] { "jpg", "jpeg", "png" };
            //if (!supportedTypes.Contains(filetext))
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>");
            //}
            var image = new System.Web.Helpers.WebImage(uploadfile.InputStream);
            image.Save(path);// lưu vào project
            rondom = host + rondom;
            sach.HinhAnh = rondom;// luu vào database
            sach.IDSach = "";
            sach.SoLuong = 0;
            sach.SoLuongTon = 0;
            sach.TinhTrang = 1;
            db.Saches.Add(sach);
            db.SaveChanges();
            return RedirectToAction("Sach");
        }

        [HttpGet]
        public ActionResult Edit(string ma)
        {
            Sach Book = db.Saches.Find(ma);
            if (Book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.IDTheLoai = new SelectList(db.TheLoais, "IDTheLoai", "TenTheLoai", Book.IDTheLoai);
            ViewBag.IDTacGia = new SelectList(db.TacGias, "IDTacGia", "TenTacGia", Book.IDTacGia);
            ViewBag.IDNhaXuatBan = new SelectList(db.NhaXuatBans, "IDNhaXuatBan", "TenNhaXuatBan", Book.IDNhaXuatBan);
            return PartialView(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSach, IDTacGia, IDNhaXuatBan, IDTheLoai, TenSach, HinhAnh, NamXuatBan, SoLuong, SoLuongTon, TriGia, TinhTrang, MoTa")] Sach sach, HttpPostedFileBase uploadfile)
        {
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            String host = "http://qlthuvien.somee.com/Images/";
            uploadfile = Request.Files[0];

            //if (uploadfile.FileName != "" && uploadfile != null)
            //{
            var fileName = System.IO.Path.GetFileName(uploadfile.FileName);
            var rondom = fileName;
            //var rondom = Guid.NewGuid() + fileName;
            var path = System.IO.Path.Combine(Server.MapPath("~/Images"), rondom);
            var filetext = System.IO.Path.GetExtension(uploadfile.FileName).Substring(1);
            var supportedTypes = new[] { "jpg", "jpeg", "png" };
            //if (!supportedTypes.Contains(filetext))
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>");
            //}
            var image = new System.Web.Helpers.WebImage(uploadfile.InputStream);
            image.Save(path);// lưu vào project
            rondom = host + rondom;
            sach.HinhAnh = rondom;// luu vào database


            db.Entry(sach).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Sach");
        }

    }
}