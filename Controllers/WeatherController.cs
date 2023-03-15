using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using WeatherReport.Models;

namespace WeatherForecast.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetWeatherInfo(WeatherReportViewtModel weatherModel)
        {
            try
            {
                // call the weather API to get the information.
                weatherModel = ApiHelper.GetAsync(weatherModel)?.Result;

                weatherModel.ShowWeatherCard = true;
                return View("Index", weatherModel);
            }
            catch (Exception ex)
            {
                // TODO: Log the stack trace in log file.
                return View("Error");
            }

        }
    }
}
