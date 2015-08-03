$(function () {
    $("<div><p>O login do usuário fornecido não foi encontrado.</p><p>Verifique se o login está digitado corretamente ou entre em contato para obter auxílio.</p></div>")
    .dialog({
        title: "Login",
        draggable: true,
        width: 400,
        buttons: {
            "Tentar novamente": function () {
                $(this).dialog("close");
            },
            "Fale conosco": function () {
                window.location.href = "/Contato.aspx?origem=login";
            }
        }
    });
});