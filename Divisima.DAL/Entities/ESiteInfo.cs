
using System.ComponentModel.DataAnnotations;

namespace Divisima.DAL.Entities
{
    public enum ESiteInfo
    {
        [Display(Name = "Sosyal Medya Bilgileri")]
        Sosyal = 1,

        [Display(Name = "Meta Bilgileri")]
        Meta = 2,

        [Display(Name = "Contact Bilgileri")]
        Contact = 3,
    }
}
