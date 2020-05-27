using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA_Proje_DataLayer;

namespace BA_Proje_CommonLayer
{
	public class StatusResult<T>
	{
		public Result<int> GetStatus(KirtasiyeDB con)
		{
			Result<int> res = new Result<int>();
			int sonuc = con.SaveChanges();

			if (sonuc > 0)
			{
				res.ReturnMessage = "Basarili";
				res.Control = true;
				res.StatusResult = sonuc;
			}
			else
			{
				res.ReturnMessage = "Basarisiz";
				res.Control = false;
				res.StatusResult = sonuc;
			}
			return res;
		}

		public Result<List<T>> GetListStatus(List<T> dt)
		{
			Result<List<T>> res = new Result<List<T>>();
			if (dt != null)
			{
				res.ReturnMessage= "işlem Başarılı";
				res.Control = true;
				res.StatusResult= dt;
			}
			else
			{
				res.ReturnMessage= "işlem Başarısız";
				res.Control = false;
				res.StatusResult=dt;
			}
			return res;
		}
		public Result<T> GetT(T dt)
		{
			Result<T> res = new Result<T>();
			if (dt != null)
			{
				
				res.ReturnMessage= "Başarılı";
				res.Control = true;
				res.StatusResult= dt;
			}
			else
			{
				res.ReturnMessage = "Başarısız";
				res.Control= false;
				res.StatusResult= dt;
			}
			return res;
		}
	}
}
