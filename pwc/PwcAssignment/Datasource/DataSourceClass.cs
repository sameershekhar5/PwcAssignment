using PwcAssignment.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PwcAssignment.Datasource
{
    public class DataSourceClass : IDataSourceClass
    {
        #region Fields
        private readonly IWebHostEnvironment _webHost;
        private static new List<DataSourceModel> _AllData;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        #endregion

        #region Constructor
        public DataSourceClass(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Use this method to add all data from json file to static list 
        /// </summary>
        /// <returns></returns>
        public async Task AddNewData()
        {
            try
            {
                var location = _webHost.WebRootPath + "/in.json";
                string jsonString = File.ReadAllText(location);
                List<DataSourceModel> Data = JsonSerializer.Deserialize<List<DataSourceModel>>(jsonString)!;
                if (_AllData is not null && _AllData.Any())
                {
                    _AllData.Clear();
                }
                _AllData = Data;

            }
            catch (Exception e)
            {
                //Add exception in log file
            }

        }
        /// <summary>
        /// Use this method to fetch data based on given parameters
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="longi"></param>
        /// <returns></returns>
        public async Task<DataSourceModel> GetLocationDetails(decimal lat, decimal longi)
        {
            var data = _AllData.FirstOrDefault(x => Convert.ToDecimal(x.lng) == longi && Convert.ToDecimal(x.lat) == lat);
            return await Task.FromResult(data);
        }

        public async Task<DataSourceWithCurrentWeatherModel> GetForcastData(decimal lat, decimal longi)
        {
            var data = await GetLocationDetails(lat, longi);
            if (data is null)
                return new DataSourceWithCurrentWeatherModel();
            var forcastdata = Enumerable.Range(1, 1).Select(index => new CurrentWeather
            {
                time = DateTime.Now.AddDays(index),
                temperature = Random.Shared.Next(-20, 55),
                weathercode = Random.Shared.Next(0, 10),
                winddirection = Random.Shared.Next(0, 10),
                windspeed = Random.Shared.Next(0, 10)
            })
             .FirstOrDefault();

            DataSourceWithCurrentWeatherModel forcast_data = new()
            {
                admin_name = data.admin_name,
                capital = data.capital,
                city = data.city,
                country = data.country,
                iso2 = data.iso2,
                lat = data.lat,
                lng = data.lng,
                population = data.population,
                population_proper = data.population_proper,
                current_weather = forcastdata
            };
            return forcast_data;
        }
        #endregion
    }
}
