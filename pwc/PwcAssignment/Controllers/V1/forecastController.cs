using Microsoft.AspNetCore.Mvc;
using PwcAssignment.Datasource;
using System.Runtime.ConstrainedExecution;

namespace PwcAssignment.Controllers.V1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class forecastController : Controller
    {
        private readonly IDataSourceClass _dataSource;

        public forecastController(IDataSourceClass dataSource)
        {
            _dataSource = dataSource;
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> Get(decimal latitude, decimal longitude, bool current_weather)
        {
            return Ok(current_weather ? await _dataSource.GetForcastData(latitude, longitude) : await _dataSource.GetLocationDetails(latitude, longitude));
        }        
    }
}
