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
                    eventDateString = CalculateDateString(5, 2, 1)[..10];
                    break;
                case "Fathers":
                    eventDateString = CalculateDateString(6, 3, 1)[..10];
                    break;
                case "Memorial":
                    eventDateString = CalculateDateString(5, 4, 2).Replace("05-24", "05-31")[..10];
                    break;
                case "Labor":
                    eventDateString = CalculateDateString(9, 1, 2)[..10];
                    break;
                case "Thanksgiving":
                    eventDateString = CalculateDateString(11, 4, 5)[..10];
                    break;
                case "MartinLutherKing":
                    eventDateString = CalculateDateString(1, 3, 2)[..10];
                    break;
                case "Presidents":
                    eventDateString = CalculateDateString(2, 3, 2)[..10];
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
        //   evenDay = Day of Event. Sunday = 1, Monday = 2,...
        public static string CalculateDateString(int eventMonth, int eventWeek, int eventDay)
        {
            int eventYear = DateTime.UtcNow.Month > eventMonth ||
                (DateTime.UtcNow.Month == eventMonth &&
                DateTime.UtcNow.Day > eventDay)
                ? DateTime.UtcNow.Year + 1
                : DateTime.UtcNow.Year;
            
            DateTime eventDate = DateTime.Parse($"{eventYear}/{eventMonth}/{1 + (7 * eventWeek) - (int)DateTime.Parse($"{eventYear}/{eventMonth}/{8 - eventDay}", CultureInfo.InvariantCulture).DayOfWeek}", CultureInfo.InvariantCulture).ToUniversalTime();

            string eventDateYear = eventDate.Year.ToString();
            string eventDateDay = eventDate.Day.ToString().PadLeft(2, '0');
            string eventDateMonth = eventDate.Month.ToString().PadLeft(2, '0');

            return $"{eventDateYear}-{eventDateMonth}-{eventDateDay}";
        }

        // Calculate Easter Date String
        public static string CalculateEasterDateString(int eventYear)
        {
            int h = ((19 * (eventYear % 19)) + (eventYear / 100) - ((eventYear / 100) / 4) - (((8 * (eventYear / 100)) + 13) / 25) + 15) % 30;
            int m = ((eventYear % 19) + (11 * h)) / 319;
            int l = ((2 * ((eventYear / 100) % 4)) + (2 * ((eventYear % 100) / 4)) - ((eventYear % 100) % 4) - h + m + 32) % 7;

            int month = (h - m + l + 90) / 25;
            int day = (h - m + l + ((h - m + l + 90) / 25) + 19) % 32;

            return DateTime.Parse(eventYear + "/" + month + "/" + day, CultureInfo.InvariantCulture).ToUniversalTime().ToString();
        }        
        
    }
}
