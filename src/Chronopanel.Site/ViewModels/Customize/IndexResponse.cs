using Chronopanel.Site.Models;
using System;
using System.Collections.Generic;

namespace Chronopanel.Site.ViewModels.Customize
{
    public class IndexResponse
    {
        public IndexResponse(
            string backgroundColor,
            string hoursActiveColor,
            string hoursInactiveColor,
            string minutesActiveColor,
            string minutesInactiveColor,
            string secondsActiveColor,
            string secondsInactiveColor,
            IEnumerable<ColorSwatch> colorSwatches = null)
        {
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
            HoursActiveColor = hoursActiveColor;
            HoursInactiveColor = hoursInactiveColor;
            MinutesActiveColor = minutesActiveColor;
            MinutesInactiveColor = minutesInactiveColor;
            SecondsActiveColor = secondsActiveColor;
            SecondsInactiveColor = secondsInactiveColor;

            if (colorSwatches != null)
            {
                ColorSwatches = colorSwatches;
            }
        }

        public readonly string BackgroundColor;
        public IEnumerable<Models.ColorSwatch> ColorSwatches { get; set; } = new List<Models.ColorSwatch>();
        public readonly string HoursActiveColor;
        public readonly string HoursInactiveColor;
        public readonly string MinutesActiveColor;
        public readonly string MinutesInactiveColor;
        public readonly string SecondsActiveColor;
        public readonly string SecondsInactiveColor;
    }
}
