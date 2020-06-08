using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BA_Proje.Areas.Admin.Models.ViewModel
{
	public class MemberRoleModel
	{
		public Member Member{ get; set; }
		public IEnumerable<SelectListItem> RoleList{ get; set; }
	}
}