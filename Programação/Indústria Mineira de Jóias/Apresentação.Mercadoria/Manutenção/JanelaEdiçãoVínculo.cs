using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresenta��o.Mercadoria.Manuten��o
{
    public partial class JanelaEdi��oV�nculo : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        // Atributos
        public enum EnumModo { Inser��o, Altera��o }
        private EnumModo modo;
        private Entidades.Mercadoria.Mercadoria mercadoria;
        
        /// <summary>
        /// Componente antes do vinculo antes de altera��o do usu�rio 
        /// </summary>
        private ComponenteCusto componenteOriginal;

        public JanelaEdi��oV�nculo()
        {
            InitializeComponent();

            if (!DesignMode)
                comboBoxComponenteCusto.Carregar();
        }

        public Entidades.Mercadoria.Mercadoria Mercadoria
        {
            set { mercadoria = value; }
            get { return mercadoria; }
        }


        public EnumModo Modo
        {
            get { return modo; }
            set
            {
                modo = value;
                if (modo == EnumModo.Inser��o)
                {
                    lblT�tulo.Text = "Adicionando";
                    lblDescri��o.Text = "Insira as informa��es para vincular novo componente de custo � mercadoria.";
                }
                else
                {
                    lblT�tulo.Text = "Alterando";
                    lblDescri��o.Text = "Edite o vinculo entre mercadoria e componente de custo.";
                }

            }
        }

        public ComponenteCusto Componente
        {
            get { return comboBoxComponenteCusto.Componente; }
            set 
            { 
                comboBoxComponenteCusto.Componente = value;
                componenteOriginal = value;
            }
        }

        public double Quantidade
        {
            get { return txtQuantidade.Double; }
            set { txtQuantidade.Double = value; }
        }

        public bool ComponenteFoiAlterado
        {
            get
            {
                return Componente != componenteOriginal;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string mensagemErro = "";

            if (Quantidade <= 0)
                mensagemErro += "\n\tQuantidade inv�lida";

            if (Componente == null)
            {
                mensagemErro += "\n\tNenhum componente escolhido";
            }
            else if (ComponenteFoiAlterado || (Modo == EnumModo.Inser��o))
            {
                // Verifica se vinculo j� existe
                if (Componente.ExisteV�nculo(mercadoria))
                    mensagemErro += "\n\tEste mercadoria j� possui este v�nculo";
            }

            if (mensagemErro != "")
            {
                MessageBox.Show(mensagemErro, "N�o foi poss�vel completar a opera��o", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void JanelaEdi��oV�nculo_Load(object sender, EventArgs e)
        {
            comboBoxComponenteCusto.Focus();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    txtQuantidade.SelectedText = Entidades.Configura��o.DadosGlobais.Inst�ncia.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}