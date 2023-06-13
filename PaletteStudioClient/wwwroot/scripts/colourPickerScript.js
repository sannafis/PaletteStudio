function initColourPicker() {
    var canvas = document.getElementById('colourCanvas');


    let gradient = canvas.getContext('2d').createLinearGradient(0, 0, canvas.width, 0);
    gradient.addColorStop(0, '#ff0000');
    gradient.addColorStop(1 / 6, '#ffff00');
    gradient.addColorStop((1 / 6) * 2, '#00ff00');
    gradient.addColorStop((1 / 6) * 3, '#00ffff');
    gradient.addColorStop((1 / 6) * 4, '#0000ff');
    gradient.addColorStop((1 / 6) * 5, '#ff00ff');
    gradient.addColorStop(1, '#ff0000');
    canvas.getContext('2d').fillStyle = gradient;
    canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);

    gradient = canvas.getContext('2d').createLinearGradient(0, 0, 0, canvas.height);
    gradient.addColorStop(0, '#ffffff');
    gradient.addColorStop(0.5, 'rgba(255, 255, 255, 0)');
    gradient.addColorStop(1, 'rgba(255, 255, 255, 0)');
    canvas.getContext('2d').fillStyle = gradient;
    canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);

    gradient = canvas.getContext('2d').createLinearGradient(0, 0, 0, canvas.height);
    gradient.addColorStop(0, 'rgba(0, 0, 0, 0)');
    gradient.addColorStop(0.5, 'rgba(0, 0, 0, 0)');
    gradient.addColorStop(1, '#000000');
    canvas.getContext('2d').fillStyle = gradient;
    canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);

    var saturationSlider = document.getElementById('saturationSlider').value;
    if (saturationSlider != null) {
        gradient = canvas.getContext('2d').createLinearGradient(0, 0, 0, canvas.height);
        gradient.addColorStop(0, `rgba(128, 128, 128, ${saturationSlider / 100})`);
        gradient.addColorStop(1, `rgba(128, 128, 128, ${saturationSlider / 100})`);
        canvas.getContext('2d').fillStyle = gradient;
        canvas.getContext('2d').fillRect(0, 0, canvas.width, canvas.height);
    }

    var selector = document.getElementById('selector');
    var selectorX = selector.getAttribute("cx").replace("%", "") /100;
    var selectorY = selector.getAttribute("cy").replace("%", "")/100;


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

    // get colour
    var imgData = canvasContext.getImageData(newX, newY, 1, 1);
    var rgba = imgData.data;
    var rgbString = "rgb(" + rgba[0] + ", " + rgba[1] + ", " + rgba[2] + ",1" + ")";
    var rgbArray = [rgba[0], rgba[1], rgba[2]];
    console.log("%c" + rgbString, "colour:" + rgbString);


    return rgbArray;
}


function moveSelector(e) {
    var canvas = document.getElementById('colourCanvas');
    var selector = document.getElementById('selector');
    var newSelectorX = (e.offsetX / canvas.clientWidth) * 100;
    var newSelectorY = (e.offsetY / canvas.clientHeight) * 100;
    selector.setAttribute("cx", newSelectorX + "%");
    selector.setAttribute("cy", newSelectorY + "%");
    console.log("Selector: cx: " + newSelectorX + "%" + " cy: " + newSelectorY + "%");

    var rgb = changeColour(newSelectorX / 100, newSelectorY / 100);
    return rgb;

}