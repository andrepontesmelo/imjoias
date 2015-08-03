$(function () {
    $("<div/>")
        .text("Mercadoria não encontrada.")
        .dialog({
            title: "Encontre pela referência",
            draggable: true,
            buttons: { "OK": function () { $(this).dialog("close"); } }
        });
});