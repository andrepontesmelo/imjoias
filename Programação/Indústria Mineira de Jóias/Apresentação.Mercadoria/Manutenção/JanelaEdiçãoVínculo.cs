using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Mercadoria.Manutenção
{
    public partial class JanelaEdiçãoVínculo : Apresentação.Formulários.JanelaExplicativa
    {
        // Atributos
        public enum EnumModo { Inserção, Alteração }
        private EnumModo modo;
        private Entidades.Mercadoria.Mercadoria mercadoria;
        
        /// <summary>
        /// Componente antes do vinculo antes de alteração do usuário 
        /// </summary>
        private ComponenteCusto componenteOriginal;

        public JanelaEdiçãoVínculo()
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
                if (modo == EnumModo.Inserção)
                {
                    lblTítulo.Text = "Adicionando";
                    lblDescrição.Text = "Insira as informações para vincular novo componente de custo à mercadoria.";
                }
                else
                {
                    lblTítulo.Text = "Alterando";
                    lblDescrição.Text = "Edite o vinculo entre mercadoria e componente de custo.";
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
                mensagemErro += "\n\tQuantidade inválida";

            if (Componente == null)
            {
                mensagemErro += "\n\tNenhum componente escolhido";
            }
            else if (ComponenteFoiAlterado || (Modo == EnumModo.Inserção))
            {
                // Verifica se vinculo já existe
                if (Componente.ExisteVínculo(mercadoria))
                    mensagemErro += "\n\tEste mercadoria já possui este vínculo";
            }

            if (mensagemErro != "")
            {
                MessageBox.Show(mensagemErro, "Não foi possível completar a operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void JanelaEdiçãoVínculo_Load(object sender, EventArgs e)
        {
            comboBoxComponenteCusto.Focus();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    txtQuantidade.SelectedText = Entidades.Configuração.DadosGlobais.Instância.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}