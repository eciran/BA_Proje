using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class Invoice
	{
		[Key]
		[Required]
		public int InvoiceID { get; set; }
		public int? OrderID { get; set; }     // FK
		public int? PaymentID { get; set; }  //  FK
		[MaxLength(40, ErrorMessage = "Adres max. 40 karakter olabilir"), MinLength(3, ErrorMessage = "Adres min. 3 karakter olabilir")]
		public string Address { get; set; }

		public virtual Payment Payment { get; set; }
		public virtual Order Order { get; set; }

	}
}
