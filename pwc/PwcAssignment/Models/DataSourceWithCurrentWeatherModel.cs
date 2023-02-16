namespace PwcAssignment.Models
{
    public class DataSourceWithCurrentWeatherModel
    {
        public string city { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string population_proper { get; set; }
        public CurrentWeather current_weather { get; set; }
    }
}
public class CurrentWeather
{
    public float temperature { get; set; }
    public float windspeed { get; set; }
    public float winddirection { get; set; }
    public float weathercode { get; set; }
    public DateTime time { get; set; }

}