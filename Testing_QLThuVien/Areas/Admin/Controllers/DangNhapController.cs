using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        QLThuVien db = new QLThuVien();
        // GET: Admin/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap([Bind(Include = "IDNhanVien, IDChucVu, TenNhanVien, GioiTinh, DiaChi, SoDienThoai, Email, CMND, NgayVaoLam, MatKhau")] NhanVien nv, FormCollection f)
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
                    Session["TaiKhoanAdmin"] = ad;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng !";
                }

            }
            return View("DangNhap");
        }
    }
}