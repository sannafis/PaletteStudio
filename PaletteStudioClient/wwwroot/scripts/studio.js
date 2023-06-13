function getButtonCoords(id) {
    buttonClicked = document.getElementById(id);

    var left = 0.0;
    var top = 0.0;

    if (buttonClicked.offsetParent) {
        do {
            left += buttonClicked.offsetLeft;
            top += buttonClicked.offsetTop;
        } while (buttonClicked = buttonClicked.offsetParent);

        return { X: left, Y: top };
    }
}