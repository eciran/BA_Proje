using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class Product
	{
		[Key]
		[Required]
		[Column("ID")]
		public int ProductID { get; set; }
		[Required]
		[MaxLength(40, ErrorMessage = "Ürün ismi maksimum 40 karakter olabilir"), MinLength(3, ErrorMessage = "Ürün ismi minumum 3 karakter olabilir")]
		[Column("Name")]
		public string ProductName { get; set; }
		[Required]
		[Column("Stok")]
		[Range(0, Int32.MaxValue,ErrorMessage = "Stok Değeri 0'dan Kücük Olamaz")]
		public int Stock { get; set; }
		[Required]
		[Column("Fiyat")]
		[Range(0,Double.MaxValue,ErrorMessage ="Fiyat 0'dan Kücük Olamaz")]
		public int Price { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Ürün acıklaması maksimum 50 karakter olabilir"), MinLength(3, ErrorMessage = "Ürün acıklaması minumum 3 karakter olabilir")]
		[Column("UrunAçiklama")]
		public string Description { get; set; }
		[Required]
		[Column("UrunFoto")]
		public string Photo { get; set; }


		public int? BrandID { get; set; }           //FK
		public virtual Brand Brand { get; set; }

		public int? CategoryID { get; set; }       //FK       
		public virtual Category Category { get; set; }

		public virtual ICollection<OrderDetail> OrderDetail { get; set; }
	}
}
