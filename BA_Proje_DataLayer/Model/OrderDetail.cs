using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class OrderDetail
	{

		[Required]
		[Key]
		[Column(Order = 1)]
		public int OrderID { get; set; }
		[Key]
		[Required]
		[Column(Order = 2)]
		public int ProductID { get; set; }
		[Column("UrunAdedi")]
		[Range(0, 500)]
		public int? Quantity { get; set; }
		[Column("Odeme")]
		public decimal? Price { get; set; }
		public int? ShippingID { get; set; }    //FK

		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
		public virtual Shipping Shipping { get; set; }
	}
}
