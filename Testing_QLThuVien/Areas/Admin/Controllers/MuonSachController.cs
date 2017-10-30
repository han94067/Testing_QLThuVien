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
    }
}