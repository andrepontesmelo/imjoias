$(function() {
    $("<div>A senha de confirmação não confere com a nova senha.</div>")
    .dialog({
        title: "Alterar senha",
        draggable: true,
        width: 400,
        buttons: {
            "Tentar novamente": function() {
                $(this).dialog("close");
            }
        }
    });
});