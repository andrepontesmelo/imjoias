using Apresentação.Mercadoria;
using Apresentação.Mercadoria.Bandeja;
using Apresentação.Mercadoria.Cotação;
using Entidades;
using Entidades.Privilégio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// ComboBox para seleção de tabela.
    /// </summary>
    [ProvideProperty("DefinirTabela", typeof(Bandeja))]
    public class ComboTabela : ComboBox, IExtenderProvider
    {
        /// <summary>
        /// Determina se os dados estão carregados.
        /// </summary>
        private bool carregado = false;

        /// <summary>
        /// TxtCotação cuja moeda será automaticamente atualizada.
        /// </summary>
        private TxtCotação cotação = null;

        /// <summary>
        /// Setor que restringirá as tabelas.
        /// </summary>
        private Setor setor = null;

        /// <summary>
        /// Lista de bandejas, cuja tabela será definida.
        /// </summary>
        private List<Bandeja> bandejas = new List<Bandeja>();

        /// <summary>
        /// Lista de DigitaçãoComum, cuja tabela será definida.
        /// </summary>
        private List<DigitaçãoComum> digitações = new List<DigitaçãoComum>();

        /// <summary>
        /// TxtMercadoria cuja tabela será automaticamente atualizada.
        /// </summary>
        private TxtMercadoria mercadoria = null;


        public delegate void TabelaCallback(ComboTabela sender, Tabela moeda);

        /// <summary>
        /// Ocorre ao selecionar uma tabela.
        /// </summary>
        public event TabelaCallback AoSelecionar;


        /// <summary>
        /// Constrói o ComboBox.
        /// </summary>
        public ComboTabela()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.DisplayMember = "Nome";
        }

        #region Propriedades

        /// <summary>
        /// Setor que restringirá as tabelas.
        /// </summary>
        [DefaultValue(null), Browsable(false), ReadOnly(true)]
        public Setor Setor
        {
            get { return setor; }
            set { setor = value; carregado = false; }
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

        [Browsable(false), DefaultValue(null)]
        public Tabela Seleção
        {
            get
            {
                return base.SelectedItem as Tabela;
            }
            set
            {
                if (Items.Count == 0)
                    Carregar();

                if (value == null)
                    base.SelectedIndex = -1;
                else
                {
                    if (Items.IndexOf(value) < 0)
                        Items.Add(value);

                    base.SelectedIndex = Items.IndexOf(value);
                }
            }
        }

        [DefaultValue(null)]
        public TxtCotação Cotação
        {
            get { return cotação; }
            set
            {
                cotação = value;

                if (Seleção != null)
                    cotação.Moeda = Seleção.Moeda;
            }
        }

        public Tabela[] ObterTabelas()
        {
            Tabela[] tabelas;

            Carregar();

            tabelas = new Tabela[Items.Count];
            Items.CopyTo(tabelas, 0);

            return tabelas;
        }

        [DefaultValue(null)]
        public TxtMercadoria Mercadoria
        {
            get { return mercadoria; }
            set { mercadoria = value; }
        }

        #endregion

        /// <summary>
        /// Ocorre ao baixar a lista de tabelas.
        /// </summary>
        protected override void OnDropDown(EventArgs e)
        {
            Carregar();

            base.OnDropDown(e);
        }

        private void Carregar()
        {
            if (!DesignMode && !carregado)
            {
                try
                {
                    List<Tabela> tabelas;

                    if (PermissãoFuncionário.ValidarPermissão(Permissão.EscolherQualquerTabela) || setor == null || setor == Setor.ObterSetor(Setor.SetorSistema.Representante))
                        tabelas = Tabela.ObterTabelas();
                    else
                        tabelas = Tabela.ObterTabelas(setor);

                    base.Items.AddRange(tabelas.ToArray());

                    carregado = true;

                    if (Seleção != null)
                        cotação.Moeda = Seleção.Moeda;
                }
                catch (Exception e)
                {
                    try
                    {
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                    }
                    catch { }

                    MessageBox.Show("Não foi possível carergar tabelas de preço.\n\n" + e.ToString());
                }
            }
        }

        /// <summary>
        /// Ocorre ao selecionar uma tabela.
        /// </summary>
        /// <param name="e"></param>
        protected override void  OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            if (cotação != null && Seleção != null)
            {
                cotação.Moeda = Seleção.Moeda;
            }

            foreach (Bandeja bandeja in bandejas)
                bandeja.Tabela = Seleção;

            foreach (DigitaçãoComum digitação in digitações)
                digitação.Bandeja.Tabela = Seleção;

            if (mercadoria != null)
                mercadoria.Tabela = Seleção;

            if (AoSelecionar != null)
                AoSelecionar(this, Seleção);
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is DigitaçãoComum || extendee is Bandeja;
        }

        /// <summary>
        /// Método utilizado pelo designer para verificar se
        /// um controle do tipo Bandeja deve ser definido por este controle.
        /// </summary>
        [Description("Determina se a bandeja deve ter a tabela definida."),
         DefaultValue(false)]
        public bool GetDefinirTabela(Bandeja controle)
        {
            return bandejas.Contains(controle);
        }


        /// <summary>
        /// Método utilizado pelo designer para definir se um
        /// controle do tipo Bandeja deve ser definido por este controle.
        /// </summary>
        public void SetDefinirTabela(Bandeja controle, bool valor)
        {
            if (valor)
                bandejas.Add(controle);
            else
                bandejas.Remove(controle);
        }

        /// <summary>
        /// Método utilizado pelo designer para verificar se
        /// um controle do tipo DigitaçãoComum deve ser definido por este controle.
        /// </summary>
        [Description("Determina se a bandeja deve ter a tabela definida."),
         DefaultValue(false)]
        public bool GetDefinirTabela(DigitaçãoComum controle)
        {
            return digitações.Contains(controle);
        }


        /// <summary>
        /// Método utilizado pelo designer para definir se um
        /// controle do tipo DigitaçãoComum deve ser definido por este controle.
        /// </summary>
        public void SetDefinirTabela(DigitaçãoComum controle, bool valor)
        {
            if (valor)
                digitações.Add(controle);
            else
                digitações.Remove(controle);
        }

        #endregion
    }
}
