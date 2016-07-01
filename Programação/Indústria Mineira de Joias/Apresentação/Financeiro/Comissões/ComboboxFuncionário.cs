using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.ComissãoCálculo;

namespace Apresentação.Pessoa
{
    public partial class ComboboxFuncionário : UserControl
    {
        public ComboboxFuncionário()
        {
            InitializeComponent();
        }

        public event EventHandler FuncionárioAlterado;
        private Dictionary<string, Entidades.Pessoa.Pessoa> hashItemPessoa = new Dictionary<string,Entidades.Pessoa.Pessoa>();
        private Dictionary<Entidades.Pessoa.Pessoa, string> hashPessoaItem = new Dictionary<Entidades.Pessoa.Pessoa, string>();
        private Comissão comissão;


        public Entidades.Pessoa.Pessoa Funcionário
        {
            get
            {
                if (comboBox1.SelectedItem == null)
                    return null;

                Entidades.Pessoa.Pessoa retorno;
                if (hashItemPessoa.TryGetValue((string)comboBox1.SelectedItem, out retorno))
                    return retorno;
                else 
                    return null;
            }
            set
            {
                string item;
                if (value == null)
                {
                    comboBox1.SelectedItem = null;
                    return;
                }

                if (hashPessoaItem.TryGetValue(value, out item)
                    && comboBox1.Items.Contains(item))
                {
                    comboBox1.SelectedItem = item;
                }
            }
        }


        internal void Carregar(Comissão comissão)
        {
            this.comissão = comissão;

            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }


        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoasComissionadas();
            e.Result = pessoas;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Entidades.Pessoa.Pessoa> pessoas = (List<Entidades.Pessoa.Pessoa>)e.Result;

            comboBox1.Items.Clear();
            hashPessoaItem.Clear();
            hashItemPessoa.Clear();
            foreach (Entidades.Pessoa.Pessoa p in pessoas)
            {
                string nomeReduzido = Entidades.Pessoa.Pessoa.AbreviarNome(p.Nome);
                hashPessoaItem.Add(p, nomeReduzido);
                hashItemPessoa.Add(nomeReduzido, p);
                comboBox1.Items.Add(nomeReduzido);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (FuncionárioAlterado != null)
                FuncionárioAlterado(sender, e);
        }
    }
}
