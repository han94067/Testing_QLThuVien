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
    }
}