using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
	public class Product
	{
		public int ID { get; set; }

		[StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Ürün Adı")]
		public string? Name { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "Fiyat")]
		public decimal? Price { get; set; }

		[StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Ürün Açıklaması")]
		public string? Description { get; set; }

		[Display(Name = "Stok Miktarı")]
		public int? Stock { get; set; }

		[Column(TypeName = "text"), Display(Name = "Ürün Detayı")]
		public string? Detail { get; set; }

		[Display(Name = "Kayıt Tarihi")]
		public DateTime? RecDate { get; set; }

        [Display(Name = "Görüntüleme Sırası")]
        public int? DisplayIndex { get; set; }

        [Display(Name = "Kategorisi")]
		public int? CategoryID{ get; set; }
		public Category Category { get; set; }

		public ICollection<ProductImage> ProductImages { get; set; }

	}

}
