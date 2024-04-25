using Kwiatostan.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Kwiatostan.Models
{
	public class Article
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000")]
		[Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public required decimal Price { get; set; }

		public string? ImageFilename { get; set; }

	}
}