using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_DataLayer
{
	public class KirtasiyeDB : DbContext
	{
		public KirtasiyeDB() : base("KirtasiyeDB")
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Shipping> Shippings { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Payment> Payments { get; set; }
	}
}
