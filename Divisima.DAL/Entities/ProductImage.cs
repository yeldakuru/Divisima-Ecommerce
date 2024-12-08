
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
	public class ProductImage
	{
        public int ID { get; set; }

		[StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Resim Yolu")]
		public string? Path { get; set; }

		[Display(Name = "Görüntüleme Sırası")]
		public int? DisplayIndex { get; set; }


		[Display(Name = "Bağlı Olduğu Ürün")]
		public int ProductID { get; set; }
		public Product Product { get; set; }

	}
}
