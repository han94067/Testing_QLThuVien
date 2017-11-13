using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_QLThuVien.Models;
using System.Text.RegularExpressions;

namespace Testing_QLThuVien.Areas.User.Controllers
{
    public class GioHangController : Controller
    {
        // GET: User/GioHang
        QLThuVien db = new QLThuVien();

        private static bool IsNumber(string val)
        {
            if (val != "")
                return Regex.IsMatch(val, @"^[0-9]*$");
            else return true;
        }

        #region
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(String iMaSach, string strURL, FormCollection f)
        {

            Sach sach = db.Saches.SingleOrDefault(n => n.IDSach == iMaSach);
            if (IsNumber(f["SoLuongDat"]) != true || f["SoLuongDat"].ToString() == "")
            {
                Session["LoiSoLuong"] = "Hãy nhập số lượng sách cần đặt.";
                return RedirectToAction("XemChiTiet", "Sach", new { MaSach = iMaSach });
            }
            int soluong = Int32.Parse(f["SoLuongDat"]);
            if (soluong == 0)
            {
                Session["LoiSoLuong"] = "Hãy nhập số lượng sách cần đặt.";
                return RedirectToAction("XemChiTiet", "Sach", new { MaSach = iMaSach });
            }
            if (soluong > sach.SoLuong)
            {
                Session["LoiSoLuong"] = "Không đủ số lượng sách";
                return RedirectToAction("XemChiTiet", "Sach", new { MaSach = iMaSach });
            }
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "DocGias");
            }
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sách này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMaSach == iMaSach);
            Session["LoiSoLuong"] = "";
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                sanpham.iSoLuong = soluong;
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong += soluong;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(String iMaSP, FormCollection f)
        {
            //Kiểm tra masp
            Sach sach = db.Saches.SingleOrDefault(n => n.IDSach == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(String iMaSP)
        {
            //Kiểm tra masp
            Sach sach = db.Saches.SingleOrDefault(n => n.IDSach == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSach == iMaSP);

            }
            //if (lstGioHang.Count == 0)
            //{
            //    return RedirectToAction("Sach", "Sach");
            //}
            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            //if (Session["GioHang"] == null)
            //{
            //    return RedirectToAction("Sach", "Sach");
            //}
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        //private double TongTien()
        //{
        //    double dTongTien = 0;
        //    List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
        //    if (lstGioHang != null)
        //    {
        //        dTongTien = lstGioHang.Sum(n => n.ThanhTien);
        //    }
        //    return dTongTien;
        //}
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            //ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Sach", "Sach");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }
        #endregion
        #region Đặt hàng
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "DocGias");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Sach", "Sach");
            }
            //Thêm đơn hàng
            DocGia dg = (DocGia)Session["TaiKhoan"];
            if(dg.NgayHetHan < DateTime.Now.Date)
            {
                return RedirectToAction("DGQuaHan");
            }
            List<GioHang> gh = LayGioHang();
            foreach (var item in gh)
            {
                CTMuonTra ddh = new CTMuonTra();
                ddh.IDDocGia = dg.IDDocGia;
                ddh.NgayMuon = DateTime.Now.Date;
                ddh.STT = "";
                ddh.IDSach = item.iMaSach;
                ddh.SoLuongThue = item.iSoLuong;
                ddh.NgayQuaHan = 0;
                ddh.TinhTrangMuon = 1;
                ddh.TriGia = item.sDonGia;
                ddh.TienCoc = item.sDonGia;
                ddh.TienThue = item.sDonGia * 10 / 100;
                ddh.TongTien = item.sDonGia + (item.sDonGia * 10 / 100);
                db.CTMuonTras.Add(ddh);
            }
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            //foreach (var item in gh)
            //{
            //    CTMuonTra ctDH = new CTMuonTra();
            //    ctDH.STT = ddh.STT;
            //    ctDH.IDSach = item.iMaSach;
            //    ctDH.SoLuongThue = item.iSoLuong;
            //    //ctDH.DonGia = (decimal)item.dDonGia;
            //    db.CTMuonTras.Add(ctDH);
            //}
            //db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Sach", "Sach");
        }
        #endregion

        public ActionResult DGQuaHan()
        {
            return View();
        }
    }
}