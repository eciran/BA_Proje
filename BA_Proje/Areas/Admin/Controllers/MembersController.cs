using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security;
using BA_Proje.Areas.Admin.Models.ResultModel;
using BA_Proje_BusinessLayer;
using BA_Proje_DataLayer;

namespace BA_Proje.Areas.Admin.Controllers
{
    public class MembersController : Controller
    {
        private KirtasiyeDB db = new KirtasiyeDB();
		MemberRepository Mr = new MemberRepository();
		InstanceResult<Member> res = new InstanceResult<Member>();

   [Authorize]
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.UserRole);
            return View(members.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        public ActionResult Create()
        {
			Member member = new Member();
			member.CreatedDate = DateTime.Now;
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleID", "RoleName");
		   return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,FirstName,LastName,CreatedDate,Email,Password,RoleId,Address")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleID", "RoleName", member.RoleId);
            return View(member);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleID", "RoleName", member.RoleId);
            return View(member);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,FirstName,LastName,CreatedDate,Email,Password,RoleId,Address")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleID", "RoleName", member.RoleId);
            return View(member);
        }

     
        public ActionResult Delete(int id)
        {
			res.resint = Mr.Delete(id);
			return RedirectToAction("Index", new { @mesaj = res.resint.ReturnMessage });
		
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
