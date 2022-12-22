using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using web.Models;
using static web.Models.Model;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string UrlApi;
        public HomeController(ILogger<HomeController> logger)
        {
            var MyConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            UrlApi = MyConfig.GetValue<string>("Variables:RutaApi");
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }
        public HttpClient getHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            return new HttpClient(clientHandler);
        }

        public object CambiarContrasennaRouter(routerAdmin datos)
        {
            string URI = UrlApi + "/CambiarContrasennaRouter";
            var httpClient = getHttpClient();
            var response = httpClient.PostAsJsonAsync(URI, datos).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}