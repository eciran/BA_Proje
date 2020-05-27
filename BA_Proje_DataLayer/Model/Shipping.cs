using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class Shipping
	{
		[Key]
		[Column("ID")]
		[Required]
		public int ShippingID { get; set; }
		[Column("KargoAdı")]
		[Required]
		[MaxLength(20), MinLength(3)]
		public string ShippingName { get; set; }
		[StringLength(11)]
		[Column("Telefon")]
		public string ShipPhone { get; set; }
	}
}
