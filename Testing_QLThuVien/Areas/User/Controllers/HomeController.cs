using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using PagedList;
using PagedList.Mvc;

namespace Testing_QLThuVien.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        // GET: User/Home
        QLThuVien db = new QLThuVien();
        public ActionResult Index(int? page)
        {

            int pageSize = 9;
            ////Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.Saches.Where(n => n.TinhTrang == 1).OrderBy(n => n.IDSach).ToPagedList(pageNumber, pageSize));
        }
    }
}