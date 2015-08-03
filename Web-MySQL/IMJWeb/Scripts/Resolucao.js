var Resolucao = (function () {
    var href = "";
    var estilos = [
        {
            altura: 500,
            href: "Estilos-800x600"
        },
        {
            altura: 800,
            href: "Estilos"
        },
        {
            altura: Infinity,
            href: "Estilos-1280x1024"
        }
    ];
    var estiloPadrao = "Estilos";
    var estiloAtual = "Estilos";
    var estilosCss = new Array();
    var obj = {
        // Adaptado de http://www.howtocreate.co.uk/tutorials/javascript/browserwindow
        calcularDimensoes: function () {
            var dimensions = { width: 0, height: 0 };

            if (typeof (window.innerWidth) == 'number') {
                //Non-IE
                dimensions.width = window.innerWidth;
                dimensions.height = window.innerHeight;
            } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
                //IE 6+ in 'standards compliant mode'
                dimensions.width = document.documentElement.clientWidth;
                dimensions.height = document.documentElement.clientHeight;
            } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
                //IE 4 compatible
                dimensions.width = document.body.clientWidth;
                dimensions.height = document.body.clientHeight;
            }

            if (dimensions.height > 0)
                return dimensions;
            else
                return window.screen;
        },

        registrarCss: function (css) {
            estilosCss.push(css);

            if (estiloAtual != estiloPadrao) {
                loadjscssfile(estiloPadrao + "/" + css, "css");
                loadjscssfile(estiloAtual + "/" + css, "css");
            }
        },

        definirHRef: function (url) {
            href = url;
        }
    };

    obj.registrarCss("Personalizacao.css");
    obj.registrarCss("Cabecalho.css");
    obj.registrarCss("Rodape.css");
    obj.registrarCss("Conteudo.css");

    // Função obtida de http://www.javascriptkit.com/javatutors/loadjavascriptcss.shtml
    function loadjscssfile(filename, filetype) {
        if (filetype == "js") { //if filename is a external JavaScript file
            var fileref = document.createElement('script')
            fileref.setAttribute("type", "text/javascript")
            fileref.setAttribute("src", href + filename)
        }
        else if (filetype == "css") { //if filename is an external CSS file
            var fileref = document.createElement("link")
            fileref.setAttribute("rel", "stylesheet")
            fileref.setAttribute("type", "text/css")
            fileref.setAttribute("href", href + filename)
        }
        if (typeof fileref != "undefined") {
            var elemento = document.getElementsByTagName("head")[0].appendChild(fileref);

            $(fileref).load(function () {
                $(window).resize();
            });

            $(fileref).ready(function () {
                $(window).resize();
            });
        }
    }

    function verificarTamanho() {
        for (var i = 0; i < estilos.length; i++) {
            var estilo = estilos[i];

            if (estilo.altura >= obj.calcularDimensoes().height) {
                if (estiloAtual != estilo.href) {
                    estiloAtual = estilo.href;
                    for (var j = 0; j < estilosCss.length; j++)
                        loadjscssfile(estiloPadrao + "/" + estilosCss[j], "css");
                    for (var j = 0; j < estilosCss.length; j++)
                        loadjscssfile(estiloAtual + "/" + estilosCss[j], "css");
                }
                break;
            }
        }
    }

    $(verificarTamanho);
    $(window).resize(verificarTamanho);

    return obj;
})();
