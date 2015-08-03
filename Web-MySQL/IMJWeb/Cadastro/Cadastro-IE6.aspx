<%@ Page Title="Indústria Mineira de Jóias - Cadastro" Language="C#" MasterPageFile="~/Leiaute.Master"
    AutoEventWireup="true" CodeBehind="Cadastro-IE6.aspx.cs" Inherits="IMJWeb.Cadastro.Cadastro_IE6" %>

<%@ Register Src="~/Controles/LblTextBox.ascx" TagName="LblTextBox" TagPrefix="imj" %>
<asp:Content ID="PreHeader" ContentPlaceHolderID="prehead" runat="server">
    <meta name="description" content="Cadastro de cliente logistas e revendedores da Indústria Mineira de Joia ou para solicitação de nossos representantes." />
    <meta name="keyword" content="logista,revendedor,representante" lang="pt-br" />
    <meta name="ROBOTS" content="NOINDEX,NOFOLLOW">
</asp:Content>
<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilos/Formularios-IE6.css" rel="stylesheet" type="text/css" media="screen" />

    <script src="../Scripts/Comunicacao.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript" defer="defer">
        jQuery.comunicar.padrao.raiz = '<%= ResolveUrl("~/") %>';
        jQuery.comunicar.padrao.categoria = 'Cadastro';
        jQuery.comunicar.padrao.mensagemSucesso = 'Agradecemos o envio de seu cadastro e entraremos em contato para vermos a possibilidade da visita de nosso representante.';
    </script>

</asp:Content>
<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="server">
    Cadastro
</asp:Content>
<asp:Content ID="Conteudo" ContentPlaceHolderID="Conteudo" runat="server">
    <div id="cadastro">
        <p id="disponibilidade">
            Cadastro disponível apenas para <strong>logistas</strong>, <strong>revendedores</strong>
            e clientes que queiram começar a revender. É necessário preencher todos os dados,
            inclusive se já for cliente,
            para atualização de cadastro e para se ter acesso a todo o catálogo de mercadorias
            da Indústria Mineira de Joias.
        </div>
        <p>
            O usuário e a senha para acesso ao catálogo será liberado por e-mail apenas após aprovação da empresa.
        </p>
        <p>
            Em caso de dúvida, entre em contato por meio do telefone (31) 3057-7555 falar com
            nosso gerente Antônio Casarim.
        </p>
        <p><center><button id="btnCiente" onclick="javascript:$('#btnCiente').hide();$('#formulario').show();return false;">Estou ciente</button></center></p>
        <div class="formulario" style="display: none" id="formulario">
            <h4>Pessoa Jurídica</h4>
            <div class="pj" id="formularioPJ" style="padding-top: 1em">
                <imj:LblTextBox Obrigatorio="true" ID="pjRazaoSocial" Texto="Razão Social" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjLoja" Texto="Loja" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjEndereco" Texto="Endereço" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjBairro" Texto="Bairro" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjCEP" Texto="CEP" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjCidade" Texto="Cidade" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjEstado" Texto="Estado" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjCNPJ" Texto="CNPJ" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjInscEstadual" Texto="Insc. Estadual" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjTelefones" Texto="Telefones" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="pjEmail" Texto="E-Mail" runat="server" />
                <div class="referencias">
                    <p class="grupo">
                        Referências:</p>
                    <div class="contato">
                        <imj:LblTextBox ID="pjEmpresa1" Texto="Empresa 1" runat="server" />
                        <imj:LblTextBox ID="pjTelEmpresa1" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="pjEmpresa2" Texto="Empresa 2" runat="server" />
                        <imj:LblTextBox ID="pjTelEmpresa2" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="pjEmpresa3" Texto="Empresa 3" runat="server" />
                        <imj:LblTextBox ID="pjTelEmpresa3" Texto="Telefone" runat="server" />
                    </div>
                </div>
                <div class="botoes">
                    Para efetuar o cadastro de pessoa jurídica, preencha também o cadastro de pessoa
                    física.
                </div>
            </div>
            <h4>Pessoa Física</h4>
            <div class="pf" style="padding-top: 1em">
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox1" Texto="Nome" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox3" Texto="Endereço" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox4" Texto="Bairro" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox5" Texto="CEP" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox6" Texto="Cidade" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox7" Texto="Estado" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox8" Texto="CPF" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox9" Texto="Identidade" runat="server" />
                <imj:LblTextBox ID="LblTextBox18" Texto="Filiação" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox2" Texto="Data nasc." runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox10" Texto="Telefones" runat="server" />
                <imj:LblTextBox Obrigatorio="true" ID="LblTextBox11" Texto="E-Mail Pessoal:" runat="server" />
                <div>
                    <p class="grupo">
                        Cônjuge:</p>
                    <label>
                        Estado civil:</label>
                        <div class="radio">
                    <input type="radio" id="pfSolteiro" name="pfEstadoCivil" value="Solteiro(a)" /><label
                        for="pfSolteiro">Solteiro(a)</label>
                    <input type="radio" id="pfCasado" name="pfEstadoCivil" value="Casado(a)" /><label
                        for="pfCasado">Casado(a)</label>
                    <input type="radio" id="pfDivorciado" name="pfEstadoCivil" value="Divorciado(a)" /><label
                        for="pfDivorciado">Divorciado(a)</label>
                    <input type="radio" id="pfViuvo" name="pfEstadoCivil" value="Viúvo(a)" /><label for="pfViuvo">Viúvo(a)</label>
                    </div>
                    <imj:LblTextBox ID="LblTextBox19" Texto="Nome do Cônjuge" runat="server" />
                    <imj:LblTextBox ID="LblTextBox20" Texto="CPF do Cônjuge" runat="server" />
                </div>
                <div class="referencias">
                    <p class="grupo">
                        Referências: (preencha preferencialmente com empresas ou representantes de joias)</p>
                    <div class="contato">
                        <imj:LblTextBox ID="LblTextBox12" Texto="Empresa 1" runat="server" />
                        <imj:LblTextBox ID="LblTextBox13" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="LblTextBox14" Texto="Empresa 2" runat="server" />
                        <imj:LblTextBox ID="LblTextBox15" Texto="Telefone" runat="server" />
                    </div>
                    <div class="contato">
                        <imj:LblTextBox ID="LblTextBox16" Texto="Empresa 3" runat="server" />
                        <imj:LblTextBox ID="LblTextBox17" Texto="Telefone" runat="server" />
                    </div>
                    <p class="grupo">
                        Referência bancária:</p>
                    <imj:LblTextBox ID="LblTextBox21" Texto="Banco" runat="server" />
                    <imj:LblTextBox ID="LblTextBox22" Texto="Agência" runat="server" />
                    <imj:LblTextBox ID="LblTextBox23" Texto="Cliente desde" runat="server" />
                </div>
                <label>
                    Faço compras em:</label>
                    <div class="radio">
                <input type="radio" id="pfEmMeuNome" name="pfComprasEm" value="Faço compras em meu nome"
                    onclick="$('.pj .obrigatorio').removeClass('obrigatorio');" /><label for="pfEmMeuNome">meu
                        nome</label>
                <input type="radio" id="pfPelaEmpresa" name="pfComprasEm" value="Faço compras em nome da minha empresa"
                    onclick="$('.pj input:not(.opcional)').addClass('obrigatorio');" /><label for="pfPelaEmpresa">nome
                        da minha empresa</label>
                        </div>
                <div class="botoes">
                    <button type="button" class="enviar">
                        Enviar</button>
                </div>
                <br />
            </div>
        </div>
    </div>

</asp:Content>
