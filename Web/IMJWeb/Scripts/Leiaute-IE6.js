(function () {
    var jCabecalhoEsquerda;
    var jCabecalhoCentro;
    var jCabecalhoDireita;
    var jLogin;
    var jLoginCentro;
    var jRodape;
    var jConteudo;
    var jConteudoWrapper;

    function ajustarLeiauteIE6() {
        var dimensoes = Resolucao.calcularDimensoes();

        function ajustarCabecalho() {
            jCabecalhoCentro.css("width", jCabecalhoDireita.offset().left - jCabecalhoCentro.offset().left);
            jLogin.css("width", $("#endereco").outerWidth());

            $("#cabecalhoConteudo").css("width", "469px");
            $("#loginCentro")
                .css("padding-right", "0")
                .find("input[type=submit]").each(function () {
                    $(this).css("position", "absolute")
                           .css("left", $("#loginCentro").innerWidth() - $(this).outerWidth());
                });
        }

        function ajustarRodape() {
            jRodape.css("position", "absolute");
        }

        function ajustarConteudo() {
            jConteudo.css("height", 0);
            jConteudo.css("height", jRodape.offset().top - jConteudo.offset().top - jConteudo.outerHeight());

            var marginLeft = parseInt(jConteudo.css("margin-left"));
            var marginRight = parseInt(jConteudo.css("margin-right"));
            var paddingLeft = parseInt(jConteudo.css("padding-left"));
            var paddingRight = parseInt(jConteudo.css("padding-right"));

            jConteudo.css("width", dimensoes.width - marginLeft - marginRight - paddingLeft - paddingRight);
        }

        ajustarCabecalho();
        ajustarRodape();
        ajustarConteudo();
    }

    if (jQuery.browser.msie && jQuery.browser.version == "6.0") {
        $(function () {
            jCabecalhoEsquerda = $("#cabecalhoEsquerda");
            jCabecalhoCentro = $("#cabecalhoCentro");
            jCabecalhoDireita = $("#cabecalhoDireita");
            jLogin = $("#login");
            jLoginCentro = $("#loginCentro");
            jRodape = $("#rodape");
            jConteudo = $("#conteudo");

            $(document).pngFix();
            $("#marca").appendTo("#cabecalho")
                       .css("left", $("#marca").offset().left + $("#cabecalhoEsquerda").outerWidth());

            ajustarLeiauteIE6();
            $(window).resize(ajustarLeiauteIE6);
            jRodape.resize(ajustarLeiauteIE6);
        });
    }
})();