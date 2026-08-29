namespace ECommerceApi.DTOs
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }

    }
}
