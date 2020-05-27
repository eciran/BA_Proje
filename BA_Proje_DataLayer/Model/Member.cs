using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class Member
	{
		[Key]
		[Column("ID")]
		[Required]
		public int MemberID { get; set; }
		[Column("Isim")]
		[Required]
		public string FirstName { get; set; }
		[Column("Soyisim")]
		[Required]
		public string LastName { get; set; }
		[Column("Kayit Tarihi")]
		public DateTime? CreatedDate { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[Column("Sifre")]
		[MaxLength(40), MinLength(5)]
		public string Password { get; set; }
		public int? RoleId { get; set; }  //FK
		[MaxLength(100), MinLength(5)]
		[Column("Adres")]
		public string Address { get; set; }


		public virtual UserRole RoleID { get; set; }

	}
}
