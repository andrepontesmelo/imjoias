(function () {
    var carregado = false;

    Resolucao.registrarCss("Capa.css");

    function carregarFotoMaiorResolucao() {
        var jFoto = $("#joia");

        if (jFoto.outerHeight() > 300) {
            var src = jFoto.attr("src");
            var pic = new Image();

            // Este evento não é capturado pelo IE 6.
            pic.onload = function () {
                jFoto.attr("src", pic.src);
            };

            pic.src = src.replace("-peq.png", ".png");

            $(window).unbind("resize", carregarFotoMaiorResolucao);
        }
    }

    /* Caso o usuário não esteja utilizando IE 6, baixaremos uma
     * versão da foto em maior resolução em segundo plano.
     */
    if (!(jQuery.browser.msie && jQuery.browser.version == "6.0")) {
        $(function () {
            var jFoto = $("#joia");

            if (jFoto.outerHeight() > 300) {
                setTimeout(function () {
                    carregarFotoMaiorResolucao();
                }, 1);
            } else {
                $(window).resize(carregarFotoMaiorResolucao);
            }
        });
    }
})();