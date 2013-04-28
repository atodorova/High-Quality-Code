function onButtonClick(event) {
    var browserCodeName = window.navigator.appCodeName;
    if (browserCodeName == "Mozilla") {
        alert("You are using Mozilla");
    }
    else {
        alert("You aren't using Mozilla");
    }
}