using NodaTime;
using System;

namespace Chronopanel.ViewModels.Dashboard
{
    public class ClockContainerViewModel
    {
        public ClockContainerViewModel(LocalTime time)
        {
            if (time == null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            var timeHour = time.Hour < 10 ? $"0{time.Hour}" : time.Hour.ToString();
            var timeMinute = time.Minute < 10 ? $"0{time.Minute}" : time.Minute.ToString();
            var timeSecond = time.Second < 10 ? $"0{time.Second}" : time.Second.ToString();

            var hourTens = Convert.ToUInt16(timeHour.Substring(0, 1));
            var hourOnes = Convert.ToUInt16(timeHour.Substring(1, 1));
            var minuteTens = Convert.ToUInt16(timeMinute.Substring(0, 1));
            var minuteOnes = Convert.ToUInt16(timeMinute.Substring(1, 1));
            var secondTens = Convert.ToUInt16(timeSecond.Substring(0, 1));
            var secondOnes = Convert.ToUInt16(timeSecond.Substring(1, 1));

            HourTens2 = (hourTens & 2) != 0 ? true : false;
            HourTens1 = (hourTens & 1) != 0 ? true : false;

            HourOnes8 = (hourOnes & 8) != 0 ? true : false;
            HourOnes4 = (hourOnes & 4) != 0 ? true : false;
            HourOnes2 = (hourOnes & 2) != 0 ? true : false;
            HourOnes1 = (hourOnes & 1) != 0 ? true : false;

            MinuteTens4 = (minuteTens & 4) != 0 ? true : false;
            MinuteTens2 = (minuteTens & 2) != 0 ? true : false;
            MinuteTens1 = (minuteTens & 1) != 0 ? true : false;

            MinuteOnes8 = (minuteOnes & 8) != 0 ? true : false;
            MinuteOnes4 = (minuteOnes & 4) != 0 ? true : false;
            MinuteOnes2 = (minuteOnes & 2) != 0 ? true : false;
            MinuteOnes1 = (minuteOnes & 1) != 0 ? true : false;

            SecondTens4 = (secondTens & 4) != 0 ? true : false;
            SecondTens2 = (secondTens & 2) != 0 ? true : false;
            SecondTens1 = (secondTens & 1) != 0 ? true : false;

            SecondOnes8 = (secondOnes & 8) != 0 ? true : false;
            SecondOnes4 = (secondOnes & 4) != 0 ? true : false;
            SecondOnes2 = (secondOnes & 2) != 0 ? true : false;
            SecondOnes1 = (secondOnes & 1) != 0 ? true : false;
        }

        public readonly bool HourTens2;
        public readonly bool HourTens1;

        public readonly bool HourOnes8;
        public readonly bool HourOnes4;
        public readonly bool HourOnes2;
        public readonly bool HourOnes1;

        public readonly bool MinuteTens4;
        public readonly bool MinuteTens2;
        public readonly bool MinuteTens1;

        public readonly bool MinuteOnes8;
        public readonly bool MinuteOnes4;
        public readonly bool MinuteOnes2;
        public readonly bool MinuteOnes1;

        public readonly bool SecondTens4;
        public readonly bool SecondTens2;
        public readonly bool SecondTens1;

        public readonly bool SecondOnes8;
        public readonly bool SecondOnes4;
        public readonly bool SecondOnes2;
        public readonly bool SecondOnes1;
    }
}
