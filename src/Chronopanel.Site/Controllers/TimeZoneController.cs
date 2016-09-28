using Chronopanel.Site.Models;
using Chronopanel.Site.Models.TimeZone;
using Chronopanel.Site.ViewModels.TimeZone;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
using NodaTime.TimeZones;
using System.Collections.Generic;
using System.Linq;

namespace Chronopanel.Site.Controllers
{
    [Route("time-zone")]
    public class TimeZoneController : BaseController
    {
        public TimeZoneController(
            IClock clock,
            IDateTimeZoneProvider dateTimeZoneProvider,
            TzdbDateTimeZoneSource dateTimeZoneSource)
            : base(clock, dateTimeZoneProvider)
        {
            var now = clock.GetCurrentInstant();

            foreach (var temp in dateTimeZoneSource.ZoneLocations)
            {
                var timeZone = dateTimeZoneProvider.GetZoneOrNull(temp.ZoneId);
                var zoneInterval = timeZone.GetZoneInterval(now);
                var offset = zoneInterval.WallOffset;

                if (timeZone != null)
                {
                    timeZones.Add(new TimeZoneInformation
                    {
                        Id = timeZone.Id,
                        Name = zoneInterval.Name,
                        Offset = offset.ToTimeSpan().Hours
                    });
                }
            }
        }

        public readonly ICollection<TimeZoneInformation> timeZones = new List<TimeZoneInformation>();

        [HttpGet]
        public IActionResult Index()
        {
            var response = new IndexResponse()
            {
                TimeZones = timeZones.OrderBy(x => x.Id).ToList(),
                TimeZoneId = GetTimeZoneId()
            };

            return View(response);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest request)
        {
            Response.Cookies.Append(TimeZoneId, request.TimeZone);

            return RedirectToAction("Index", "Home");
        }
    }
}
