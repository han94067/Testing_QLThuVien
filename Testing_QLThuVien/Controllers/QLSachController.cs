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

        // GET: QLSach
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Saches.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IndexDG()
        {
            return View(db.DocGias.ToList());
        }
    }
}