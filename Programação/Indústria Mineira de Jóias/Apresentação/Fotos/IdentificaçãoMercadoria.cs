using Apresentação.Álbum.Edição.Álbuns;
using Apresentação.Formulários.Fornecedor;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Fotos
{
    public partial class IdentificaçãoMercadoria : UserControl
    {
        /// <summary>
        /// Ocorre quando usuário altera algum dado.
        /// </summary>
        public event EventHandler Alterado;

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
        }

        #region Propriedades

        public bool TxtReferênciaEnabled
        {
            get { return txtReferência.Enabled; }
            set { txtReferência.Enabled = value; }
        }

        /// <summary>
        /// Entidade do banco de dados.
        /// </summary>
        [DefaultValue(null), Browsable(false)]
        public Entidades.Álbum.Foto Foto
        {
            get { return foto; }
            set
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
                    
                    if (foto.Peso.HasValue)
                        txtPeso.Double = foto.Peso.Value;
                    
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
        }

        private void CarregarFornecedor()
        {

            Entidades.Mercadoria.MercadoriaFornecedor fornecedor = Entidades.Mercadoria.MercadoriaFornecedor.ObterFornecedor(foto.ReferênciaNumérica);
            if (fornecedor != null)
            {
                txtFornecedor.Txt.Text = fornecedor.Fornecedor.Nome;
                txtFornecedorReferência.Text = fornecedor.ReferênciaFornecedor;
            }
            else
            {
                txtFornecedor.Txt.Text = "";
                txtFornecedorReferência.Text = "";
            }
        }

        private void CarregarPeso(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            if (!mercadoria.DePeso)
                foto.Peso = null;

            txtPeso.Text = mercadoria.Peso.ToString();
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
            return txtReferência.Txt.Text.Length == 16;
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

            if (listaÁlbuns != null)
                listaÁlbuns.Foto = foto;
        }

        /// <summary>
        /// Ocorre quando se pressiona alguma tecla na caixa de texto
        /// </summary>
        private void TxtKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtReferência.Txt.Focused && txtReferência.Txt.Text.Length != txtReferência.Txt.MaxLength)
                    return;

                Control próximo = this.GetNextControl((Control)sender, true);

                // Salta controles não TextBox e não TxtFornecedor
                while ((próximo as TextBox == null) &&
                    (próximo as TxtFornecedor == null))
                    próximo = this.GetNextControl(próximo, true);

                TextBox txt = próximo as TextBox;

                próximo.Focus();

                if (txt != null)
                    txt.SelectAll();
            }
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
            foto.ReferênciaNumérica = txtReferência.ReferênciaNumérica;

            Entidades.Mercadoria.Mercadoria mercadoria = txtReferência.Mercadoria;

            txtDescriçãoMercadoria.Text = txtReferência.Mercadoria.Descrição ?? "";

            CarregarPeso(mercadoria);
            CarregarFornecedor();

            if (Alterado != null)
                Alterado(sender, e);
        }

        /// <summary>
        /// Ocorre ao deixar o TxtPeso.
        /// </summary>
        private void txtPeso_Leave(object sender, EventArgs e)
        {
            if (txtPeso.Enabled && txtPeso.Double > 0)
                foto.Peso = txtPeso.Double;
            else
                foto.Peso = null;
            
            
            if (Alterado != null)
                Alterado(sender, e);
        }
        
        /// <summary>
        /// Ocorre ao deixar o TxtDescrição.
        /// </summary>
        private void txtDescrição_Leave(object sender, EventArgs e)
        {
            foto.Descrição = txtDescrição.Text;

            if (Alterado != null)
                Alterado(sender, e);
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

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                GetNextControl(sender as Control, true).Focus();
                e.Handled = true;
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
    }
}
