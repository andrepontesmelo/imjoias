/// <reference path="Mercadoria.js"/>
/// <reference path="../Scripts/jquery-1.3.2-vsdoc.js"/>

var Catalogo = (function () {
    Resolucao.registrarCss("RodapeSubMenu.css");
    Resolucao.registrarCss("RodapeProcura.css");
    Resolucao.registrarCss("Catalogo.css");

    var estado = {
        idCatalogo: null,
        idxMercadoria: null,
        cntMercadorias: null,
        referencias: new Array()
    };

    function navegarProximo() {
        Mercadoria.mostrarJoia(estado.referencias[++estado.idxMercadoria]);

        if (estado.idxMercadoria == estado.referencias.length - 1)
            $("#joiaPosterior").hide();

        $("#joiaAnterior").show();
    }

    function navegarAnterior() {
        Mercadoria.mostrarJoia(estado.referencias[--estado.idxMercadoria]);

        if (estado.idxMercadoria == 0)
            $("#joiaAnterior").hide();

        $("#joiaPosterior").show();
    }

    var obj = {
        estado: estado,
        iniciarEstado: function (idCatalogo, idxMercadoria, cntMercadorias) {
            estado.idCatalogo = idCatalogo;
            estado.idxMercadoria = idxMercadoria;
            estado.cntMercadorias = cntMercadorias;

            if (idxMercadoria == 0)
                $("#joiaAnterior").hide();

            if (idxMercadoria == cntMercadorias - 1)
                $("#joiaPosterior").hide();

            $(function () {
                try {
                    IMJWeb.Catalogo.Mercadoria.ObterReferenciasCatalogo(estado.idCatalogo, function (referencias) {
                        estado.referencias = referencias;

                        // Define eventos
                        $("#joiaPosterior").click(function () {
                            navegarProximo();
                            return false;
                        }).attr("href", "#");

                        $("#joiaAnterior").click(function () {
                            navegarAnterior();
                            return false;
                        }).attr("href", "#");

                        $("#conteudo").trigger("referenciasCarregadas");
                    });
                } catch (e) {
                    // Ignorar erros, caso não seja possível obter referências do webservice.
                    alert(e);
                }

                $("#txtReferencia").keypress(function (e) {
                    if (e.keyCode == 13 /* ENTER */) {
                        $("form").submit();
                        return false;
                    }
                });
            });
        }
    };

    $(function () {
        var joia = {
            container: $("#joiaImagemContainer"),
            imagem: $("#joiaImagem"),
            descricao: $("#joiaDescricao")
        };

        var conteudo = $("#conteudo");
        var primeiraColuna = conteudo.find(".primeiraMaior");
        var segundaColuna = conteudo.find(".segundaMenor");
        var navegadoresHorizontais = $(".navegador", primeiraColuna);
        var txtReferencia = $("#txtReferencia");

        segundaColuna.css("position", "relative");

        // Define máscara para a caixa de procura
        $(".txtReferencia").setMask("999.999.99.999-9").focus();

        // Define proporção de itens no submenu
        var rodapeSubMenu = $("#rodapeSubMenu");
        var subMenu = $("#subMenu");
        var itensSubMenu = $("li", subMenu);

        function ajustarLarguraSubMenu(percentual) {
            itensSubMenu.width((percentual / itensSubMenu.length) + "%");
        }

        var percentual = 100;

        ajustarLarguraSubMenu(percentual);

        // Parece não garantir em todos os casos, então agendamos a verificação...
        function ajustarLarguraSubMenuTimeOut() {

            var mudado = false;

            while ($(itensSubMenu.get(itensSubMenu.length - 1)).position().top != $(itensSubMenu.get(0)).position().top) {
                percentual -= 1;
                ajustarLarguraSubMenu(percentual);
                mudado = true;
            }

            if (mudado)
                setTimeout(ajustarLarguraSubMenuTimeOut, 150);
        }

        setTimeout(ajustarLarguraSubMenuTimeOut, 150);

        itensSubMenu.filter(":has(a:not([disabled]))")
               .ahover()
               .css("cursor", "pointer")
               .click(function () { window.location.href = $("a", this).attr("href"); });

        // Ajusta o leiaute quando a janela é redimensionada
        function ajustarLeiaute() {

            var alturaColuna;

            if (!($.browser.msie && $.browser.version == 7))
                alturaColuna = conteudo.height() * .90 - rodapeSubMenu.outerHeight();
            else
                alturaColuna = (rodapeSubMenu.offset().top - conteudo.offset().top * 2) * .90;

            primeiraColuna.height(alturaColuna);
            segundaColuna.height(alturaColuna);

            var altura = alturaColuna - joia.descricao.outerHeight();

            joia.imagem.height(altura);
            joia.imagem.width("auto");

            if (joia.imagem.outerWidth() > primeiraColuna.width()) {
                joia.imagem.width(primeiraColuna.width()).height("auto");
                joia.imagem.css("padding-top", Math.max(0, (joia.descricao.offset().top - primeiraColuna.offset().top - joia.imagem.outerHeight()) / 2));
            } else {
                joia.imagem.css("padding-top", 0);
            }

            if ($.browser.msie)
                txtReferencia.width(txtReferencia.parent().width() - (txtReferencia.offset().left - txtReferencia.parent().offset().left) - 2 - (txtReferencia.innerWidth() - txtReferencia.width()));
        }

        ajustarLeiaute();

        conteudo.resize(ajustarLeiaute);

        joia.imagem.load(ajustarLeiaute);

        if ($("#joiaValorDescricao").text() == "")
            $("#joiaDescricao").hide();

        if ($.browser.msie)
            setTimeout(ajustarLeiaute, 3000);
        //        setTimeout(ajustarLeiaute, 5000);
        //        setTimeout(ajustarLeiaute, 7000);

    });

    return obj;
})();