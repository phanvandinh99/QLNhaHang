using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.NhanVien.Controllers
{
    public class BanController : Controller
    {
        DatabaseQuanLyNhaHang db = new DatabaseQuanLyNhaHang();
        public ActionResult DanhSachBan()
        {
            var listBan = db.Tang.ToList();
            return View(listBan);
        }
        public ActionResult XemChiTiet(int iMaBan)
        {
            var ban = db.Tang.Find(iMaBan);
            return View(ban);
        }
        public ActionResult XoaBan(int iMaBan)
        {
            try
            {
                db.Tang.Remove(db.Tang.Find(iMaBan));
                db.SaveChanges();
                return RedirectToAction("DanhSachBan", "Tang");
            }
            catch
            {
                return RedirectToAction("XoaBan", "Error");
            }
        }
        //Thêm bàn
        public ActionResult ThemBan()
        {
            ViewBag.MaTang = db.Tang;
            return View();
        }
        [HttpPost]
        public ActionResult ThemBan(Tang Model)
        {
            Tang ban = new Tang();
            ban.TenBan = Model.TenBan;
            ban.SoGhe = Model.SoGhe;
            ban.Vip = Model.Vip;
            ban.TinhTrang = 0;
            ban.MaTang_id = Model.MaTang_id;
            db.Tang.Add(ban);
            db.SaveChanges();
            return RedirectToAction("DanhSachBan", "Tang");
        }
        //Cập Nhật Bàn
        public ActionResult CapNhatBan(int iMaBan)
        {
            var ban = db.Tang.SingleOrDefault(n => n.MaBan == iMaBan);
            ViewBag.MaTang_id = new SelectList(db.Tang, "MaTang", "TenTang", ban.MaTang_id); // lẫy mã tầng
            ViewBag.MaTang = db.Tang;
            return View(ban);
        }
        [HttpPost]
        public ActionResult CapNhatBan(Tang Model)
        {
            Tang ban = new Tang();
            ban.TenBan = Model.TenBan;
            ban.SoGhe = Model.SoGhe;
            ban.Vip = Model.Vip;
            ban.TinhTrang = 0;
            ban.MaTang_id = Model.MaTang_id;
            db.Tang.Add(ban);
            db.SaveChanges();
            return RedirectToAction("DanhSachBan", "Tang");
        }
    }
}