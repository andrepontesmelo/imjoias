(function () {
    $(function () {
        if (jQuery.browser.msie) {
            $("a[disabled]").each(function () {
                $(this).replaceWith("<span class='linkDesligado'>" + $(this).text() + "</span>");
            });
        }
    });
})();