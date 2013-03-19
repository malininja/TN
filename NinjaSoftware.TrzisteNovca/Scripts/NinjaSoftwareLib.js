﻿function namespace(namespaceString) {
    var parts = namespaceString.split('.'),
        parent = window,
        currentPart = '';    

    for(var i = 0, length = parts.length; i < length; i++) {
        currentPart = parts[i];
        parent[currentPart] = parent[currentPart] || {};
        parent = parent[currentPart];
    }

    return parent;
}

/* START URL specific functions */

var nsUrl = namespace("ninjaSoftware.url");

nsUrl.getParameterValue = function (parameterName) {
    parameterName = parameterName.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + parameterName + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}

/* END URL specific functions */

/* START HTML element specific functions */

var nsHtmlInput = namespace("ninjaSoftware.htmlInput");

nsHtmlInput.submitAsRedirect = function (submitId, redirectUrl) {
    $(document).ready(function () {
        $("#" + redirectUrl).click(function (e) {
            e.preventDefault();
            window.location.href = redirectUrl;
        });
    });
}

/* END HTML element specific functions */