﻿using Apresentação.Álbum.Edição.Álbuns;
using Entidades.Configuração;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Fotos
{
    public partial class IdentificaçãoMercadoria : UserControl
    {
        public delegate void AlteradoDelegate(string referênciaAnterior, string referênciaNova);
        public event AlteradoDelegate Alterado;

        /// <summary>
        /// Entidade do banco de dados;
        /// </summary>
        private Entidades.Álbum.Foto foto = null;

        /// <summary>
        /// Lista de álbuns que permitirá a seleção
        /// de álbuns para a foto da mercadoria editada.
        /// </summary>
        private ListaÁlbuns listaÁlbuns = null;

        /// <summary>
        /// Constrói o controle.
        /// </summary>
        public IdentificaçãoMercadoria()
        {
            InitializeComponent();

            if (!DadosGlobais.ModoDesenho)
                txtReferência.Tabela = Entidades.Tabela.TabelaPadrão;
        }

        #region Propriedades

        public bool TxtReferênciaEnabled
        {
            get { return txtReferência.Enabled; }
            set { txtReferência.Enabled = value; }
        }

        public string Referência => txtReferência.Txt.Text;

        /// <summary>
        /// Entidade do banco de dados.
        /// </summary>
        [DefaultValue(null), Browsable(false)]
        public Entidades.Álbum.Foto Foto
        {
            get { return foto; }
            set
            {
                Carregar(value);
            }
        }

        private void Carregar(Entidades.Álbum.Foto value)
        {
            if (value != null)
            {
                foto = value;

                /* Como a referência na foto não contém o dígito
                 * verificador, a referência deve ser completada
                 * pelo TxtMeracadoria.
                 */
                txtReferência.Referência = foto.ReferênciaFormatada;

                txtReferência.CompletarReferência();

                var mercadoria = txtReferência.Mercadoria;
                if (mercadoria != null)
                {
                    txtPeso.Double = mercadoria.Peso;
                    txtÍndice.Text = mercadoria.ÍndiceArredondado.ToString();
                }

                CarregarFornecedor();

                if (foto.Descrição != null)
                    txtDescrição.Text = foto.Descrição;
                else
                    txtDescrição.Text = "";

                if (foto.Data.HasValue)
                    txtData.Text = foto.Data.Value.ToLongDateString();
                else
                    txtData.Text = "N/D";

                if (listaÁlbuns != null)
                    listaÁlbuns.CarregarFotoParaAlteração(value);
            }
            else
                Limpar();
        }

        private void CarregarFornecedor()
        {

            Entidades.Mercadoria.MercadoriaFornecedor fornecedor = Entidades.Mercadoria.MercadoriaFornecedor.ObterFornecedor(foto.ReferênciaNumérica);

            if (fornecedor != null)
            {
                txtFornecedor.Text = fornecedor.FornecedorCódigo.ToString();
                txtFornecedorReferência.Text = fornecedor.ReferênciaFornecedorComFFL;
            }
            else
            {
                txtFornecedor.Text = "";
                txtFornecedorReferência.Text = "";
            }
        }

        private void CarregarPesoIndice(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            txtPeso.Text = mercadoria?.Peso.ToString();
            txtÍndice.Text = mercadoria?.ÍndiceArredondado.ToString();
        }

        /// <summary>
        /// Define o controle para manipulação dos álbuns
        /// atribuídos a esta foto.
        /// </summary>
        [DefaultValue(null), Browsable(true),
         Description("Controle utilizado para manipulação dos álbuns atribuídos à foto editada.")]
        public ListaÁlbuns ListaÁlbuns
        {
            get { return listaÁlbuns; }
            set
            {
                this.listaÁlbuns = value;

                if (listaÁlbuns != null && !DesignMode)
                    listaÁlbuns.Foto = this.foto;
            }
        }

        /// <summary>
        /// Mercadoria entrada.
        /// </summary>
        [Browsable(false)]
        public Entidades.Mercadoria.Mercadoria Mercadoria
        {
            get { return txtReferência.Mercadoria; }
        }

        #endregion

        /// <summary>
        /// Valida dados preenchidos
        /// </summary>
        /// <returns>Validação dos dados</returns>
        public bool ValidarDados()
        {
            return Referência.Length == 16;
        }

        /// <summary>
        /// Prepara o controle para entrada de novos dados.
        /// </summary>
        public void Limpar()
        {
            foto = new Entidades.Álbum.Foto();
            txtReferência.Txt.ResetText();
            txtDescrição.ResetText();
            txtFornecedor.ResetText();
            txtData.ResetText();
            txtÍndice.ResetText();

            if (listaÁlbuns != null)
                listaÁlbuns.Foto = foto;
        }

        /// <summary>
        /// Ocorre quando se pressiona alguma tecla na caixa de texto
        /// </summary>
        private void TxtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (txtReferência.Txt.Focused && txtReferência.Txt.Text.Length != txtReferência.Txt.MaxLength)
                return;

            Control próximo = this.GetNextControl((Control)sender, true);

            while (próximo as TextBox == null)
                próximo = GetNextControl(próximo, true);

            TextBox txt = próximo as TextBox;

            próximo.Focus();

            if (txt != null)
                txt.SelectAll();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            txtReferência.Focus();
        }

        /// <summary>
        /// Ocorre ao confirmar a referência digitada.
        /// </summary>
        private void txtReferência_ReferênciaConfirmada(object sender, EventArgs e)
        {
            string referênciaAnterior = foto.ReferênciaNumérica;
            foto.ReferênciaNumérica = txtReferência.ReferênciaNumérica;

            Entidades.Mercadoria.Mercadoria mercadoria = txtReferência.Mercadoria;

            txtDescriçãoMercadoria.Text = txtReferência.Mercadoria?.Descrição ?? "";

            CarregarPesoIndice(mercadoria);
            CarregarFornecedor();

            if (Alterado != null)
                Alterado(referênciaAnterior, txtReferência.ReferênciaNumérica);
        }
        
        /// <summary>
        /// Ocorre ao deixar o TxtDescrição.
        /// </summary>
        private void txtDescrição_Leave(object sender, EventArgs e)
        {
            foto.Descrição = txtDescrição.Text;

            if (Alterado != null)
                Alterado(txtReferência.ReferênciaNumérica, txtReferência.ReferênciaNumérica);
        }

        /// <summary>
        /// Ocorre ao ganhar foco em algum TextBox.
        /// Neste momento, cria-se a entidade caso
        /// nenhuma esteja sendo editada.
        /// </summary>
        private void AoGanharFocoEmTextBox(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            if (foto == null)
            {
                foto = new Entidades.Álbum.Foto();

                if (listaÁlbuns != null)
                    listaÁlbuns.Foto = foto;
            }
        }

        private void txtDescrição_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                GetNextControl(sender as Control, true).Focus();
                e.Handled = true;
            }
        }

        private void txtDescriçãoMercadoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                GetNextControl(sender as Control, true).Focus();
                e.Handled = true;
            }
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                GetNextControl(sender as Control, true).Focus();
                e.Handled = true;
            }
        }

        internal void Recarregar()
        {
            Carregar(Foto);
        }
    }
}
