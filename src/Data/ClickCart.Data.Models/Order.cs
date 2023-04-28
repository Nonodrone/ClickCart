namespace ClickCart.Data.Models
{
    public class Order : BaseEntity
    {
        public bool isCompleted { get; set; }

        public ClickCartUser User { get; set; }

        //public List<OrderProduct> OrderProducts { get; set; }
    }
}
