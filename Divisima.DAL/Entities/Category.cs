
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
	public class Category
	{
		public int ID { get; set; }

		[StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Kategori Adı")]
		public string? Name { get; set; }

		[Display(Name = "Görüntüleme Sırası")]
		public int? DisplayIndex { get; set; }

		public ICollection<Product> Products { get; set; }
	}

}
