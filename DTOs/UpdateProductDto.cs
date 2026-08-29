namespace ECommerceApi.DTOs
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
