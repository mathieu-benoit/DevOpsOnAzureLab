using MainWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MainWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class RandomAdditionController : Controller
    {
        private readonly IAdditionService _additionService;

        public RandomAdditionController(IAdditionService additionService)
        {
            _additionService = additionService;
        }

        // GET api/randomaddition
        [HttpGet]
        public string Get()
        {
            var random = new Random();
            var maxRandomValue = 10000;
            var x = random.Next(maxRandomValue);
            var y = random.Next(maxRandomValue);
            var result = _additionService.Add(x, y);
            return $"Did you know that '{x} + {y} = {result}'? ;)";
        }
    }
}
