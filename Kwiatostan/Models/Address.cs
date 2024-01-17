using System.ComponentModel.DataAnnotations;

namespace Kwiatostan.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Adres ulicy jest wymagany.")]
        [StringLength(100, ErrorMessage = "Adres ulicy nie może przekraczać 100 znaków.")]
        public required string Ulica { get; set; }

        [Required(ErrorMessage = "Number budynku jest wymagany.")]
        public required int NumerBudynku { get; set; }

        public int? NumerMieszkania { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane.")]
        [StringLength(50, ErrorMessage = "Miasto nie może przekraczać 50 znaków.")]
        public required string Miasto { get; set; }

        [Required(ErrorMessage = "Kod pocztowy jest wymagany.")]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Nieprawidłowy kod pocztowy.")]
        public required string KodPocztowy { get; set; }

        public string? UserId { get; set; }
    }
}
