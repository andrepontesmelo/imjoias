using Entidades.Moedas;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Mercadoria.Cotação
{
    /// <summary>
    /// ComboBox para seleção de moeda.
    /// </summary>
    public class ComboMoeda : ComboBox
    {
        private bool carregado = false;
        private TxtCotação cotação = null;

        public delegate void MoedaCallback(ComboMoeda sender, Moeda moeda);

        public event MoedaCallback AoSelecionar;

        public ComboMoeda()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.DisplayMember = "Nome";
        }

        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set { }
        }

        public new string DisplayMember
        {
            get { return base.DisplayMember; }
            set { }
        }

        public new string ValueMember
        {
            get { return base.ValueMember; }
            set { }
        }

        protected override void OnDropDown(EventArgs e)
        {
            if (!DesignMode)
                if (!carregado && Acesso.Comum.Usuários.UsuárioAtual != null)
                {
                    Moeda[] moedas = MoedaObtenção.Instância.ObterMoedas();

                    base.Items.AddRange(moedas);

                    carregado = true;
                }

            base.OnDropDown(e);
        }

        [Browsable(false)]
        public Moeda Seleção
        {
            get
            {
                return base.SelectedItem as Moeda;
            }
        }

        public TxtCotação Cotação
        {
            get { return cotação; }
            set { cotação = value; }
        }

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);

            if (cotação != null)
                cotação.Moeda = Seleção;

            if (AoSelecionar != null)
                AoSelecionar(this, Seleção);
        }
    }
}
