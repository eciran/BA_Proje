using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA_Proje_BusinessLayer;
using BA_Proje.Areas.Admin.Models.ResultModel;

namespace BA_Proje.Areas.Admin.Controllers
{
    public class ShippingController : Controller
    {
		private ShippingRepository Sr = new ShippingRepository();
		InstanceResult<Shipping> res = new InstanceResult<Shipping>();


		// GET: Admin/Shipping
		public ActionResult AddShip()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddShip(Shipping model)
		{
			res.resint = Sr.Insert(model);
			ViewBag.Mesaj = res.resint.ReturnMessage;
			return RedirectToAction("List");
		}
		public ActionResult List()
		{
			res.resList =Sr.List();
			return View(res.resList.StatusResult);
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			res.resK =Sr.GetObjById(id);
			return View(res.resK.StatusResult);
		}

		[HttpPost]
		public ActionResult Edit(Shipping model)
		{
			res.resint = Sr.Update(model);
			ViewBag.Mesaj = res.resint.ReturnMessage;
			return RedirectToAction("List");
		}
		
		public ActionResult Delete(int id)
		{
			res.resint = Sr.Delete(id);
			return RedirectToAction("List", new { @mesaj = res.resint.ReturnMessage });
		}
	}
}