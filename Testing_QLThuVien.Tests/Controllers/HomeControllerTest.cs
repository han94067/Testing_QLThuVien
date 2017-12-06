using System.Web.Mvc;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing_QLThuVien;
using Testing_QLThuVien.Areas.Admin.Controllers;
using Testing_QLThuVien.Models;
using System.Collections.Generic;
using System.Web.Routing;

namespace Testing_QLThuVien.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //[TestMethod]
        //public void UTCID01()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "image";
        //    sach.NamXuatBan = 2010;
        //    sach.TriGia = 50000;
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "a9@-";

        //    ActionResult re = qls.ThemSach(sach, null);
        //    Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        //}

        [TestMethod]
        public void UTCID02()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 1000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[0].ErrorMessage);
        }

        //[TestMethod]
        //public void UTCID03()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "image";
        //    sach.NamXuatBan = 2000;
        //    sach.TriGia = 50000;
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "a9@-";

        //    ActionResult re = qls.ThemSach(sach, null);
        //    Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        //}

        [TestMethod]
        public void UTCID04()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = null;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID05()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[0].ErrorMessage);
        }

        //[TestMethod]
        //public void UTCID06()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "image";
        //    sach.NamXuatBan = 2010;
        //    sach.TriGia = 1000;
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "a9@-";

        //    ActionResult re = qls.ThemSach(sach, null);
        //    Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        //}

        //[TestMethod]
        //public void UTCID07()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "image";
        //    sach.NamXuatBan = 2010;
        //    sach.TriGia = 500; // ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "a9@-";

        //    var test = TestModelHelper.Validate(sach);

        //    Assert.AreEqual(1, test.Count);
        //    Assert.AreEqual("Không được nhập chữ và ký tự đặc biệt.", test[0].ErrorMessage);
        //}

        [TestMethod]
        public void UTCID08()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[0].ErrorMessage);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[1].ErrorMessage);
        }

        //[TestMethod]
        //public void UTCID09()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "image";
        //    sach.NamXuatBan = 2000;
        //    sach.TriGia = 1000;
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "a9@-";

        //    ActionResult re = qls.ThemSach(sach, null);
        //    Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        //}

        [TestMethod]
        public void UTCID10()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = null;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID11()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = null;
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Hình ảnh không được bỏ trống.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID12()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID13()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID14()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 2000;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID15()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = null;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID16()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID17()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 1000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID18()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 2010;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID19()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(3, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[2].ErrorMessage);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID20()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 2000;
            sach.TriGia = 1000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
        }

        //[TestMethod]
        //public void UTCID21()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "Image";
        //    sach.NamXuatBan = @@; // ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TriGia = @@; // ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

        //    var test = TestModelHelper.Validate(sach);

        //    Assert.AreEqual(3, test.Count);
        //    Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
        //    Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[1].ErrorMessage);
        //    Assert.AreEqual("Không được nhập chữ và ký tự đặc biệt.", test[2].ErrorMessage);
        //}

        [TestMethod]
        public void UTCID22()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = null;
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-a9@-";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Hình ảnh không được bỏ trống.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID23()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            ActionResult re = qls.ThemSach(sach, null);
            Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        }

        [TestMethod]
        public void UTCID24()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID25()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2000;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            ActionResult re = qls.ThemSach(sach, null);
            Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        }

        [TestMethod]
        public void UTCID26()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = null;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID27()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID28()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 1000;
            sach.TinhTrang = 1;
            sach.TenSach = "a9@-";

            ActionResult re = qls.ThemSach(sach, null);
            Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        }

        //[TestMethod]
        //public void UTCID29()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "Image";
        //    sach.NamXuatBan = 2010; 
        //    sach.TriGia = @@; // ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "@";

        //    var test = TestModelHelper.Validate(sach);

        //    Assert.AreEqual(1, test.Count);
        //    Assert.AreEqual("Không được nhập chữ và ký tự đặc biệt.", test[0].ErrorMessage);
        //}

        [TestMethod]
        public void UTCID30()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "Image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[0].ErrorMessage);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID31()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2000;
            sach.TriGia = 1000;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            ActionResult re = qls.ThemSach(sach, null);
            Assert.AreEqual("Sach", (re as RedirectToRouteResult).RouteValues["action"]);
        }

        //[TestMethod]
        //public void UTCID32()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "Image";
        //    sach.NamXuatBan = @@; // ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TriGia = @@; // ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TinhTrang = 1;
        //    sach.TenSach = "@";

        //    var test = TestModelHelper.Validate(sach);

        //    Assert.AreEqual(2, test.Count);
        //    Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[0].ErrorMessage);
        //    Assert.AreEqual("Không được nhập chữ và ký tự đặc biệt.", test[1].ErrorMessage);
        //}

        [TestMethod]
        public void UTCID33()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = null;
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Hình ảnh không được bỏ trống.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID34()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
        }

        // [TestMethod]
        //public void UTCID35()
        //{
        //    var qls = new QLSachController();
        //    var sach = new Sach();
        //    sach.IDSach = "";
        //    sach.IDTacGia = "TG001";
        //    sach.IDTheLoai = "TL001";
        //    sach.IDNhaXuatBan = "XB001";
        //    sach.HinhAnh = "image";
        //    sach.NamXuatBan = null;
        //    sach.TriGia = @@;// ký tự đặc biệt không bắt được trong unit test code.
        //    sach.TinhTrang = 1;
        //    sach.TenSach = null;

        //    var test = TestModelHelper.Validate(sach);

        //    Assert.AreEqual(3, test.Count);
        //    Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
        //    Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[1].ErrorMessage);
        //    Assert.AreEqual("Không được nhập chữ và ký tự đặc biệt.", test[2].ErrorMessage);
        //}

        [TestMethod]
        public void UTCID36()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 1000;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID37()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 500;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
            Assert.AreEqual("Trị Giá từ 1.000 đến 10.000.000", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID38()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = null;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID39()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2000;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID40()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 1999;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID41()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = null;
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
            Assert.AreEqual("Hình ảnh không được bỏ trống.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID42()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "@ab";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID43()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = null;
            sach.NamXuatBan = 2010;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = null;

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(3, test.Count);
            Assert.AreEqual("Xin mời nhập Tên Sách.", test[0].ErrorMessage);
            Assert.AreEqual("Hình ảnh không được bỏ trống.", test[1].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[2].ErrorMessage);
        }

        [TestMethod]
        public void UTCID44()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "@ba-d@ba-d@ba-d@ba-d@ba-d@ba-d@ba-d@ba-d@ba-d@ba-d@ba-d";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Tên sách không được vượt quá 50 kí tự.", test[0].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID45()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID46()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 1999;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "@bs-a";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Năm Xuất Bản từ năm 2000 đến năm 2017.", test[0].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID47()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2000;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "@";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[0].ErrorMessage);
        }

        [TestMethod]
        public void UTCID48()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = null;
            sach.TriGia = null;
            sach.TinhTrang = 1;
            sach.TenSach = "@bs-a";

            var test = TestModelHelper.Validate(sach);

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual("Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.", test[0].ErrorMessage);
            Assert.AreEqual("Xin mời nhập Trị Giá.", test[1].ErrorMessage);
        }

        [TestMethod]
        public void UTCID49()
        {
            var qls = new QLSachController();
            var sach = new Sach();
            sach.IDSach = "";
            sach.IDTacGia = "TG001";
            sach.IDTheLoai = "TL001";
            sach.IDNhaXuatBan = "XB001";
            sach.HinhAnh = "image";
            sach.NamXuatBan = 2010;
            sach.TriGia = 50000;
            sach.TinhTrang = 1;
            sach.TenSach = "@bs-a";

            var test = TestModelHelper.Validate(sach);
            var val = new ValidationController();
            var re = val.checka(sach.HinhAnh) as JsonResult;
            IDictionary<string, object> data = (IDictionary<string, object>)new RouteValueDictionary(re.Data);

            Assert.AreEqual("Chỉ những file(jpg, jpeg, png) mới được hỗ trợ.", data["ms"]);
        }

    }
}
