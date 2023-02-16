using PwcAssignment.Models;

namespace PwcAssignment.Datasource
{
    public interface IDataSourceClass
    {
        Task AddNewData();
        Task<DataSourceModel> GetLocationDetails(decimal lat, decimal longi);
        Task<DataSourceWithCurrentWeatherModel> GetForcastData(decimal lat, decimal longi);
    }
}