using Apresentação.Financeiro.Venda;
using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Fiscal;
using Entidades.Fiscal.NotaFiscalEletronica;
using Entidades.Relacionamento.Venda;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Janela
{
    public partial class JanelaNFe : JanelaExplicativa
    {
        public event EventHandler AoSalvarNfe;
        private Venda venda;

        private ConfiguraçãoGlobal<int> últimaNFe = null;
        private ConfiguraçãoGlobal<int> últimaFatura = null;
        private ConfiguraçãoGlobal<long> últimaVendaExportada = null;
        private ConfiguraçãoGlobal<int> cfop = null;
        
        public JanelaNFe()
        {
            InitializeComponent();
            Carregar();
        }

        private void Carregar()
        {
            últimaNFe = new ConfiguraçãoGlobal<int>("ultimaNfe", 301);
            últimaFatura = new ConfiguraçãoGlobal<int>("ultimaFatura", 422);
            cfop = new ConfiguraçãoGlobal<int>("cfop", 5101);
            txtNfe.Text = (últimaNFe.Valor + 1).ToString();
            txtNumeroFatura.Text = (últimaFatura.Valor + 1).ToString();
            txtCFOP.Text = cfop.Valor.ToString();

            Cfop entidade = Cfop.Obter(cfop.Valor);
            if (entidade != null)
                txtCFOPDesc.Text = entidade.Descricao;

            últimaVendaExportada = new ConfiguraçãoGlobal<long>("ultimaVendaExportadaNFE", 0);
            txtUltimaVenda.Text = "Última venda exportada: " + últimaVendaExportada.Valor.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Carregar(Venda v)
        {
            DadosVenda dv = new DadosVenda();

            dv.Abrir(v, null);
            flow.Controls.Add(dv);
            dv.Width = flow.ClientSize.Width;
            dv.Dock = DockStyle.Fill;
        }

        private void Salvar(Venda v)
        {
            int códigoNfe;
            if (!int.TryParse(txtNfe.Text, out códigoNfe))
            {
                txtNfe.Focus();
                return;
            }

            int códigoCFOP;
            if (!int.TryParse(txtCFOP.Text, out códigoCFOP))
            {
                txtCFOP.Focus();
                return;
            }

            int códigoFatura;
            if (!int.TryParse(txtNumeroFatura.Text, out códigoFatura))
            {
                txtNumeroFatura.Focus();
                return;
            }

            double aliquota;
            if (!double.TryParse(txtAliquota.Text, out aliquota))
            {
                txtAliquota.Focus();
                return;
            }

            NfeVenda nota = new NfeVenda(v, códigoNfe, códigoCFOP, códigoFatura, aliquota);
            NfeVendaTxt escritorTxt = new NfeVendaTxt(nota);
            FolderBrowserDialog janela = new FolderBrowserDialog();
            DialogResult resultado = janela.ShowDialog();

            if (resultado == DialogResult.OK)
                SalvarVenda(v, códigoNfe, códigoFatura, nota, escritorTxt, janela);
        }

        private void SalvarVenda(Venda v, int códigoNfe, int códigoFatura, NfeVenda nota, NfeVendaTxt escritorTxt, FolderBrowserDialog janela)
        {
            string arquivo = Path.Combine(janela.SelectedPath, v.Código.ToString() + ".txt");
            if (File.Exists(arquivo))
            {
                DialogResult apagar = MessageBox.Show(this,
                    "Sobrescrever ?",
                    "Arquivo já existe",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (apagar == DialogResult.No)
                    return;

                File.Delete(arquivo);
            }

            if (!TentaSalvarArquivo(escritorTxt, arquivo))
                return;

            nota.Cadastrar();

            if (AoSalvarNfe != null)
                AoSalvarNfe(null, null);

            Process.Start(janela.SelectedPath);

            últimaNFe.Valor = códigoNfe;
            últimaFatura.Valor = códigoFatura;
            últimaVendaExportada.Valor = v.Código;
            txtCódigoVenda.Text = "";

            Carregar();
            txtCódigoVenda.Focus();
        }

        private bool TentaSalvarArquivo(NfeVendaTxt escritorTxt, string arquivo)
        {
            try
            {
                escritorTxt.Salvar(arquivo);
            }
            catch (Exception erro)
            {
                if (File.Exists(arquivo))
                    File.Delete(arquivo);

                MessageBox.Show(this, erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void txtCódigoVenda_Validating(object sender, CancelEventArgs e)
        {
            int código;
            if (txtCódigoVenda.Text.Trim() == "")
            {
                e.Cancel = false;
                return;
            }

            bool ok = int.TryParse(txtCódigoVenda.Text, out código);

            if (!ok)
            {
                e.Cancel = true;
                btnSalvar.Enabled = false;
                return;
            }

            venda = Venda.ObterVenda(código);

            if (venda == null)
            {
                e.Cancel = true;
                btnSalvar.Enabled = false;
                return;
            }

            e.Cancel = false;
            btnSalvar.Enabled = true;
            Carregar(venda);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (venda == null)
            {
                MessageBox.Show("Venda inexistente.");
                return;
            }

            Salvar(venda);
        }

        private void txtCódigoVenda_Enter(object sender, EventArgs e)
        {
            flow.Controls.Clear();
            venda = null;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            txtCódigoVenda.Focus();
        }

        private void txtCódigoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCFOP.Focus();
        }

        private void lnkBuscarCFOP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JanelaCFOP janela = new JanelaCFOP();
            janela.AoEscolher += janela_AoEscolher;
            janela.ShowDialog(this);
        }

        void janela_AoEscolher(Cfop entidade)
        {
            txtCFOP.Text = entidade.Codigo.ToString();
            txtCFOPDesc.Text = entidade.Descricao;
            cfop.Valor = entidade.Codigo;
        }

        internal void CarregarVenda(long códigoVenda)
        {
            txtCódigoVenda.Text = códigoVenda.ToString();
            venda = Venda.ObterVenda(códigoVenda);
            Carregar(venda);
            btnSalvar.Enabled = true;
        }
    }
}
