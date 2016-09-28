using Chronopanel.Site.Models.Dashboard;
using Chronopanel.Site.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System;

namespace Chronopanel.Site.Controllers
{
    [Route("panels/bcd/dashboard")]
    public class DashboardController : BaseController
    {
        public DashboardController(
            IClock clock,
            IDateTimeZoneProvider dateTimeZoneProvider)
            : base(clock, dateTimeZoneProvider)
        { }

        public IActionResult Index([FromQuery]IndexRequest request)
        {
            if (!request.ContainsValidColors())
            {
                throw new Exception("Invalid colors.");
            }

            var now = GetCurrentZonedTime();

            var response = new IndexResponse(
                now,
                request.BackgroundColor,
                request.HoursActiveColor,
                request.HoursInactiveColor,
                request.MinutesActiveColor,
                request.MinutesInactiveColor,
                request.SecondsActiveColor,
                request.SecondsInactiveColor);

            return View(response);
        }
    }
}
