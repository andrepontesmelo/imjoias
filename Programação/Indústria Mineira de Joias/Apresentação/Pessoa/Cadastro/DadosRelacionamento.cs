/*
 *
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    /// <summary>
    /// Fornece entrada de relacionamento inter-pessoal.
    /// </summary>
    public partial class DadosRelacionamento : UserControl, Apresentação.Formulários.IEditorItem<RelacionamentoInterpessoal>
    {
        private RelacionamentoInterpessoal relacionamento;
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// Dicionário de valores do tipo de relacionamento.
        /// </summary>
        private Dictionary<string, TipoRelacionamento> hashValorTipo;
        private Dictionary<TipoRelacionamento, string> hashTipoValor;


        public DadosRelacionamento()
        {
            InitializeComponent();

            hashValorTipo = new Dictionary<string, TipoRelacionamento>();
            hashTipoValor = new Dictionary<TipoRelacionamento, string>();

            AdicionarTipo(TipoRelacionamento.Amigo, "Amigo(a)");
            AdicionarTipo(TipoRelacionamento.Avô, "Avô(ó)");
            AdicionarTipo(TipoRelacionamento.Bisavô, "Bisavô(ó)");
            AdicionarTipo(TipoRelacionamento.Bisneto, "Bisneto(a)");
            AdicionarTipo(TipoRelacionamento.Empregador, "Empregador(a)");
            AdicionarTipo(TipoRelacionamento.Filho, "Filho(a)");
            AdicionarTipo(TipoRelacionamento.Funcionário, "Funcionário(a)");
            AdicionarTipo(TipoRelacionamento.Irmão, "Irmão(ã)");
            AdicionarTipo(TipoRelacionamento.Mãe, "Mãe");
            AdicionarTipo(TipoRelacionamento.Neto, "Neto(a)");
            AdicionarTipo(TipoRelacionamento.Pai, "Pai");
            AdicionarTipo(TipoRelacionamento.Primo, "Primo(a) de 1o grau");
            AdicionarTipo(TipoRelacionamento.Primo2o, "Primo(a) de 2o grau");
            AdicionarTipo(TipoRelacionamento.Representante, "Representante");
            AdicionarTipo(TipoRelacionamento.Sobrinho, "Sobrinho(a)");
            AdicionarTipo(TipoRelacionamento.Tio, "Tio(a)");
            AdicionarTipo(TipoRelacionamento.Esposo, "Esposo(a)");
            AdicionarTipo(TipoRelacionamento.Namorado, "Namorado(a)");
            AdicionarTipo(TipoRelacionamento.Colega, "Colega");
            AdicionarTipo(TipoRelacionamento.Cunhado, "Cunhado(a)");
            AdicionarTipo(TipoRelacionamento.Genro, "Genro(Nora)");
            AdicionarTipo(TipoRelacionamento.Sogro, "Sogro(a)");
            AdicionarTipo(TipoRelacionamento.VendePara, "Vende para");
            AdicionarTipo(TipoRelacionamento.CompraDe, "Compra de");
            AdicionarTipo(TipoRelacionamento.Desconhecido, " (?) ");

            EventHandler aoFocarControle = new EventHandler(AoFocarControle);

            foreach (Control controle in Controls)
                controle.GotFocus += aoFocarControle;
        }

        /// <summary>
        /// Constrói o controle de entrada de relacionamento inter-pessoal.
        /// </summary>
        /// <param name="pessoa">Pessoa cujo relacionamento está em edição.</param>
        public DadosRelacionamento(Entidades.Pessoa.Pessoa pessoa)
            : this()
        {
            if (pessoa == null)
                throw new ArgumentNullException("pessoa");

            this.pessoa = pessoa;

            relacionamento = new RelacionamentoInterpessoal();
            relacionamento.Pessoa1 = pessoa;
            txtPessoa.Focus();
        }

        /// <summary>
        /// Constrói o controle de entrada de relacionamento inter-pessoal.
        /// </summary>
        /// <param name="pessoa">Pessoa cujo relacionamento está em edição.</param>
        /// <param name="relacionamento">Relacionamento em edição.</param>
        public DadosRelacionamento(Entidades.Pessoa.Pessoa pessoa, RelacionamentoInterpessoal relacionamento)
            : this(pessoa)
        {
            if (!pessoa.Equals(relacionamento.Pessoa1) && !pessoa.Equals(relacionamento.Pessoa2))
                throw new ArgumentException("Pessoa deve fazer parte do relacionamento.", "pessoa");

            this.pessoa = pessoa;

            Item = relacionamento;
        }

        #region Propriedades

        /// <summary>
        /// Pessoa utilizada como referência. O relacionamento
        /// editado diz respeito desta pessoa.
        /// </summary>
        [Browsable(false), ReadOnly(true), DefaultValue(null)]
        public Entidades.Pessoa.Pessoa Referência
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        /// <summary>
        /// Entidade de relacionamento.
        /// </summary>
        [Browsable(false), ReadOnly(true), DefaultValue(null)]
        public RelacionamentoInterpessoal Item
        {
            get { return relacionamento; }
            set
            {
                this.relacionamento = value;

                if (value == null)
                    txtPessoa.Text = "";
                else
                {
                    System.Diagnostics.Debug.Assert(pessoa != null, "Atribua a propriedade Pessoa antes de definir os itens.");

                    if (pessoa.Equals(value.Pessoa1))
                    {
                        txtPessoa.Pessoa = value.Pessoa2;
                        
                        if (value.Pessoa2 != null)
                            cmbTipo.SelectedItem = hashTipoValor[value.Pessoa2.ObterRelacionamento(pessoa)];
                    }
                    else
                    {
                        txtPessoa.Pessoa = value.Pessoa1;
                        cmbTipo.SelectedItem = value.TipoRelacionamento;
                    }

                    if (value.Pessoa1 != null && value.Pessoa2 != null)
                        chkIndicação.Text = String.Format(
                            "{0} indicou {1}.",
                            value.Pessoa2.PrimeiroNome,
                            value.Pessoa1.PrimeiroNome);

                    chkIndicação.Checked = value.Indicação;
                }
            }
        }

        #endregion

        /// <summary>
        /// Adiciona um tipo de relacionamento ao controle.
        /// </summary>
        /// <param name="tipo">Tipo de relacionamento.</param>
        /// <param name="valor">Valor literal do tipo a ser exibido ao usuário.</param>
        private void AdicionarTipo(TipoRelacionamento tipo, string valor)
        {
            hashValorTipo.Add(valor, tipo);
            hashTipoValor.Add(tipo, valor);

            cmbTipo.Items.Add(valor);
        }

        /// <summary>
        /// Ocorre ao selecionar uma pessoa, atualizando a entidade.
        /// </summary>
        private void txtPessoa_Selecionado(object sender, EventArgs e)
        {
            if (relacionamento.Pessoa1.Equals(pessoa))
                relacionamento.Pessoa2 = txtPessoa.Pessoa;
            else
                relacionamento.Pessoa1 = txtPessoa.Pessoa;

            if (relacionamento.Pessoa1 != null &&
                relacionamento.Pessoa2 != null &&
                relacionamento.Pessoa1.Nome != null &&
                relacionamento.Pessoa2.Nome != null)
            {
                chkIndicação.Text = String.Format(
                    "{0} indicou {1}.",
                    relacionamento.Pessoa2.PrimeiroNome,
                    relacionamento.Pessoa1.PrimeiroNome);
            }
        }

        /// <summary>
        /// Ocorre ao validar um tipo, atualizando a entidade.
        /// </summary>
        private void cmbTipo_Validated(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem != null)
            {
                if (relacionamento.Pessoa1.Equals(pessoa))
                    relacionamento.TipoRelacionamento = RelacionamentoInterpessoal.InverterRelacionamento(hashValorTipo[(string)cmbTipo.SelectedItem]);
                else
                    relacionamento.TipoRelacionamento = hashValorTipo[(string)cmbTipo.SelectedItem];
            }
        }

        private void AoFocarControle(object sender, EventArgs e)
        {
            OnGotFocus(e);
        }

        private void chkIndicação_CheckedChanged(object sender, EventArgs e)
        {
            relacionamento.Indicação = chkIndicação.Checked;
        }
    }
}
*/