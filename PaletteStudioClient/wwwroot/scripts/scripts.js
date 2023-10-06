window.getWindowDimensions = function () {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

MyDOMGetBoundingClientRect = (element, parm) =>
{
    return element.getBoundingClientRect();
};