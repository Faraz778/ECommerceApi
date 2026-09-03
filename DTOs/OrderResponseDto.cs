namespace ECommerceApi.DTOs
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemResponseDto> OrderItems { get; set; } = new();
    }
}