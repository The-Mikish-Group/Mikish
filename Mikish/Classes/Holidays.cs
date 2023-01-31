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
            string midnight = "T00:00:00";
            object temp = DateTime.Now;

            // Seasons and Easter - (Date-time is Calculated)

            // Holidays - (Date is Fixed)
            switch (eventName)
            {
                case "NewYears":
                    {
                        return eventYear + "-01-01" + midnight;
                    }

                case "Valentines":
                    {
                        return eventYear + "-02-14" + midnight;
                    }
                case "Independence":
                    {
                        return eventYear + "-07-04" + midnight;
                    }
                case "Veterans":
                    {
                        return eventYear + "-11-11" + midnight;
                    }
                case "Halloween":
                    {
                        return eventYear + "-10-31" + midnight;
                    }
                case "Christmas":
                    {
                        return eventYear + "-12-25" + midnight;
                    }
                case "Lincoln":
                    {
                        return eventYear + "-02-12" + midnight;
                    }

                case "Washington":
                    {
                        return eventYear + "-02-22" + midnight;
                    }
                case "Jefferson":
                    {
                        return eventYear + "-04-13" + midnight;
                    }
                case "Army":
                    {
                        return eventYear + "-06-14" + midnight;
                    }
                case "AirForce":
                    {
                        return eventYear + "-09-18" + midnight;
                    }
                case "Navy":
                    {
                        return eventYear + "-10-13" + midnight;
                    }
                case "MarineCorp":
                    {
                        return eventYear + "-11-10" + midnight;
                    }
                case "NationalGuard":
                    {
                        return eventYear + "-12-13" + midnight;
                    }                
                
                // Non-Fixed Dates (calculated)
                case "Mothers":
                    {
                        return CalculateDateString(5, 2, 1);
                    }
                case "Fathers":
                    {
                        return CalculateDateString(6, 3, 1);
                    }
                case "Memorial":
                    {
                        //Memorial Day is usually the 4 Monday of the Month,
                        //but sometimes it is the 5th Monday. The Replace() catches
                        //those times and returns the correct date.
                        return CalculateDateString(5, 4, 2).Replace("05-24", "05-31");
                    }
                case "Labor":
                    {
                        return CalculateDateString(9, 1, 2);
                    }
                case "Thanksgiving":
                    {
                        return CalculateDateString(11, 4, 5);
                    }
                case "MartinLutherKing":
                    {
                        return CalculateDateString(1, 3, 2);
                    }
                case "Presidents":
                    {
                        return CalculateDateString(2, 3, 2);
                    }
                case "Easter":
                    {
                        return CalculateEasterDateString(eventYear);
                    }

            }

            // Return a default Date if target Date not found (Shouldn't happen)        
            return eventYear + "-03-31" + midnight;

        }

        public static string CalculateDateString(int eventMonth, int eventWeek, int eventDay)
        {
            // Build Date String  (based on Month, Week, and Day of Event with 1 = Sunday)
            // Handy for events falling on days like the second Tuesday of a Month.
            //
            // Input:
            //   eventMonth = Month of the Event
            //   eventWeek = Week number of Event (ie. Event is in the third week of the month.)
            //   evenDay = Day of Event. Sunday = 1, Monday = 2,...
            //
            // Output:
            //   EventDate String
                    
            int eventYear = DateTime.UtcNow.Year;

            string wkdayInput = eventYear.ToString() + "/" + eventMonth.ToString() + "/" + (8 - eventDay).ToString();
            int wkday = ((int)DateTime.Parse(wkdayInput, CultureInfo.InvariantCulture).DayOfWeek);

            string eventYearInput = eventYear.ToString() + "/" + eventMonth.ToString() + "/" + (1 + (7 * eventWeek) - wkday).ToString();
            DateTime eventDate = DateTime.Parse(eventYearInput, CultureInfo.InvariantCulture).ToUniversalTime();

            // Catch to see if we are beyond the event date for this year.
            // If so, then add a year and countdown to next year's event.

            //int UtcMonth = DateTime.UtcNow.Month;
            //int UtcDay = DateTime.UtcNow.Day;

            if (DateTime.UtcNow.Month > eventMonth)
            {
                eventYear = DateTime.UtcNow.Year + 1;
            }
            else
            {    
                if (DateTime.UtcNow.Month == eventMonth)
                {
                    if (DateTime.UtcNow.Day > eventDay)
                    {
                        eventYear = DateTime.UtcNow.Year + 1;
                    }
                }
            }

            wkdayInput = eventYear.ToString() + "/" + eventMonth.ToString() + "/" + (8 - eventDay).ToString();
            wkday = ((int)DateTime.Parse(wkdayInput, CultureInfo.InvariantCulture).DayOfWeek);

            eventYearInput = eventYear.ToString() + "/" + eventMonth.ToString() + "/" + (1 + (7 * eventWeek) - wkday).ToString();
            eventDate = DateTime.Parse(eventYearInput, CultureInfo.InvariantCulture).ToUniversalTime();

            string eventDateYear = eventDate.Year.ToString();


            string eventDateDay = eventDate.Day.ToString();
            if (eventDateDay.Length < 2)
            {
                eventDateDay = eventDateDay.PadLeft(eventDateDay.Length + 1, '0');
            }           

            string eventDateMonth = eventDate.Month.ToString();
            if (eventDateMonth.Length < 2)             {
                eventDateMonth = eventDateMonth.PadLeft(eventDateMonth.Length + 1, '0');
            }
            
            string returnString = (eventDateYear + "-" + eventDateMonth + "-" + eventDateDay + "T00:00:00");
            return returnString;
        }

        public static string CalculateEasterDateString(int eventYear) {        
            
            int H = ((19 * (eventYear % 19)) + (eventYear / 100) - ((eventYear / 100) / 4) - (((8 * (eventYear / 100)) + 13) / 25) + 15) % 30;
            int M = ((eventYear % 19) + (11 * H)) / 319;
            int L = ((2 * ((eventYear / 100) % 4)) +(2 * ((eventYear % 100) / 4)) - ((eventYear % 100) % 4) - H + M + 32) % 7;

            return DateTime.Parse(eventYear.ToString() + "/" + ((H - M + L + 90) / 25).ToString() + "/" + ((H - M + L + ((H - M + L + 90) / 25) + 19) % 32).ToString(), CultureInfo.InvariantCulture).ToUniversalTime().ToString();

        }
        
    }
}
