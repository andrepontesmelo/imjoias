using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.ComissãoCálculo;
using Apresentação.Formulários;
using Entidades;
using System.Globalization;

namespace Apresentação.Financeiro.Comissões
{
    public partial class ListViewComissionados : UserControl
    {
        private Dictionary<Setor, ListViewGroup> hashSetorGrupo;
        private Entidades.Pessoa.Pessoa[] vetorPessoas;
        private Comissão comissão;

        private List<Resumo> resumos;
        CultureInfo cultura = Entidades.Configuração.DadosGlobais.Instância.Cultura;

        public ListViewComissionados()
        {
            InitializeComponent();

            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!designMode)
            {
                hashSetorGrupo = new Dictionary<Setor, ListViewGroup>();
                lst.Groups.Clear();
                Setor[] setores = Setor.ObterSetores();
                foreach (Setor s in setores)
                {
                    ListViewGroup grupo = new ListViewGroup(s.Nome);
                    hashSetorGrupo.Add(s, grupo);
                    lst.Groups.Add(grupo);
                }
            }
        }

        internal void Carregar(Comissão comissão)
        {
            this.comissão = comissão;

            if (!bg.IsBusy)
            {
                AguardeDB.Mostrar();
                bg.RunWorkerAsync(comissão);
                UseWaitCursor = true;
            }

        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            Comissão comissão = (Comissão)e.Argument;
            List<Entidades.Pessoa.Pessoa> pessoasTodas = Entidades.Pessoa.Pessoa.ObterPessoasComissionadas();
            //List<Entidades.Pessoa.Pessoa> pessoasChecadas = Entidades.Pessoa.Pessoa.ObterPessoasNaComissão(comissão.Código);
            List<Entidades.Pessoa.Pessoa> pessoasChecadas = pessoasTodas;
            vetorPessoas = new Entidades.Pessoa.Pessoa[pessoasTodas.Count];
            List<KeyValuePair<Entidades.Pessoa.Pessoa, bool>> lstParPessoaChecada = new List<KeyValuePair<Entidades.Pessoa.Pessoa, bool>>();
            foreach (Entidades.Pessoa.Pessoa p in pessoasTodas)
            {
                lstParPessoaChecada.Add(new KeyValuePair<Entidades.Pessoa.Pessoa, bool>(p, pessoasChecadas.Contains(p)));
  
            }

            resumos = Resumo.Obter(comissão.Código);

            e.Result = lstParPessoaChecada;
        }

        private Resumo ObterResumo(Entidades.Pessoa.Pessoa p)
        {
            foreach (Resumo r in resumos)
            {
                if (r.Pessoa == p.Código)
                    return r;
            }
            return null;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<KeyValuePair<Entidades.Pessoa.Pessoa, bool>> lstParPessoaChecada = (List<KeyValuePair<Entidades.Pessoa.Pessoa, bool>>) e.Result;

            lst.Items.Clear();
            int x = 0;
            foreach (KeyValuePair<Entidades.Pessoa.Pessoa,bool> par in lstParPessoaChecada)
            {
                ListViewItem novoItem = new ListViewItem(Entidades.Pessoa.Pessoa.ReduzirNome(par.Key.Nome),
                    hashSetorGrupo[par.Key.Setor]);
                vetorPessoas[x++] = par.Key;
                novoItem.Checked = par.Value;
                Resumo resumo = ObterResumo(par.Key);
                if (resumo != null)
                {
                    novoItem.SubItems.AddRange(new string[] {formatarValor(resumo.Comissaoaberta), 
                    formatarValor(resumo.Comissaofechada), 
                    formatarValor(resumo.Estorno),
                    formatarValor(resumo.AReceber)});
                }
                lst.Items.Add(novoItem);
            }

            lst.Enabled = true;
            UseWaitCursor = false;

            AguardeDB.Fechar();
        }

        private string formatarValor(double valor)
        {
            if (valor == 0)
                return String.Empty;
            else
                return Math.Round(valor, 2).ToString("C", cultura);
        }
    }
}
