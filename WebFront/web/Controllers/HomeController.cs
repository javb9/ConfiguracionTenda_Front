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

        public IActionResult Home(decimal idUsuario)
        {
            ViewBag.idUsuario = idUsuario;
            return View();
        }
        public HttpClient getHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            return new HttpClient(clientHandler);
        }

        public object solicitudVisita(decimal idUsuario)
        {
            string URI = UrlApi + "/solicitudVisita/" + idUsuario;
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            return true;
        }

        public object CambiarContrasennaRouter(routerAdmin datos)
        {
            string URI = UrlApi + "/EditRouterInfo";
            var httpClient = getHttpClient();
            var response = httpClient.PostAsJsonAsync(URI, datos).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public object BlockDevice(BlockDeviceModel data)
        {
            string URI = UrlApi + "/BlockDevice/";
            var httpClient = getHttpClient();
            var response = httpClient.PostAsJsonAsync(URI, data).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public object consultarTiposDocumento()
        {
            List<parametricas> tipos = new List<parametricas>();
            string URI = UrlApi + "/consultarTiposDoc";
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                tipos = JsonConvert.DeserializeObject<List<parametricas>>(respuesta.Response.ToString());
            }
            return tipos;
        }

        public object consultarUsuario(decimal idUsuario)
        {
            datasUser usuario = new datasUser();
            string URI = UrlApi + "/consultarUsuario/" + idUsuario;
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                usuario = JsonConvert.DeserializeObject<datasUser>(respuesta.Response.ToString());
            }
            return usuario;
        }
        
        public object EditarUsuario(datasUser usuario)
        {
            validacionAut validacion = new validacionAut();
            string URI = UrlApi + "/EditarUsuario";
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

        public object consultarNotifiaciones()
        {
            List<notificaciones> not = new List<notificaciones>();
            string URI = UrlApi + "/consultarNotifiaciones";
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                not = JsonConvert.DeserializeObject<List<notificaciones>>(respuesta.Response.ToString());
            }
            return not;
        }

        public object EliminarNotificacion(decimal id)
        {
            string URI = UrlApi + "/EliminarNotificacion/" + id;
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public object consultarConectados(string puertaEnlace)
        {
            List<conectados> tipos = new List<conectados>();
            string URI = UrlApi + "/ObtenerConectados/" + puertaEnlace;
            var httpClient = getHttpClient();
            var response = httpClient.GetAsync(URI).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                Responses respuesta = JsonConvert.DeserializeObject<Responses>(responseString);
                tipos = JsonConvert.DeserializeObject<List<conectados>>(respuesta.Response.ToString());
            }
            return tipos;
        }
    }
}