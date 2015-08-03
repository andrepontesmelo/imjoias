Mercadoria.obterURLImagem = function (referencia, tamanho) {
    return "Foto.ashx?ref=" + referencia + "&largura=" + tamanho.largura + "&altura=" + tamanho.altura + "&formato=jpeg";
}

$(function () {
    var mercadoriaAtual = $("#joiaValorReferencia").text();

    Mercadoria.limpar();

    setTimeout(function () {
        Mercadoria.mostrarJoia(mercadoriaAtual);
    }, 5000);
});