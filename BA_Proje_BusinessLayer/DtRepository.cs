using BA_Proje_CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_BusinessLayer
{
	public abstract class DataRepository<K, N>
	{
		public abstract Result<int> Insert(K item);
		public abstract Result<int> Delete(N id);
		public abstract Result<int> Update(K item);
		public abstract Result<List<K>> List();
		public abstract Result<K> GetObjById(N id); //M id type
		public abstract Result<List<K>> GetLastObj(int quantity);

	}
}
