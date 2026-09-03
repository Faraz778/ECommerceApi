using ECommerceApi.DTOs;
using ECommerceApi.Models;

namespace ECommerceApi.Services
{
    public interface IOrderItemService
    {
        Task<OrderItem> CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto);
    }
}