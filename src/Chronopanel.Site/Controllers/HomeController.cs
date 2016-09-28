using Chronopanel.Site.Models.Home;
using Chronopanel.Site.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System;

namespace Chronopanel.Site.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(
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

            var timeZoneId = GetTimeZoneId();
            var now = GetCurrentZonedTime();

            var response = new IndexResponse(
                now,
                request.BackgroundColor,
                request.HoursActiveColor,
                request.HoursInactiveColor,
                request.MinutesActiveColor,
                request.MinutesInactiveColor,
                request.SecondsActiveColor,
                request.SecondsInactiveColor,
                timeZoneId);

            return View(response);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
