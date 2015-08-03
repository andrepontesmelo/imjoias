$(function () {
    $("<div>A senha para o usuário fornecido encontra-se incorreta.</div>")
    .dialog({
        title: "Login",
        draggable: true,
        width: 400,
        buttons: {
            "Tentar novamente": function () {
                $(this).dialog("close");
            }
        }
    });
});