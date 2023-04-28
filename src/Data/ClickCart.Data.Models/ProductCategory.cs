namespace ClickCart.Data.Models
{
    public class ProductCategory : BaseEntity
    {
        public String Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
