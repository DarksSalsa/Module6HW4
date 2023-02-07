using Basket.Models.Responses;

namespace Basket.Services.Interfaces
{
    public interface IBasketService
    {
        Task<AddItemToCatalogResponse<int>?> AddItemToCatalogAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
        void GetUserIdFromContext(string? userId);
        void LogInformation();
    }
}
