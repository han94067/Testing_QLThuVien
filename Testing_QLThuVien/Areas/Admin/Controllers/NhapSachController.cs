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
    public class NhapSachController : Controller
    {

        QLThuVien db = new QLThuVien();

        // GET: Admin/NhapSach
        public ActionResult DSPhieuNhap()
        {
            return View(db.PhieuNhapSaches.ToList());
        }

        public ActionResult ThemPhieuNhap()
        {
            PhieuNhapSach pn = new PhieuNhapSach();
            pn.IDPhieuNhapSach = "";
            pn.NgayNhap = DateTime.Now.Date;
            pn.TongSoLuong = 0;
            pn.TongDongia = 0;
            db.PhieuNhapSaches.Add(pn);
            db.SaveChanges();

            string ma = "";
            var phieu = db.PhieuNhapSaches.OrderByDescending(x => x.IDPhieuNhapSach).ToList();
            foreach(var item in phieu)
            {
                ma = item.IDPhieuNhapSach;
                break;
            }

            return PartialView(db.PhieuNhapSaches.Find(ma));
        }

        public ActionResult CTPhieuNhap(string ma)
        {
            //string ma = "";
            //var phieu = db.PhieuNhapSaches.OrderByDescending(x => x.IDPhieuNhapSach).ToList();
            //foreach (var item in phieu)
            //{
            //    ma = item.IDPhieuNhapSach;
            //    break;
            //}
            return PartialView(db.ChiTietPhieuNhapSaches.Where(n => n.IDPhieuNhapSach == ma).ToList());
        }

        public ActionResult ThemCTPhieuNhap()
        {
            if (Session["TTSach"] == null)
            {
                Session["TTSach"] = "";
            }
            if (Session["IDSach"] == null)
            {
                Session["IDSach"] = "";
            }
            return PartialView();
        }

        public ActionResult ChonSach()
        {
            return PartialView(db.Saches.ToList());
        }

        public ActionResult ChonS(string ma, string ten)
        {
            Session["TTSach"] = ten;
            Session["IDSach"] = ma;
            return RedirectToAction("ThemCTPhieuNhap");
        }

        public ActionResult ThemChiTiet(string so, string dg)
        {
            
            ChiTietPhieuNhapSach ct = new ChiTietPhieuNhapSach();
            string ma = "";
            var phieu = db.PhieuNhapSaches.OrderByDescending(x => x.IDPhieuNhapSach).ToList();
            foreach (var item in phieu)
            {
                ma = item.IDPhieuNhapSach;
                break;
            }
            ct.IDPhieuNhapSach = ma;
            ct.IDSach = Session["IDSach"].ToString();
            ct.SoLuong = Convert.ToInt32(so);
            ct.DonGia = Convert.ToInt32(dg);
            //ct.SoLuong = int.Parse(f["SoLuong"]);
            //ct.DonGia = int.Parse(f["DonGia"]);
            db.ChiTietPhieuNhapSaches.Add(ct);
            db.SaveChanges();
            return View();
        }

        public ActionResult CapNhatNhapSach()
        {
            string ma = "";
            var phieu = db.PhieuNhapSaches.OrderByDescending(x => x.IDPhieuNhapSach).ToList();
            foreach (var item in phieu)
            {
                ma = item.IDPhieuNhapSach;
                break;
            }

            return PartialView(db.PhieuNhapSaches.Find(ma));
        }

        public ActionResult XemPhieuNhap(string ma)
        {
            return PartialView(db.PhieuNhapSaches.Find(ma));
        }
    }
}