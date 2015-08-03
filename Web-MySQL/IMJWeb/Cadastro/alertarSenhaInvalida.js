$(function () {
    $("<div>A senha atual para o usuário fornecido encontra-se incorreta.</div>")
    .dialog({
        title: "Alterar senha",
        draggable: true,
        width: 400,
        buttons: {
            "Tentar novamente": function () {
                $(this).dialog("close");
            }
        }
    });
});