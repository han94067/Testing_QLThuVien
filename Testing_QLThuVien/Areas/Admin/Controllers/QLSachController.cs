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
    public class QLSachController : Controller
    {
        QLThuVien db = new QLThuVien();

        [HttpGet]
        public ActionResult Sach()
        {
            //ViewBag.IDTheLoai = new SelectList(db.TheLoais, "IDTheLoai", "TenTheLoai");
            return View(db.Saches.ToList());
        }

        [HttpGet]
        public ActionResult ThemSach()
        {
            ViewBag.IDTheLoai = new SelectList(db.TheLoais, "IDTheLoai", "TenTheLoai");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSach([Bind(Include = "IDSach, IDTacGia, IDNhaXuatBan, IDTheLoai, TenSach, HinhAnh, NamXuatBan, SoLuong, SoLuongTon, TriGia, TinhTrang, MoTa")] Sach sach, FormCollection f)
        {
            string TacGia = f["TenTacGia"];
            string NhaXuatBan = f["NhaXuatBan"];

            // Thêm tác giả
            var tg = db.TacGias.Where(n => n.TenTacGia.Contains(TacGia)).ToList();
            if(tg.Count() == 0)
            {
                TacGia tacgia = new TacGia();
                tacgia.IDTacGia = "";
                tacgia.TenTacGia = TacGia;
                db.TacGias.Add(tacgia);
                db.SaveChanges();         
            }
            tg = db.TacGias.Where(n => n.TenTacGia.Contains(TacGia)).ToList();
            string matg = "";
            foreach (var item in tg)
            {
                matg = item.IDTacGia;
            }
            sach.IDTacGia = matg;

            // Thêm nhà xuất bản
            var nxb = db.NhaXuatBans.Where(n => n.TenNhaXuatBan.Contains(NhaXuatBan)).ToList();
            if(nxb.Count() == 0)
            {
                NhaXuatBan NXB = new NhaXuatBan();
                NXB.IDNhaXuatBan = "";
                NXB.TenNhaXuatBan = NhaXuatBan;
                db.NhaXuatBans.Add(NXB);
                db.SaveChanges();
            }
            nxb = db.NhaXuatBans.Where(n => n.TenNhaXuatBan.Contains(NhaXuatBan)).ToList();
            string manxb = "";
            foreach (var item in nxb)
            {
                manxb = item.IDNhaXuatBan;
            }
            sach.IDNhaXuatBan = manxb;

            sach.IDSach = "";
            //sach.IDTacGia = "1";
            //sach.IDNhaXuatBan = "1";
            sach.HinhAnh = "Image";
            sach.SoLuong = 0;
            sach.SoLuongTon = 0;
            sach.TinhTrang = 0;
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
            return PartialView(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSach, IDTacGia, IDNhaXuatBan, IDTheLoai, TenSach, HinhAnh, NamXuatBan, SoLuong, SoLuongTon, TriGia, TinhTrang, MoTa")] Sach sach, FormCollection f)
        {
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            string TacGia = f["TenTacGia"];
            string NhaXuatBan = f["NhaXuatBan"];

            // Thêm tác giả
            var tg = db.TacGias.Where(n => n.TenTacGia.Contains(TacGia)).ToList();
            if (tg.Count() == 0)
            {
                TacGia tacgia = new TacGia();
                tacgia.IDTacGia = "";
                tacgia.TenTacGia = TacGia;
                db.TacGias.Add(tacgia);
                db.SaveChanges();
            }
            tg = db.TacGias.Where(n => n.TenTacGia.Contains(TacGia)).ToList();
            string matg = "";
            foreach (var item in tg)
            {
                matg = item.IDTacGia;
            }
            sach.IDTacGia = matg;

            // Thêm nhà xuất bản
            var nxb = db.NhaXuatBans.Where(n => n.TenNhaXuatBan.Contains(NhaXuatBan)).ToList();
            if (nxb.Count() == 0)
            {
                NhaXuatBan NXB = new NhaXuatBan();
                NXB.IDNhaXuatBan = "";
                NXB.TenNhaXuatBan = NhaXuatBan;
                db.NhaXuatBans.Add(NXB);
                db.SaveChanges();
            }
            nxb = db.NhaXuatBans.Where(n => n.TenNhaXuatBan.Contains(NhaXuatBan)).ToList();
            string manxb = "";
            foreach (var item in nxb)
            {
                manxb = item.IDNhaXuatBan;
            }
            sach.IDNhaXuatBan = manxb;

            //UpdateModel(sach);
            db.Entry(sach).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Sach");
        }

        [HttpGet]
        public ActionResult Delete(string ma)
        {
            Sach Book = db.Saches.Find(ma);
            if (Book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(Book);
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "IDSach, IDTacGia, IDNhaXuatBan, IDTheLoai, TenSach, HinhAnh, NamXuatBan, SoLuong, SoLuongTon, TriGia, TinhTrang, MoTa")] Sach sach)
        {
            Sach s = db.Saches.Find(sach.IDSach);
            db.Saches.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Sach");
        }

    }
}