using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace Chronopanel.Site.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(
            IClock clock,
            IDateTimeZoneProvider dateTimeZoneProvider)
        {
            this.clock = clock;
            this.dateTimeZoneProvider = dateTimeZoneProvider;
        }

        private readonly IClock clock;
        private readonly IDateTimeZoneProvider dateTimeZoneProvider;

        public const string TimeZoneId = "TimeZoneId";

        protected LocalTime GetCurrentZonedTime()
        {
            var timeZoneId = GetTimeZoneId();
            DateTimeZone zone = null;

            if (!string.IsNullOrEmpty(timeZoneId))
            {
                zone = dateTimeZoneProvider.GetZoneOrNull(timeZoneId);
            }

            if (zone == null)
            {
                timeZoneId = string.Empty;
            }

            var now = zone == null
                ? clock.GetCurrentInstant().InUtc().LocalDateTime.TimeOfDay
                : clock.GetCurrentInstant().InZone(zone).TimeOfDay;

            return now;
        }

        protected string GetTimeZoneId()
        {
            var timeZoneId = string.Empty;

            timeZoneId = Request.Cookies[TimeZoneId];

            if (string.IsNullOrEmpty(timeZoneId))
            {
                timeZoneId = Request.Query[TimeZoneId];
            }

            return timeZoneId;
        }
    }
}
