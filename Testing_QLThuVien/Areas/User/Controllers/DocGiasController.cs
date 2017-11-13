using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using PagedList;
using PagedList.Mvc;

namespace Testing_QLThuVien.Areas.User.Controllers
{
    public class DocGiasController : Controller
    {
        private QLThuVien db = new QLThuVien();

        // GET: User/DocGias
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/DocGias/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DocGia docGia = db.DocGias.Find(id);
        //    if (docGia == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(docGia);
        //}

        // GET: User/DocGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/DocGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDocGia,SoDienThoai,MatKhau,TenDocGia,DiaChi,Email,CMND,NgayLap,NgayHetHan,NgaySinh,TinhTrang,TongTienPhat")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                var dg = db.DocGias.Where(n => n.SoDienThoai == docGia.SoDienThoai).ToList();
                if(dg.Count() != 0)
                {
                    ModelState.AddModelError("", "Số điện thoại đã được sử dụng.");
                    return View(docGia);
                }

                docGia.IDDocGia = "";
                docGia.NgayLap = DateTime.Now.Date;
                docGia.NgayHetHan = DateTime.Now.Date.AddDays(90);
                db.DocGias.Add(docGia);
                db.SaveChanges();
                return RedirectToAction("Index");              
            }

            return View(docGia);
        }

        // GET: User/DocGias/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DocGia docGia = db.DocGias.Find(id);
        //    if (docGia == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(docGia);
        //}

        // POST: User/DocGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IDDocGia,SoDienThoai,MatKhau,TenDocGia,DiaChi,Email,CMND,NgayLap,NgayHetHan,NgaySinh,TinhTrang,TongTienPhat")] DocGia docGia)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(docGia).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(docGia);
        //}

        // GET: User/DocGias/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DocGia docGia = db.DocGias.Find(id);
        //    if (docGia == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(docGia);
        //}

        // POST: User/DocGias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    DocGia docGia = db.DocGias.Find(id);
        //    db.DocGias.Remove(docGia);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"];
            string sMatKhau = f["txtMatKhau"];
            DocGia docgia = db.DocGias.SingleOrDefault(n => n.SoDienThoai == sTaiKhoan && n.MatKhau == sMatKhau);
            if (docgia != null)
            {

                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                Session["TaiKhoan"] = docgia;
                return RedirectToAction("Sach", "Sach");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        } 
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Sach","Sach");
        } 
    }
}
