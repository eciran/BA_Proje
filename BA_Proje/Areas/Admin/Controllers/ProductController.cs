using BA_Proje.Areas.Admin.Models.ResultModel;
using BA_Proje.Areas.Admin.Models.ViewModel;
using BA_Proje_BusinessLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace BA_Proje.Areas.Admin.Controllers
{
	public class ProductController : Controller
	{
		private  ProductRepository Pr = new ProductRepository();
		private CategoryRepository Cr = new CategoryRepository();
		private BrandRepository Br = new BrandRepository();
		private  InstanceResult<Product> res = new InstanceResult<Product>();

		// GET: Admin/Product
		[HttpGet]

		public ActionResult AddProduct()
		{
			ProductViewModel pvm = new ProductViewModel();
			List<SelectListItem> CList = new List<SelectListItem>();
			List<SelectListItem> BList = new List<SelectListItem>();
			foreach (Category item in Cr.List().StatusResult)
			{
				CList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
			}

			foreach (Brand item in Br.List().StatusResult)
			{
				BList.Add(new SelectListItem { Value = item.BrandID.ToString(), Text = item.BrandName });
			}

			pvm.BrandList = BList;
			pvm.CategoryList = CList;
			pvm.Product = null;

			return View(pvm);
		}

	[HttpPost]
	
		public ActionResult AddProduct(ProductViewModel model, HttpPostedFileBase photo)
		{
			string photoName = "";
			if (photo != null && photo.ContentLength > 0)
			{
				photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
				string path = Server.MapPath("~/Upload/" + photoName);
				photo.SaveAs(path);
			}
			model.Product.Photo = photoName;

			res.resint = Pr.Insert(model.Product);
			if (res.resint.StatusResult > 0)
			{
				return RedirectToAction("List");
			}
			return View();
		}

		public ActionResult List(string p, int? id)
		{
			res.resList = Pr.List();
			if (p != null)
			{
				ViewBag.Mesaj = string.Format("{0} nolu kaydın silme işlemi {1}", id, p);
			}
			return View(res.resList.StatusResult);
		}

		public ActionResult Edit(int id)
		{
			ProductViewModel pvm = new ProductViewModel();
			List<SelectListItem> catList = new List<SelectListItem>();
			List<SelectListItem> brandList = new List<SelectListItem>();

			foreach (Category item in Cr.List().StatusResult)
			{
				catList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
			}

			foreach (Brand item in Br.List().StatusResult)
			{
				brandList.Add(new SelectListItem { Value = item.BrandID.ToString(), Text = item.BrandName });
			}

			pvm.BrandList = brandList;
			pvm.CategoryList = catList;
			pvm.Product = Pr.GetObjById(id).StatusResult;

			return View(pvm);
		}

		[HttpPost]
		public ActionResult Edit(ProductViewModel model, HttpPostedFileBase photo)
		{
			string photoName = model.Product.Photo;
			if (photo != null && photo.ContentLength > 0)
			{
				photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
				string path = Server.MapPath("~/Upload/" + photoName);
				photo.SaveAs(path);
			}
			model.Product.Photo = photoName;

			res.resint = Pr.Update(model.Product);
			if (res.resint.StatusResult > 0)
			{
				return RedirectToAction("List");
			}
			return View(model);
		}
		public ActionResult Delete(int id)
		{
			res.resint = Pr.Delete(id);
			return RedirectToAction("List", new { @mesaj = res.resint.ReturnMessage });
		}

	}
}
