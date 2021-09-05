
using CityAttractions.Data;
using CityAttractions.Models;
using CityAttractions.Services;
using CityAttractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityAttractions.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICityRepository _repository;
        

        public HomeController(ILogger<HomeController> logger, IMailService mailService, IHttpClientFactory httpClientFactory, ICityRepository repository)
        {
            _logger = logger;
            _mailService = mailService;
            _httpClientFactory = httpClientFactory;
            this._repository = repository;
           
        }

        private async Task<CityAttractions.Data.Root> results()
        {
            // Get an instance of HttpClient from the factpry that we registered
            // in Startup.cs
            var client = _httpClientFactory.CreateClient("API Client");

            // Call the API & wait for response.
            // If the API call fails, call it again according to the re-try policy
            // specified in Startup.cs
            var result = await client.GetAsync("api/20200405/location.json?tag_labels=city&order_by=-score&count=100&account=I0OEOPWQ&token=0d843xcrheh2r5cz6qj5a0b1kos2qjbp");

            if (result.IsSuccessStatusCode)
            {

                // Read all of the response and deserialise it into an instace of
                // WeatherForecast class
                var content = await result.Content.ReadAsStringAsync();

                var contentObject = JsonConvert.DeserializeObject<CityAttractions.Data.Root>(content);

                return contentObject;
            }
            return null;
        }


        public async Task<IActionResult> Index()
        {
            var model = await results();
            // Pass the data into the View
            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the Email
                _mailService.SendMessage("r@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent...";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Popup1()
        {
            var model = await results();

            // Pass the data into the View
            return View(model);

        }

        public IActionResult Details()
        {
            var results = _repository.GetAllCities();
               
            return View(results);
        }




    }
}
