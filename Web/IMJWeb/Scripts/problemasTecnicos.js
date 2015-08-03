$(function() {
    $("<div><p>Desculpe-nos, mas infelizmente estamos enfrentando problemas técnicos em nossos servidores web que impossiblitam a navegação adequada pelo catálogo.</p><p>Estamos trabalhando para resolver o problema.</p><p>Agradecemos a compreensão.</p></div>")
    .dialog({
        title: "Problemas técnicos",
        draggable: true,
        width: 400,
        buttons: {
            "Ok": function() {
                $(this).dialog("close");
            },
            "Fale conosco": function () {
                window.location.href = "Contato.aspx?origem=login";
            }
        }
    });
});