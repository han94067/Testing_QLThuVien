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
    public class TheLoaiController : Controller
    {

        QLThuVien db = new QLThuVien();

        public ActionResult Index()
        {
            return View(db.TheLoais.ToList());
        }

        [HttpGet]
        public ActionResult ThemTheLoai()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ThemTheLoai([Bind(Include = "IDTheLoai, TenTheLoai")] TheLoai tl)
        {
            tl.IDTheLoai = "";
            db.TheLoais.Add(tl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}