using BA_Proje_CommonLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_BusinessLayer
{
	public class BrandRepository : DataRepository<Brand, int>
	{
		private static KirtasiyeDB con = Connection.GetConnection();
		StatusResult<Brand> res = new StatusResult<Brand>();

		public override Result<int> Delete(int id)
		{
			Brand markaSil = con.Brands.SingleOrDefault(s => s.BrandID == id);
			con.Brands.Remove(markaSil);
			return res.GetStatus(con);
		}

		public override Result<List<Brand>> GetLastObj(int quantity)
		{
			return res.GetListStatus(con.Brands.OrderByDescending(p => p.BrandID).Take(quantity).ToList());
		}

		public override Result<Brand> GetObjById(int id)
		{
			Brand marka = con.Brands.SingleOrDefault(x =>x.BrandID == id);
			return res.GetT(marka);
		}

		public override Result<int> Insert(Brand item)
		{
			con.Brands.Add(item);
			return res.GetStatus(con);
		}

		public override Result<List<Brand>> List()
		{
			return res.GetListStatus(con.Brands.ToList());
		}

		public override Result<int> Update(Brand item)
		{
			Brand markaUpdate = con.Brands.SingleOrDefault(b => b.BrandID== item.BrandID);
			markaUpdate.BrandName= item.BrandName;
			markaUpdate.BrandPhoto = item.BrandPhoto;
			return res.GetStatus(con);
		}
	}
}
