using Chronopanel.ViewModels.Dashboard;
using NodaTime;
using System;

namespace Chronopanel.Site.ViewModels.Dashboard
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
            string secondsInactiveColor)
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

            BackgroundColor = backgroundColor;
            ClockContainer = new ClockContainerViewModel(time);
            HoursActiveColor = hoursActiveColor;
            HoursInactiveColor = hoursInactiveColor;
            MinutesActiveColor = minutesActiveColor;
            MinutesInactiveColor = minutesInactiveColor;
            SecondsActiveColor = secondsActiveColor;
            SecondsInactiveColor = secondsInactiveColor;

            var hours = time.Hour;
            var minutes = time.Minute;
            var seconds = time.Second;

            SecondOnes = seconds % 10;
            SecondTens = seconds % 60;

            MinuteOnes = (minutes % 10) * 60 + seconds;
            MinuteTens = (minutes % 60) * 60 + seconds;

            HourOnes = (hours % 10) * 3600 + (minutes * 60) + seconds;
            HourTens = (hours % 24) * 3600 + (minutes * 60) + seconds;
        }

        public readonly string BackgroundColor;
        public readonly ClockContainerViewModel ClockContainer;
        public readonly string HoursActiveColor;
        public readonly string HoursInactiveColor;
        public readonly string MinutesActiveColor;
        public readonly string MinutesInactiveColor;
        public readonly string SecondsActiveColor;
        public readonly string SecondsInactiveColor;

        public readonly int SecondOnes;
        public readonly int SecondTens;
        public readonly int MinuteOnes;
        public readonly int MinuteTens;
        public readonly int HourOnes;
        public readonly int HourTens;
    }
}
