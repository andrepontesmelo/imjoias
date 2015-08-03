(function () {
    function ajustarLeiauteIE6() {
        var dimensoes = Resolucao.calcularDimensoes();

        $("body").css("overflow", "hidden");
        
        $("#conteudo").css("top", 0)
                      .css("left", 0)
                      .css("width", dimensoes.width)
                      .css("height", dimensoes.height)
                      .css("overflow", "hidden");
    }

    if (jQuery.browser.msie && jQuery.browser.version == "6.0") {
        $(ajustarLeiauteIE6);
        $(window).resize(ajustarLeiauteIE6);
    }
})();