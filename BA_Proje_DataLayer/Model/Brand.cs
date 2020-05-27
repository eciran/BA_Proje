using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class Brand
	{
		[Key]
		[Required]
		public int BrandID { get; set; }
		[Required]
		[MaxLength(40, ErrorMessage = "Marka ismi maksimum 40 karakter olabilir"), MinLength(3, ErrorMessage = "Marka ismi minumum 3 karakter olabilir")]
		[Column("Name")]
		public string BrandName { get; set; }
		[Column("Photos")]
		public string BrandPhoto { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
