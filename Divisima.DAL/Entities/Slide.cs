

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
	public class Slide
	{
		public int ID { get; set; }

		[StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Slayt Sloganı")]
		public string? Motto { get; set; }

		[StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Slayt Başlığı")]
		public string? Title { get; set; }

		[StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Slayt Açıklaması")]
		public string? Description { get; set; }

		[StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Slayt Resmi")]
		public string? Picture { get; set; }

		[StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Slayt Linki")]
		public string? Link { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "Slayt Fiyatı")]
		public decimal? Price { get; set; }

		[Display(Name = "Slayt Kayıt Tarihi")]
		public DateTime? RecDate { get; set; }

	}
}
