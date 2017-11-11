using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    public class HoTroController : Controller
    {
        // GET: Admin/HoTro
        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult QuyDinh()
        {
            return View();
        }
    }
}