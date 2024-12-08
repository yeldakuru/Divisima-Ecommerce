using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
    public class Admin
    {
        public int ID { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Adı")]
        public string? Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Soyadı")]
        public string? Surname { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Adı"), Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez...")]
        public string UserName { get; set; }

        [StringLength(32), Column(TypeName = "varchar(32)"), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Boş Geçilemez...")]
        public string Password { get; set; }

        [Display(Name="En son Giriş Tarihi")]
        public DateTime? LastDate { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "En Son Giriş Yapılan IP Adresi")]
        public string? LastIpNo { get; set; }
    }
}
