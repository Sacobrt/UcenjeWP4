
namespace EdunovaAPP.Models.DTO
{
    public record SmjerDTORead(
        int Sifra, 
        string Naziv, 
        int? Trajanje,
        decimal? Cijena,
        DateTime? IzvodiSeOd,
        bool? Vaucer
        );

   
}
