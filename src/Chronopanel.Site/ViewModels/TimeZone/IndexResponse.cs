using Chronopanel.Site.Models;
using System.Collections.Generic;

namespace Chronopanel.Site.ViewModels.TimeZone
{
    public class IndexResponse
    {
        public string TimeZoneId { get; set; }
        public ICollection<TimeZoneInformation> TimeZones { get; set; } = new List<TimeZoneInformation>();
    }
}
