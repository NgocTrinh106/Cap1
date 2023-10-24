using MVCLOGIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Home()
        {
            return View();
        }
        //HTTP get/ Home/DangKy
        public ActionResult SignIn()
        {
            return View();
        }
        //HTTP Post /Home/DangKy
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("SignUp");
        }
        //HTTP get/ Home/DangNhap
        public ActionResult SignUp()
        {
            return View();
        }
        //HTTP Post /Home/DangNhap
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            var taikhoanForm = user.TaiKhoan;
            var matkhauForm = user.MatKhau;
            var userCheck = db.Users.SingleOrDefault(x => x.TaiKhoan.Equals(taikhoanForm) && x.MatKhau.Equals(matkhauForm));
            if(userCheck != null) 
            {
                Session["User"] = userCheck;
                return RedirectToAction("Home", "Home");
            }else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng  kt lại!";
                return View("SignUp");
            }    
            
        }
        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}