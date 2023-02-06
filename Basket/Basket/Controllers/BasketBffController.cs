using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Basket.Models.Responses;
using System.Net;
using Basket.Services.Interfaces;
using Infrastructure;

namespace Basket.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketBffController : ControllerBase
    {
        private readonly ILogger<BasketBffController> _logger;
        private readonly IBasketService _basketService;

        public BasketBffController(ILogger<BasketBffController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TextResponse), (int)HttpStatusCode.OK)]
        public IActionResult LogMessage()
        {
            _basketService.LogInformation();
            return Ok(new TextResponse() { Text = "Logged message"});
        }

        [HttpPost]
        [ProducesResponseType(typeof(TextResponse), (int)HttpStatusCode.OK)]
        public IActionResult LogUserId()
        {
            _basketService.GetUserIdFromContext();
            return Ok(new TextResponse() { Text = "Logged user id" });
        }
    }
}