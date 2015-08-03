using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negócio.Importação.EntidadesAntigas;
using Negócio.Importação;
using Acesso.Comum;
using Apresentação.Pessoa;
using System.Threading;
using System.Runtime.InteropServices;

namespace Apresentação.Importação
{
    public partial class Importador : Form
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private struct Progresso
        {
            public uint total;
            public uint pronto;
            public uint posRanking;

            public Progresso(uint total, uint pronto, uint posRanking)
            {
                this.total = total;
                this.pronto = pronto;
                this.posRanking = posRanking;
            }
        }

        public Importador()
        {
            InitializeComponent();
        }

        private delegate void AtualizarCallback(Progresso p);

        private void Atualizar(Progresso p)
        {
            if (InvokeRequired)
            {
                AtualizarCallback método = new AtualizarCallback(Atualizar);
                try
                {
                    Invoke(método, p);
                }
                catch { }
            }
            else
            {
                linkRanking.Enabled = true;

                lblTotal.Text = p.total.ToString();
                lblImportado.Text = p.pronto.ToString();

                if (progresso.Maximum != p.total)
                    progresso.Maximum = (int)p.total;

                progresso.Value = (int)p.pronto;

                if (progresso.Style != ProgressBarStyle.Blocks)
                    progresso.Style = ProgressBarStyle.Blocks;

                lblIntervenção.Text = problemas.Count.ToString();

                lblCódigo.Text = "Carregando";
                lblNome.Text = "";

                lblPosRanking.Text = p.posRanking.ToString() + "o Lugar";

                if (WindowState == FormWindowState.Minimized && problemas.Count > 0)
                    FlashWindow(importador.Handle, false);
            }
        }

        private delegate void MostrarCallback(string código, string nome);

        private void Mostrar(string código, string nome)
        {
            if (InvokeRequired)
            {
                MostrarCallback método = new MostrarCallback(Mostrar);
                try
                {
                    Invoke(método, código, nome);
                }
                catch { }
            }
            else
            {
                lblCódigo.Text = código;
                lblNome.Text = nome;
            }
        }

        private static Importador importador;

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            importador = new Importador();

            importador.Show();

            Thread thread = new Thread(new ThreadStart(ExecutarImportador));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Priority = ThreadPriority.Lowest;
            thread.Start();

            Application.Run(importador);
        }

        private static void ExecutarImportador()
        {
            Usuários usuários = new Acesso.MySQL.MySQLUsuários();

            try
            {
                if (Apresentação.Formulários.Login.EfetuarLogin(usuários, null))
                {
                    Progresso p;
                    IDbConnection conexão;

                    FormatadorNome.CarregarConstantes();

                    conexão = Acesso.Comum.Usuários.UsuárioAtual.Conexão;

                    do
                    {
                        conexão = Acesso.Comum.Usuários.UsuárioAtual.Conexão;

                        lock (conexão)
                            using (IDbCommand cmd = conexão.CreateCommand())
                            {
                                cmd.CommandText = "SELECT COUNT(*) FROM cadcli";
                                p.total = Convert.ToUInt32(cmd.ExecuteScalar());

                                cmd.CommandText = "SELECT COUNT(*) FROM cadcli WHERE mapeamento IS NOT NULL";
                                p.pronto = Convert.ToUInt32(cmd.ExecuteScalar());

                                cmd.CommandText = "select count(*)+1 from ( select pessoa.nome as colaborador, count(*) as intervencoes from cadcli join pessoa where intervencaoFuncionario is not null and intervencaoFuncionario = pessoa.codigo group by intervencaoFuncionario order by intervencoes DESC ) bla where intervencoes > (select count(*) from cadcli where intervencaoFuncionario is not null and intervencaoFuncionario = " + Entidades.Pessoa.Funcionário.FuncionárioAtual.Código.ToString() + ")";
                                p.posRanking = Convert.ToUInt32(cmd.ExecuteScalar());
                            }

                        if (importador != null)
                            importador.Atualizar(p);

                        if (p.pronto < p.total)
                        {
                            try
                            {
                                bool repetir;
                                CadCli antigo;

                                do
                                {
                                    antigo = CadCli.ObterAleatório();

                                    lock (problemas)
                                        repetir = problemas.Contains(antigo);
                                } while (repetir);

                                importador.Mostrar(antigo.Código, antigo.Nome);

                                if (!Cliente.Importar(antigo, false))
                                    AdicionarIntervenção(antigo);
                            }
                            catch (Negócio.Importação.Cliente.Cancelar)
                            {
                                return;
                            }
                            catch (Exception e)
                            {
                                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                                MessageBox.Show(e.ToString());
                            }
                        }
                    } while (p.pronto + problemas.Count < p.total && importador != null && importador.Visible);

                    if (p.pronto == p.total)
                    {
                        importador.Mostrar("Completado!", "");

                        MessageBox.Show("Completado!");
                    }
                    else
                        importador.Mostrar("Cancelado!", "");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }

        private static Queue<CadCli> problemas = new Queue<CadCli>();

        private static void AdicionarIntervenção(CadCli antigo)
        {
            lock (problemas)
            {
                problemas.Enqueue(antigo);

                if (problemas.Count == 1)
                {
                    Thread ui = new Thread(new ThreadStart(ExecutarImportadorUI));

                    ui.Priority = ThreadPriority.Highest;
                    ui.SetApartmentState(ApartmentState.STA);
                    ui.Start();
                }
            }
        }

        private static bool avisado = false;

        private static void ExecutarImportadorUI()
        {
            if (!avisado)
            {
                avisado = true;

                MessageBox.Show(
                    "ATENÇÃO\n\nVocê será questionado sempre que o sistema não conseguir interpretar corretamente os dados do banco de dados.\n\nSempre que requisitado, verifique os dados interpretados. NUNCA deixe dados em campos errados.\n\nPor exemplo, dados como profissão devem constar no campo profissão e JAMAIS em observações, endereço, telefone ou documento. Da mesma maneira, nunca em um nome deixe comentários. Utilize os respectivos campos para tais finalidades.\n\nSó é possível processar corretamente os dados esperados nos campos corretos. Apesar de uma pessoa ser capaz de compreender um campo em um lugar incorreto, o sistema computacional não é dotado de tal inteligência.",
                    "Importação de dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            try
            {
                bool repetir;

                do
                {
                    CadCli antigo = problemas.Peek();

                    while (importador.WindowState == FormWindowState.Minimized && importador.Visible)
                    {
                        Thread.Sleep(1000);
                    }

                    if (!antigo.VerificarMapeamento() && importador.Visible)
                        try
                        {
                            if (!Cliente.Importar(antigo, true))
                                MessageBox.Show("Não foi possível importar cadastro.");
                            else
                            {
                                // Informa que o funcionário atual que fez a intervenção
                                antigo.AcabouIntervenção(Convert.ToUInt32(Entidades.Pessoa.Funcionário.FuncionárioAtual.Código));
                            }
                        }
                        catch (Negócio.Importação.Cliente.Cancelar)
                        {
                            if (MessageBox.Show(
                                "Deseja interromper o processo de importação?",
                                "Importação de dados",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Application.Exit();
                                problemas.Clear();
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                        }
                    

                    lock (problemas)
                    {
                        problemas.Dequeue();
                        repetir = problemas.Count > 0;
                    }
                } while (repetir && importador.Visible);
            }
            catch (Negócio.Importação.Cliente.Cancelar)
            {
                return;
            }
        }

        private void Importador_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, Screen.PrimaryScreen.WorkingArea.Bottom - Height);
        }

        private void Importador_Shown(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ranking janela = new Ranking();
            janela.Show();
        }
    }
}
