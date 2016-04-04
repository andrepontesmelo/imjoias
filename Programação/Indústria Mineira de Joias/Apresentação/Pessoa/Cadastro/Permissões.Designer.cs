namespace Apresentação.Pessoa.Cadastro
{
    partial class Permissões
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpCadastro = new System.Windows.Forms.GroupBox();
            this.chkPermissãoAdicionarHistórico = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkCadastroRemover = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkCadastroEditar = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkCadastroAcesso = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.grpConsignado = new System.Windows.Forms.GroupBox();
            this.chkEscolherDocumentos = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkDataAcerto = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkZerarAcerto = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkConsignadoDestrancar = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkConsignadoRetorno = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkConsignadoSaída = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.grpFinanceiro = new System.Windows.Forms.GroupBox();
            this.chkPermissãoFaturamento = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkManipularComissão = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkPersonalizarVenda = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkVisualizarHistórico = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkEscolherTabela = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkVendasVerificar = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkVendasDestrancar = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkVendasEditar = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkVendasAcesso = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkFinanceiroCotação = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.grpBancoDados = new System.Windows.Forms.GroupBox();
            this.txtUsuário = new System.Windows.Forms.TextBox();
            this.lblUsuário = new System.Windows.Forms.Label();
            this.grpMercadoria = new System.Windows.Forms.GroupBox();
            this.chkPermissãoBalanço = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkPermissãoEstoque = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkPermissãoTécnico = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkPermissão1 = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkPedidosConsertos = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.chkEditarMercadorias = new Apresentação.Pessoa.Cadastro.ChkPermissão();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrivVendedor = new System.Windows.Forms.Button();
            this.grpCadastro.SuspendLayout();
            this.grpConsignado.SuspendLayout();
            this.grpFinanceiro.SuspendLayout();
            this.grpBancoDados.SuspendLayout();
            this.grpMercadoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCadastro
            // 
            this.grpCadastro.Controls.Add(this.chkPermissãoAdicionarHistórico);
            this.grpCadastro.Controls.Add(this.chkCadastroRemover);
            this.grpCadastro.Controls.Add(this.chkCadastroEditar);
            this.grpCadastro.Controls.Add(this.chkCadastroAcesso);
            this.grpCadastro.Location = new System.Drawing.Point(7, 32);
            this.grpCadastro.Name = "grpCadastro";
            this.grpCadastro.Size = new System.Drawing.Size(185, 116);
            this.grpCadastro.TabIndex = 0;
            this.grpCadastro.TabStop = false;
            this.grpCadastro.Text = "Cadastro de pessoas";
            // 
            // chkPermissãoAdicionarHistórico
            // 
            this.chkPermissãoAdicionarHistórico.Location = new System.Drawing.Point(6, 80);
            this.chkPermissãoAdicionarHistórico.Name = "chkPermissãoAdicionarHistórico";
            this.chkPermissãoAdicionarHistórico.Privilégio = Entidades.Privilégio.Permissão.CadastroAdicionarHistórico;
            this.chkPermissãoAdicionarHistórico.Size = new System.Drawing.Size(173, 30);
            this.chkPermissãoAdicionarHistórico.TabIndex = 3;
            this.chkPermissãoAdicionarHistórico.Text = "Adicionar informação no histórico";
            this.chkPermissãoAdicionarHistórico.UseVisualStyleBackColor = true;
            // 
            // chkCadastroRemover
            // 
            this.chkCadastroRemover.AutoSize = true;
            this.chkCadastroRemover.Location = new System.Drawing.Point(6, 65);
            this.chkCadastroRemover.Name = "chkCadastroRemover";
            this.chkCadastroRemover.Privilégio = Entidades.Privilégio.Permissão.CadastroRemover;
            this.chkCadastroRemover.Size = new System.Drawing.Size(113, 17);
            this.chkCadastroRemover.TabIndex = 2;
            this.chkCadastroRemover.Text = "Remover cadastro";
            this.chkCadastroRemover.UseVisualStyleBackColor = true;
            // 
            // chkCadastroEditar
            // 
            this.chkCadastroEditar.AutoSize = true;
            this.chkCadastroEditar.Location = new System.Drawing.Point(6, 42);
            this.chkCadastroEditar.Name = "chkCadastroEditar";
            this.chkCadastroEditar.Privilégio = Entidades.Privilégio.Permissão.CadastroEditar;
            this.chkCadastroEditar.Size = new System.Drawing.Size(135, 17);
            this.chkCadastroEditar.TabIndex = 1;
            this.chkCadastroEditar.Text = "Criar ou editar cadastro";
            this.chkCadastroEditar.UseVisualStyleBackColor = true;
            // 
            // chkCadastroAcesso
            // 
            this.chkCadastroAcesso.AutoSize = true;
            this.chkCadastroAcesso.Location = new System.Drawing.Point(6, 19);
            this.chkCadastroAcesso.Name = "chkCadastroAcesso";
            this.chkCadastroAcesso.Privilégio = Entidades.Privilégio.Permissão.CadastroAcesso;
            this.chkCadastroAcesso.Size = new System.Drawing.Size(114, 17);
            this.chkCadastroAcesso.TabIndex = 0;
            this.chkCadastroAcesso.Text = "Visualizar cadastro";
            this.chkCadastroAcesso.UseVisualStyleBackColor = true;
            // 
            // grpConsignado
            // 
            this.grpConsignado.Controls.Add(this.chkEscolherDocumentos);
            this.grpConsignado.Controls.Add(this.chkDataAcerto);
            this.grpConsignado.Controls.Add(this.chkZerarAcerto);
            this.grpConsignado.Controls.Add(this.chkConsignadoDestrancar);
            this.grpConsignado.Controls.Add(this.chkConsignadoRetorno);
            this.grpConsignado.Controls.Add(this.chkConsignadoSaída);
            this.grpConsignado.Location = new System.Drawing.Point(198, 84);
            this.grpConsignado.Name = "grpConsignado";
            this.grpConsignado.Size = new System.Drawing.Size(185, 158);
            this.grpConsignado.TabIndex = 1;
            this.grpConsignado.TabStop = false;
            this.grpConsignado.Text = "Consignado";
            // 
            // chkEscolherDocumentos
            // 
            this.chkEscolherDocumentos.AutoSize = true;
            this.chkEscolherDocumentos.Location = new System.Drawing.Point(6, 134);
            this.chkEscolherDocumentos.Name = "chkEscolherDocumentos";
            this.chkEscolherDocumentos.Privilégio = Entidades.Privilégio.Permissão.MoverDocumentoAcerto;
            this.chkEscolherDocumentos.Size = new System.Drawing.Size(167, 17);
            this.chkEscolherDocumentos.TabIndex = 6;
            this.chkEscolherDocumentos.Text = "Mover documentos em acerto";
            this.toolTip.SetToolTip(this.chkEscolherDocumentos, "Permite mover um documento de um acerto para outro. ");
            this.chkEscolherDocumentos.UseVisualStyleBackColor = true;
            // 
            // chkDataAcerto
            // 
            this.chkDataAcerto.AutoSize = true;
            this.chkDataAcerto.Location = new System.Drawing.Point(6, 111);
            this.chkDataAcerto.Name = "chkDataAcerto";
            this.chkDataAcerto.Privilégio = Entidades.Privilégio.Permissão.AlterarDataAcerto;
            this.chkDataAcerto.Size = new System.Drawing.Size(128, 17);
            this.chkDataAcerto.TabIndex = 5;
            this.chkDataAcerto.Text = "Alterar data de acerto";
            this.toolTip.SetToolTip(this.chkDataAcerto, "Permite que o funcionário altere a data de previsão de acerto e também permite qu" +
        "e o acerto marcado possa extrapolar o prazo máximo definido no sistema.");
            this.chkDataAcerto.UseVisualStyleBackColor = true;
            // 
            // chkZerarAcerto
            // 
            this.chkZerarAcerto.AutoSize = true;
            this.chkZerarAcerto.Location = new System.Drawing.Point(6, 88);
            this.chkZerarAcerto.Name = "chkZerarAcerto";
            this.chkZerarAcerto.Privilégio = Entidades.Privilégio.Permissão.ZerarAcerto;
            this.chkZerarAcerto.Size = new System.Drawing.Size(150, 17);
            this.chkZerarAcerto.TabIndex = 4;
            this.chkZerarAcerto.Text = "Zerar acerto que não bate";
            this.toolTip.SetToolTip(this.chkZerarAcerto, "Permite que o funcionário zere o acerto de mercadorias, mesmo que o acerto não es" +
        "teja batendo.\r\n\r\nVeja que acertos que batem podem ser zerados por qualquer vende" +
        "dor.");
            this.chkZerarAcerto.UseVisualStyleBackColor = true;
            // 
            // chkConsignadoDestrancar
            // 
            this.chkConsignadoDestrancar.AutoSize = true;
            this.chkConsignadoDestrancar.Location = new System.Drawing.Point(6, 65);
            this.chkConsignadoDestrancar.Name = "chkConsignadoDestrancar";
            this.chkConsignadoDestrancar.Privilégio = Entidades.Privilégio.Permissão.ConsignadoDestravar;
            this.chkConsignadoDestrancar.Size = new System.Drawing.Size(139, 17);
            this.chkConsignadoDestrancar.TabIndex = 3;
            this.chkConsignadoDestrancar.Text = "Destrancar documentos";
            this.chkConsignadoDestrancar.UseVisualStyleBackColor = true;
            // 
            // chkConsignadoRetorno
            // 
            this.chkConsignadoRetorno.AutoSize = true;
            this.chkConsignadoRetorno.Location = new System.Drawing.Point(6, 42);
            this.chkConsignadoRetorno.Name = "chkConsignadoRetorno";
            this.chkConsignadoRetorno.Privilégio = Entidades.Privilégio.Permissão.ConsignadoRetorno;
            this.chkConsignadoRetorno.Size = new System.Drawing.Size(156, 17);
            this.chkConsignadoRetorno.TabIndex = 2;
            this.chkConsignadoRetorno.Text = "Registrar retorno à empresa";
            this.chkConsignadoRetorno.UseVisualStyleBackColor = true;
            // 
            // chkConsignadoSaída
            // 
            this.chkConsignadoSaída.AutoSize = true;
            this.chkConsignadoSaída.Location = new System.Drawing.Point(6, 19);
            this.chkConsignadoSaída.Name = "chkConsignadoSaída";
            this.chkConsignadoSaída.Privilégio = Entidades.Privilégio.Permissão.ConsignadoSaída;
            this.chkConsignadoSaída.Size = new System.Drawing.Size(156, 17);
            this.chkConsignadoSaída.TabIndex = 1;
            this.chkConsignadoSaída.Text = "Registrar saída da empresa";
            this.chkConsignadoSaída.UseVisualStyleBackColor = true;
            // 
            // grpFinanceiro
            // 
            this.grpFinanceiro.Controls.Add(this.chkPermissãoFaturamento);
            this.grpFinanceiro.Controls.Add(this.chkManipularComissão);
            this.grpFinanceiro.Controls.Add(this.chkPersonalizarVenda);
            this.grpFinanceiro.Controls.Add(this.chkVisualizarHistórico);
            this.grpFinanceiro.Controls.Add(this.chkEscolherTabela);
            this.grpFinanceiro.Controls.Add(this.chkVendasVerificar);
            this.grpFinanceiro.Controls.Add(this.chkVendasDestrancar);
            this.grpFinanceiro.Controls.Add(this.chkVendasEditar);
            this.grpFinanceiro.Controls.Add(this.chkVendasAcesso);
            this.grpFinanceiro.Controls.Add(this.chkFinanceiroCotação);
            this.grpFinanceiro.Location = new System.Drawing.Point(7, 154);
            this.grpFinanceiro.Name = "grpFinanceiro";
            this.grpFinanceiro.Size = new System.Drawing.Size(185, 271);
            this.grpFinanceiro.TabIndex = 2;
            this.grpFinanceiro.TabStop = false;
            this.grpFinanceiro.Text = "Financeiro";
            // 
            // chkPermissãoFaturamento
            // 
            this.chkPermissãoFaturamento.AutoSize = true;
            this.chkPermissãoFaturamento.Location = new System.Drawing.Point(6, 248);
            this.chkPermissãoFaturamento.Name = "chkPermissãoFaturamento";
            this.chkPermissãoFaturamento.Privilégio = Entidades.Privilégio.Permissão.Faturamento;
            this.chkPermissãoFaturamento.Size = new System.Drawing.Size(85, 17);
            this.chkPermissãoFaturamento.TabIndex = 10;
            this.chkPermissãoFaturamento.Text = "Faturamento";
            this.chkPermissãoFaturamento.UseVisualStyleBackColor = true;
            // 
            // chkManipularComissão
            // 
            this.chkManipularComissão.AutoSize = true;
            this.chkManipularComissão.Location = new System.Drawing.Point(6, 226);
            this.chkManipularComissão.Name = "chkManipularComissão";
            this.chkManipularComissão.Privilégio = Entidades.Privilégio.Permissão.ManipularComissão;
            this.chkManipularComissão.Size = new System.Drawing.Size(119, 17);
            this.chkManipularComissão.TabIndex = 9;
            this.chkManipularComissão.Text = "Manipular comissão";
            this.chkManipularComissão.UseVisualStyleBackColor = true;
            // 
            // chkPersonalizarVenda
            // 
            this.chkPersonalizarVenda.AutoSize = true;
            this.chkPersonalizarVenda.Location = new System.Drawing.Point(6, 88);
            this.chkPersonalizarVenda.Name = "chkPersonalizarVenda";
            this.chkPersonalizarVenda.Privilégio = Entidades.Privilégio.Permissão.PersonalizarVenda;
            this.chkPersonalizarVenda.Size = new System.Drawing.Size(116, 17);
            this.chkPersonalizarVenda.TabIndex = 8;
            this.chkPersonalizarVenda.Text = "Personalizar venda";
            this.chkPersonalizarVenda.UseVisualStyleBackColor = true;
            // 
            // chkVisualizarHistórico
            // 
            this.chkVisualizarHistórico.Location = new System.Drawing.Point(6, 190);
            this.chkVisualizarHistórico.Name = "chkVisualizarHistórico";
            this.chkVisualizarHistórico.Privilégio = Entidades.Privilégio.Permissão.VisualizarDocumentosAntigos;
            this.chkVisualizarHistórico.Size = new System.Drawing.Size(173, 30);
            this.chkVisualizarHistórico.TabIndex = 7;
            this.chkVisualizarHistórico.Text = "Visualizar históricos e documentos antigos";
            this.chkVisualizarHistórico.UseVisualStyleBackColor = true;
            // 
            // chkEscolherTabela
            // 
            this.chkEscolherTabela.Location = new System.Drawing.Point(6, 152);
            this.chkEscolherTabela.Name = "chkEscolherTabela";
            this.chkEscolherTabela.Privilégio = Entidades.Privilégio.Permissão.EscolherQualquerTabela;
            this.chkEscolherTabela.Size = new System.Drawing.Size(173, 36);
            this.chkEscolherTabela.TabIndex = 6;
            this.chkEscolherTabela.Text = "Escolher qualquer tabela de preço em documentos";
            this.toolTip.SetToolTip(this.chkEscolherTabela, "Permite à pessoa escolher a tabela de preço a ser utilizada em uma venda ou saída" +
        " de consignado.\r\n\r\nLembre-se que vendedores podem, sem este privilégio, acessar " +
        "qualquer tabela atribuída a seu setor.");
            this.chkEscolherTabela.UseVisualStyleBackColor = true;
            // 
            // chkVendasVerificar
            // 
            this.chkVendasVerificar.AutoSize = true;
            this.chkVendasVerificar.Location = new System.Drawing.Point(6, 135);
            this.chkVendasVerificar.Name = "chkVendasVerificar";
            this.chkVendasVerificar.Privilégio = Entidades.Privilégio.Permissão.VendasVerificar;
            this.chkVendasVerificar.Size = new System.Drawing.Size(114, 17);
            this.chkVendasVerificar.TabIndex = 4;
            this.chkVendasVerificar.Text = "Autorizar comissão";
            this.chkVendasVerificar.UseVisualStyleBackColor = true;
            // 
            // chkVendasDestrancar
            // 
            this.chkVendasDestrancar.AutoSize = true;
            this.chkVendasDestrancar.Location = new System.Drawing.Point(6, 112);
            this.chkVendasDestrancar.Name = "chkVendasDestrancar";
            this.chkVendasDestrancar.Privilégio = Entidades.Privilégio.Permissão.VendasDestravar;
            this.chkVendasDestrancar.Size = new System.Drawing.Size(111, 17);
            this.chkVendasDestrancar.TabIndex = 3;
            this.chkVendasDestrancar.Text = "Destrancar venda";
            this.toolTip.SetToolTip(this.chkVendasDestrancar, "Permite destrancar uma venda, possibilitando a sua alteração mesmo depois de impr" +
        "essa.");
            this.chkVendasDestrancar.UseVisualStyleBackColor = true;
            // 
            // chkVendasEditar
            // 
            this.chkVendasEditar.AutoSize = true;
            this.chkVendasEditar.Location = new System.Drawing.Point(6, 65);
            this.chkVendasEditar.Name = "chkVendasEditar";
            this.chkVendasEditar.Privilégio = Entidades.Privilégio.Permissão.VendasEditar;
            this.chkVendasEditar.Size = new System.Drawing.Size(101, 17);
            this.chkVendasEditar.TabIndex = 2;
            this.chkVendasEditar.Text = "Registrar venda";
            this.toolTip.SetToolTip(this.chkVendasEditar, "Permite o registro de vendas no sistema.");
            this.chkVendasEditar.UseVisualStyleBackColor = true;
            // 
            // chkVendasAcesso
            // 
            this.chkVendasAcesso.AutoSize = true;
            this.chkVendasAcesso.Location = new System.Drawing.Point(6, 42);
            this.chkVendasAcesso.Name = "chkVendasAcesso";
            this.chkVendasAcesso.Privilégio = Entidades.Privilégio.Permissão.VendasLeitura;
            this.chkVendasAcesso.Size = new System.Drawing.Size(108, 17);
            this.chkVendasAcesso.TabIndex = 1;
            this.chkVendasAcesso.Text = "Visualizar vendas";
            this.toolTip.SetToolTip(this.chkVendasAcesso, "Permite a visualização de vendas realizadas por um representante ou funcionário o" +
        "u ainda vendas realizadas para um cliente.");
            this.chkVendasAcesso.UseVisualStyleBackColor = true;
            // 
            // chkFinanceiroCotação
            // 
            this.chkFinanceiroCotação.AutoSize = true;
            this.chkFinanceiroCotação.Location = new System.Drawing.Point(6, 19);
            this.chkFinanceiroCotação.Name = "chkFinanceiroCotação";
            this.chkFinanceiroCotação.Privilégio = Entidades.Privilégio.Permissão.EditarCotação;
            this.chkFinanceiroCotação.Size = new System.Drawing.Size(95, 17);
            this.chkFinanceiroCotação.TabIndex = 0;
            this.chkFinanceiroCotação.Text = "Editar cotação";
            this.chkFinanceiroCotação.UseVisualStyleBackColor = true;
            // 
            // grpBancoDados
            // 
            this.grpBancoDados.Controls.Add(this.txtUsuário);
            this.grpBancoDados.Controls.Add(this.lblUsuário);
            this.grpBancoDados.Location = new System.Drawing.Point(197, 32);
            this.grpBancoDados.Name = "grpBancoDados";
            this.grpBancoDados.Size = new System.Drawing.Size(185, 49);
            this.grpBancoDados.TabIndex = 3;
            this.grpBancoDados.TabStop = false;
            this.grpBancoDados.Text = "Banco de dados";
            // 
            // txtUsuário
            // 
            this.txtUsuário.Location = new System.Drawing.Point(62, 19);
            this.txtUsuário.Name = "txtUsuário";
            this.txtUsuário.Size = new System.Drawing.Size(117, 20);
            this.txtUsuário.TabIndex = 1;
            this.txtUsuário.Leave += new System.EventHandler(this.txtUsuário_Leave);
            // 
            // lblUsuário
            // 
            this.lblUsuário.AutoSize = true;
            this.lblUsuário.Location = new System.Drawing.Point(6, 22);
            this.lblUsuário.Name = "lblUsuário";
            this.lblUsuário.Size = new System.Drawing.Size(46, 13);
            this.lblUsuário.TabIndex = 0;
            this.lblUsuário.Text = "Usuário:";
            // 
            // grpMercadoria
            // 
            this.grpMercadoria.Controls.Add(this.chkPermissãoBalanço);
            this.grpMercadoria.Controls.Add(this.chkPermissãoEstoque);
            this.grpMercadoria.Controls.Add(this.chkPermissãoTécnico);
            this.grpMercadoria.Controls.Add(this.chkPermissão1);
            this.grpMercadoria.Controls.Add(this.chkPedidosConsertos);
            this.grpMercadoria.Controls.Add(this.chkEditarMercadorias);
            this.grpMercadoria.Location = new System.Drawing.Point(197, 248);
            this.grpMercadoria.Name = "grpMercadoria";
            this.grpMercadoria.Size = new System.Drawing.Size(185, 171);
            this.grpMercadoria.TabIndex = 4;
            this.grpMercadoria.TabStop = false;
            this.grpMercadoria.Text = "Outros";
            // 
            // chkPermissãoBalanço
            // 
            this.chkPermissãoBalanço.Location = new System.Drawing.Point(6, 147);
            this.chkPermissãoBalanço.Name = "chkPermissãoBalanço";
            this.chkPermissãoBalanço.Privilégio = Entidades.Privilégio.Permissão.Balanço;
            this.chkPermissãoBalanço.Size = new System.Drawing.Size(173, 24);
            this.chkPermissãoBalanço.TabIndex = 3;
            this.chkPermissãoBalanço.Text = "Balanço";
            this.chkPermissãoBalanço.UseVisualStyleBackColor = true;
            // 
            // chkPermissãoEstoque
            // 
            this.chkPermissãoEstoque.Location = new System.Drawing.Point(6, 125);
            this.chkPermissãoEstoque.Name = "chkPermissãoEstoque";
            this.chkPermissãoEstoque.Privilégio = Entidades.Privilégio.Permissão.Estoque;
            this.chkPermissãoEstoque.Size = new System.Drawing.Size(173, 24);
            this.chkPermissãoEstoque.TabIndex = 3;
            this.chkPermissãoEstoque.Text = "Estoque";
            this.chkPermissãoEstoque.UseVisualStyleBackColor = true;
            // 
            // chkPermissãoTécnico
            // 
            this.chkPermissãoTécnico.Location = new System.Drawing.Point(6, 95);
            this.chkPermissãoTécnico.Name = "chkPermissãoTécnico";
            this.chkPermissãoTécnico.Privilégio = Entidades.Privilégio.Permissão.Técnico;
            this.chkPermissãoTécnico.Size = new System.Drawing.Size(173, 30);
            this.chkPermissãoTécnico.TabIndex = 3;
            this.chkPermissãoTécnico.Text = "Acesso Técnico-Administrativo";
            this.chkPermissãoTécnico.UseVisualStyleBackColor = true;
            // 
            // chkPermissão1
            // 
            this.chkPermissão1.Location = new System.Drawing.Point(6, 68);
            this.chkPermissão1.Name = "chkPermissão1";
            this.chkPermissão1.Privilégio = Entidades.Privilégio.Permissão.Álbum;
            this.chkPermissão1.Size = new System.Drawing.Size(173, 30);
            this.chkPermissão1.TabIndex = 2;
            this.chkPermissão1.Text = "Acesso ao álbum de fotografias";
            this.chkPermissão1.UseVisualStyleBackColor = true;
            // 
            // chkPedidosConsertos
            // 
            this.chkPedidosConsertos.Location = new System.Drawing.Point(6, 47);
            this.chkPedidosConsertos.Name = "chkPedidosConsertos";
            this.chkPedidosConsertos.Privilégio = Entidades.Privilégio.Permissão.EditarPedidosConsertos;
            this.chkPedidosConsertos.Size = new System.Drawing.Size(173, 30);
            this.chkPedidosConsertos.TabIndex = 1;
            this.chkPedidosConsertos.Text = "Alterar pedidos/consertos";
            this.chkPedidosConsertos.UseVisualStyleBackColor = true;
            // 
            // chkEditarMercadorias
            // 
            this.chkEditarMercadorias.Location = new System.Drawing.Point(6, 14);
            this.chkEditarMercadorias.Name = "chkEditarMercadorias";
            this.chkEditarMercadorias.Privilégio = Entidades.Privilégio.Permissão.EditarMercadorias;
            this.chkEditarMercadorias.Size = new System.Drawing.Size(173, 37);
            this.chkEditarMercadorias.TabIndex = 0;
            this.chkEditarMercadorias.Text = "Cadastrar mercadorias e atualizar tabela de preços";
            this.chkEditarMercadorias.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Privilégio";
            // 
            // btnPrivVendedor
            // 
            this.btnPrivVendedor.AutoSize = true;
            this.btnPrivVendedor.Location = new System.Drawing.Point(7, 3);
            this.btnPrivVendedor.Name = "btnPrivVendedor";
            this.btnPrivVendedor.Size = new System.Drawing.Size(159, 23);
            this.btnPrivVendedor.TabIndex = 5;
            this.btnPrivVendedor.Text = "Definir privilégios de vendedor";
            this.btnPrivVendedor.UseVisualStyleBackColor = true;
            this.btnPrivVendedor.Click += new System.EventHandler(this.btnPrivVendedor_Click);
            // 
            // Permissões
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnPrivVendedor);
            this.Controls.Add(this.grpMercadoria);
            this.Controls.Add(this.grpBancoDados);
            this.Controls.Add(this.grpFinanceiro);
            this.Controls.Add(this.grpConsignado);
            this.Controls.Add(this.grpCadastro);
            this.Name = "Permissões";
            this.Size = new System.Drawing.Size(392, 432);
            this.grpCadastro.ResumeLayout(false);
            this.grpCadastro.PerformLayout();
            this.grpConsignado.ResumeLayout(false);
            this.grpConsignado.PerformLayout();
            this.grpFinanceiro.ResumeLayout(false);
            this.grpFinanceiro.PerformLayout();
            this.grpBancoDados.ResumeLayout(false);
            this.grpBancoDados.PerformLayout();
            this.grpMercadoria.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCadastro;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkCadastroRemover;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkCadastroEditar;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkCadastroAcesso;
        private System.Windows.Forms.GroupBox grpConsignado;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkConsignadoSaída;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkConsignadoRetorno;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkConsignadoDestrancar;
        private System.Windows.Forms.GroupBox grpFinanceiro;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkFinanceiroCotação;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkVendasEditar;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkVendasAcesso;
        private Apresentação.Pessoa.Cadastro.ChkPermissão chkVendasDestrancar;
        private System.Windows.Forms.GroupBox grpBancoDados;
        private System.Windows.Forms.TextBox txtUsuário;
        private System.Windows.Forms.Label lblUsuário;
        private ChkPermissão chkVendasVerificar;
        private ChkPermissão chkZerarAcerto;
        private System.Windows.Forms.GroupBox grpMercadoria;
        private ChkPermissão chkEditarMercadorias;
        private ChkPermissão chkPermissãoAdicionarHistórico;
        private ChkPermissão chkEscolherTabela;
        private ChkPermissão chkDataAcerto;
        private ChkPermissão chkEscolherDocumentos;
        private ChkPermissão chkVisualizarHistórico;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnPrivVendedor;
        private ChkPermissão chkPersonalizarVenda;
        private ChkPermissão chkPedidosConsertos;
        private ChkPermissão chkPermissão1;
        private ChkPermissão chkManipularComissão;
        private ChkPermissão chkPermissãoTécnico;
        private ChkPermissão chkPermissãoFaturamento;
        private ChkPermissão chkPermissãoBalanço;
        private ChkPermissão chkPermissãoEstoque;
    }
}
