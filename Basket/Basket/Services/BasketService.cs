using Basket.Models.Requests;
using Basket.Models.Responses;
using Basket.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;

namespace Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IInternalHttpClientService _httpClient;
        private readonly IHttpContextAccessor _context;
        private readonly ILogger<BasketService> _logger;
        public BasketService(IInternalHttpClientService httpClient, IOptions<AppSettings> settings, IHttpContextAccessor context, ILogger<BasketService> logger)
        {
            _settings = settings;
            _httpClient = httpClient;
            _context = context;
            _logger = logger;
        }

        public async Task<AddItemToCatalogResponse<int>?> AddItemToCatalogAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            var result = await _httpClient.SendAsync<AddItemToCatalogResponse<int>, AddItemToCatalogRequest>(
                "http://www.alevelwebsite.com:5000/api/v1/CatalogItem/add",
                HttpMethod.Post,
                new AddItemToCatalogRequest()
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    AvailableStock = availableStock,
                    CatalogBrandId = catalogBrandId,
                    PictureFileName = pictureFileName,
                    CatalogTypeId = catalogTypeId,
                });
            if (result == null)
            {
                return null;
            }
            return result;
        }
        public void LogInformation()
        {
            _logger.Log(LogLevel.Information, "Information");
        }

        public void GetUserIdFromContext(string? userId)
        {
            if (userId != null)
            {
                _logger.Log(LogLevel.Critical, userId);
                return;
            }

            _logger.Log(LogLevel.Critical, "UserId was not found.");
        }
    }
}
