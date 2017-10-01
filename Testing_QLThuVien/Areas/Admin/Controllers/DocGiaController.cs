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
    }
}