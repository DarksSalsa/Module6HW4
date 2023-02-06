using Basket.Models.Requests;
using Basket.Models.Responses;
using Basket.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("basket.basket")]
    [Route(ComponentDefaults.DefaultRoute)] 
    public class BasketItemController : ControllerBase
    {
        private readonly ILogger<BasketItemController> _logger;
        private readonly IBasketService _basketService;

        public BasketItemController(ILogger<BasketItemController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemToCatalogResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(AddItemToCatalogRequest request)
        {
            var result = await _basketService.AddItemToCatalogAsync(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
            return Ok(result);
        }
    }
}
