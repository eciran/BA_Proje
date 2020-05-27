using BA_Proje_CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BA_Proje.Areas.Admin.Models.ResultModel
{
	public class InstanceResult<K>
	{
		public Result<List<K>> resList { get; set; }
		public Result<int> resint { get; set; }
		public Result<K> resK { get; set; }
	}
}