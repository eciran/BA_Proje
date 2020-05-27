using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA_Proje_DataLayer;

namespace BA_Proje_CommonLayer
{
	public class Connection
	{
		public static KirtasiyeDB con = null;
		public static KirtasiyeDB GetConnection()
		{
			if (con == null)
			{
				con = new KirtasiyeDB();
			}
			return con;
		}
}
}
