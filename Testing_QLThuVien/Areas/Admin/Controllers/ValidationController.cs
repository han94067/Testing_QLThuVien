using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using System.Web.UI;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {

        public ActionResult check(string HinhAnh)
        {
            string temp = "";
            String[] s = HinhAnh.Split('.');
            foreach(var x in s)
            {
                temp = x;
            }
            if(temp == "png" || temp == "jpeg" || temp == "jpg")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);           
        }
    }
}