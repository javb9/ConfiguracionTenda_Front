using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using web.Models;
using static web.Models.Model;

namespace web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly string UrlApi;
        public LoginController(ILogger<LoginController> logger)
        {
            var MyConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            UrlApi = MyConfig.GetValue<string>("Variables:RutaApi");
            _logger = logger;
        }

        public HttpClient getHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            return new HttpClient(clientHandler);
        }

        public object Autenticar(user usuario)
        {
            validacionAut validacion = new validacionAut();
            string URI = UrlApi + "/Autenticacion";
            var httpClient = getHttpClient();
            var response = httpClient.PostAsJsonAsync(URI, usuario).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                validacion = JsonConvert.DeserializeObject<validacionAut>(respuesta.Response.ToString());
            }
            return validacion;
        }

        public object consultarRoles()
        {
            List<parametricas> roles = new List<parametricas>();
            string URI = UrlApi + "/consultarRoles";
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                roles = JsonConvert.DeserializeObject<List<parametricas>>(respuesta.Response.ToString());
            }
            return roles;
        }

        public object RegistrarUsuario(datasUser usuario)
        {
            validacionAut validacion = new validacionAut();
            string URI = UrlApi + "/RegistrarUsuario";
            var httpClient = getHttpClient();
            var response = httpClient.PostAsJsonAsync(URI, usuario).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                validacion = JsonConvert.DeserializeObject<validacionAut>(respuesta.Response.ToString());
            }
            return validacion;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}