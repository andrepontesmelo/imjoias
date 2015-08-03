/// <reference path="Catalogo.js"/>
/// <reference path="../Scripts/jquery-1.3.2-vsdoc.js"/>

var Mercadoria = (function() {
    var elementos = {};
    var tamanho = { largura: 0, altura: 0 };
    var mercadoriaAtual;
    var fotoExibicao;

    $(function() {
        elementos = {
            imagem: $("#joiaImagem"),
            referencia: $("#joiaValorReferencia"),
            descricao: $("#joiaValorDescricao"),
            indice: $("#joiaValorIndice"),
            peso: $("#joiaValorPeso"),
            areaDescricao: $("#joiaDescricao"),
            areaIndice: $("#joiaIndice"),
            areaPeso: $("#joiaPeso")
        };

        elementos.imagem.load(function() { elementos.imagem.fadeIn(); });

        /* Ao redimensionar janela, verifica se ela foi aumentada em 10%
        * para requisitar uma foto com resolução melhor da mercadoria.
        */
        $("#conteudo").resize(function() {
            if (tamanho.largura * 1.1 < elementos.imagem.width() || tamanho.altura * 1.1 < elementos.imagem.height())
                carregarFoto();
        });
    });

    function aoCarregarMercadoria(mercadoria) {
        if (!mercadoriaAtual || mercadoriaAtual.Referencia.numero == mercadoria.Referencia.ValorNumerico) {
            mercadoriaAtual = mercadoria;
            mercadoriaAtual.Referencia.numero = mercadoria.Referencia.ValorNumerico;
            elementos.descricao.text(mercadoria.Descricao);
            elementos.indice.text(mercadoria.Indice);
            elementos.peso.text(mercadoria.Peso);

            if (fotoExibicao)
                carregarFoto();

            if (mercadoria.Descricao)
                elementos.areaDescricao.show();
            else
                elementos.areaDescricao.hide();

            elementos.areaIndice.show();
            
            if (mercadoria.Peso)
                elementos.areaPeso.css('display', 'inline');
        }
    }

    function carregarFoto() {
        if (mercadoriaAtual && (!fotoExibicao || fotoExibicao != mercadoriaAtual.Referencia.numero)) {
            tamanho.largura = Math.max(tamanho.largura, elementos.imagem.width());
            tamanho.altura = Math.max(tamanho.altura, elementos.imagem.height());
            elementos.imagem.attr("src", Mercadoria.obterURLImagem(mercadoriaAtual.Referencia.numero, tamanho))
                .attr("alt", mercadoriaAtual.Referencia.numero);
            fotoExibicao = mercadoriaAtual.Referencia.numero;
        }
    }

    return {
        limpar: function() {
            elementos.descricao.text("");
            elementos.indice.text("");
            elementos.peso.text("");
            elementos.areaDescricao.hide();
            elementos.areaIndice.hide();
            elementos.areaPeso.hide();
            elementos.imagem.hide();
            fotoExibicao = null;
            mercadoriaAtual = null;
        },

        mostrarJoia: function(referencia) {
            if (mercadoriaAtual && mercadoriaAtual.Referencia.numero == referencia)
                return;

            elementos.referencia.text(referencia.replace(/(\d{3})(\d{3})(\d{2})(\d{3})(\d{1})/, "$1.$2.$3.$4-$5"));
            elementos.descricao.text("");
            elementos.indice.text("");
            elementos.peso.text("");
            elementos.areaDescricao.hide();
            elementos.areaIndice.hide();
            elementos.areaPeso.hide();
            elementos.imagem.fadeOut(carregarFoto, function() {
                if (fotoExibicao == null)
                    carregarFoto();
            });
            fotoExibicao = null;

            mercadoriaAtual = { Referencia: { numero: referencia} };
            IMJWeb.Catalogo.Mercadoria.ObterMercadoria(referencia, aoCarregarMercadoria);
        },

        obterURLImagem: function(referencia, tamanho) {
            return "Foto.ashx?ref=" + referencia + "&largura=" + tamanho.largura + "&altura=" + tamanho.altura;
        }
    };
})();