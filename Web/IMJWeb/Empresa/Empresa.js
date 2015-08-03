var Empresa = (function () {
    var jColunaGrande;
    var jColunaPequena;
    var jOuro;
    var jLoja1;
    var jLoja2;
    var jConteudo;
    var backup = {};

    var objeto = {
        reposicionar: function () {
            var altura = jConteudo.innerHeight() * .8;
            var borda = altura < 311 ? 1 : 2;
            //var prop1 = 396 / 284;
            var prop2 = 187 / 140;
            var th = 284 + 140 + altura * 0.2;
            var alturaLoja = 140 * altura / th - 2 * borda;

            jColunaGrande.find("img").css("border-width", borda);
            //jOuro.css("height", 284 * altura / th - 2 * borda);
            jOuro.css("height", "auto");
            jLoja1.css("width", "auto");
            jLoja1.css("height", alturaLoja);
            jLoja2.css("width", "auto");
            jLoja2.css("height", alturaLoja);
            jOuro.css("width", jLoja1.outerWidth() + jLoja2.outerWidth() + altura * 0.02 - 2 * borda);

            if (jColunaPequena.outerHeight() > jConteudo.innerHeight()) {
                if (!backup.ConteudoPaddingTop)
                    backup.ConteudoPaddingTop = jConteudo.css("padding-top");
                jConteudo.css("padding-top", "0");
            } else if (backup.ConteudoPaddingTop) {
                jConteudo.css("padding-top", backup.ConteudoPaddingTop);
            }
        }
    }

    $(function () {
        jColunaGrande = $(".colunaGrande");
        jColunaPequena = $(".colunaPequena");
        jOuro = $("#ouro");
        jLoja1 = $("#loja1");
        jLoja2 = $("#loja2");
        jConteudo = $("#conteudo");

        objeto.reposicionar();

        $(window).resize(objeto.reposicionar);
        jLoja1.load(objeto.reposicionar);
        jLoja2.load(objeto.reposicionar);
    });

    return objeto;
})();

