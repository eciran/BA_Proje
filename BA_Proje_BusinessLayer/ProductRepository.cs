using BA_Proje_CommonLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_BusinessLayer
{
	public class ProductRepository : DataRepository<Product, int>
	{
		private static KirtasiyeDB con = Connection.GetConnection();
		StatusResult<Product> res = new StatusResult<Product>();

		public override Result<int> Delete(int id)
		{
			Product urun = con.Products.SingleOrDefault(p => p.ProductID == id);
			con.Products.Remove(urun);
			return res.GetStatus(con);
		}

		public override Result<List<Product>> GetLastObj(int quantity)
		{
			return res.GetListStatus(con.Products.OrderByDescending(p => p.ProductID).Take(quantity).ToList());
		}

		public override Result<Product> GetObjById(int id)
		{
			return res.GetT(con.Products.SingleOrDefault(p => p.ProductID == id));
		}

		public override Result<int> Insert(Product item)
		{
			con.Products.Add(item);
			return res.GetStatus(con);
		}

		public override Result<List<Product>> List()
		{
			return res.GetListStatus(con.Products.ToList());
		}

		public override Result<int> Update(Product item)
		{
			Product urunUpdate = con.Products.SingleOrDefault(p => p.ProductID == item.ProductID);
			urunUpdate.ProductName = item.ProductName;
			urunUpdate.Brand = item.Brand;
			urunUpdate.Category = item.Category;
			urunUpdate.Description = item.Description;
			urunUpdate.Photo = item.Photo;
			urunUpdate.Price = item.Price;
			urunUpdate.Stock = item.Stock;
			return res.GetStatus(con);
		}
	}
}
