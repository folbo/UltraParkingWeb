(function () {
    "use strict";

    var Ultra = function () {
    };
    var p = Ultra.prototype;

    p.handleRedirections = function (xhr) {
        if (xhr.status === 430) {
            window.location = xhr.responseJSON.redirectionUrl;
            return true;
        }
        return false;
    };

    p.handleTimeout = function (textStatus) {
        if (textStatus === "timeout") {
            toastr.error('Przekroczono czas oczekiwania. Spróbuj wykonać operację ponownie.');
            return true;
        }
        return false;
    };

    p.postJson = function (url, paramsObj, successMessage, async) {
        if (typeof async === "undefined") {
            async = true;
        }

        return $.ajax({
            method: "POST",
            url: url,
            timeout: 15000,
            contentType: "application/json; charset=utf-8",
            async: async,
            data: JSON.stringify(paramsObj)
        }).fail(function (xhr, textStatus) {
            var isHandled = p.handleRedirections(xhr)
                || p.handleTimeout(textStatus);
            if (!isHandled) {
                toastr.error("Nieoczekiwany błąd. Odśwież stronę i spróbuj ponownie.");
            }

        }).done(function () {
            if (successMessage) {
                toastr.success(successMessage);
            }
        });;
    };
    // =========================================================================
    // DEFINE NAMESPACE
    // =========================================================================

    window.Ultra = new Ultra();
}());