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
    public class MuonSachController : Controller
    {
        QLThuVien db = new QLThuVien();

        // GET: Admin/MuonSach
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SachDaDat()
        {
            return View(db.CTMuonTras.Where(n => n.TinhTrangMuon == 1).ToList());
        }

        public ActionResult SachDangMuon()
        {
            return View(db.CTMuonTras.Where(n => n.TinhTrangMuon == 2).ToList());
        }

        public ActionResult SachDaTra()
        {
            return View(db.CTMuonTras.Where(n => n.TinhTrangMuon == 3).ToList());
        }

        public ActionResult SachQuaHan()
        {
            return View(db.CTMuonTras.Where(n => n.TinhTrangMuon == 4).ToList());
        }

        public ActionResult ThemDatSach()
        {
            CTMuonTra ct = new CTMuonTra();
            ct.STT = "";
            ct.IDSach = "MS001";
            ct.IDDocGia = "DG001";
            ct.NgayMuon = DateTime.Now.Date;
            ct.TinhTrangMuon = 1;
            ct.SoLuongThue = 1;
            ct.TriGia = 10;
            ct.TienCoc = 10;
            ct.TienThue = 10;
            ct.TongTien = 10;
            db.CTMuonTras.Add(ct);
            db.SaveChanges();
            return RedirectToAction("SachDaDat");
        }

        public ActionResult XacNhanDatSach(string stt, string iddg, string idsach)
        {
            CTMuonTra ct = db.CTMuonTras.Where(n => n.STT == stt && n.IDSach == idsach && n.IDDocGia == iddg).SingleOrDefault();
            //ct.NgayMuon = ct.NgayMuon.Value.AddDays(1); // thêm 1 ngày
            ct.NgayMuon = DateTime.Now.Date;
            ct.NgayTraQuyDinh = DateTime.Now.Date.AddDays(30);
            ct.NgayQuaHan = 0; // số ngày quá hạn
            ct.TinhTrangMuon = 2;

            db.Entry(ct).State = EntityState.Modified;
            db.SaveChanges();    

            return RedirectToAction("SachDangMuon");
        }

        [HttpGet]
        public ActionResult ThemDangMuon()
        {
            if (Session["TTDocGia"] == null)
            {
                Session["TTDocGia"] = "";
            }
            if (Session["IDDocGia"] == null)
            {
                Session["IDDocGia"] = "";
            }
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

        [HttpPost]
        public ActionResult ThemDangMuon([Bind(Include = "STT, IDSach, IDDocGia, NgayMuon, NgayTraQuyDinh, NgayTraThucTe, NgayQuaHan, TinhTrangMuon, SoLuongThue, TriGia, TienCoc, TienThue, TienPhat, TongTien")] CTMuonTra ct)
        {
            ct.STT = "";
            ct.IDDocGia = Session["IDDocGia"].ToString();
            ct.IDSach = Session["IDSach"].ToString();

            Sach s = db.Saches.Find(ct.IDSach);

            ct.NgayMuon = DateTime.Now.Date;
            ct.NgayTraQuyDinh = DateTime.Now.Date.AddDays(30);
            ct.TinhTrangMuon = 2;
            ct.TriGia = s.TriGia;//bằng giá sách
            ct.TienCoc = 100000;//bằng trị giá
            ct.TienThue = s.TriGia * 10 / 100;//100.000 1 quyển
            ct.TongTien = 100000 + (s.TriGia * 10 / 100);//tiencoc + tien thue
            ct.TienPhat = 0;
            db.CTMuonTras.Add(ct);
            db.SaveChanges();

            return RedirectToAction("SachDangMuon");
        }


        public ActionResult ChonDocGia()
        {
            return PartialView(db.DocGias.ToList());
        }

        public ActionResult ChonSach()
        {
            return PartialView(db.Saches.ToList());
        }

        public ActionResult ChonDG(string ma, string ten)
        {
            Session["TTDocGia"] = ten;
            Session["IDDocGia"] = ma;
            return RedirectToAction("ThemDangMuon");
        }

        public ActionResult ChonS(string ma, string ten)
        {
            Session["TTSach"] = ten;
            Session["IDSach"] = ma;
            return RedirectToAction("ThemDangMuon");
        }

        public ActionResult DaTraSach(string stt, string iddg, string idsach)
        {
            CTMuonTra ct = db.CTMuonTras.Where(n => n.STT == stt && n.IDSach == idsach && n.IDDocGia == iddg).SingleOrDefault();
            ct.NgayTraThucTe = DateTime.Now.Date;
            if(DateTime.Now.Date <= ct.NgayTraQuyDinh)
            {
                ct.NgayQuaHan = 0;
                ct.TienPhat = 0;
            }
            else
            {
                TimeSpan Time = DateTime.Now.Date - ct.NgayTraQuyDinh.Value;
                ct.NgayQuaHan = Time.Days;
                ct.TienPhat = Time.Days * 1000;
                ct.TongTien += Time.Days * 1000;

                DocGia dg = db.DocGias.Find(iddg);
                dg.TongTienPhat += Time.Days * 1000;
                db.Entry(dg).State = EntityState.Modified;
                db.SaveChanges();

                PhieuThuTienPhat phieu = new PhieuThuTienPhat();
                phieu.IDPhieuThuTienPhat = "";
                phieu.NgayThang = DateTime.Now.Date;
                phieu.IDDocGia = iddg;
                phieu.TienThu = Time.Days * 1000;
                db.PhieuThuTienPhats.Add(phieu);
                db.SaveChanges();
            }
            ct.TinhTrangMuon = 3;

            db.Entry(ct).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SachDaTra");
        }
    }
}