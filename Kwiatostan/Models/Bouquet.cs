using Kwiatostan.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Kwiatostan.Models
{
    public class Bouquet: Article
	{
        public string UserId { set; get; }
        public DateTime CreationTime { set; get; }

        public List<BouquetProduct> InvolvedProducts = new List<BouquetProduct>();

	}
}