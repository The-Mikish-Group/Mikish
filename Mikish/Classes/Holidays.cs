using Microsoft.AspNetCore.Mvc.Diagnostics;
using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mikish.Classes
{
    public static class Holidays
    {
        public static string GetEventUtcDateString(string eventName, int eventYear)
        {
            string monthAndDay = "";

            string eventDateString;
            switch (eventName)
            {
                case "NewYears":
                    monthAndDay = "-01-01";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                case "Valentines":
                    monthAndDay = "-02-14";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }                   
                    break;

                case "Independence":
                    monthAndDay = "-07-24";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                case "Veterans":
                    monthAndDay = "-11-11";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                case "Halloween":
                    monthAndDay = "-10-31";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;


                case "Christmas":
                    monthAndDay = "-12-25";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                case "Lincoln":
                    monthAndDay = "-02-12";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                case "Washington":
                    monthAndDay = "-02-22";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                case "Jefferson":
                    monthAndDay = "-04-13";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;
                case "Army":
                    monthAndDay = "-06-14";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;
                case "AirForce":
                    monthAndDay = "-09-18";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;
                case "Navy":
                    monthAndDay = "-10-13";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;
                case "MarineCorp":
                    monthAndDay = "-11-10";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;
                case "NationalGuard":
                    monthAndDay = "-12-13";
                    eventDateString = $"{eventYear}{monthAndDay}";
                    if (DateTime.Parse(eventDateString) < DateTime.UtcNow)
                    {
                        eventDateString = $"{eventYear + 1}{monthAndDay}";
                    }
                    break;

                // Calculated based on week and day of month
                case "Mothers":
                    eventDateString = CalculateDateString(5, 2, 0)[..10];
                    break;
                case "Fathers":
                    eventDateString = CalculateDateString(6, 3, 0)[..10];
                    break;
                case "Memorial":
                    eventDateString = CalculateDateString(5, 4, 1).Replace("05-24", "05-31")[..10];
                    break;
                case "Labor":
                    eventDateString = CalculateDateString(9, 1, 1)[..10];
                    break;
                case "Thanksgiving":
                    eventDateString = CalculateDateString(11, 4, 4)[..10];
                    break;
                case "MartinLutherKing":
                    eventDateString = CalculateDateString(1, 3, 1)[..10];
                    break;
                case "Presidents":
                    eventDateString = CalculateDateString(2, 3, 1)[..10];
                    break;

                // Easter is calculated 
                case "Easter":
                    eventDateString = CalculateEasterDateString(eventYear);
                    break;

                // Default... shouldn't hit this point unless a Season
                default:
                    eventDateString = $"{eventYear}-03-31";
                    break;
            }

            return eventDateString;
        }

        // Build Date String  (based on Month, Week, and Day of Event with 1 = Sunday)
        // Handy for events falling on days like the second Tuesday of a Month.
        //
        //   eventMonth = Month of the Event
        //   eventWeek = Week number of Event (ie. Event is in the third week of the month.)
        //   evenDay = Day of Event. Sunday = 0, Monday = 1,...
        public static string CalculateDateString(int eventMonth, int eventWeek, int eventDay)
        {
            // Determine the event year based on the current date
            int eventYear = DateTime.UtcNow.Month > eventMonth ||
                (DateTime.UtcNow.Month == eventMonth &&
                DateTime.UtcNow.Day > eventDay)
                ? DateTime.UtcNow.Year + 1
                : DateTime.UtcNow.Year;

            // Get the first day of the month
            DateTime firstDayOfMonth = new DateTime(eventYear, eventMonth, 1);

            // Calculate the target day of the week (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
            int targetDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // Calculate the number of days to add to reach the target day of the week
            int daysToAdd = (eventDay - targetDayOfWeek + 7) % 7;

            // Calculate the number of weeks to add
            int weeksToAdd = eventWeek - 1;

            // Calculate the event date by adding weeks and days to the first occurrence of the target day of the week
            DateTime eventDate = firstDayOfMonth.AddDays(daysToAdd + (7 * weeksToAdd)).ToUniversalTime();

            // Format the event date as a string
            string eventDateYear = eventDate.Year.ToString();
            string eventDateDay = eventDate.Day.ToString().PadLeft(2, '0');
            string eventDateMonth = eventDate.Month.ToString().PadLeft(2, '0');

            return $"{eventDateYear}-{eventDateMonth}-{eventDateDay}";
        }

        public static string CalculateEasterDateString(int eventYear)
        {
            int goldenNumber = eventYear % 19;
            int century = eventYear / 100;
            int h = (century - century / 4 - (8 * century + 13) / 25 + 19 * goldenNumber + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - goldenNumber) / 11));
            int j = (eventYear + eventYear / 4 + i + 2 - century + century / 4) % 7;
            int L = i - j;
            int month = 3 + (L + 40) / 44;
            int day = L + 28 - 31 * (month / 4);

            return new DateTime(eventYear, month, day, new GregorianCalendar()).ToUniversalTime().ToString("yyyy-MM-dd");
        }

    }
}
