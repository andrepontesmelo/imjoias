/// <reference path="Catalogo.js"/>
/// <reference path="Mercadoria.js"/>
/// <reference path="../Scripts/jquery-1.3.2-vsdoc.js"/>

Miniatura = function (indice, onclick) {

    var imgReferencia = $("#listaJoias li:first a img");

    this.referencia = Catalogo.estado.referencias[indice];
    this.tamanho = imgReferencia.width();
    this.indice = indice;

    var li = $("<li />");
    var link = $("<a href='#' />")
        .attr("indice", indice)
        .attr("title", "Ref. " + this.referencia)
        .click(function () { onclick(link) })
        .appendTo(li);
    var img = $("<img />")
        .attr("alt", this.referencia)
        .attr("src", this.obterURLImagem())
        .appendTo(link).removeAttr("width").removeAttr("height");

    $("#listaJoias").append(" ").append(li);

    this.elemento = li;
    this.aplicarAnimacao();
}

Miniatura.prototype.aplicarAnimacao = function () { };
Miniatura.prototype.obterURLImagem = function(referencia, tamanho) {
    return "Foto.ashx?recortar=true&ref=" + (referencia || this.referencia)
            + "&largura=" + (tamanho || this.tamanho)
            + "&altura=" + (tamanho || this.tamanho);
}


$(function () {
    // Define efeito de mouse sobre lista de joias.
    var sobre;
    var segundaColuna = $("#conteudo .segundaMenor");
    var opacidadeClara = 0.35;
    var tamanhoConjunto = 4;
    var antecipacao = new Array();
    var areaScroll;
    var posicaoScroll;
    var indiceDesejado = null;
    var semScroll = true;

    function obterIndiceAtual() {
        return parseInt($("#listaJoias li:not(.emRemocao):first a").attr("indice"));
    }

    function obterUltimoIndice() {
        return parseInt($("#listaJoias li:not(.emRemocao):last a").attr("indice"));
    }

    function anteciparImagens() {
        antecipacao = new Array();

        var indiceInicial = obterIndiceAtual();
        var indiceFinal = obterUltimoIndice();
        var tamanho = $("#listaJoias li:first a img").width();

        function anteciparPorIndice(indice) {
            if (Catalogo.estado.referencias[indice]) {
                var img = new Image();
                img.src = Miniatura.prototype.obterURLImagem(Catalogo.estado.referencias[indice], tamanho);
                antecipacao.push(img);
            }
        }

        for (var i = 1; i <= tamanhoConjunto; i++) {
            anteciparPorIndice(indiceInicial - i);
            anteciparPorIndice(indiceFinal + i);
        }
    }

    anteciparImagens();

    function completarFila() {
        for (var i = $("#listaJoias li:not(.emRemocao)").length % tamanhoConjunto; i > 0; i--) {
            var indice = parseInt($("#listaJoias li:not(.emRemocao):last a").attr("indice")) + 1;

            if (!Catalogo.estado.referencias[indice + i])
                break;

            new Miniatura(indice + i, navegarJoia);
        }
    }

    function reorganizarMiniaturas() {

        if (!Catalogo.estado.referencias || Catalogo.estado.referencias.length == 0)
            return;

        var miniaturaReferencia = $("#listaJoias li:first");
        var quantidade = $("#listaJoias li").length;

        /* ATENÇÃO: A altura é calculada em relação à largura da miniatura,
        * devido ao tamanho definido em percentual proporcional à largura (no CSS).
        * A altura só é definida após a carga da imagem, que, em pixels, será
        * do mesmo tamanho da largura.
        */
        var altura;

        completarFila();

        // Determina a área útil, removendo a área informativa de cadastro.
        if ($("#informativoCadastro").length > 0) {
            altura = Math.max(miniaturaReferencia.outerWidth() * (Math.round(quantidade / tamanhoConjunto))
                + $("#informativoCadastro").outerHeight(), $("#informativoCadastro").position().top + $("#informativoCadastro").outerHeight());
        } else {
            altura = miniaturaReferencia.outerWidth() * (Math.round(quantidade / tamanhoConjunto));
        }

        // Verifica se a quantidade de elementos ultrapassa a área útil...
        if (altura > segundaColuna.height() && quantidade > tamanhoConjunto) {
            for (var i = (tamanhoConjunto - quantidade % tamanhoConjunto) % tamanhoConjunto; i < tamanhoConjunto; i++)
                $("#listaJoias li:last").remove();
        }
        // ...ou se a área útil sobra espaço...
        else if (altura + miniaturaReferencia.outerWidth() <= segundaColuna.height()) {
            var indice = parseInt($("#listaJoias li:last a").attr("indice")) + 1;

            for (var i = 0; i < tamanhoConjunto; i++) {
                if (!Catalogo.estado.referencias[indice + i])
                    break;

                new Miniatura(indice + i, navegarJoia);
            }
        }

        completarFila();
        anteciparImagens();

        var indice = parseInt($("#listaJoias li:last a").attr("indice")) + 1;

        if (!Catalogo.estado.referencias[indice + 1])
            $("#miniaturasBaixo").hide();
        else
            $("#miniaturasBaixo").show();

        if ($("#listaJoias li").length == Catalogo.estado.referencias.length) {
            semScroll = true;
            posicaoScroll.add($("#miniaturasLinhaScroll")).hide();
        } else {
            semScroll = false;
        }
    }

    function navegarJoia(ancora) {
        Catalogo.estado.idxMercadoria = ancora.attr("indice");

        if (Catalogo.estado.idxMercadoria == 0)
            $("#joiaAnterior").hide();
        else
            $("#joiaAnterior").show();

        if (Catalogo.estado.idxMercadoria == Catalogo.estado.referencias.length - 1)
            $("#joiaPosterior").hide();
        else
            $("#joiaPosterior").show();

        Mercadoria.mostrarJoia(Catalogo.estado.referencias[Catalogo.estado.idxMercadoria]);
    }

    function adicionarMiniaturaInicio() {
        var indice = parseInt($("#listaJoias li:first a").attr("indice")) - 1;

        if (indice >= 0) {
            var miniatura = new Miniatura(indice, navegarJoia);
            $("#listaJoias li:first").before(miniatura.elemento).before(" ");
            miniatura.elemento.children("a").children("img").slideDown();

            if (indice == 0)
                $("#miniaturasCima").hide();
        } else {
            reorganizarMiniaturas();
        }
    }

    function navegarMiniaturasCima() {
        var ultima = $("#listaJoias li:not(.emRemocao):last");
        var aux = ultima;
        var conjuntoAntigo = ultima;
        var altura = ultima.outerHeight();
        var cnt;
        var linha = Math.floor(ultima.children("a").attr("indice") / tamanhoConjunto);

        aux = aux.prev("li:not(.emRemocao)");

        for (var i = 1; i < tamanhoConjunto && Math.floor(aux.children("a").attr("indice") / tamanhoConjunto) == linha; i++) {
            conjuntoAntigo = conjuntoAntigo.add(aux)
            aux = aux.prev("li:not(.emRemocao)");
        }

        cnt = conjuntoAntigo.length;
        conjuntoAntigo.addClass('emRemocao');

        function substituir() {
            $(this).parent().parent().remove();
            adicionarMiniaturaInicio();

            if (! --cnt)
                for (var i = 0; i < tamanhoConjunto - conjuntoAntigo.length; i++)
                    adicionarMiniaturaInicio();

            anteciparImagens();
        }

        if (!($.browser.msie && $.browser.version < 8)) {
            conjuntoAntigo.children("a").children("img").animate({ opacity: 0 }, {
                duration: 250,
                queue: true,
                complete: substituir
            });
        } else {
            conjuntoAntigo.children("a").children("img").each(substituir);
        }

        $("#miniaturasBaixo").show();
    }

    function navegarMiniaturasBaixo() {
        var primeira = $("#listaJoias li:not(.emRemocao):first");
        var aux = primeira;
        var conjuntoAntigo = primeira;

        for (var i = 1; i < tamanhoConjunto; i++) {
            aux = aux.next("li:not(.emRemocao)");
            conjuntoAntigo = conjuntoAntigo.add(aux)
        }

        function substituir() {
            $(this).remove();

            var indice = parseInt($("#listaJoias li:last a").attr("indice")) + 1;

            if (Catalogo.estado.referencias[indice]) {
                new Miniatura(indice, navegarJoia);
            }

            if (!Catalogo.estado.referencias[indice + 1])
                $("#miniaturasBaixo").hide();

            anteciparImagens();
        }

        conjuntoAntigo.addClass('emRemocao');

        if (!($.browser.msie && $.browser.version < 8)) {
            conjuntoAntigo.children("a").children("img").animate({ opacity: 0 }, {
                duration: 250,
                queue: true,
                complete: function () {
                    $(this).parent().parent().slideUp('normal', substituir);
                }
            });
        } else {
            conjuntoAntigo.each(substituir);
        }

        $("#miniaturasCima").show();
    }

    if ($.browser.msie) {
        if ($.browser.version > 7) {
            function sobreJoiaListaIE() {
                sobre = $(this);
                sobre.children("a").children("img").animate({ opacity: 1 }, { duration: 500, queue: false });
                sobre.siblings("li").children("a").children("img").animate({ opacity: opacidadeClara }, { duration: 500, queue: false });
            }

            function sairJoiaListaIE() {
                sobre = null;
                $(this).animate({ opacity: opacidadeClara }, { duration: 500, queue: false });

                setTimeout(function () {
                    if (!sobre)
                        $("#listaJoias li a img").animate({ opacity: 1 }, { duration: 500, queue: false });
                }, 1000);
            }

            $("#listaJoias li").hover(sobreJoiaListaIE, sairJoiaListaIE);

            Miniatura.prototype.aplicarAnimacao = function () {
                $(this.elemento).hover(sobreJoiaListaIE, sairJoiaListaIE);
            }
        } else {
            function sobreJoiaListaIEVelho() {
                $(this).css("border-color", "#bba932");
            }

            function sairJoiaListaIEVelho() {
                $(this).css("border-color", "#939598");
            }

            $("#listaJoias li a img").hover(sobreJoiaListaIEVelho, sairJoiaListaIEVelho);

            Miniatura.prototype.aplicarAnimacao = function () {
                $(this.elemento).children("a img").hover(sobreJoiaListaIEVelho, sairJoiaListaIEVelho);
            }
        }
    } else {
        function sobreJoiaLista() {
            sobre = $(this);
            sobre.animate({ opacity: 1 }, { duration: 500, queue: false })
                         .siblings("li").animate({ opacity: opacidadeClara }, { duration: 500, queue: false });
        }

        function sairJoiaLista() {
            sobre = null;
            $(this).animate({ opacity: opacidadeClara }, { duration: 500, queue: false });

            setTimeout(function () {
                if (!sobre)
                    $("#listaJoias li").animate({ opacity: 1 }, { duration: 500, queue: false });
            }, 1000);
        }

        $("#listaJoias li").hover(sobreJoiaLista, sairJoiaLista);

        Miniatura.prototype.aplicarAnimacao = function () {
            $(this.elemento).hover(sobreJoiaLista, sairJoiaLista);
        }
    }

    function calcularIndiceScroll() {
        var quantidade;

        if (!Catalogo.estado || !Catalogo.estado.referencias)
            return 0;

        var posicao = Math.min(1, posicaoScroll.position().top / (areaScroll.height() - posicaoScroll.height()));

        return Math.floor(posicao * (Catalogo.estado.referencias.length - tamanhoConjunto) / tamanhoConjunto) * tamanhoConjunto;
    }

    function navegarAteScroll() {

        $("#listaJoias li.emRemocao").stop(true, true);

        var cnt = $("#listaJoias li:not(.emRemocao)").length;
        var indice = calcularIndiceScroll();
        var miniatura = new Miniatura(indice, navegarJoia);

        $("#listaJoias li").not(miniatura.elemento).remove();

        for (var i = 1; i < cnt; i++) {
            if (Catalogo.estado.referencias[++indice]) {
                new Miniatura(indice, navegarJoia);
            }
        }

        reorganizarMiniaturas();

        if (indice - cnt <= 0)
            $("#miniaturasCima").hide();
        else
            $("#miniaturasCima").show();

        if (!Catalogo.estado.referencias[indice + 1])
            $("#miniaturasBaixo").hide();
        else
            $("#miniaturasBaixo").show();
    }

    function criarScroll() {
        areaScroll = $("<div id='miniaturasAreaScroll'><div id='miniaturasLinhaScroll'/><div id='miniaturasPosicaoScroll'/></div>");

        $("#miniaturasCima").before(areaScroll);

        posicaoScroll = $("#miniaturasPosicaoScroll");

        posicaoScroll.draggable({
            axis: 'y',
            containment: 'parent',
            drag: navegarAteScroll
        });

        var conjuntoScrollVisivel = posicaoScroll.add($("#miniaturasLinhaScroll"));
        conjuntoScrollVisivel.hide();

        var visivel = false;

        areaScroll.parent().mousemove(function (e) {
            var posicao = areaScroll.offset();
            var dist = posicao.left - e.pageX;

            if (visivel && Math.abs(dist) > 20) {
                conjuntoScrollVisivel.fadeOut();
                visivel = false;
            } else if (!visivel && Math.abs(dist) <= 20 && !semScroll) {
                conjuntoScrollVisivel.fadeIn();
                visivel = true;
            }
        });
    }

    function reposicionarScroll(indice) {
        if (indice == null)
            indice = obterIndiceAtual();

        var posicao = Math.floor(indice / tamanhoConjunto) / Math.floor(Catalogo.estado.referencias.length / tamanhoConjunto) * (areaScroll.height() - posicaoScroll.height());
        posicaoScroll.css("top", posicao);
    }

    $("#listaJoias li a").click(function () {
        navegarJoia($(this));
        return false;
    }).attr("href", "#");

    $("#miniaturasCima").click(function () {
        reposicionarScroll(obterIndiceAtual() - tamanhoConjunto);
        navegarMiniaturasCima();
        return false;
    }).attr("href", "#");

    $("#miniaturasBaixo").click(function () {
        navegarMiniaturasBaixo();
        reposicionarScroll();
        return false;
    }).attr("href", "#");

    reorganizarMiniaturas();

    setInterval(reorganizarMiniaturas, 1000);

    with ($("#conteudo")) {
        resize(reorganizarMiniaturas);
        bind("referenciasCarregadas", reorganizarMiniaturas);
    }

    if (parseInt($("#listaJoias li:first a").attr("indice")) == 0)
        $("#miniaturasCima").hide();

    criarScroll();
});
