function setupEvents() {

    $('input').keyup(function (e) {

        if (e.keyCode === 13)  // the enter key code
        {
           
           $('input').blur();
        }
    });
}


function initColourPicker() {

    var canvas = document.getElementById('colourCanvas');



  
    if (canvas != null) {

        gradient = canvas.getContext('2d').createLinearGradient(0, 0, 0, canvas.height);
        gradient.addColorStop(0, '#ffffff');
        gradient.addColorStop(0.5, '#ffffff');
        gradient.addColorStop(1, '#ffffff');
        canvas.getContext('2d').fillStyle = gradient;
        canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);

        gradientWhite = canvas.getContext('2d').createLinearGradient(0, 0, canvas.width, 0);
        gradientWhite.addColorStop(0, 'rgba(255, 255, 255, 0)');
        gradientWhite.addColorStop(1, 'rgba(255, 255, 255, 1)');
        canvas.getContext('2d').fillStyle = gradientWhite;
        canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);

        let hue = document.getElementById('saturationSlider').value;

        gradientColour = canvas.getContext('2d').createLinearGradient(0, 0, canvas.width, 0);
        gradientColour.addColorStop(0, 'rgba(255, 255, 255, 0)');
        gradientColour.addColorStop(1, `hsl(${hue}, 100%, 50%)`);
        canvas.getContext('2d').fillStyle = gradientColour;
        canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);

        let gradientBlack = canvas.getContext('2d').createLinearGradient(0, 0, canvas.width, 0);
        gradientBlack = canvas.getContext('2d').createLinearGradient(0, 0, 0, canvas.height);
        gradientBlack.addColorStop(0, 'rgba(0, 0, 0, 0)');
        gradientBlack.addColorStop(1, '#000000');
        canvas.getContext('2d').fillStyle = gradientBlack;
        canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);
    }


    var selector = document.getElementById('selector');

    if (selector != null) {
        var selectorX = selector.getAttribute("cx").replace("%", "") / 100;
        var selectorY = selector.getAttribute("cy").replace("%", "") / 100;

        //alert(selectorX + " " + selectorY);

        //selectorX = (hue / 100) * 0.27777777777;
        //selectorY = value / 100;
    }


    /*if()*/


    return changeColour(selectorX, selectorY);

}

function changeColour(x, y) {
    console.log();

    var canvas = document.getElementById('colourCanvas');
    var canvasContext = canvas.getContext('2d');

    // set new selected colour coords from canvas
    var newX = x * canvas.width;
    var newY = y * canvas.height;
    console.log("Canvas Coords: x: " + newX + " y: " + newY);

    let hue = document.getElementById('saturationSlider').value / 360;
    let saturation = x;
    let value = 1 - y;

    let hsv = HSLtoHSV(hue, saturation, value)

    console.log(hue + " " + saturation + " " + value)

    let rgb = HSVtoRGB(hue,saturation,value)

    return rgb;

    // get colour
    var imgData = canvasContext.getImageData(newX, newY, 1, 1);
    var rgba = imgData.data;
    var rgbString = "rgb(" + rgba[0] + ", " + rgba[1] + ", " + rgba[2] + ",1" + ")";
    var rgbArray = [rgba[0], rgba[1], rgba[2]];
    console.log("%c" + rgbString, "colour:" + rgbString);


    return rgbArray;
}

function HSVtoRGB(h, s, v) {
    var r, g, b, i, f, p, q, t;
    if (arguments.length === 1) {
        s = h.s, v = h.v, h = h.h;
    }
    i = Math.floor(h * 6);
    f = h * 6 - i;
    p = v * (1 - s);
    q = v * (1 - f * s);
    t = v * (1 - (1 - f) * s);
    switch (i % 6) {
        case 0: r = v, g = t, b = p; break;
        case 1: r = q, g = v, b = p; break;
        case 2: r = p, g = v, b = t; break;
        case 3: r = p, g = q, b = v; break;
        case 4: r = t, g = p, b = v; break;
        case 5: r = v, g = p, b = q; break;
    }
    return [
        Math.round(r * 255),
        Math.round(g * 255),
        Math.round(b * 255)
    ];
}


function HSLtoHSV(h, s, l) {
    if (arguments.length === 1) {
        s = h.s, l = h.l, h = h.h;
    }
    var _h = h,
        _s,
        _v;

    l *= 2;
    s *= (l <= 1) ? l : 2 - l;
    _v = (l + s) / 2;
    _s = (2 * s) / (l + s);

    return [
        _h,
        _s,
        _v
    ];
}


function moveSelector(e) {
    var canvas = document.getElementById('colourCanvas');
    var selector = document.getElementById('selector');
    var newSelectorX = (e.offsetX / canvas.clientWidth) * 100;
    var newSelectorY = (e.offsetY / canvas.clientHeight) * 100;
    selector.setAttribute("cx", newSelectorX + "%");
    selector.setAttribute("cy", newSelectorY + "%");
    console.log("Selector: cx: " + newSelectorX + "%" + " cy: " + newSelectorY + "%");

    var selectorX = selector.getAttribute("cx").replace("%", "") / 100;
    var selectorY = selector.getAttribute("cy").replace("%", "") / 100;



    var rgb = changeColour(selectorX, selectorY);

    console.log(rgb[0],rgb[1],rgb[2],)

    return rgb;

}
function setValue(element, value) {
    alert("OK");
    try {
        element.value = value;
        initColourPicker();
       alert("DID IT");
    } catch  {
       alert("WROMG");
    ////    alert(error.value);
       
    }
    
}