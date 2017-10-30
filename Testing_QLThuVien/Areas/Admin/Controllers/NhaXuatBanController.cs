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
    public class NhaXuatBanController : Controller
    {
        QLThuVien db = new QLThuVien();

        // GET: Admin/NhaXuatBan
        public ActionResult Index()
        {
            return View(db.NhaXuatBans.ToList());
        }
    }
}