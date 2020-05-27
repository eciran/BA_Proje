using BA_Proje.Areas.Admin.Models.ResultModel;
using BA_Proje_BusinessLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BA_Proje.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
		 CategoryRepository cr = new CategoryRepository();
		 InstanceResult<Category> res = new InstanceResult<Category>();

        // GET: Admin/Category
        public ActionResult AddCategory()
        {
            return View();
        }
		[HttpPost]
		public ActionResult AddCategory(Category model)
		{
			res.resint= cr.Insert(model);
			ViewBag.Mesaj = res.resint.ReturnMessage;
			return RedirectToAction("List");
		}
		public ActionResult List()
		{
			res.resList= cr.List();
			return View(res.resList.StatusResult);
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			res.resK= cr.GetObjById(id);
			return View(res.resK.StatusResult);
		}

		[HttpPost]
		public ActionResult Edit(Category model)
		{
			res.resint= cr.Update(model);
			ViewBag.Mesaj = res.resint.ReturnMessage;
			return RedirectToAction("List");
		}

		public ActionResult Delete(int id)
		{
			res.resint= cr.Delete(id);
			return RedirectToAction("List", new { @mesaj = res.resint.ReturnMessage});
		}
	}
}