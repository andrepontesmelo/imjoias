Leiaute.capa.tamanhos = [800, 700, 550, 0];

$(function () {
    var esquerda = 0;

    function deslocarCapa() {
        var offset = Leiaute.capa.objImagem.offset();
        var x = offset.left + Leiaute.capa.objImagem.width();

        if (x > $("#conteudo").width()) {
            esquerda = esquerda - 1;
            Leiaute.capa.objImagem.css({ left: esquerda, right: "auto" });
            setTimeout(deslocarCapa, 50);
        } else if (x < $("#conteudo").width()) {
            Leiaute.capa.objImagem.css({ left: 0, right: "auto" });
            esquerda = 0;
        }
    }

    Leiaute.capa.objImagem.load(deslocarCapa);
    $(window).resize(deslocarCapa);

    deslocarCapa();
});