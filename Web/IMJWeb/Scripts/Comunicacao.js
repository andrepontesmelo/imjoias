/// <reference path="../Scripts/jquery-1.3.2-vsdoc.js"/>

jQuery.extend({
    comunicar: {
        padrao: {
            raiz: "/",
            url: "Comunicacao/CaixaEntrada.ashx",
            categoria: null,
            mensagemSucesso: "Formulário enviado com sucesso."
        }
    }
});

jQuery.fn.extend({
    comunicar: function(options) {
        var options = jQuery.extend({}, jQuery.comunicar.padrao, options);
        var dados = new String();

        if (!options.retorno)
            options.retorno = options.raiz;

        this.find("input").add(this.find("textarea")).each(function() {
            var jThis = jQuery(this);
            var par;

            par = {
                Chave: jThis.siblings("label[for=" + jQuery(this).attr("id") + "]").text() || jThis.attr("name"),
                Valor: jThis.val()
            };

            var tipo = jThis.attr("type");

            if (tipo == "radio") {
                if (!jThis.attr("checked"))
                    return;
            } else if (tipo == "hidden" && par.Chave == "Categoria") {
                options.categoria = par.Valor;
                return;
            }

            dados = dados.concat((dados.length > 0 ? "\t" : "") + par.Chave + "\t" + par.Valor);
        });

        if (options.raiz.charAt(options.raiz.lenght - 1) != "/")
            options.raiz += "/";

        jQuery.post(options.raiz + options.url, { dados: dados, categoria: options.categoria }, function() {
            jQuery("#notificacao-comunicacao").dialog("destroy").remove();

            var mensagem = jQuery("<div/>").text(options.mensagemSucesso)
                .dialog({
                    title: options.titulo || "Indústria Mineira de Joias",
                    draggable: true,
                    buttons: { "OK": function () { jQuery(this).dialog("close"); window.location.href = options.retorno; } }
                });
        });
    }
});

jQuery(function() {
    jQuery(".formulario button.enviar").click(function() {
        var jThis = jQuery(this);
        var incompleto = false;

        jThis.parents(".formulario").find(".obrigatorio").each(function() {
            if (incompleto)
                return;

            if (!jQuery(this).val() || jQuery(this).val() == "") {
                incompleto = true;
                jThis.after("<div id='notificacao-comunicacao'>É necessário preencher o campo "
                    + (jQuery(this).siblings("label[for=" + jQuery(this).attr("id") + "]").text() || jThis.attr("name")).replace(":", "")
                    + ".");
                jQuery("#notificacao-comunicacao").dialog({
                    closeOnEspace: true,
                    modal: true,
                    title: "Envio de Formulário",
                    close: function() {
                        $("#notificacao-comunicacao").remove();
                    },
                    buttons: {
                        "OK" : function() { jQuery(this).dialog("close"); }
                    }
                });
            }
        });

        if (!incompleto) {
            jQuery(this).attr("disabled", "disabled");
            jQuery(this).after("<div id='notificacao-comunicacao'>Aguarde o envio do formulário...</div>");
            jQuery("#notificacao-comunicacao").dialog({ closeOnEspace: false, modal: true, title: "Envio de Formulário" });
            jQuery(this).parents(".formulario").comunicar();
        }
    });
});
