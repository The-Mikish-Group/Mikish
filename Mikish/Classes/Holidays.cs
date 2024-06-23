using System;
using System.Globalization;

namespace Mikish.Classes
{
    public static class Holidays
    {
        public static string GetEventUtcDateString(string eventName, int eventYear)
        {
            string eventDateString;

            switch (eventName)
            {
                case "NewYears":
                    eventDateString = CalculateFixedDate(eventYear, 1, 1);
                    break;
                case "Valentines":
                    eventDateString = CalculateFixedDate(eventYear, 2, 14);
                    break;
                case "Independence":
                    eventDateString = CalculateFixedDate(eventYear, 7, 4);
                    break;
                case "Veterans":
                    eventDateString = CalculateFixedDate(eventYear, 11, 11);
                    break;
                case "Halloween":
                    eventDateString = CalculateFixedDate(eventYear, 10, 31);
                    break;
                case "Christmas":
                    eventDateString = CalculateFixedDate(eventYear, 12, 25);
                    break;
                case "Lincoln":
                    eventDateString = CalculateFixedDate(eventYear, 2, 12);
                    break;
                case "Washington":
                    eventDateString = CalculateFixedDate(eventYear, 2, 22);
                    break;
                case "Jefferson":
                    eventDateString = CalculateFixedDate(eventYear, 4, 13);
                    break;
                case "Army":
                    eventDateString = CalculateFixedDate(eventYear, 6, 14);
                    break;
                case "AirForce":
                    eventDateString = CalculateFixedDate(eventYear, 9, 18);
                    break;
                case "Navy":
                    eventDateString = CalculateFixedDate(eventYear, 10, 13);
                    break;
                case "MarineCorp":
                    eventDateString = CalculateFixedDate(eventYear, 11, 10);
                    break;
                case "NationalGuard":
                    eventDateString = CalculateFixedDate(eventYear, 12, 13);
                    break;
                case "Mothers":
                    eventDateString = CalculateNthWeekdayOfMonth(eventYear, 5, 2, DayOfWeek.Sunday);
                    break;
                case "Fathers":
                    eventDateString = CalculateNthWeekdayOfMonth(eventYear, 6, 3, DayOfWeek.Sunday);
                    break;
                case "Memorial":
                    eventDateString = CalculateLastWeekdayOfMonth(eventYear, 5, DayOfWeek.Monday);
                    break;
                case "Labor":
                    eventDateString = CalculateNthWeekdayOfMonth(eventYear, 9, 1, DayOfWeek.Monday);
                    break;
                case "Thanksgiving":
                    eventDateString = CalculateNthWeekdayOfMonth(eventYear, 11, 4, DayOfWeek.Thursday);
                    break;
                case "MartinLutherKing":
                    eventDateString = CalculateNthWeekdayOfMonth(eventYear, 1, 3, DayOfWeek.Monday);
                    break;
                case "Presidents":
                    eventDateString = CalculateNthWeekdayOfMonth(eventYear, 2, 3, DayOfWeek.Monday);
                    break;
                case "Easter":
                    eventDateString = CalculateEasterDateString(eventYear);
                    break;

                // Default... okay to break through to Seasons in JS
                default:
                    eventDateString = $"{eventYear}-03-31";
                    break;
            }

            DateTime eventDate = DateTime.Parse(eventDateString).ToUniversalTime();
            if (eventDate < DateTime.UtcNow)
            {
                eventDate = eventDate.AddYears(1);
            }

            return eventDate.ToString("yyyy-MM-dd");
        }

        private static string CalculateFixedDate(int year, int month, int day)
        {
            return new DateTime(year, month, day).ToString("yyyy-MM-dd");
        }

        private static string CalculateNthWeekdayOfMonth(int year, int month, int n, DayOfWeek dayOfWeek)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            int targetDayOfWeek = (int)dayOfWeek;

            int daysToAdd = (targetDayOfWeek - firstDayOfWeek + 7) % 7;
            daysToAdd += 7 * (n - 1);

            DateTime nthDayOfWeek = firstDayOfMonth.AddDays(daysToAdd - 1);
            return nthDayOfWeek.ToString("yyyy-MM-dd");
        }

        private static string CalculateLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            int lastDayOfWeek = (int)lastDayOfMonth.DayOfWeek;
            int targetDayOfWeek = (int)dayOfWeek;

            int daysToSubtract = (lastDayOfWeek - targetDayOfWeek + 7) % 7;
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

