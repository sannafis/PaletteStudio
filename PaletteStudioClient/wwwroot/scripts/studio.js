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

//function doTheThing() {
//    console.log("do the thing");

//    var inputs = document.querySelectorAll(".toggle-window");
//    var nodes = document.querySelectorAll(".dynamic-sizing");
//    var total = nodes.length;
//    var dirty = true;
//    var time = 0.9;
//    var omega = 12;
//    var zeta = 0.9;
//    var boxes = [];

//    for (var i = 0; i < total; i++) {

//        var node = nodes[i];
//        var width = node.offsetWidth;
//        var height = node.offsetHeight;
//        var color = "transparent";

//        // Need another element to animate width & height... use clone instead of editing HTML
//        var content = node.cloneNode(true);
//        content.classList.add("item-content");


//        gsap.set(node, { x: "+=0" });
//        gsap.set(content, { width, height });
//        gsap.set([node, node.children], { backgroundColor: color, color });

//        node.appendChild(content);

//        var transform = node._gsTransform;
//        var x = node.offsetLeft;
//        var y = node.offsetTop;

//        boxes[i] = { content, height, node, transform, width, x, y };
//    }

//    //for (var i = 0; i < inputs.length; i++) {
//    //    inputs[i].addEventListener("click", layout);                            //REPLACE
//    //}

//    window.addEventListener("resize", () => { dirty = true; });                             //REPLACE
//    console.log("added event listener");

//    //gsap.ticker.addEventListener("tick", () => dirty && layout());
//    gsap.ticker.add(layout, true, true)
//    console.log("added tick");

//    layout();
//    console.log("did the thing");
//}



//function layout() {
//    console.log("layout");

//    var inputs = document.querySelectorAll(".toggle-window");
//    var nodes = document.querySelectorAll(".dynamic-sizing");
//    var total = nodes.length;
//    var dirty = true;
//    var time = 0.9;
//    var omega = 12;
//    var zeta = 0.9;
//    var boxes = [];

//    dirty = false;

//    for (var i = 0; i < total; i++) {

//        var node = nodes[i];
//        var width = node.offsetWidth;
//        var height = node.offsetHeight;
//        var color = "transparent";

//        // Need another element to animate width & height... use clone instead of editing HTML
//        var content = node.cloneNode(true);
//        content.classList.add("item-content");


//        gsap.set(node, { x: "+=0" });
//        gsap.set(content, { width, height });
//        gsap.set([node, node.children], { backgroundColor: color, color });

//        node.appendChild(content);

//        var transform = node._gsTransform;
//        var x = node.offsetLeft;
//        var y = node.offsetTop;

//        boxes[i] = { content, height, node, transform, width, x, y };
//    }


//    for (var i = 0; i < total; i++) {

//        var box = boxes[i];

//        var lastX = box.x;
//        var lastY = box.y;

//        var lastW = box.width;
//        var lastH = box.height;

//        var width = box.width = box.node.offsetWidth;
//        var height = box.height = box.node.offsetHeight;

//        box.x = box.node.offsetLeft;
//        box.y = box.node.offsetTop;

//        if (lastX !== box.x || lastY !== box.y) {

//            var x = box.transform.x + lastX - box.x;
//            var y = box.transform.y + lastY - box.y;

//            // Tween to 0 to remove the transforms
//            gsap.set(box.node, { x, y });
//            gsap.to(box.node, time, { x: 0, y: 0, ease });
//        }

//        if (lastW !== box.width || lastH !== box.height) {

//            gsap.to(box.content, time, { autoRound: false, width, height, ease });
//        }
//    }
//    console.log("layout done");
//}

//function ease(progress) {
//    var inputs = document.querySelectorAll(".toggle-window");
//    var nodes = document.querySelectorAll(".dynamic-sizing");
//    var total = nodes.length;
//    var dirty = true;
//    var time = 0.9;
//    var omega = 12;
//    var zeta = 0.9;
//    var boxes = [];

//    var beta = Math.sqrt(1.0 - zeta * zeta);
//    progress = 1 - Math.cos(progress * Math.PI / 2);
//    progress = 1 / beta *
//        Math.exp(-zeta * omega * progress) *
//        Math.sin(beta * omega * progress + Math.atan(beta / zeta));

//    return 1 - progress;
//}


//function setupAnimations() {

//    animatedObject = document.getElementById("edit-window");
//    closeButton = document.getElementById("edit-window");

//    closeButton.addEventListener("click", function (evt) {
//        document.getElementById("edit-window").classList.add("closed");
//        console.log("Close window");
//    }, false);

//    animatedObject.addEventListener("webkitTransitionEnd", function (evt) {
//        document.getElementById("edit-window").classList.add("d-none");
//    }, false);
//}

function setClickEvents() {
    console.log("setting up events");


    $(".colour-group").click(function () {
        $("#palette").addClass('palette-collapsed');
        $("#editor").each(function () {
            $(this).removeClass("editor-collapsed");
            $(this).removeClass("hide");
        });
        console.log("opening editor");

    });

    console.log("colour group click setup");

    $("#closeButton").click(function () {
        $("#editor").addClass('editor-collapsed');
        $("#palette").each(function () {
            $(this).removeClass("palette-collapsed");
        });
        console.log("closing editor");

    });

    console.log("close button click setup");

    $('#editor').on("animationend", function () {
        if ($('#editor').hasClass('editor-collapsed')) {
            $('#editor').addClass('hide');
        }
        console.log("hide editor contents");
    });

    // *********************************************

    console.log("setting up sub colour events");

    $("#btnToggleSubColours").click(function () {
        if (!$("#subColourPanel").hasClass('subcolours-collapsed')) {
            $("#subColourPanel").addClass('subcolours-collapsed');
            console.log("closing sub colours");
        } else {
            $("#subColourPanel").removeClass('subcolours-collapsed');
            console.log("opening sub colours");
        }
       
       

    });

    console.log("close button click setup");

    $('#subColourPanel').on("animationend", function () {
        if ($('#subColourPanel').hasClass('subcolours-collapsed')) {
            
        }
        console.log("hide subcolour contents");
    });


}
