using NodaTime;
using System;
using DashboardIndexResponse = Chronopanel.Site.ViewModels.Dashboard.IndexResponse;

namespace Chronopanel.Site.ViewModels.Home
{
    public class IndexResponse
    {
        public IndexResponse(
            LocalTime time,
            string backgroundColor,
            string hoursActiveColor,
            string hoursInactiveColor,
            string minutesActiveColor,
            string minutesInactiveColor,
            string secondsActiveColor,
            string secondsInactiveColor,
            string timeZone = null)
        {
            if (time == null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            if (backgroundColor == null)
            {
                throw new ArgumentNullException(nameof(backgroundColor));
            }

            if (hoursActiveColor == null)
            {
                throw new ArgumentNullException(nameof(hoursActiveColor));
            }

            if (hoursInactiveColor == null)
            {
                throw new ArgumentNullException(nameof(hoursInactiveColor));
            }

            if (minutesActiveColor == null)
            {
                throw new ArgumentNullException(nameof(minutesActiveColor));
            }

            if (minutesInactiveColor == null)
            {
                throw new ArgumentNullException(nameof(minutesInactiveColor));
            }

            if (secondsActiveColor == null)
            {
                throw new ArgumentNullException(nameof(secondsActiveColor));
            }

            if (secondsInactiveColor == null)
            {
                throw new ArgumentNullException(nameof(secondsInactiveColor));
            }

            Dashboard = new DashboardIndexResponse(
                time,
                backgroundColor,
                hoursActiveColor,
                hoursInactiveColor,
                minutesActiveColor,
                minutesInactiveColor,
                secondsActiveColor,
                secondsInactiveColor);

            TimeZoneId = timeZone;
        }

        public readonly DashboardIndexResponse Dashboard;
        public bool IsTimeZoneSet() => !string.IsNullOrEmpty(TimeZoneId);
        public readonly string TimeZoneId;
    }
}
