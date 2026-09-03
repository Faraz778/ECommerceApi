using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.DTOs
{
    public class CreateOrderItemDto
    {
        public int OrderId { get; set; }

        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
