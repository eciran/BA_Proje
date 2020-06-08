using BA_Proje_CommonLayer;
using BA_Proje_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_BusinessLayer
{
	public class MemberRepository : DataRepository<Member, int>
	{
		private static KirtasiyeDB con = Connection.GetConnection();
		StatusResult<Member> res = new StatusResult<Member>();


		public override Result<int> Delete(int id)
		{
			Member UyeSil = con.Members.SingleOrDefault(m => m.MemberID == id);
			con.Members.Remove(UyeSil);
			return res.GetStatus(con);
		}

		public override Result<List<Member>> GetLastObj(int quantity)
		{
			return res.GetListStatus(con.Members.OrderByDescending(m => m.MemberID).Take(quantity).ToList());
		}

		public override Result<Member> GetObjById(int id)
		{
			Member M = con.Members.SingleOrDefault(u => u.MemberID== id);
			return res.GetT(M);
		}

		public override Result<int> Insert(Member item)
		{
			con.Members.Add(item);
			return res.GetStatus(con);
		}

		public override Result<List<Member>> List()
		{
			return res.GetListStatus(con.Members.ToList());
		}

		public override Result<int> Update(Member item)
		{
			Member m = con.Members.SingleOrDefault(x => x.MemberID== item.MemberID);
			m.FirstName = item.FirstName;
			m.LastName = item.LastName;
			m.Password = item.Password;
			m.RoleId = item.RoleId;
			m.Address = item.Address;
			m.Email = item.Email;
			return res.GetStatus(con);
		}
	}
}
