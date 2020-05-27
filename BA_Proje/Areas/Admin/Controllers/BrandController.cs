using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA_Proje.Areas.Admin.Models.ResultModel;
using BA_Proje_BusinessLayer;
using BA_Proje_DataLayer;

namespace BA_Proje.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
		BrandRepository br = new BrandRepository();
		InstanceResult<Brand> res = new InstanceResult<Brand>();

		// GET: Admin/Brand
		public ActionResult AddBrand()
		{
			Brand marka = new Brand();
			marka.BrandPhoto = "denemeBrandFoto";

			return View(marka);
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult AddBrand(Brand model, HttpPostedFileBase photoPath)
		{
			string photoName = "";
			if (photoPath != null && photoPath.ContentLength > 0)
			{
				photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
				string path = Server.MapPath("~/Upload/" + photoName);
				photoPath.SaveAs(path);
			}
			model.BrandPhoto= photoName;
			if (ModelState.IsValid)
			{
				res.resint = br.Insert(model);
				if (res.resint.Control)
				{
					return RedirectToAction("List"); 
				}
				else
				{
					ViewBag.Mesaj = res.resint.ReturnMessage;
					return View(model);
				}
			}
			else
			{
				return View();
			}
		}

		public ActionResult List()
		{
			res.resList = br.List();
			return View(res.resList.StatusResult);
		}

		public ActionResult Edit(int id)
		{
			res.resK = br.GetObjById(id);
			return View(res.resK.StatusResult);
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Edit(Brand model, HttpPostedFileBase PhotoPath)
		{
			string photoName = "";
			if (PhotoPath != null && PhotoPath.ContentLength > 0)
			{
				photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
				string path = Server.MapPath("~/Upload/" + photoName);
				PhotoPath.SaveAs(path);
			}
			model.BrandPhoto = photoName;

			res.resint= br.Update(model);
			if (res.resint.Control)
			{
				return RedirectToAction("List");
			}
			ViewBag.Mesaj = res.resint.ReturnMessage;
			return View(model);
		}

		public ActionResult Delete(int id)
		{
			res.resint= br.Delete(id);
			return RedirectToAction("List", new { @mesaj = res.resint.ReturnMessage});
		}
	}
}
