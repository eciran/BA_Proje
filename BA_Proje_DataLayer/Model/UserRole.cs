using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class UserRole
	{

		[Key]
		[Required]
		[Column("ID")]
		public int RoleID { get; set; }
		[Required]
		[Column("Name")]
		public string RoleName { get; set; }

		public virtual ICollection<Member> Member { get; set; }
	}
}
