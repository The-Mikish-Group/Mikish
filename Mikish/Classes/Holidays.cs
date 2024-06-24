
using System;

namespace Mikish.Classes
{
    public static class Holidays
    {
        public static string GetEventUtcDateString(string eventName, int eventYear)
        {
            string eventDateString = eventName switch
            {
                "NewYears" => CalculateFixedDate(eventYear, 1, 1),
                "Valentines" => CalculateFixedDate(eventYear, 2, 14),
                "Independence" => CalculateFixedDate(eventYear, 7, 4),
                "Veterans" => CalculateFixedDate(eventYear, 11, 11),
                "Halloween" => CalculateFixedDate(eventYear, 10, 31),
                "Christmas" => CalculateFixedDate(eventYear, 12, 25),
                "Lincoln" => CalculateFixedDate(eventYear, 2, 12),
                "Washington" => CalculateFixedDate(eventYear, 2, 22),
                "Jefferson" => CalculateFixedDate(eventYear, 4, 13),
                "Army" => CalculateFixedDate(eventYear, 6, 14),
                "AirForce" => CalculateFixedDate(eventYear, 9, 18),
                "Navy" => CalculateFixedDate(eventYear, 10, 13),
                "MarineCorp" => CalculateFixedDate(eventYear, 11, 10),
                "NationalGuard" => CalculateFixedDate(eventYear, 12, 13),
                "Mothers" => CalculateNthWeekdayOfMonth(eventYear, 5, 2, DayOfWeek.Sunday),
                "Fathers" => CalculateNthWeekdayOfMonth(eventYear, 6, 3, DayOfWeek.Sunday),
                "Memorial" => CalculateLastWeekdayOfMonth(eventYear, 5, DayOfWeek.Monday),
                "Labor" => CalculateNthWeekdayOfMonth(eventYear, 9, 1, DayOfWeek.Monday),
                "Thanksgiving" => CalculateNthWeekdayOfMonth(eventYear, 11, 4, DayOfWeek.Thursday),
                "MartinLutherKing" => CalculateNthWeekdayOfMonth(eventYear, 1, 3, DayOfWeek.Monday),
                "Presidents" => CalculateNthWeekdayOfMonth(eventYear, 2, 3, DayOfWeek.Monday),
                "Easter" => CalculateEasterDateString(eventYear),
                _ => $"{eventYear}-03-31"
            };

            DateTime eventDate = DateTime.Parse(eventDateString).ToUniversalTime();

            if (eventDate < DateTime.UtcNow)
            {
                eventDateString = GetEventUtcDateString(eventName, eventYear + 1);
            }

            return eventDateString; //eventDate.ToString("yyyy-MM-dd");
        }

        private static string CalculateFixedDate(int year, int month, int day) =>
            new DateTime(year, month, day).ToString("yyyy-MM-dd");

        private static string CalculateNthWeekdayOfMonth(int year, int month, int n, DayOfWeek dayOfWeek)
        {
            DateTime firstDayOfMonth = new(year, month, 1);
            int daysToAdd = ((int)dayOfWeek - (int)firstDayOfMonth.DayOfWeek + 7) % 7;
            DateTime firstOccurrence = firstDayOfMonth.AddDays(daysToAdd);
            DateTime nthOccurrence = firstOccurrence.AddDays((n - 1) * 7);

            return nthOccurrence.ToString("yyyy-MM-dd");
        }

        private static string CalculateLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            DateTime lastDayOfMonth = new(year, month, DateTime.DaysInMonth(year, month));
            int daysToSubtract = ((int)lastDayOfMonth.DayOfWeek - (int)dayOfWeek + 7) % 7;
            DateTime lastDayOfWeekInMonth = lastDayOfMonth.AddDays(-daysToSubtract);

            return lastDayOfWeekInMonth.ToString("yyyy-MM-dd");
        }

        public static string CalculateEasterDateString(int year)
        {
            int goldenNumber = year % 19;
            int century = year / 100;
            int h = (century - century / 4 - (8 * century + 13) / 25 + 19 * goldenNumber + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - goldenNumber) / 11));
            int j = (year + year / 4 + i + 2 - century + century / 4) % 7;
            int l = i - j;
            int month = 3 + (l + 40) / 44;
            int day = l + 28 - 31 * (month / 4);

            return new DateTime(year, month, day).ToString("yyyy-MM-dd");
        }
    }
}

