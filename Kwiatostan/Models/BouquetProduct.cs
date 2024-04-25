namespace Kwiatostan.Models
{
    public class BouquetProduct
    {
        public int Id { get; set; }
        public int BouquetId { get; set; }
        public int ProductId { get; set; }

        public int Amount{ get; set; }
    }
}
