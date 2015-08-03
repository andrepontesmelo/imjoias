/// <reference path="Miniatura.js"/>

$(function () {
    $("#listaJoias li").after(" ");
});

Miniatura.prototype.obterURLImagem = function(referencia, tamanho) {
    return "Foto.ashx?recortar=true&ref=" + (referencia || this.referencia)
            + "&largura=" + (tamanho || this.tamanho)
            + "&altura=" + (tamanho || this.tamanho)
            + "&formato=jpeg";
}