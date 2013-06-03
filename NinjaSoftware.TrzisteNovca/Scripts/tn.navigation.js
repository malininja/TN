ie6hover = function () {
    var nav_lis = document.getElementById("nav").getElementsByTagName("li");
    for (var i = 0; i < nav_lis.length; i++) {
        nav_lis[i].onmouseover = function () {
            this.className += " ie6hover";
        }
        nav_lis[i].onmouseout = function () {
            this.className = this.className.replace(new RegExp(" ie6hover\\b"), "");
        }
    }
}

if (window.attachEvent) {
    window.attachEvent("onload", ie6hover);
}