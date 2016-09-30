namespace Chronopanel.Site.Models
{
    public abstract class BaseIndexRequest<T>
        where T : BaseIndexRequest<T>, new()
    {
        protected const string DefaultColor = "000000";

        public virtual string BackgroundColor { get; set; } = "000000";
        public virtual string HoursActiveColor { get; set; } = "ffff00";
        public virtual string HoursInactiveColor { get; set; } = "707010"; // desaturate(darken(25%), 25%)
        public virtual string MinutesActiveColor { get; set; } = "00ffff";
        public virtual string MinutesInactiveColor { get; set; } = "107070"; // desaturate(darken(25%), 25%)
        public virtual string SecondsActiveColor { get; set; } = "ff00ff";
        public virtual string SecondsInactiveColor { get; set; } = "701070"; // desaturate(darken(25%), 25%)
        public virtual string TimeZoneId { get; set; }

        public bool ContainsValidColors()
        {
            var result = true;
            uint parsedHex;

            foreach (var color in new[] { BackgroundColor, HoursActiveColor, HoursInactiveColor, MinutesActiveColor, MinutesInactiveColor, SecondsActiveColor, SecondsInactiveColor })
            {
                result = !uint.TryParse(color, System.Globalization.NumberStyles.HexNumber, null, out parsedHex)
                    ? false
                    : result;
            }

            return result;
        }

        public static T CreateRequest(
            string backgroundColor = null,
            string hoursActiveColor = null,
            string hoursInactiveColor = null,
            string minutesActiveColor = null,
            string minutesInactiveColor = null,
            string secondsActiveColor = null,
            string secondsInactiveColor = null,
            string timeZoneId = null)
        {
            var request = new T();

            request.BackgroundColor = string.IsNullOrEmpty(backgroundColor)
                ? DefaultColor
                : backgroundColor.Replace("#", "");

            request.HoursActiveColor = string.IsNullOrEmpty(hoursActiveColor)
                ? DefaultColor
                : hoursActiveColor.Replace("#", "");

            request.HoursInactiveColor = string.IsNullOrEmpty(hoursInactiveColor)
                ? DefaultColor
                : hoursInactiveColor.Replace("#", "");

            request.MinutesActiveColor = string.IsNullOrEmpty(minutesActiveColor)
                ? DefaultColor
                : minutesActiveColor.Replace("#", "");

            request.MinutesInactiveColor = string.IsNullOrEmpty(minutesInactiveColor)
                ? DefaultColor
                : minutesInactiveColor.Replace("#", "");

            request.SecondsActiveColor = string.IsNullOrEmpty(secondsActiveColor)
                ? DefaultColor
                : secondsActiveColor.Replace("#", "");

            request.SecondsInactiveColor = string.IsNullOrEmpty(secondsInactiveColor)
                ? DefaultColor
                : secondsInactiveColor.Replace("#", "");

            if (!string.IsNullOrEmpty(timeZoneId))
            {
                request.TimeZoneId = timeZoneId;
            }

            return request;
        }

        public void ResetColors()
        {
            var _ = new T();

            BackgroundColor = _.BackgroundColor;
            HoursActiveColor = _.HoursActiveColor;
            HoursInactiveColor = _.HoursInactiveColor;
            MinutesActiveColor = _.MinutesActiveColor;
            MinutesInactiveColor = _.MinutesInactiveColor;
            SecondsActiveColor = _.SecondsActiveColor;
            SecondsInactiveColor = _.SecondsInactiveColor;
        }
    }
}
