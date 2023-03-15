using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherReport.Models;

namespace WeatherForecast
{
    public static class ApiHelper
    {
        public static async Task<WeatherReportViewtModel> GetAsync(WeatherReportViewtModel weatherModel)
        {
            //TODO: Get this from app settings instead of hard coding.
            string appId = "8113fcc5a7494b0518bd91ef3acc074f";

            //TODO: Get this from app settings instead of hard coding.
            string url = "http://api.openweathermap.org/data/2.5/";

            string weatherApi = string.Format("weather?q={0}&units=Celsius&APPID={1}", weatherModel.Country, appId);

            using var client = new HttpClient();
            {
                client.BaseAddress = new Uri(url);
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));
                // Get data response
                var response = await client.GetAsync(weatherApi);
                if (response.IsSuccessStatusCode)
                {
                    weatherModel = JsonConvert.DeserializeObject<WeatherReportViewtModel>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    //TODO: Log the exception in log file.
                }
            }

            return weatherModel;
        }
    }
}
