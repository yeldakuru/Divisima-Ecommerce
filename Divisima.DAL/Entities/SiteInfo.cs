

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
    public class SiteInfo
    {
        public int ID { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Info 1")]
        public string? Info1 { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Info 2")]
        public string? Info2 { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Info 3")]
        public string? Info3 { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Info 4")]
        public string? Info4 { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Info 5")]
        public string? Info5 { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Info 6")]
        public string? Info6 { get; set; }


        [Display(Name = "Bilgi Filtresi")]
        public ESiteInfo? ESiteInfo { get; set; }

    }
}
