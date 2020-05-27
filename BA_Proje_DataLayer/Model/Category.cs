using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class Category
	{
		[Key]
		[Required]
		public int CategoryID { get; set; }
		[Required]
		[MaxLength(40, ErrorMessage = "Kategoryi ismi maksimum 40 karakter olabilir"), MinLength(3, ErrorMessage = "Kategori ismi minumum 3 karakter olabilir")]
		[Column(name: "KategoriAdı")]
		public string CategoryName { get; set; }
		[MaxLength(40, ErrorMessage = "Kategori ismi maksimum 40 karakter olabilir"), MinLength(3, ErrorMessage = "Kategori ismi minumum 3 karakter olabilir")]
		[Column("Acıklama")]
		public string CategoryDesc { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
