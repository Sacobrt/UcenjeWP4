
using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models.DTO
{
    public record GrupaDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string? Naziv,
        [Range(1, int.MaxValue, ErrorMessage = "{0} mora biti između {1} i {2}")]
        [Required(ErrorMessage = "smjer obavezno")]
        int? SmjerSifra,
        string? Predavac,
        [Range(5, 30, ErrorMessage = "{0} mora biti između {1} i {2}")]
        [Required(ErrorMessage = "Najveći broj polaznika obavezno")]
        int? MaksimalnoPolaznika
        );

   
}
