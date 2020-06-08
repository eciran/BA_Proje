using BA_Proje_CommonLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_BusinessLayer
{
 public class ShippingRepository: DataRepository<Shipping,int>
	{
		private static KirtasiyeDB con = Connection.GetConnection();
		StatusResult<Shipping> res = new StatusResult<Shipping>();

		public override Result<int> Delete(int id)
		{
			Shipping KargoSil = con.Shippings.SingleOrDefault(k=> k.ShippingID== id);
			con.Shippings.Remove(KargoSil);
			return res.GetStatus(con);
		}

		public override Result<List<Shipping>> GetLastObj(int quantity)
		{
			throw new NotImplementedException();
		}

		public override Result<Shipping> GetObjById(int id)
		{
			Shipping Kargo= con.Shippings.SingleOrDefault(k => k.ShippingID== id);
			return res.GetT(Kargo);
		}

		public override Result<int> Insert(Shipping item)
		{
			con.Shippings.Add(item);
			return res.GetStatus(con);
		}

		public override Result<List<Shipping>> List()
		{
			List<Shipping>  KargoListe= con.Shippings.ToList();
			return res.GetListStatus(KargoListe);
		}

		public override Result<int> Update(Shipping item)
		{
			Shipping Kargo= con.Shippings.SingleOrDefault(k => k.ShippingID== item.ShippingID);
			Kargo.ShippingName= item.ShippingName;
			Kargo.ShippingName = item.ShipPhone;
			return res.GetStatus(con); 
		}
	}
}
