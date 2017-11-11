using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using System.Web.Security;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        QLThuVien db = new QLThuVien();

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection f, string returnUrl)
        {
            var tenDN = f["TenDangNhap"];
            var MK = f["MatKhau"];
            if (String.IsNullOrEmpty(tenDN) || String.IsNullOrEmpty(MK))
            {
                if (String.IsNullOrEmpty(tenDN))
                {
                    ViewData["Loi1"] = "Chưa nhập tên đăng nhập !";
                }
                if (String.IsNullOrEmpty(MK))
                {
                    ViewData["Loi2"] = "Chưa nhập mật khẩu !";
                }
            }
            else
            {
                NhanVien ad = db.NhanViens.SingleOrDefault(n => n.TenNhanVien == tenDN && n.MatKhau == MK);
                if (ad != null)
                {
                    FormsAuthentication.SetAuthCookie(ad.TenNhanVien, false);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("BaoLoi", "DangNhap");
                    }

                    else
                    {
                        Session["TaiKhoanAdmin"] = ad;
                        Session["ChucVu"] = ad.ChucVu.TenChucVu.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng !";
                }

            }
            return View("DangNhap");
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoanAdmin"] = null;
            Session["ChucVu"] = "";
            return RedirectToAction("DangNhap");
        }

        public ActionResult BaoLoi()
        {
            return View();
        }

    }
}