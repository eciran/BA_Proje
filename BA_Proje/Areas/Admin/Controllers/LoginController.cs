using BA_Proje_BusinessLayer;
using BA_Proje_CommonLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace BA_Proje.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		private static KirtasiyeDB con = Connection.GetConnection();
		// GET: Admin/Login
		[AllowAnonymous]
		public ActionResult AdminLogin()
        {
							return View();
        }
		[AllowAnonymous]
		[HttpPost]
		public ActionResult AdminLogin(Login model)
		{

			MemberRepository Mr = new MemberRepository();
				List<Member> mlist = Mr.List().StatusResult;
				bool loginFlag = false;
				foreach (Member item in mlist)
				{
					var  bilgiler = con.Members.FirstOrDefault(m => m.Email == item.Email && m.Password == item.Password);
					if (bilgiler != null)
					{
						loginFlag = true;
					
						return RedirectToAction("AddCategory", "Category", new { area = "Admin" });
					}
					else
					{
						loginFlag = false;
					}
				}
				if (loginFlag == true)
				{
					return RedirectToAction("List", "Category", new { area = "Admin" });
				}
						
			return View("Login", "Login", new { area = "Admin" });
		}
			public ActionResult LogOff()
		{
			Session["UserName"] = null;
			Session["userid"] = null;
			Session.Abandon();
			return RedirectToAction("Login");
		}

	}
}