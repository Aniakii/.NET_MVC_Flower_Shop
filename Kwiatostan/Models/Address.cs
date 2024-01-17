using System.ComponentModel.DataAnnotations;

namespace Kwiatostan.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Adres ulicy jest wymagany.")]
        [StringLength(100, ErrorMessage = "Adres ulicy nie może przekraczać 100 znaków.")]
        public required string Street { get; set; }

        [Required(ErrorMessage = "Number budynku jest wymagany.")]
        public required int BuildingNumber { get; set; }

        public int? ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane.")]
        [StringLength(50, ErrorMessage = "Miasto nie może przekraczać 50 znaków.")]
        public required string City { get; set; }

        [Required(ErrorMessage = "Kod pocztowy jest wymagany.")]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Nieprawidłowy kod pocztowy.")]
        public required string PostalCode { get; set; }

        public string? UserId { get; set; }

        public override string ToString()
        {
            return $"{Street} {BuildingNumber}{(ApartmentNumber.HasValue ? $", mieszkanie {ApartmentNumber}" : "")}, {City}, {PostalCode}";
        }
    }
}
