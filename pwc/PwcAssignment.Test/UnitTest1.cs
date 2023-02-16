using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PwcAssignment.Controllers.V1;
using PwcAssignment.Datasource;
using Xunit;

namespace PwcAssignment.Test
{
    public class UnitTest1
    {
        private readonly forecastController _controller;
        private readonly IDataSourceClass _service;
        private readonly MockHostingEnvironment _webHostEnvironment;
        public UnitTest1(MockHostingEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _service = new DataSourceClass(_webHostEnvironment);
            _controller = new forecastController(_service);
        }
        [Fact]
        public async Task TestCase1()
        {
            decimal longitude = 77.2300m;
            decimal latitude = 28.6600m;
            bool weather = true;
            await _service.AddNewData();
            var result = await _controller.Get(latitude, longitude, weather);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
    }
}