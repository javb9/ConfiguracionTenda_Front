using Microsoft.AspNetCore.Mvc;
using web.Controllers;
using web.Models;
using Xunit;

namespace TestProject
{
    public class HomeTesting
    {
        private readonly HomeController _Controller;
        private readonly ErrorViewModel _Model;
        public HomeTesting()
        {
            _Controller = new HomeController();
            _Model = new ErrorViewModel(_Controller);
        }

        [Fact]
        public void Get_OK()
        {
            var result = _Controller.getHttpClient();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}