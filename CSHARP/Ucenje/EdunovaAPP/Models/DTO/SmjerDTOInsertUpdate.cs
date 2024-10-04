using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models.DTO
{
    public record SmjerDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string Naziv,
        [Range(30, 500, ErrorMessage = "{0} mora biti između {1} i {2}")]
        [Required(ErrorMessage = "trajanje obavezno")]
        int? Trajanje,
        [Range(0, 10000, ErrorMessage = "Vrijednost {0} mora biti između {1} i {2}")]
        decimal? Cijena,
        DateTime? IzvodiSeOd,
        bool? Vaucer
        );
}
