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
    public class SachController : Controller
    {
        // GET: User/Sach
        QLThuVien db = new QLThuVien();
        public List<Sach> LaySachMoi(int count)
        {
            return db.Saches.OrderByDescending(a => a.IDSach).Take(count).ToList();
        }
        public ActionResult SachMoiPartial(int? page)
        {
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var lstSachMoi = db.Saches.OrderByDescending(a => a.IDSach).ToPagedList(pageNumber, pageSize);
            return PartialView(lstSachMoi);
        }

        public ActionResult Sach(int? page)
        {
            int pageSize = 9;
            ////Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.Saches.OrderByDescending(a => a.IDSach).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult XemChiTiet(string MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.IDSach == MaSach);
            if (sach == null)
            {
                //Trả về trang báo lỗi 
                Response.StatusCode = 404;
                return null;
            }
            //ChuDe cd = db.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe);
            //ViewBag.TenCD = cd.TenChuDe;
            //ViewBag.LoiSoLuong = "dasd";
            if(Session["LoiSoLuong"] == null)
            {
                Session["LoiSoLuong"] = "";
            }
            ViewBag.TenChuDe = db.TheLoais.Single(n => n.IDTheLoai == sach.IDTheLoai).TenTheLoai;
            ViewBag.NhaXuatBan = db.NhaXuatBans.Single(n => n.IDNhaXuatBan == sach.IDNhaXuatBan).TenNhaXuatBan;
            return View(sach);
        }
    }
}