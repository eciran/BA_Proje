using BA_Proje_CommonLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_BusinessLayer
{
	public class CategoryRepository : DataRepository<Category, int>
	{
		private static KirtasiyeDB con = Connection.GetConnection();
		StatusResult<Category> res = new StatusResult<Category>();

		public override Result<int> Insert(Category item)
		{
			con.Categories.Add(item);
			return res.GetStatus(con);

		}

		public override Result<int> Delete(int id)
		{
			Category delete = con.Categories.SingleOrDefault(d => d.CategoryID==id);
			con.Categories.Remove(delete);
			return res.GetStatus(con);
		}

		public override Result<List<Category>> GetLastObj(int quantity)
		{
			throw new NotImplementedException();
		}

		public override Result<Category> GetObjById(int id)
		{
			Category cat = con.Categories.SingleOrDefault(c => c.CategoryID== id);
			return res.GetT(cat);
		}

		public override Result<List<Category>> List()
		{
			List<Category> CategoryList = con.Categories.ToList();
			return res.GetListStatus(CategoryList);
		}

		public override Result<int> Update(Category item)
		{
			Category cat = con.Categories.SingleOrDefault(c => c.CategoryID == item.CategoryID);
			cat.CategoryName = item.CategoryName;
			cat.CategoryDesc= item.CategoryDesc;
			return res.GetStatus(con);
		}
	}
}
