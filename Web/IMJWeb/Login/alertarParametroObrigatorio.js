$(function () {
    $("<div/>")
        .text("É necessário preencher o login do usuário e sua senha para validar o acesso.")
        .dialog({
            title: "Login",
            draggable: true,
            buttons: { "OK": function () { $(this).dialog("close"); } }
        });
});