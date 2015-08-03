using System;
using System.Collections.Generic;
using System.Text;
using Negócio.Importação.EntidadesAntigas;
using Entidades.Pessoa;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Apresentação.Pessoa;
using Apresentação.Importação.Intervenção;
using Entidades.Pessoa.Endereço;
using Entidades;
using Apresentação.Pessoa.Cadastro;
using Apresentação.Formulários;
using Apresentação.Pessoa.Endereço;
using EstruturasDeDados;

namespace Negócio.Importação
{
    /// <summary>
    /// Controla a importação do cliente, implementando todos
    /// os métodos de tratamento de dados.
    /// </summary>
    public class Cliente
    {
        private CadCli antigo;
        private Entidades.Pessoa.Pessoa novo;

        public class Cancelar : ApplicationException
        { }

        public static bool Importar(CadCli cadastro, bool ui)
        {
            Cliente cliente = new Cliente(cadastro);

            //if (!cliente.Importar())
            //{
            //    using (CadastroCliente dlg = new CadastroCliente(cliente.Pessoa))
            //    {
            //        if (dlg.ShowDialog() != DialogResult.OK)
            //            return;
            //    }
            //}
            if (!cliente.Importar(ui))
                return false;

        verificar:
            if (cliente.VerificarDuplicidade(ui))
            {
                try
                {
                    if (!cliente.antigo.VerificarMapeamento())
                        cliente.Pessoa.Cadastrar();
                }
                catch (Exception e)
                {
                    if (ui)
                    {
                        cliente.MostrarProblema("Não foi possível gravar os dados no banco de dados. Algum campo deve estar mal preenchido. Favor verificar ou cancelar.");
                        cliente.MostrarProblema(e.ToString());

                        using (CadastroCliente dlg = new CadastroCliente(cliente.Pessoa))
                        {
                            if (dlg.ShowDialog() != DialogResult.OK)
                                return false;
                        }

                        goto verificar;
                    }
                    else
                        return false;
                }

                cliente.antigo.Mapear(cliente.Pessoa);

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Cadastro da pessoa importada.
        /// </summary>
        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return novo; }
        }

        /// <summary>
        /// Constrói o importadord e cliente.
        /// </summary>
        /// <param name="importação">Cliente a ser importado.</param>
        public Cliente(CadCli importação)
        {
            this.antigo = importação;
            novo = antigo.Mapeamento;
        }

        #region Eliminar duplicidade

        /// <summary>
        /// Verifica se o cadastro encontra-se duplicado,
        /// permitindo ao usuário editar duplicação.
        /// </summary>
        /// <returns>Se o novo cadastro deve ser duplicado.</returns>
        public bool VerificarDuplicidade(bool ui)
        {
            bool ok = true;

            Entidades.Pessoa.Pessoa[] pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(antigo.Nome);

            if (pessoas.Length > 0)
            {
                if (!ui)
                    return false;

                MostrarProblema("Já existe um cadastro de uma pessoa com o mesmo nome: " + antigo.Nome
                    + "\n\nCaso seja a mesma pessoa com endereços diferentes, favor apenas acrescentar novos endereços.");

                ok = CompararCadastros(pessoas);
            }

            volta:
            if (ok && novo is PessoaFísica)
            {
                if (((PessoaFísica)novo).CPF != null)
                {
                    Entidades.Pessoa.PessoaFísica pf;

                    pf = Entidades.Pessoa.PessoaFísica.ObterPessoaPorCPF(((PessoaFísica)novo).CPF);

                    if (pf != null)
                    {
                        if (!ui)
                            return false;

                        MostrarProblema("Encontradas pessoas com o mesmo CPF.");

                        if (CompararCadastros(new Entidades.Pessoa.Pessoa[] { pf }))
                            goto volta;
                        else
                            ok = false;
                    }
                }
            }
            else if (ok && novo is PessoaJurídica)
            {
                if (((PessoaJurídica)novo).CNPJ != null)
                {
                    Entidades.Pessoa.PessoaJurídica pj;

                    pj = Entidades.Pessoa.PessoaJurídica.ObterPessoaPorCNPJ(((PessoaJurídica)novo).CNPJ);

                    if (pj != null)
                    {
                        if (!ui)
                            return false;

                        MostrarProblema("Encontradas pessoas com o mesmo CNPJ.");

                        if (CompararCadastros(new Entidades.Pessoa.Pessoa[] { pj }))
                            goto volta;
                        else
                            ok = false;
                    }
                }
            }

            return ok;
        }

        private bool CompararCadastros(Entidades.Pessoa.Pessoa[] pessoas)
        {
            bool ok = true;

            using (Comparação dlg = new Comparação())
            {
                dlg.Mostrar(pessoas, novo);

                dlg.ShowDialog();

                if (dlg.OK)
                {
                    if (dlg.Duplicar)
                        ok = true;
                    else
                    {
                        antigo.Mapear(pessoas[0].Código);
                        
                        ok = false;
                    }
                }
                else
                    return false;

                AguardeDB.Mostrar();

                foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
                    pessoa.Atualizar();

                AguardeDB.Fechar();
            }

            return ok;
        }

        #endregion

        #region Cache

        private static Setor varejo, atacado, altoAtacado;

        protected static Setor Varejo
        {
            get
            {
                if (varejo == null)
                    varejo = Setor.ObterSetor("Varejo");
                return varejo;
            }
        }

        protected static Setor Atacado
        {
            get
            {
                if (atacado == null)
                    atacado = Setor.ObterSetor("Atacado");
                return atacado;
            }
        }

        protected static Setor AltoAtacado
        {
            get
            {
                if (altoAtacado == null)
                    altoAtacado = Setor.ObterSetor("Alto-Atacado");
                return altoAtacado;
            }
        }

        #endregion

        #region Base da importação

        /// <summary>
        /// Tenta importar o cadastro antigo.
        /// </summary>
        /// <param name="ui">Se o sistema pode utilizar interface de usuário.</param>
        /// <returns>Verdadeiro se o processo não requer
        /// intervenção humana.</returns>
        public bool Importar(bool ui)
        {
            bool ok = true;
            TipoPessoa? tipo = null;

            if (Entidades.Pessoa.Pessoa.ObterPessoa((ulong)antigo.CódigoNumérico) != null)
            {
                if (!ui)
                    return false;

                throw new Exception("O código " + antigo.CódigoNumérico + " está duplicado.\n\nFavor comunicar o Júlio ou o André e informar o número do código.");
            }

            // Determinar se é pessoa física ou jurídica.
            if (antigo.CPF != null && antigo.CNPJ != null)
            {
                bool cnpj, cpf;

                ok = false;

                cnpj = PessoaJurídica.ValidarCNPJ(antigo.CNPJ);
                cpf = PessoaFísica.ValidarCPF(antigo.CPF);

                if (cpf && cnpj)
                {
                    if (!ui)
                        return false;

                    MostrarProblema("Cadastro apresenta campos válidos de CPF e CNPJ!!!");
                    tipo = Apresentação.Importação.Intervenção.QuestionarTipoPessoa.Questionar(antigo);
                }
                else if (cpf)
                    tipo = TipoPessoa.Física;
                else if (cnpj)
                    tipo = TipoPessoa.Jurídica;
                else if (!ui)
                    return false;
                else
                    tipo = Apresentação.Importação.Intervenção.QuestionarTipoPessoa.Questionar(antigo);
            }
            else if (antigo.CPF != null)
                tipo = TipoPessoa.Física;
            else if (antigo.CNPJ != null)
                tipo = TipoPessoa.Jurídica;
            else
            {
                if (ui)
                    tipo = Apresentação.Importação.Intervenção.QuestionarTipoPessoa.Questionar(antigo);
                else
                    return false;
            }

            if (tipo.HasValue)
                switch (tipo.Value)
                {
                    case TipoPessoa.Física:
                        novo = new PessoaFísica();
                        ok &= ImportarPessoaFísica(ui);
                        break;

                    case TipoPessoa.Jurídica:
                        novo = new PessoaJurídica();
                        ok &= ImportarPessoaJurídica(ui);
                        break;

                    default:
                        throw new NotSupportedException();
                }

            if (!ok)
                return false;

            novo.Código = (ulong)antigo.CódigoNumérico;

            novo.Nome = FormatadorNome.FormatarTexto(antigo.Nome);

            if (antigo.Obs.Trim().Length > 0)
                novo.Observações = antigo.Obs.Trim();

            if (!ImportarRegião(ui))
                return false;

            if (!ImportarEndereço(ui))
                return false;

            if (!ImportarTelefone(ui))
                return false;

            if (!ImportarCategoria())
                return false;

            if (!ImportarNossoNúmero(ui))
                return false;

            if (!ImportarComentários(ui))
                return false;

            if (antigo.Classe == "F")
                novo.Fornecedor = true;

            if (novo.Nome.IndexOfAny(new char[] { '/', '\\', '-', '(', ')', '*', '!', '%', '$', '#', '@', '_', '|', ':', '[', ']', '{', '}', '<', ';', '?' } ) >= 0)
            {
                if (ui)
                {
                    MostrarProblema("O nome do cliente parece estar poluído com dados que não deveriam estar lá.");

                    using (CadastroCliente dlg = new CadastroCliente(novo))
                    {
                        if (dlg.ShowDialog() != DialogResult.OK)
                            return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Mostra um problema na importação.
        /// </summary>
        private void MostrarProblema(string problema)
        {
            MessageBox.Show(
                "Problema importando cliente " + antigo.Código + ":\n\n" + problema,
                "Importação de cliente",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Acrescenta um comentário às observações do cliente importado.
        /// </summary>
        private void AcrescentarComentário(string p)
        {
            if (novo.Observações == null)
                novo.Observações = p;
            else
                novo.Observações += "\n" + p;
        }

        #endregion

        #region Pessoa física

        /// <summary>
        /// Importa os dados como uma pessoa física.
        /// </summary>
        private bool ImportarPessoaFísica(bool ui)
        {
            bool ok = true;

            PessoaFísica novo = (PessoaFísica)this.novo;

            if (antigo.CPF != null && antigo.CPF.Length > 3)
            {
                try
                {
                    novo.CPF = antigo.CPF;
                }
                catch
                {
                    if (novo.Observações != null)
                        novo.Observações += "\nCPF inválido: confirmar.";
                    else
                        novo.Observações = "CPF inválido: confirmar.";

                    if (novo.CPF != antigo.CPF)
                        throw new NotSupportedException("CPF inválido não é suportado na importação.");
                }
            }
            else
                novo.CPF = null;

            ok &= ImportarDocumentoPessoaFísica(ui);

            return ok;
        }

        private static Regex regexDI;

        private static Regex RegexDI
        {
            get
            {
                if (regexDI == null)
                    regexDI = new Regex(
                        @"((?<documento>\w+([.-]\w+)*)\s*(?<emissor>(SSP|OAB|CREA|CRM|TJ))((\s|[/-])?(?<estado>\w{2}))?)"
                        + @"|((?<emissor>(SSP|OAB|CREA|CRM|TJ))((\s|[/-])?(?<estado>\w{2}))?\s(?<documento>\w+([.-]\w+)*))"
                        + @"|(?<documento>([a-zA-Z0-9]{1,2}(\s|[-.]))?\d+([.-]\d+)*)",
                        RegexOptions.Compiled | RegexOptions.IgnoreCase);

                return regexDI;
            }
        }

        /// <summary>
        /// Importa o campo Insc como documento de identidiade
        /// da pessoa física.
        /// </summary>
        private bool ImportarDocumentoPessoaFísica(bool ui)
        {
            if (antigo.Insc != null && antigo.Insc.Length > 1)
            {
                PessoaFísica novo = (PessoaFísica)this.novo;
                Match match;

                /* O campo Insc pode conter RG, carteira de trabalho
                 * ou outros documentos.
                 */
                match = RegexDI.Match(antigo.Insc);

                if (!match.Success)
                {
                    int ssp = antigo.Insc.IndexOf("SSP");

                    if (ssp > 0)
                    {
                        novo.DI = antigo.Insc.Substring(0, ssp).Trim();
                        novo.DIEmissor = antigo.Insc.Substring(ssp);

                        return true;
                    }
                    else if (antigo.Insc.Trim() == "ISENTO")
                    {
                        novo.DI = null;
                        novo.DIEmissor = null;
                        return true;
                    }
                    else if (antigo.Insc.Trim().IndexOf(' ') > 0)
                    {
                        int p = antigo.Insc.Trim().IndexOf(' ');

                        novo.DI = antigo.Insc.Trim().Substring(0, p);
                        novo.DIEmissor = antigo.Insc.Trim().Substring(p);
                    }
                    else
                        novo.DI = antigo.Insc;
                }
                else if (match.Groups["emissor"].Success)
                {
                    novo.DI = match.Groups["documento"].Value;

                    if (match.Groups["estado"].Success)
                        novo.DIEmissor = String.Format(
                            "{0}/{1}", match.Groups["emissor"].Value, match.Groups["estado"].Value);
                    else
                        novo.DIEmissor = match.Groups["emissor"].Value;

                    if (match.Length >= antigo.Insc.Trim().Length)
                        return true;
                }
                else
                {
                    novo.DIEmissor = null;

                    if (match.Length >= antigo.Insc.Trim().Length)
                    {
                        novo.DI = match.Groups["documento"].Value;
                        return true;
                    }
                    else
                        novo.DI = antigo.Insc;
                }

                if (!ui)
                    return false;

                using (QuestionarInscPF dlg = new QuestionarInscPF(antigo, novo))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        novo.DI = dlg.DI;
                        novo.DIEmissor = dlg.Órgão;
                    }
                    else
                        throw new Cancelar();
                }
            }

            return true;
        }

#endregion

        #region Pessoa jurídica

        /// <summary>
        /// Importa os dados como uma pessoa jurídica.
        /// </summary>
        private bool ImportarPessoaJurídica(bool ui)
        {
            PessoaJurídica novo = (PessoaJurídica)this.novo;
            bool ok = true;

            if (antigo.CNPJ != null && antigo.CNPJ.Trim().Length > 10)
            {
                try
                {
                    novo.CNPJ = antigo.CNPJ.Trim();
                }
                catch
                {
                    if (novo.Observações != null)
                        novo.Observações += "\nCNPJ inválido: confirmar.";
                    else
                        novo.Observações += "CNPJ inválido: confirmar.";

                    if (novo.CNPJ != antigo.CNPJ)
                        throw new NotSupportedException("CNPJ inválido não é suportado na importação.");
                }
            }
            else if (antigo.CNPJ != null && antigo.CNPJ.Trim().Length > 3)
            {
                if (novo.Observações != null)
                    novo.Observações += "CNPJ inválido: " + antigo.CNPJ;
                else
                    novo.Observações = "CNPJ inválido: " + antigo.CNPJ;
            }
            else
                novo.CNPJ = null;

            novo.InscEstadual = antigo.Insc;

            return ok;
        }

        #endregion

        #region Endereço

        /// <summary>
        /// Importa os campos de endereço.
        /// </summary>
        private bool ImportarEndereço(bool ui)
        {
            bool ok = true;

            ok &= ImportarEndereço(ui, "Principal", antigo.Endereço, antigo.Bairro, antigo.Cidade, antigo.UF, antigo.CEP);

            if (antigo.Endereço != antigo.EndereçoCobrança ||
                antigo.Cidade != antigo.CidadeCobrança ||
                antigo.UFCobrança != antigo.UF ||
                antigo.CEP != antigo.CEPCobrança)
            {
                ok &= ImportarEndereço(ui, "Cobrança", antigo.EndereçoCobrança, null, antigo.CidadeCobrança, antigo.UFCobrança, antigo.CEPCobrança);
            }

            return ok;
        }

        private bool ImportarEndereço(bool ui, string descrição, string antigoEndereço, string antigoBairro, string antigoCidade, string antigoUF, string antigoCEP)
        {
            bool ok = true;

            if (antigoEndereço != null && antigoEndereço.Length > 1)
            {
                Endereço endereço = new Endereço(novo);
                Localidade[] localidades;

                ok &= ExtrairLogradouro(endereço, antigoEndereço);

                endereço.Descrição = descrição;

                if (antigoBairro != null)
                    endereço.Bairro = FormatadorNome.FormatarTexto(antigoBairro);

                endereço.CEP = antigoCEP;

                if (antigoCidade != null)
                {
                    antigoCidade = antigoCidade.Trim();

                    localidades = Localidade.ObterLocalidades(antigoCidade);

                    endereço.Localidade = VerificarLocalidades(localidades, antigoCidade, antigoUF, out ok);
                }

                if (endereço.Localidade == null)
                {
                    Estado[] estados = Estado.ObterEstados(antigoUF);

                    ok = false;

                    if (estados.Length == 1)
                        endereço.Localidade = VerificarLocalidades(Localidade.ObterLocalidades(estados[0]), antigoCidade, antigoUF, out ok);

                    if (!ok)
                    {
                        endereço.Localidade = new Localidade();
                        endereço.Localidade.Nome = FormatadorNome.FormatarTexto(antigoCidade);

                        if (ui)
                            MostrarProblema("Localidade \"" + endereço.Localidade.Nome + "\" desconhecida.\n\nCertifique-se que a grafia esteja correta.");

                        if (estados.Length == 1)
                            endereço.Localidade.Estado = estados[0];
                    }
                }

                novo.Endereços.Adicionar(endereço);

                if (!ok)
                {
                    if (!ui)
                        return false;
                    else
                        using (EditarEndereço dlg = new EditarEndereço(antigo, endereço, antigoEndereço, antigoBairro, antigoCEP, antigoCidade, antigoUF))
                        {
                            do
                            {
                                if (dlg.ShowDialog() == DialogResult.Cancel)
                                {
                                    if ((endereço.Logradouro.Length == 0 || endereço.Localidade == null) && MessageBox.Show("Deseja excluir aquele endereço?", "Edição de endereço", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        novo.Endereços.Remover(endereço);
                                        ok = true;
                                    }
                                    else
                                        throw new Cancelar();
                                }
                                else if (endereço.Logradouro.Length == 0)
                                    MostrarProblema("O logradouro está vazio. Por favor, verifique se os dados foram corretamente importados. Caso não saiba o logradouro, cancele a próxima tela para excluir o endereço.");

                                else if (endereço.Localidade == null)
                                    MostrarProblema("Localidade precisa ser preenchida em um endereço. Por favor, verifique outros dados a procura da cidade. Caso não saiba a cidade, cancele a próxima tela para excluir o endereço.");

                                else if (endereço.Localidade.Estado == null)
                                    MostrarProblema("Estado precisa ser preenchido em um endereço.");

                                else if (endereço.Localidade.Estado.País == null)
                                    MostrarProblema("País precisa ser preenchido em um endereço.");

                                else if (!endereço.Localidade.Cadastrado)
                                    using (EditarLocalidade dlgLocalidade = new EditarLocalidade(endereço.Localidade))
                                    {
                                        if (dlgLocalidade.ShowDialog() == DialogResult.OK)
                                        {
                                            try
                                            {
                                                endereço.Localidade.Cadastrar();
                                                ok = true;
                                            }
                                            catch (Exception e)
                                            {
                                                ok = false;
                                                MostrarProblema("Erro cadastrando localidade \"" + endereço.Localidade.Nome + "\".\n\n" + e.Message);
                                                break;
                                            }
                                        }
                                    }
                                else
                                    ok = true;

                            } while (!ok);
                        }
                }
            }

            return ok;
        }

        private Localidade VerificarLocalidades(Localidade[] localidades, string antigoCidade, string antigoUF, out bool ok)
        {
            Localidade escolha = null;
            int minDist = int.MaxValue;

            ok = false;

            foreach (Localidade localidade in localidades)
                if (antigoUF != localidade.Estado.Sigla)
                    ok = false;
                else
                {
                    if (Acentuação.CompararSemAcentos(localidade.Nome, antigoCidade, true) == 0)
                    {
                        escolha = localidade;
                        ok = true;
                        break;
                    }
                    else
                    {
                        int dist = DistânciaLevenshtein.CalcularDistância(localidade.Nome, antigoCidade);

                        if (dist < minDist)
                        {
                            escolha = localidade;
                            minDist = dist;
                        }

                        ok = false;
                    }
                }

            return escolha;
        }

        private static Regex regexEndereço = null;

        protected static Regex RegexEndereço
        {
            get
            {
                if (regexEndereço == null)
                    regexEndereço = new Regex(
                        //@"^(?<logradouro>([a-zA-Z][a-zA-Z]+\s[a-zA-Z]+(\s[a-z][A-Z][a-zA-Z]+)*|[a-zA-Z][a-zA-Z]+\s\d+(\s[a-zA-Z]+)*))\s+(?<número>\d+)(\s+(APT|APTO)\s*(?<complemento>\d+)|/(?<complemento>\d+)|)",
                        //@"^(?<logradouro>(\w\w+\s\w+(\s\w\w+)*|\w\w+\s\d+(\s\w+)*))(,\s?|\s+)(?<número>\d+)(\s+(APT|APTO)\s*(?<complemento>\d+)|\s*/\s*(?<complemento>\d+)|)",
                        //@"^(?<logradouro>(\w\w+\.?\s\w+\.?(\s\w\w+\.?)*|\w\w+\.?\s\d+(\s\w+\.?)*))(,\s?|\s+)(?<número>\d+)\s+(AP(TO|T|\.)?|L(OJA|OJ(\.)?|J(\.)?)?|CASA|SL(\.)?|SALA)\s*(?<complemento>\d+)|(?<logradouro>(\w\w+\.?\s\w+\.?(\s\w\w+\.?)*|\w\w+\.?\s\d+(\s\w+\.?)*))(,\s?|\s+)(?<número>\d+)(\s+(AP(TO|T|\.)?|L(OJA|OJ(\.)?|J(\.)?)?|CASA|SL(\.)?|SALA)\s*(?<complemento>\d+)|\s*/\s*(?<complemento>\d+)|)",
                        @"^(?<logradouro>(\w\w+\.?\s\w+\.?(\s\w\w+\.?)*|\w\w+\.?\s\d+(\s\w+\.?)*))(,\s?|\s+)(?<número>\d+)\s+(?<complemento>(AP(TO|T|\.)?|L(OJA|OJ(\.)?|J(\.)?)?|CASA|SL(\.)?|SALA)\s*\d+)|(?<logradouro>(\w\w+\.?\s\w+\.?(\s\w\w+\.?)*|\w\w+\.?\s\d+(\s\w+\.?)*))(,\s?|\s+)(?<número>\d+)(\s+(?<complemento>(AP(TO|T|\.)?|L(OJA|OJ(\.)?|J(\.)?)?|CASA|SL(\.)?|SALA)\s*\d+)|\s*/\s*(?<complemento>\d+)|)",
                        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

                return regexEndereço;
            }
        }

        /// <summary>
        /// Extrai o campo "endereço" utilizando expressão regular,
        /// preenchendo os campos "logradouro", "número" e "complemento".
        /// </summary>
        /// <param name="endereço">Objeto que conterá os dados interpretados.</param>
        /// <param name="str">String contendo o endereço a ser tratado.</param>
        private bool ExtrairLogradouro(Endereço endereço, string str)
        {
            Match match;
            bool ok = true;

            match = RegexEndereço.Match(str);
            
            if (match != null)
            {
                endereço.Logradouro = FormatadorNome.FormatarTexto(match.Groups["logradouro"].Value);
                endereço.Número = match.Groups["número"].Value;
                endereço.Complemento = match.Groups["complemento"].Value.Length > 0 ? match.Groups["complemento"].Value : null;

                ok &= !endereço.Logradouro.Contains("Bloco");
                ok &= !endereço.Logradouro.Contains("Apt");
                ok &= !endereço.Logradouro.Contains("Sala");
                ok &= !endereço.Logradouro.Contains("Casa ");
                ok &= endereço.Logradouro.Length > 0 && endereço.Número.Length > 0;
            }
            else
            {
                endereço.Logradouro = FormatadorNome.FormatarTexto(str);
                ok = false;
            }

            return ok;
        }

        #endregion

        #region Telefone

        private static Regex regexTelefone = null;

        protected Regex RegexTelefone
        {
            get
            {
                if (regexTelefone == null)
                    regexTelefone = new Regex(
                        /* (ddd) prefixo-sufixo */
                        @"(?<descrição>[a-zA-Z]*)\s?\(0?(?<ddd>\d{2})\)\s?(?<prefixo>\"
                        + @"d{3,4})\s?[-.]?\s?(?<sufixo1>\d{2})[ .-]?(?<sufixo2>\d{2})(\"
                        + @"s(?<obs>([a-zA-Z]+\s+)+[a-zA-Z]+)|)" +
                        /* ddd prefixo-sufixo */
                        @"|(?<descrição>[a-zA-Z]*"
                        + @")\s?0?(?<ddd>\d{2})\s*[-.]?\s*(?<prefixo>\d{3,4})\s?[-.]?\s?(?<suf"
                        + @"ixo1>\d{2})[ .-]?(?<sufixo2>\d{2})(\s(?<obs>([a-zA-Z]+\s+)+["
                        + @"a-zA-Z]+)|)" +
                        /* prefixo-sufixo */
                        @"|(?<descrição>[a-zA-Z]*)\s?(?<prefixo>\d{3,})\"
                        + @"s?[-.]?\s?(?<sufixo1>\d{2})[ .-]?(?<sufixo2>\d{2})(\s(?<obs>"
                        + @"([a-zA-Z]+\s+)+[a-zA-Z]+)|)",
                        RegexOptions.IgnoreCase
                        | RegexOptions.ExplicitCapture
                        | RegexOptions.IgnorePatternWhitespace
                        | RegexOptions.Compiled
                        );

                return regexTelefone;
            }
        }

        /// <summary>
        /// Importa dados de telefone.
        /// </summary>
        private bool ImportarTelefone(bool ui)
        {
            MatchCollection matches;
            int contador = 0;
            bool ok = true;

            if (antigo.Telefone != null && antigo.Telefone.Length > 1)
            {
                matches = RegexTelefone.Matches(antigo.Telefone);

                foreach (Match match in matches)
                {
                    contador++;
                    ExtrairTelefone(contador, match);
                }

                ok &= ValidarTelefones(matches, antigo.Telefone);
            }

            if (antigo.Fax != null && antigo.Fax.Length > 1)
            {
                matches = RegexTelefone.Matches(antigo.Fax);

                if (matches.Count == 1)
                {
                    Telefone telefone = ExtrairTelefone(++contador, matches[0]);

                    if (telefone.Descrição == contador.ToString())
                        telefone.Descrição = "Fax";
                }
                else
                    foreach (Match match in matches)
                    {
                        contador++;
                        ExtrairTelefone(contador, match);
                    }

                ok &= ValidarTelefones(matches, antigo.Fax);
            }

            if (!ok)
            {
                if (!ui)
                    return false;
                else
                    using (EditarTelefones dlg = new EditarTelefones(antigo, novo))
                    {
                        if (dlg.ShowDialog() == DialogResult.Cancel)
                            throw new Cancelar();

                        ok = true;
                    }
            }

            return ok;
        }

        /// <summary>
        /// Extrai um objeto do tipo telefone.
        /// </summary>
        private Telefone ExtrairTelefone(int contador, Match match)
        {
            Telefone telefone;
            telefone = new Telefone();

            telefone.Pessoa = novo;
            telefone.Descrição = match.Groups["descrição"].Value.Length == 0 ?
                contador.ToString() : match.Groups["descrição"].Value;

            if (match.Groups["ddd"].Value.Length > 0)
                telefone.Número = String.Format("({0}) {1}-{2}{3}",
                    match.Groups["ddd"].Value,
                    match.Groups["prefixo"].Value,
                    match.Groups["sufixo1"].Value,
                    match.Groups["sufixo2"].Value);
            else
                telefone.Número = String.Format("{0}-{1}{2}",
                    match.Groups["prefixo"].Value,
                    match.Groups["sufixo1"].Value,
                    match.Groups["sufixo2"].Value);

            if (match.Groups["obs"].Length > 0)
            {
                telefone.Observações = match.Groups["obs"].Value;

                if (antigo.Contato != null && antigo.Contato.Length > 1)
                    telefone.Observações += "\nContato: " + antigo.Contato;
            }
            else if (antigo.Contato != null && antigo.Contato.Length > 1)
                telefone.Observações = "Contato: " + antigo.Contato;
            else
                telefone.Observações = null;

            if (telefone.Número.Trim().Length > 3)
                novo.Telefones.Adicionar(telefone);

            return telefone;
        }

        /// <summary>
        /// Verifica se a interpretação está perfeita.
        /// </summary>
        private bool ValidarTelefones(MatchCollection matches, string origem)
        {
            int tamanho = 0, tamanhoTotal = 0;

            foreach (Match match in matches)
                if ((match.Groups["ddd"].Value.Length != 2 && match.Groups["ddd"].Value.Length != 0)
                    || match.Groups["prefixo"].Length < 3
                    || match.Groups["prefixo"].Length > 4
                    || match.Groups["sufixo1"].Length != 2
                    || match.Groups["sufixo2"].Length != 2)
                    return false;
                else
                {
                    tamanho += match.Groups["ddd"].Length + match.Groups["prefixo"].Length + match.Groups["sufixo1"].Length + match.Groups["sufixo2"].Length;
                    tamanhoTotal += match.Length;
                }

            if (tamanhoTotal + matches.Count - 1 < origem.Trim().Length)
            {
                foreach (char c in origem)
                    if (char.IsLetter(c))
                        return false;
                    else if (char.IsDigit(c))
                        tamanho--;

                return tamanho == 0;
            }
            else
                return true;
        }

        #endregion

        #region Categoria

        /// <summary>
        /// Importa o campo categoria.
        /// </summary>
        private bool ImportarCategoria()
        {
            if (antigo.Categoria != null)
            {
                switch (antigo.Categoria[0])
                {
                    case 'A':
                    case 'a':
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.Aprovado - 1);
                        break;

                    case 'D':
                    case 'd':
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.DifícilPagar - 1);
                        break;

                    case 'E':
                    case 'e':
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.Eliminado - 1);
                        break;

                    case 'F':
                    case 'f':
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.FazerFicha - 1);
                        break;

                    default:
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region Nosso número

        private static Regex regexNossoNúmero;

        protected static Regex RegexNossoNúmero
        {
            get
            {
                if (regexNossoNúmero == null)
                    regexNossoNúmero = new Regex(
                        @"((?<mês>\d{2})(?<ano>\d{4})\s*((?<maiorVenda>[TUDOVAIBEX]{3,})|\s+)(?<crédito>\d{2})"
                        + @"|(?<setor>AA)\s*"
                        + @"|\s*(?<classificação>(FF|NS|NSERVE|N/SERVE|NAO\sSERVE|N/S|FAZER\sFICHA|E-MAIL|EMAIL|INTERNET|SO\sDINHEIRO|SO\sA\sVISTA|FUNCIONARI[OA]|FEIRA|AGUARDAR|EX\sFUNCIONAR|EM\sDINHEIRO|A\sVISTA|EXP|EXPERIENCIA))\s*(?<crédito>\d{2})"
                        + @"|\s*(?<compraDe>HEIMAR|RODRIGO|MAURICIO\w*|CHICO|ADEMAR|EDWARD|CELSO|JOSE CARLOS|PIAZZA)\s*"
                        + @"|\s{8,9}(?<crédito>\d{2})"
                        + @"|\s{9}(?<crédito>0))"
                        + @"|\s*(?<classificação>(FF|NS|NSERVE|N/SERVE|NAO\sSERVE|N/S|FAZER\sFICHA|E-MAIL|EMAIL|INTERNET|SO\sDINHEIRO|SO\sA\sVISTA|FUNCIONARI[OA]|FEIRA|AGUARDAR|EX\sFUNCIONAR|EM\sDINHEIRO|A\sVISTA|EXP|EXPERIENCIA))\s*",
                        RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
                return regexNossoNúmero;
            }
        }

        /// <summary>
        /// Importa o campo nosso número.
        /// </summary>
        private bool ImportarNossoNúmero(bool ui)
        {
            bool ok = true;

            if (antigo.NossoNúmero != null)
            {
                Match match = RegexNossoNúmero.Match(antigo.NossoNúmero);

                ok = match.Length >= antigo.NossoNúmero.Trim().Length;

                if (match.Groups["mês"].Success && match.Groups["ano"].Success)
                {
                    int ano, mês;

                    ano = int.Parse(match.Groups["ano"].Value);
                    mês = int.Parse(match.Groups["mês"].Value);

                    if (mês > 12 || mês < 1)
                        mês = 1;

                    if (ano < 1900)
                        ano = ano >= 10 ? ano % 100 + 1900 : ano % 100 + 2000;

                    novo.DataRegistro = new DateTime(ano, mês, 1);
                }
                else
                    novo.DataRegistro = null;

                if (match.Groups["maiorVenda"].Success)
                {
                    ulong valor = 0;

                    foreach (char c in match.Groups["maiorVenda"].Value)
                    {
                        valor *= 10;

                        switch (c)
                        {
                            case 'X':
                            case 'x':
                                break;

                            case 'T':
                            case 't':
                                valor += 1;
                                break;

                            case 'U':
                            case 'u':
                                valor += 2;
                                break;

                            case 'D':
                            case 'd':
                                valor += 3;
                                break;

                            case 'O':
                            case 'o':
                                valor += 4;
                                break;

                            case 'V':
                            case 'v':
                                valor += 5;
                                break;

                            case 'A':
                            case 'a':
                                valor += 6;
                                break;

                            case 'I':
                            case 'i':
                                valor += 7;
                                break;

                            case 'B':
                            case 'b':
                                valor += 8;
                                break;

                            case 'E':
                            case 'e':
                                valor += 9;
                                break;

                            default:
                                ok = false;
                                goto depois_tudovaibex;
                        }
                    }

                    novo.MaiorVenda = valor;
                }

            depois_tudovaibex:
                if (match.Groups["crédito"].Success)
                    novo.Crédito = int.Parse(match.Groups["crédito"].Value) * 1000;

                if (match.Groups["setor"].Success)
                    if (match.Groups["setor"].Value == "AA")
                        novo.Setor = AltoAtacado;

                if (match.Groups["classificação"].Success)
                {
                    string str = match.Groups["classificação"].Value;

                    if (str == "FF" || str == "FAZER FICHA")
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.FazerFicha - 1);

                    else if (str == "NS" || str == "NSERVE" || str == "N/SERVE" || str == "NAO SERVE" || str == "N/S")
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.DifícilPagar - 1);

                    else if (str == "EMAIL" || str == "INTERNET")
                        AcrescentarComentário("Cliente iniciou contato pela Internet.");

                    else if (str == "SO DINHEIRO" || str == "EM DINHEIRO")
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.SomenteDinheiro - 1);

                    else if (str == "SO A VISTA" || str == "A VISTA")
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.SomenteÀVista - 1);

                    else if (str == "EXP" || str == "EXPERIENCIA")
                        novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.Experiência - 1);

                    else
                        ok = false;
                }

                if (match.Groups["compraDe"].Success)
                    AcrescentarComentário("Cliente de " + match.Groups["compraDe"].Value);

                if (!ok)
                {
                    if (!ui)
                        return false;
                    else
                    {
                        if (novo.DataRegistro == null && antigo.NossoNúmero.Length >= 4)
                        {
                            Regex data = new Regex(@"^(?<mês>\d{2})(?<ano>(\d{2}|\d{4}))", RegexOptions.ExplicitCapture);
                            Match mData = data.Match(antigo.NossoNúmero);

                            if (mData.Success)
                            {
                                int ano, mês;

                                ano = int.Parse(mData.Groups["ano"].Value);
                                mês = int.Parse(mData.Groups["mês"].Value);

                                novo.DataRegistro = new DateTime(
                                    ano < 10 ? ano + 2000 : (ano < 100 ? ano + 1900 : ano),
                                    mês >= 1 && mês <= 12 ? mês : 1,
                                    1);
                            }
                        }

                        using (EditarNossoNúmero dlg = new EditarNossoNúmero(antigo, novo, Varejo, Atacado, AltoAtacado))
                        {
                            if (dlg.ShowDialog() == DialogResult.Cancel)
                                throw new Cancelar();

                            ok = true;
                        }
                    }
                }
            }

            if (!ok)
            {
                string str = antigo.NossoNúmero.Trim();

                if (str == "TECHNOS")
                    AcrescentarComentário("TECHNOS");
            }

            return ok;
        }

        #endregion

        #region Região

        private bool ImportarRegião(bool ui)
        {
            if (antigo.Região == 11)
                novo.Setor = Varejo;

            else if (antigo.Região == 16)
                novo.Setor = Atacado;

            else
            {
                novo.Região = Região.ObterRegião(Convert.ToUInt16(antigo.Região));

                if (novo.Região == null)
                {
                    if (!ui)
                        return false;

                    novo.Região = new Região(Convert.ToUInt16(antigo.Região));
                    novo.Região.Cadastrar();

                    using (Apresentação.Pessoa.Endereço.EditarRegião região = new Apresentação.Pessoa.Endereço.EditarRegião(novo.Região))
                    {
                        if (região.ShowDialog() == DialogResult.OK)
                            novo.Região.Atualizar();
                    }
                }
            }

            return true;
        }

        #endregion

        #region Interpretar comentários

                private Regex regexComentário;

        private Regex RegexComentário
        {
            get
            {
                if (regexComentário == null)
                    regexComentário = new Regex(
                        @"(CLIENTE\sDESDE\s((?<dia>\d{1,2})/(?<mês>\d{1,2})/(?<ano>\d{2,4})|(?<mês>\d{1,2})/(?<ano>(\d{4}|\d{2}))|(?<ano>\d{4}))|"
                        + @"^DESDE\s((?<dia>\d{1,2})/(?<mês>\d{1,2})/(?<ano>\d{2,4})|(?<mês>\d{2})/(?<ano>(\d{4}|\d{2}))|(?<ano>\d{4}))|"
                        + @"^(?<devedor>DEVE\s)|"
                        + @".*\s(?<devedor>(DEVE|DEVENDO))\s)",
                        RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.Compiled);

                return regexComentário;
            }
        }

        private bool ImportarComentários(bool ui)
        {
            if (novo.Observações != null)
            {
                MatchCollection ms = RegexComentário.Matches(novo.Observações);
                bool devedor = false;

                foreach (Match m in ms)
                {
                    devedor |= m.Groups["devedor"].Success;

                    if (m.Groups["dia"].Success && m.Groups["mês"].Success && m.Groups["ano"].Success)
                    {
                        int dia, mês, ano;
                        DateTime data;

                        dia = int.Parse(m.Groups["dia"].Value);
                        mês = int.Parse(m.Groups["mês"].Value);
                        ano = int.Parse(m.Groups["ano"].Value);

                        try
                        {
                            data = new DateTime(ano < 10 ? ano + 2000 : (ano < 100 ? ano + 1900 : ano), mês, 1);

                            if (!novo.DataRegistro.HasValue || novo.DataRegistro.Value > data)
                                novo.DataRegistro = data;
                        }
                        catch { }
                    }
                    else if (m.Groups["mês"].Success && m.Groups["ano"].Success)
                    {
                        int mês, ano;
                        DateTime data;

                        mês = int.Parse(m.Groups["mês"].Value);
                        ano = int.Parse(m.Groups["ano"].Value);

                        if (mês > 0 && mês < 13)
                        {
                            data = new DateTime(ano < 10 ? ano + 2000 : (ano < 100 ? ano + 1900 : ano), mês, 1);

                            if (!novo.DataRegistro.HasValue || novo.DataRegistro.Value > data)
                                novo.DataRegistro = data;
                        }
                    }
                    else if (m.Groups["ano"].Success)
                    {
                        int ano = int.Parse(m.Groups["ano"].Value);
                        DateTime data = new DateTime(ano < 10 ? ano + 2000 : (ano < 100 ? ano + 1900 : ano), 1, 1);

                        if (!novo.DataRegistro.HasValue || novo.DataRegistro.Value > data)
                            novo.DataRegistro = data;
                    }
                }

                if (devedor)
                {
                    if (!ui)
                        return false;

                    novo.Classificações |= 1 << ((int)Classificação.CódigoSistema.Devedor - 1);

                    using (QuestionarDevedor dlg = new QuestionarDevedor(novo))
                    {
                        if (dlg.ShowDialog() == DialogResult.Cancel)
                            return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}
