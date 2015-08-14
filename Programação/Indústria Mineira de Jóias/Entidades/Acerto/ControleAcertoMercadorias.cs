using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Collections;
using System.Data;
using Entidades.Mercadoria;
using Entidades.Relacionamento.Venda;
using Entidades.Pessoa;
using Entidades.Configuração;

namespace Entidades.Acerto
{
    /// <summary>
    /// Controlador para obtenção do acerto de representante ou consignado
    /// </summary>
    public class ControleAcertoMercadorias : DbManipulaçãoSimples
    {
        /// <summary>
        /// Hash que contm o acerto em s. chave  gerada pela mercadoria oca.
        /// </summary>
        private Dictionary<string, SaquinhoAcerto> hash;

        /// <summary>
        /// É disponibilizada uma versão ArrayList da hash:
        /// </summary>
        private List<SaquinhoAcerto> coleçãoSaquinhos;

        /// <summary>
        /// Acerto que está sendo trabalhado.
        /// </summary>
        private AcertoConsignado acerto;


        public AcertoConsignado Acerto
        {
            get { return acerto; }
        }


        public Pessoa.Pessoa Pessoa
        {
            get { return acerto.Cliente; }
        }

        public List<long> códigosSaídas;
        public List<long> códigosRetornos;
        public List<long> códigosVendas;

        public List<long> CódigoSaídas
        {
            get
            {
                if (códigosSaídas == null)
                    códigosSaídas = ExtrairCódigos(acerto.Saídas.ExtrairElementos());

                return códigosSaídas;
            }
        }
        
        public List<long> CódigoRetornos
        {
            get
            {
                if (códigosRetornos == null)
                    códigosRetornos = ExtrairCódigos(acerto.Retornos.ExtrairElementos());

                return códigosRetornos;
            }
        }

        public List<long> CódigoVendas
        {
            get
            {
                if (códigosVendas == null)
                    códigosVendas = ExtrairCódigos(acerto.Vendas.ExtrairElementos());

                return códigosVendas;
            }
        }

        /// <summary>
        /// Dado a numeração dos documentos,
        /// recupera todas as mercadorias que compõe o acerto
        /// </summary>
        public ControleAcertoMercadorias(AcertoConsignado acerto)
        {
            this.acerto = acerto;
            this.hash = new Dictionary<string, SaquinhoAcerto>(StringComparer.Ordinal);
            Entidades.Relacionamento.Saída.Saída.ObterAcerto(CódigoSaídas, hash, acerto.FórmulaAcerto);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(CódigoRetornos, hash, acerto.FórmulaAcerto);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(CódigoVendas, hash, acerto.FórmulaAcerto);
        }

        public ControleAcertoMercadorias(List<long> saídas, List<long> retornos, List<long> vendas)
        {
            this.códigosSaídas = saídas;
            this.códigosRetornos = retornos;
            this.códigosVendas = vendas;

            this.hash = new Dictionary<string, SaquinhoAcerto>(StringComparer.Ordinal);
            Entidades.Relacionamento.Saída.Saída.ObterAcerto(CódigoSaídas, hash, FórmulaAcerto.Padrão);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(CódigoRetornos, hash, FórmulaAcerto.Padrão);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(CódigoVendas, hash, FórmulaAcerto.Padrão);
        }

        private static List<long> ExtrairCódigos(IList lista)
        {
            List<long> códigos = new List<long>(lista.Count);

            foreach (Relacionamento.Relacionamento item in lista)
                códigos.Add(item.Código);

            códigos.Sort();

            return códigos;
        }

        public List<SaquinhoAcerto> ColeçãoSaquinhos
        {
            get
            {
                // Lista gerada toda vez intencionamente:
                // Na bandeja de acerto, a lista é modificada quando usuário solicita filtragem.
                // Ao utilizar esta propriedade em mais locais, modificar implementação da filtragem.
                //if (coleçãoSaquinhos == null)
                //{
                coleçãoSaquinhos = new List<SaquinhoAcerto>(hash.Count);

                    foreach (KeyValuePair<string, Entidades.Acerto.SaquinhoAcerto> tupla in hash)
                        coleçãoSaquinhos.Add(tupla.Value);

                    coleçãoSaquinhos.Sort(new SaquinhoAcertoComparador());
                //}

                return coleçãoSaquinhos;
            }
        }

        public Dictionary<string, SaquinhoAcerto> HashSaquinhos
        {
            get { return hash; }
        }

        public System.Data.DataSet ObterImpressão(bool resumido)
        {   
            System.Data.DataSet ds = new System.Data.DataSet();
            DataTable tabelaItens = new DataTable("Itens");
            DataTable tabelaInformações = new DataTable("Informações");

            tabelaItens.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("referência"),
                new DataColumn("peso"),
                new DataColumn("quantidade"),
                new DataColumn("saída"),
                new DataColumn("retorno"),
                new DataColumn("venda"),
                new DataColumn("acerto"),
                new DataColumn("depeso", typeof(bool)),
                new DataColumn("faixagrupo")
            });

            List<SaquinhoAcerto> lista = new List<SaquinhoAcerto>();

            foreach (KeyValuePair<string, SaquinhoAcerto> tupla in hash)
            {
                if ((resumido && tupla.Value.QtdAcerto != 0) || (!resumido))
                    lista.Add(tupla.Value);
            }

            // Ordena lista por referência e peso.
            lista.Sort(new SaquinhoAcertoComparador());

            foreach (SaquinhoAcerto s in lista)
            {
                DataRow linha = tabelaItens.NewRow();
                s.PreencherDataRow(linha);
                tabelaItens.Rows.Add(linha);
            }

            // Cria coluna pessoa, que é para quem está sendo feito o acerto
            DataColumn colPessoa = new DataColumn("pessoa", typeof(string));
            DataColumn colFuncionário = new DataColumn("funcionário", typeof(string));
            DataColumn colSaídas = new DataColumn("saídas", typeof(string));
            DataColumn colRetornos = new DataColumn("retornos", typeof(string));
            DataColumn colVendas = new DataColumn("vendas", typeof(string));
            DataColumn colÍndiceDevolvido = new DataColumn("indicedevolvido", typeof(string));

            tabelaInformações.Columns.Add(colPessoa);
            tabelaInformações.Columns.Add(colFuncionário);
            tabelaInformações.Columns.Add(colSaídas);
            tabelaInformações.Columns.Add(colRetornos);
            tabelaInformações.Columns.Add(colVendas);
            tabelaInformações.Columns.Add(colÍndiceDevolvido);

            // Escreve um item único
            DataRow itemÚnico = tabelaInformações.NewRow();
            itemÚnico[colPessoa] = Pessoa.Nome;
            itemÚnico[colFuncionário] = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            tabelaInformações.Rows.Add(itemÚnico);

            // Descreve saídas
            bool primeiro = true;
            foreach (long codSaída in CódigoSaídas)
            {
                if (!primeiro)
                    itemÚnico[colSaídas] += ", ";
                else
                    primeiro = false;

                itemÚnico[colSaídas] += codSaída.ToString();
            }

            // Descreve retornos
            primeiro = true;
            foreach (long codRetorno in CódigoRetornos)
            {
                if (!primeiro)
                    itemÚnico[colRetornos] += ", ";
                else
                    primeiro = false;

                itemÚnico[colRetornos] += codRetorno.ToString();
            }


            List<string> códigoFormatadoVendas = Entidades.Relacionamento.Venda.Venda.ObterCódigoVendas(CódigoVendas);

            // Descreve vendas
            primeiro = true;
            foreach (string codVenda in códigoFormatadoVendas)
            {
                if (!primeiro)
                    itemÚnico[colVendas] += ", ";
                else
                    primeiro = false;

                itemÚnico[colVendas] += codVenda;
            }

            // Adiciona as tabelas ao dataset.
            ds.Tables.Add(tabelaItens);
            ds.Tables.Add(tabelaInformações);

            return ds;
        }


        /// <summary>
        /// Preenche o rastro parte do rastro 'lista', olhando todos os documentos
        /// do tipo deste objeto. 
        /// </summary>
        public List<RastroItem> ObterRastro(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            List<RastroItem> lista = new List<RastroItem>();

            Entidades.Relacionamento.Venda.Venda.PreencherRastro(mercadoria, Pessoa, lista, ExtrairCódigos(acerto.Vendas.ExtrairElementos()));
            Entidades.Relacionamento.Saída.Saída.PreencherRastro(mercadoria, Pessoa, lista, ExtrairCódigos(acerto.Saídas.ExtrairElementos()));
            Entidades.Relacionamento.Retorno.Retorno.PreencherRastro(mercadoria, Pessoa, lista, ExtrairCódigos(acerto.Retornos.ExtrairElementos()));

            return lista;
        }

        public void Acertar()
        {
            acerto.Acertar();
        }

        /// <summary>
        /// Obtém data do primeiro documento não acertado.
        /// </summary>
        public static DateTime? ObterPrimeiraDataNãoAcertada(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM "
                        + "((SELECT data FROM saida WHERE pessoa = " + DbTransformar(pessoa.Código) + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) )"
                        + " UNION (SELECT data FROM venda WHERE " 
                        + (Entidades.Pessoa.Pessoa.ÉCliente(pessoa) ? "cliente" : "vendedor")
                        + " = " + DbTransformar(pessoa.Código) + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null))"
                        + " UNION (SELECT data FROM retorno WHERE pessoa = " + DbTransformar(pessoa.Código) + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null)  )"
                        +") documentos";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem saídas...
                        return null;
                    }
                }
        }

        /// <summary>
        /// Verifica se o acerto está correto.
        /// </summary>
        /// <returns>Valida o acerto.</returns>
        public bool Validar()
        {
            bool ok = true;

            List<SaquinhoAcerto> coleção = ColeçãoSaquinhos;
            foreach (SaquinhoAcerto s in coleção)
                ok &= s.QtdAcerto == 0;

            return ok;
        }

        public class ExceçãoAcertoInválido : ApplicationException
        {
            public ExceçãoAcertoInválido(string msg) : base(msg) { }
        }

        /// <summary>
        /// Lança venda do que não ficou acertado.
        /// </summary>
        /// <returns>Nova venda cadastrada.</returns>
        public Entidades.Relacionamento.Venda.Venda LançarVenda()
        {
            Venda venda;
            //DateTime agora = DadosGlobais.Instância.HoraDataAtual;

            if (!acerto.Cotação.HasValue)
                throw new Exception("Cotação não foi definida no acerto!");


            List<SaquinhoAcerto> coleção = ColeçãoSaquinhos;

            /* Representantes enviam venda com antecência e, portanto,
             * não podem gerar venda a partir das mercadorias que faltam.
             */
            //if (Representante.ÉRepresentante(acerto.Cliente))
            //    throw new NotSupportedException("Não é permitido lançar venda do restante do acerto para representante.");

            // Garantir que não existe quantidade negativa de saquinhos.
            // Talvez isso poderia entrar como devolução, não?
            // -- Júlio, 18/01/2007
            //
            // Sim, conforme solicitado pela Inês.
            // -- Júlio, 18/10/2007
            //foreach (SaquinhoAcerto s in coleção)
            //    if (s.QtdAcerto < 0)
            //        throw new ExceçãoAcertoInválido("Não é possível lançar venda do restante do acerto, pois existem mercadorias devolvidas a mais. Seria um erro de digitação?");

            venda = Venda.CriarNovaVenda(acerto.Cliente, Funcionário.FuncionárioAtual);

            venda.TabelaPreço = acerto.TabelaPreço;
            venda.Cotação = acerto.Cotação.Value;
            
            acerto.Adicionar(venda);


            // Relacionar itens...
            foreach (SaquinhoAcerto s in coleção)
            {
                /* Se o acerto é positivo, retornaram menos mercadorias
                 * que foram levadas. Portanto, entra como venda.
                 */
                if (s.QtdAcerto > 0)
                    venda.Itens.Relacionar(s.Mercadoria, s.QtdAcerto, s.Índice);

                /* Se o acerto é negativo, retornaram mais mercadoris do
                 * que foram levadas, ou possivelmente retornaram mercadorias
                 * que nem sequer haviam sido relacionadas na saída, caracterizando
                 * assim uma devolução de mercadoria.
                 */
                else if (s.QtdAcerto < 0)
                    // Atenção à quantidade de acerto negativa.
                    venda.ItensDevolução.Relacionar(s.Mercadoria, -s.QtdAcerto, s.Índice);
            }

            // Existe uma regra diferente para alto-atacadistas.
            if (venda.Cliente.Setor.Referente(Setor.ObterSetor(Setor.SetorSistema.AltoAtacado)))
            {
                /* Antes de 2013:
                 * Se o alto-atacadista vender 20% ou mais do valor
                 * das mercadorias de peça (que não são de peso),
                 * ele ganha 15% das mercadorias vendidas. Caso contrário,
                 * ele ganha apenas 10% de desconto das mercadorias vendidas.
                 * 
                 * Após 2013: 
                 * Desconto = 12%
                 */
                double totalÍndiceSaída;
                double totalÍndiceVendidoMenosDevolvido;
                double totalVendaPeça = 0;
                double porcentagemAtingida;
                double porcentagemDataDesconto;

                venda.Desconto = acerto.CalcularDesconto(out totalÍndiceSaída,
                    out totalÍndiceVendidoMenosDevolvido,
                    out totalVendaPeça,
                    out porcentagemAtingida,
                    out porcentagemDataDesconto);

                venda.Observações =
                        " == Cálculo do desconto == "
                        + "\nTotal índice saída:" + totalÍndiceSaída.ToString()
                        + "\nTotal índice vendido (menos devolução): " + totalÍndiceVendidoMenosDevolvido.ToString()
                        + "\nTotal vendido em peça (valor base para desconto):" + totalVendaPeça.ToString()
                        + "\nPorcentagem atingida:" + porcentagemAtingida.ToString() + " %"
                        + "\nPorcentagem desconto:" + porcentagemDataDesconto.ToString() + " %"
                        + "\nDesconto atribuído: " + venda.Desconto.ToString("C");
            }

            if (venda.Cadastrado)
                venda.Atualizar();
            else
                venda.Cadastrar();


            if (acerto.Previsão.HasValue)
            {
                venda.Data = acerto.Previsão.Value;
                venda.Atualizar();
            }

            return venda;
        }

        /// <summary>
        /// Pega coluna de devolução e retorna o somatório em índice
        /// </summary>
        /// <param name="depeso"></param>
        /// <returns></returns>
        public double ObterÍndiceDevolvido(bool depeso)
        {
            double totalÍndiceDevolvido = 0;
            List<SaquinhoAcerto> coleção = ColeçãoSaquinhos;

            foreach (SaquinhoAcerto s in coleção)
            {
                if (s.Mercadoria.DePeso == depeso)
                    totalÍndiceDevolvido += s.QtdDevolvida * s.Índice;
            }

            return totalÍndiceDevolvido;
        }

        /// <summary>
        /// Obtem a coluna de devolução do acerto, soma, e multiplica pela cotação.
        /// </summary>
        /// <param name="depeso"></param>
        /// <returns></returns>
        public double ObterValorDevolvido(bool depeso)
        {
            if (!acerto.Cotação.HasValue)
                throw new Exception("Acerto não tem cotação associada");

            return Math.Round(ObterÍndiceDevolvido(depeso) * acerto.Cotação.Value, 2);
        }

        /// <summary>
        /// Obtem a coluna de itens vendidos do acerto, e retorna a soma de índice
        /// </summary>
        /// <param name="depeso"></param>
        /// <returns></returns>
        public double ObterÍndiceVendido(bool depeso)
        {
            double totalÍndiceVendido = 0;
            List<SaquinhoAcerto> coleção = ColeçãoSaquinhos;

            foreach (SaquinhoAcerto s in coleção)
            {
                if (s.Mercadoria.DePeso == depeso)
                    totalÍndiceVendido += s.QtdVenda * s.Índice;
            }

            return totalÍndiceVendido;
        }

        /// <summary>
        /// Obtem a coluna de itens vendidos do acerto, e retorna a soma de índice, multiplicando pela cotação do acerto
        /// </summary> 
        public double ObterValorVendido(bool depeso)
        {
            if (!acerto.Cotação.HasValue)
                throw new Exception("Acerto não tem cotação associada");

            return Math.Round(ObterÍndiceVendido(depeso) * acerto.Cotação.Value, 2);
        }


        /// <summary>
        /// Soma o campo 'desconto' de cada venda do acerto e retorna a somatória
        /// Retorna valor monetário.
        /// </summary>
        public double ObterDesconto()
        {
            List<Venda> vendas = acerto.Vendas.ExtrairElementos();
            double totalDesconto = 0;

            foreach (Venda v in vendas)
            {
                totalDesconto += v.Desconto;
            }

            return totalDesconto;
        }

        /// <summary>
        /// Pega a coluna 'acerto', faz o somatório
        /// </summary>
        /// <returns></returns>
        public double ObterÍndiceAcertar()
        {
            double totalÍndiceAcertar = 0;
            List<SaquinhoAcerto> coleção = ColeçãoSaquinhos;

            foreach (SaquinhoAcerto s in coleção)
                    totalÍndiceAcertar += s.QtdAcerto * s.Índice;

            return totalÍndiceAcertar;
        }

        /// <summary>
        /// Pega a coluna 'acerto', faz o somatório e retorna o índice, subtraindo o desconto da venda
        /// </summary>
        /// <returns></returns>
        public double ObterÍndicePagar()
        {
            if (!acerto.Cotação.HasValue)
                throw new Exception("Acerto não tem cotação associada");

            double totalÍndiceAcertar = ObterÍndiceAcertar();
            double totalDesconto = ObterDesconto();
            
            double totalÍndicePagar = totalÍndiceAcertar - (totalDesconto / acerto.Cotação.Value);

            return totalÍndicePagar;
        }

        /// <summary>
        /// Pega a coluna 'acerto', faz o somatório e retorna o índice, subtraindo o desconto da venda,
        /// retorna valor em REAL.
        /// </summary>
        public double ObterValorPagar()
        {
            if (!acerto.Cotação.HasValue)
                throw new Exception("Acerto não tem cotação associada");

            return Math.Round(ObterÍndicePagar() * acerto.Cotação.Value, 2);
        }
    }
}
