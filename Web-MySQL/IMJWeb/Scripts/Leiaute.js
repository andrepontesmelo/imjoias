Leiaute = (function() {
    var ultimaAlturaRodape = 0;
    var ultimaAlturaConteudo, ultimaLarguraConteudo;
    var timeout = null;
    var agendamento = null;

    var obj = {
        redimensionarConteudo: true,

        ajustarConteudo: function() {
            var conteudo = $("#conteudo");
            var alturaRodape = $("#rodape").outerHeight();

            if (ultimaAlturaRodape != alturaRodape && Leiaute.redimensionarConteudo) {
                conteudo.css("bottom", alturaRodape);
                ultimaAlturaRodape = alturaRodape;
            }

            // Verifica se o navegador implementa evento "onresize" para DIV...
            //if (typeof conteudo.get(0).onresize == "undefined") {
            {
                var alturaConteudo = conteudo.outerHeight();
                var larguraConteudo = conteudo.outerWidth();

                if (ultimaAlturaConteudo != alturaConteudo || ultimaLarguraConteudo != larguraConteudo)
                    $("#conteudo").trigger("resize");   // Dispara evento, já que o navegador não o disparou.

                ultimaAlturaConteudo = alturaConteudo;
                ultimaLarguraConteudo = larguraConteudo;
            }

            if (agendamento != null) {
                if (!timeout || timeout < new Date().getTime()) {
                    clearInterval(agendamento);
                    agendamento = null;
                    timeout = null;
                }
            }
        }
    }

    function aoRedimensionarJanela() {
        obj.ajustarConteudo();

        /* É possível que novos CSS sejam carregados.  Neste caso,
        * como não é possível saber quando ele foi carregado,
        * vamos insistir por um minuto.
        */
        if (agendamento == null)
            agendamento = setInterval(obj.ajustarConteudo, 50);

        timeout = new Date().getTime() + 1000 * 60;
    }

    if (!(jQuery.browser.msie && (jQuery.browser.version == "6.0" || jQuery.browser.version == "7.0"))) {
        $(obj.ajustarConteudo);
        $(window).resize(aoRedimensionarJanela);
    }

    $(function() {
        $("#menu li:not(:has(a[disabled]))").ahover()
           .css("cursor", "pointer")
           .click(function() { window.location.href = $("a", this).attr("href"); });
    });

    return obj;
})();