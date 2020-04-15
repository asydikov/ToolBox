
namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class TimeConsumingQueriesModel
    {
        public double AvgCPUTime { get; set; }
        public string StatementText { get; set; }
        public string Selector { get; set; }
    }
}
