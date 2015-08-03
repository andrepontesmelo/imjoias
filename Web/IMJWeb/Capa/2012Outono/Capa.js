Leiaute.capa.tamanhos = [800, 700, 550, 0];

$(function () {
    var direita = 0;

    function deslocarCapa() {
        var offset = Leiaute.capa.objImagem.offset();
        var x = offset.left / Leiaute.capa.objImagem.width();

        if (x < -.18) {
            direita = direita - 1;
            Leiaute.capa.objImagem.css({ right: direita });
            setTimeout(deslocarCapa, 50);
        } else if (offset.left + Leiaute.capa.objImagem.width() < $("#conteudo").width()) {
            Leiaute.capa.objImagem.css({ left: "auto", right: 0 });
            direita = 0;
        }
    }

    Leiaute.capa.objImagem.load(deslocarCapa);
    $(window).resize(deslocarCapa);

    deslocarCapa();
});