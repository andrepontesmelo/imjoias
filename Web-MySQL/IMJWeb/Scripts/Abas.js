/// <reference path="../Scripts/jquery-1.3.2-vsdoc.js"/>

jQuery.extend({
    abas: {
        padrao: {
            minTop: 150
        }
    }
});

jQuery.fn.extend({
    abas: function(options) {
        var options = jQuery.extend({}, jQuery.abas.padrao, options);
        this.addClass("abas");

        var titulos = null;

        this.children().each(function() {
            titulos = jQuery(this).children(":first").add(titulos);
        });

        var conteudos = titulos.next();

        titulos.addClass("titulo");
        titulos.each(function() {
            jQuery(this).children(":first").before("<div class='borda-esquerda'/>");
        });
        titulos.append("<div class='borda-direita'/>");
        conteudos.addClass("aba-conteudo").append("<div class='borda-esquerda'/><div class='borda-direita'/><div class='borda-topo'/><div class='borda-quina'/>");

        titulos.click(function() {
            var li = $(this).parent();

            li.siblings(".selecionado").removeClass("selecionado");
            li.addClass("selecionado");
        });

        this.children(":odd").addClass("alternado");
        this.children(":first").addClass("selecionado");

        function descobrirAlturaMaxima() {
            var alturaMaxima = 0;

            conteudos.each(function() {
                if (jQuery(this).height() > alturaMaxima)
                    alturaMaxima = jQuery(this).height();
            });

            return alturaMaxima;
        }

        var self = this;

        function redefinirAltura() {
            var altura = descobrirAlturaMaxima();
            conteudos.height("auto");
            conteudos.height(altura);
            self.height(conteudos.outerHeight() + titulos.outerHeight() + 1);

            self.css({
                bottom: 0,
                top: "auto"
            });

            if (self.position().top < options.minTop)
                self.css({
                    bottom: "auto",
                    top: options.minTop
                });

            if ($.browser.msie) {
                titulos.eq(0).hide();
                setTimeout(function() { titulos.eq(0).show(); }, 10);
            }
        }

        redefinirAltura();
        $("#conteudo").resize(redefinirAltura);

        return this;
    }
});