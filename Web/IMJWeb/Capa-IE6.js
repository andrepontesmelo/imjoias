(function() {
    function ajustarLeiauteIE6() {
        var dimensoes = Resolucao.calcularDimensoes();

        $("body").css("overflow", "hidden");
        $("#conteudo").css("top", 0)
                      .css("left", 0)
                      .css("width", dimensoes.width)
                      .css("height", dimensoes.height)
                      .css("overflow", "hidden");

        var jPlataforma = $("#plataforma");
        var jLuz = jPlataforma.children("#luz");
        var alturaPlataforma = dimensoes.height * 0.43;

        jPlataforma.css("height", alturaPlataforma);
        jPlataforma.css("position", "absolute");
        jPlataforma.css("top", dimensoes.height - alturaPlataforma);
        jLuz.css("width", jPlataforma.innerWidth());
        jLuz.css("height", jPlataforma.innerHeight());

        var pAreaJoia = $("#areaJoia");

        pAreaJoia.css("position", "absolute");
        pAreaJoia.css("top", dimensoes.height - pAreaJoia.outerHeight());

        var pJoia = $("#joia");

        // TODO: Calcular dinamicamente a largura.
        pJoia.css("height", dimensoes.height * 0.7);
        pJoia.css("width", dimensoes.height * 0.65581395348837209302325581395349);
        pJoia.parent("a").css({
            left: (pAreaJoia.innerWidth() - pJoia.outerWidth()) / 2,
            position: "absolute"
        });
    }

    if (jQuery.browser.msie && jQuery.browser.version == "6.0") {
        $(ajustarLeiauteIE6);
        $(window).resize(ajustarLeiauteIE6);
    }
})();