using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShop.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //[Route("api/flowershop")]
    public class WeatherController : ControllerBase
    {
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing a lot", "Bracing a little bit", "Chilly like boss", "Cool like on Friday",
    //        "Mild like steak", "Warm like in tropic", "Balmy finally", "Hot",
    //        "Sweltering like in the summer", "Scorching this year"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<Weather> Get()
    //    {
    //        var rng = new Random();
    //        return Enumerable.Range(1, 5).Select(index => new Weather
    //        {
    //            Data = DateTime.Now.AddDays(index),
    //            TemperaturaC = rng.Next(-20, 55),
    //            Podsumowanie = Summaries[rng.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    }
}
