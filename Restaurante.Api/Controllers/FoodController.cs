﻿using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Services;
using Restaurante.Core.Models;

namespace Restaurante.Api.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodApplicationService _foodApplicationService;

        public FoodController(IFoodApplicationService foodApplicationService)
        {
            _foodApplicationService = foodApplicationService;
        }

        [HttpPost]
        public IActionResult Add(Food food)
        {
            _foodApplicationService.Add(food);
            return Ok();
        }
    }
}