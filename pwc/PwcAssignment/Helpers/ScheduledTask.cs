using Coravel.Invocable;
using Coravel.Scheduling.Schedule.Interfaces;
using PwcAssignment.Datasource;

namespace PwcAssignment.Helpers
{
    public class ScheduledTask : IInvocable
    {
        private readonly IDataSourceClass _dataSource;

        public ScheduledTask(IDataSourceClass dataSource)
        {
            _dataSource = dataSource;
        }
        public async Task Invoke()
        {
            await _dataSource.AddNewData();
            
        }
    }
}
