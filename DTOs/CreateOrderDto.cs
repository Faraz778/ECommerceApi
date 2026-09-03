namespace ECommerceApi.DTOs
{
    public class CreateOrderDto
    {

        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}