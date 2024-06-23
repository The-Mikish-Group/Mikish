//***********************************************//
//  Function used to open Web Page in new Tab    //
//***********************************************//
function newTab(tabURL) {
    var newWindowTab = window.open(tabURL);
}

//***********************************************//
//  Create Image List of Carousel Items          //
//***********************************************//
function createImageList(imageLocation, altText, imageCount) {
    var text = "";
    for (var i = imageCount; i > 0; i--) {
        text += `<div class='carousel-item w-100 ${i === imageCount ? "active" : ""}'>
      <img src='${imageLocation}${("000000" + i).slice(-6)}.jpg' alt='${altText}${("000000" + imageCount).slice(-6)}' />
    </div>`;
    }
    document.getElementById("CarouselItems").innerHTML = text;
}

//***********************************************//
//  Change background                            //
//***********************************************//
function changeBackground(newBackground) {
    $('body').css('background-image', newBackground);
}

//***********************************************//
//  Functions used to calculate countdown        //
//  currently Seasons Only                       //
//***********************************************//
function eventCountdown(eventName, eventType, eventDate) {

    countdown(eventName, eventType, eventDate);
    setInterval(function () {
        countdown(eventName, eventType, eventDate);
    }, 1000);
}

function countdown(eventName, eventType, eventDate) {

    // Overrides Holidays Class and calculates Seasons if Type 1
    if (eventType == 1) {
        var eventYear = new Date().getFullYear();
        eventDate = calcSeasonStartDate(eventYear, eventName);
        if (new Date() > eventDate) {
            eventDate = calcSeasonStartDate(eventYear + 1, eventName);
        };
    };

    updateCountdownDisplay(eventDate, eventType);
}

function updateCountdownDisplay(eventDate, eventType) {
    if (new Date().getTime() > eventDate.getTime()) {
        countdown (eventName, eventType, eventDate);
        return;
    }

    const isEventToday = eventDate.getMonth() === new Date().getMonth() && eventDate.getDate() === new Date().getDate();

    if (isEventToday) {
        /*document.getElementById("eventdate").innerHTML = new Date().toString().substring(0, 16);*/
        document.getElementById("days").innerHTML = "<br />";
        document.getElementById("lbldays").innerHTML = "Today!";
        document.getElementById("hours").innerHTML = "<br />";
        document.getElementById("lblhours").innerHTML = "<br />";
        document.getElementById("minutes").innerHTML = "";
        document.getElementById("lblminutes").innerHTML = "";
        document.getElementById("seconds").innerHTML = "";
        document.getElementById("lblseconds").innerHTML = "";
    } else {

        const SECOND = 1000,
            MINUTE = SECOND * 60,
            HOUR = MINUTE * 60,
            DAY = HOUR * 24;

        const now = new Date().getTime();
        let datediff = eventDate - now;

        const s = Math.floor((datediff % MINUTE) / SECOND);
        const m = Math.floor((datediff % HOUR) / MINUTE);
        const h = Math.floor((datediff % DAY) / HOUR);
        const d = Math.floor(datediff / DAY);

        const timezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
        const timeString = new Date().toTimeString().slice(9);
        document.getElementById("timezone").innerHTML = `${timezone} ${timeString}`;
        document.getElementById("eventdate").innerHTML = eventType == 0
            ? eventDate.toString().substring(0, 16)
            : eventDate.toLocaleString();

        document.getElementById("days").innerHTML = d > 0 ? d : "<br />";
        document.getElementById("lbldays").innerHTML = d > 1 ? "Days" : d > 0 ? "Day" : "in";
        document.getElementById("hours").innerHTML = h > 0 ? h : "";
        document.getElementById("lblhours").innerHTML = h > 1 ? "hours," : h > 0 ? "hour," : "";
        document.getElementById("minutes").innerHTML = m > 0 ? m : "";
        document.getElementById("lblminutes").innerHTML = m > 1 ? "minutes, and" : m > 0 ? "minute, and" : "";
        document.getElementById("seconds").innerHTML = s > 0 ? s : "0";
        document.getElementById("lblseconds").innerHTML = s > 1 ? "seconds" : "second";
                
    }
}

//This function calculates the date of a particular astronomical event (spring, summer, autumn, or winter) given a year.
//The calculation is based on the Julian date(JDE), which is then converted to the Universal Time Coordinated(UTC) date and
//finally to the local date.The calculation uses the elliptic motion of the earth and the axial tilt to determine the event date.

function calcSeasonStartDate(eventYear, eventName) {
    var y = (eventYear - 2000) / 1000;
    var y2 = y * y;
    var y3 = y2 * y;
    var y4 = y3 * y;
    var jde;

    // Julian Date calculation for each season
    switch (eventName) {
        case "Spring":
            jde = 2451623.80984 + 365242.37404 * y + 0.05169 * y2 - 0.00411 * y3 - 0.00057 * y4;
            break;
        case "Summer":
            jde = 2451716.56767 + 365241.62603 * y + 0.00325 * y2 + 0.00888 * y3 - 0.0003 * y4;
            break;
        case "Autumn":
            jde = 2451810.21715 + 365242.01767 * y - 0.11575 * y2 + 0.00337 * y3 + 0.00078 * y4;
            break;
        case "Winter":
            jde = 2451900.05952 + 365242.74049 * y - 0.06223 * y2 - 0.00823 * y3 + 0.00032 * y4;
            break;
        default:
            throw new Error("Invalid event name");
            // We get here when we have exhausted Hollidays.cs entries and Season entries. They should all be covered before now.
    }

    // Periodic terms
    const a = [485, 203, 199, 182, 156, 136, 77, 74, 70, 58, 52, 50, 45, 44, 29, 18, 17, 16, 14, 12, 12, 12, 9, 8];
    const b = [324.96, 337.23, 342.08, 27.85, 73.14, 171.52, 222.54, 296.72, 243.58, 119.81, 297.17, 21.02, 247.54, 325.15, 60.93, 155.12, 288.79, 198.04, 199.76, 95.39, 287.11, 320.81, 227.73, 15.45];
    const c = [1934.136, 32964.467, 20.186, 445267.112, 45036.886, 22518.443, 65928.934, 3034.906, 9037.513, 33718.147, 150.678, 2281.226, 29929.562, 31555.956, 4443.417, 67555.328, 4562.452, 62894.029, 31436.921, 14577.848, 31931.756, 34777.259, 1222.114, 16859.074];

    var t = (jde - 2451545.0) / 36525;
    var s = 0;
    for (var i = 0; i < a.length; i++) {
        s += a[i] * Math.cos((b[i] * Math.PI) / 180 + ((c[i] * Math.PI) / 180) * t);
    }

    // Solar anomaly and sun's apparent longitude corrections
    var w = 35999.373 * t - 2.47;
    var sw = 1 + 0.0334 * Math.cos((w * Math.PI) / 180) + 0.0007 * Math.cos(2 * ((w * Math.PI) / 180));
    var eventJde = jde + (0.00001 * s) / sw;

    // Convert Julian Date to Gregorian Date
    var eventUtcDate = dateFromJulian(eventJde);
    return localFromUTCDate(eventUtcDate);
}

function dateFromJulian(jd) {
    var jdToUnix = (jd - 2440587.5) * 86400000; // Convert Julian Date to Unix timestamp
    var date = new Date(jdToUnix); // Create date object
    return date;
}

function localFromUTCDate(eventDate) {
    var offsetTZ = eventDate.getTimezoneOffset() * 60000; // Timezone offset in milliseconds
    var localTime = eventDate.getTime() - offsetTZ; // Convert to local time
    return new Date(localTime);
}
