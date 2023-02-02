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

    altText = "";
    var i = imageCount;

    // Make *first* Picture "active" or Carousel won't start"'"
    var text = "<div class='carousel-item w-100 active'><img src='" + imageLocation.concat("000000".concat(i).slice(-6)) + ".jpg' alt='" + altText.concat("000000".concat(imageCount).slice(-6)) + "' /></img></div>";
    i = i - 1;

    // Make the rest of the list
    while (i > 0) {

        text = text + "<div class='carousel-item w-100'><img src='" + imageLocation.concat("000000".concat(i).slice(-6)) + ".jpg' alt='" + altText.concat("000000".concat(imageCount).slice(-6)) + "' /></img></div>";
        i = i - 1;

    }

    // insert the list into the "CarouselItems" element
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

    if (eventType == 1) {
        var eventYear = new Date().getFullYear();
        eventDate = calcStartDate(eventYear, eventName);
        if (new Date() > eventDate) {
            eventDate = calcStartDate(eventYear + 1, eventName);
        };
    };

    updateCountdownDisplay(eventDate, eventType);
}
function updateCountdownDisplay(eventDate, eventType) {

    try {
        if (new Date().getTime() > eventDate.getTime()) throw "exit";
    } catch (e) {
        countdown(eventName, eventType, eventDate);
    }

    // Check if this is the Event Date.
    if (eventDate.getMonth() === new Date().getMonth() && eventDate.getDate() === new Date().getDate()) {
        // *** Today is the Event Day! ***//

        // Update eventDate Display
        document.getElementById("eventdate").innerHTML = new Date().toString().substring(0, 16);

        // Update Countdown Display
        document.getElementById("days").innerHTML = "<br />";
        document.getElementById("lbldays").innerHTML = "Today!";
        document.getElementById("hours").innerHTML = "<br />";
        document.getElementById("lblhours").innerHTML = "<br />";
        document.getElementById("minutes").innerHTML = "";
        document.getElementById("lblminutes").innerHTML = "";
        document.getElementById("seconds").innerHTML = "";
        document.getElementById("lblseconds").innerHTML = "";

    } else {

        // Update eventDate and timezone display. Seasons needs date and time formatting (eventType === 0).
        var timezonestring = Intl.DateTimeFormat().resolvedOptions().timeZone + " " + new Date().toTimeString().slice(9);
        document.getElementById("timezone").innerHTML = timezonestring;
        document.getElementById("eventdate").innerHTML = eventType == 0 ? eventDate.toString().substring(0, 16) : eventDate.toLocaleString();

        const second = 1000,
            minute = second * 60,
            hour = minute * 60,
            day = hour * 24;

        let datediff = eventDate - new Date().getTime();

        var s, m, h, d;
        s = Math.floor((datediff % (minute)) / second);
        m = Math.floor((datediff % (hour)) / (minute));
        h = Math.floor((datediff % (day)) / (hour));
        d = Math.floor(datediff / (day));

        document.getElementById("days").innerHTML = d > 1 ? d : d > 0 ? d : "<br />";
        document.getElementById("lbldays").innerHTML = d > 1 ? "Days" : d > 0 ? "Day" : "in";
        document.getElementById("hours").innerHTML = h > 1 ? h : h > 0 ? h : "";
        document.getElementById("lblhours").innerHTML = h > 1 ? "hours," : h > 0 ? "hour," : "";
        document.getElementById("minutes").innerHTML = m > 1 ? m : m > 0 ? m : "";
        document.getElementById("lblminutes").innerHTML = m > 1 ? "minutes, and" : m > 0 ? "minute, and" : "";
        document.getElementById("seconds").innerHTML = s > 1 ? s : s > 0 ? s : "0";
        document.getElementById("lblseconds").innerHTML = s > 1 ? "seconds" : s > 0 ? "second" : "seconds";
    };
}
function calcStartDate(eventYear, eventName) {

    var y = (eventYear - 2000) / 1000;
    var y2 = y * y;
    var y3 = y2 * y;
    var y4 = y3 * y;
    var jde;

    switch (eventName.toLowerCase()) {
        case "spring":
            jde = 2451623.80984 + 365242.37404 * y + 0.05169 * y2 - 0.00411 * y3 - 0.00057 * y4;
            break;
        case "summer":
            jde = 2451716.56767 + 365241.62603 * y + 0.00325 * y2 + 0.00888 * y3 - 0.0003 * y4;
            break;
        case "autumn":
            jde = 2451810.21715 + 365242.01767 * y - 0.11575 * y2 + 0.00337 * y3 + 0.00078 * y4;
            break;
        case "winter":
            jde = 2451900.05952 + 365242.74049 * y - 0.06223 * y2 - 0.00823 * y3 + 0.00032 * y4;
    }

    const a = [
        485, 203, 199, 182, 156, 136, 77, 74, 70, 58,
        52, 50, 45, 44, 29, 18, 17, 16, 14, 12, 12, 12,
        9, 8
    ];
    const b = [
        324.96, 337.23, 342.08, 27.85, 73.14, 171.52,
        222.54, 296.72, 243.58, 119.81, 297.17, 21.02,
        247.54, 325.15, 60.93, 155.12, 288.79, 198.04,
        199.76, 95.39, 287.11, 320.81, 227.73, 15.45
    ];
    const c = [
        1934.136, 32964.467, 20.186, 445267.112, 45036.886,
        22518.443, 65928.934, 3034.906, 9037.513, 33718.147,
        150.678, 2281.226, 29929.562, 31555.956, 4443.417,
        67555.328, 4562.452, 62894.029, 31436.921, 14577.848,
        31931.756, 34777.259, 1222.114, 16859.074
    ];

    var t = (jde - 2451545.0) / 36525;
    var s = 0;
    var i = 0;
    while (i < 24) {
        s += a[i] * Math.cos((b[i] * Math.PI) / 180 + ((c[i] * Math.PI) / 180) * t);
        i += 1;
    };

    var w = 35999.373 * t - 2.47;
    var sw = 1 + 0.0334 * Math.cos((w * Math.PI) / 180) + 0.0007 * Math.cos(2 * ((w * Math.PI) / 180));
    var eventJde = jde - 2415019 + 0.5 + (0.00001 * s) / sw;

    var eventUtcDate = dateFromOADate(eventJde);
    var eventDate = localFromUTCDate(eventUtcDate);

    return eventDate;
}
function dateFromOADate(oaDate) {

    var days = parseInt(oaDate);
    var ms = Math.abs((oaDate - days) * 8.64e7);
    var newDate = new Date(1899, 11, 30 + days, 0, 0, 0, ms);

    return newDate;
}
function localFromUTCDate(eventDate) {

    var newDate = new Date(
        eventDate.getTime() + eventDate.getTimezoneOffset() * 60 * 1000
    );
    var hours = eventDate.getHours();
    var offsetTZ = eventDate.getTimezoneOffset() / 60;
    var offsetDST = getoffsetDST();

    newDate.setHours(hours - offsetTZ + offsetDST);

    return newDate;
}
function getTZoffset() {

    var jan = new Date(this.getFullYear(), 0, 1);
    var jul = new Date(this.getFullYear(), 6, 1);

    return Math.max(jan.getTimezoneOffset(), jul.getTimezoneOffset());
}
function getoffsetDST() {

    var jan = new Date(new Date().getFullYear(), 0, 1);
    var jul = new Date(new Date().getFullYear(), 6, 1);
    var offsetDST = jan.getTimezoneOffset() < jul.getTimezoneOffset();

    return offsetDST;
}
