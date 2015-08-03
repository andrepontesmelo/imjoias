/// <reference path="Catalogo.js"/>
/// <reference path="Mercadoria.js"/>
/// <reference path="../Scripts/jquery-1.3.2-vsdoc.js"/>

$(function () {
    var rodapeSubMenu = $("#rodapeSubMenu");
    var rodapeSubMenuDireita = $("#rodapeSubMenuDireita");
    var rodapeSubMenuCentro = $("#rodapeSubMenuCentro");
    var joiaDados = $("#joiaDados");
    var primeiraColuna = $(".primeiraMaior");

    $("#rodapeProcura").width("45ex");
    $("#procuraCentro").width($("#procuraDireita").offset().left - $("#procuraCentro").offset().left)
                .css("padding-top", ".7em");

    function ajustarLeiaute() {
        rodapeSubMenuDireita.css({
            right: "auto",
            left: $("#procuraEsquerda").offset().left - rodapeSubMenuDireita.width() - rodapeSubMenu.offset().left + 1
        });

        rodapeSubMenuCentro.width(rodapeSubMenuDireita.offset().left - rodapeSubMenuCentro.offset().left);

        $("#joiaImagem").css("left", ($("#colunaMercadoria").innerWidth() - $("#joiaImagem").width()) / 2);
    }

    ajustarLeiaute();
    $("#conteudo").resize(ajustarLeiaute);

    $("#joiaImagem").css("position", "absolute").resize(function () {
        $("#joiaImagem").css("left", ($("#colunaMercadoria").innerWidth() - $("#joiaImagem").width()) / 2);
    });
});