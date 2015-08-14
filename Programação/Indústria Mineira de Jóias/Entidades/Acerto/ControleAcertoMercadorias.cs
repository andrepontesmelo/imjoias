using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Collections;
using System.Data;
using Entidades.Mercadoria;
using Entidades.Relacionamento.Venda;
using Entidades.Pessoa;
using Entidades.Configura��o;

namespace Entidades.Acerto
{
    /// <summary>
    /// Controlador para obten��o do acerto de representante ou consignado
    /// </summary>
    public class ControleAcertoMercadorias : DbManipula��oSimples
    {
        /// <summary>
        /// Hash que contm o acerto em s. chave  gerada pela mercadoria oca.
        /// </summary>
        private Dictionary<string, SaquinhoAcerto> hash;

        /// <summary>
        /// � disponibilizada uma vers�o ArrayList da hash:
        /// </summary>
        private List<SaquinhoAcerto> cole��oSaquinhos;

        /// <summary>
        /// Acerto que est� sendo trabalhado.
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

        public List<long> c�digosSa�das;
        public List<long> c�digosRetornos;
        public List<long> c�digosVendas;

        public List<long> C�digoSa�das
        {
            get
            {
                if (c�digosSa�das == null)
                    c�digosSa�das = ExtrairC�digos(acerto.Sa�das.ExtrairElementos());

                return c�digosSa�das;
            }
        }
        
        public List<long> C�digoRetornos
        {
            get
            {
                if (c�digosRetornos == null)
                    c�digosRetornos = ExtrairC�digos(acerto.Retornos.ExtrairElementos());

                return c�digosRetornos;
            }
        }

        public List<long> C�digoVendas
        {
            get
            {
                if (c�digosVendas == null)
                    c�digosVendas = ExtrairC�digos(acerto.Vendas.ExtrairElementos());

                return c�digosVendas;
            }
        }

        /// <summary>
        /// Dado a numera��o dos documentos,
        /// recupera todas as mercadorias que comp�e o acerto
        /// </summary>
        public ControleAcertoMercadorias(AcertoConsignado acerto)
        {
            this.acerto = acerto;
            this.hash = new Dictionary<string, SaquinhoAcerto>(StringComparer.Ordinal);
            Entidades.Relacionamento.Sa�da.Sa�da.ObterAcerto(C�digoSa�das, hash, acerto.F�rmulaAcerto);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(C�digoRetornos, hash, acerto.F�rmulaAcerto);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(C�digoVendas, hash, acerto.F�rmulaAcerto);
        }

        public ControleAcertoMercadorias(List<long> sa�das, List<long> retornos, List<long> vendas)
        {
            this.c�digosSa�das = sa�das;
            this.c�digosRetornos = retornos;
            this.c�digosVendas = vendas;

            this.hash = new Dictionary<string, SaquinhoAcerto>(StringComparer.Ordinal);
            Entidades.Relacionamento.Sa�da.Sa�da.ObterAcerto(C�digoSa�das, hash, F�rmulaAcerto.Padr�o);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(C�digoRetornos, hash, F�rmulaAcerto.Padr�o);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(C�digoVendas, hash, F�rmulaAcerto.Padr�o);
        }

        private static List<long> ExtrairC�digos(IList lista)
        {
            List<long> c�digos = new List<long>(lista.Count);

            foreach (Relacionamento.Relacionamento item in lista)
                c�digos.Add(item.C�digo);

            c�digos.Sort();

            return c�digos;
        }

        public List<SaquinhoAcerto> Cole��oSaquinhos
        {
            get
            {
                // Lista gerada toda vez intencionamente:
                // Na bandeja de acerto, a lista � modificada quando usu�rio solicita filtragem.
                // Ao utilizar esta propriedade em mais locais, modificar implementa��o da filtragem.
                //if (cole��oSaquinhos == null)
                //{
                cole��oSaquinhos = new List<SaquinhoAcerto>(hash.Count);

                    foreach (KeyValuePair<string, Entidades.Acerto.SaquinhoAcerto> tupla in hash)
                        cole��oSaquinhos.Add(tupla.Value);

                    cole��oSaquinhos.Sort(new SaquinhoAcertoComparador());
                //}

                return cole��oSaquinhos;
            }
        }

        public Dictionary<string, SaquinhoAcerto> HashSaquinhos
        {
            get { return hash; }
        }

        public System.Data.DataSet ObterImpress�o(bool resumido)
        {   
            System.Data.DataSet ds = new System.Data.DataSet();
            DataTable tabelaItens = new DataTable("Itens");
            DataTable tabelaInforma��es = new DataTable("Informa��es");

            tabelaItens.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("refer�ncia"),
                new DataColumn("peso"),
                new DataColumn("quantidade"),
                new DataColumn("sa�da"),
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

            // Ordena lista por refer�ncia e peso.
            lista.Sort(new SaquinhoAcertoComparador());

            foreach (SaquinhoAcerto s in lista)
            {
                DataRow linha = tabelaItens.NewRow();
                s.PreencherDataRow(linha);
                tabelaItens.Rows.Add(linha);
            }

            // Cria coluna pessoa, que � para quem est� sendo feito o acerto
            DataColumn colPessoa = new DataColumn("pessoa", typeof(string));
            DataColumn colFuncion�rio = new DataColumn("funcion�rio", typeof(string));
            DataColumn colSa�das = new DataColumn("sa�das", typeof(string));
            DataColumn colRetornos = new DataColumn("retornos", typeof(string));
            DataColumn colVendas = new DataColumn("vendas", typeof(string));
            DataColumn col�ndiceDevolvido = new DataColumn("indicedevolvido", typeof(string));

            tabelaInforma��es.Columns.Add(colPessoa);
            tabelaInforma��es.Columns.Add(colFuncion�rio);
            tabelaInforma��es.Columns.Add(colSa�das);
            tabelaInforma��es.Columns.Add(colRetornos);
            tabelaInforma��es.Columns.Add(colVendas);
            tabelaInforma��es.Columns.Add(col�ndiceDevolvido);

            // Escreve um item �nico
            DataRow item�nico = tabelaInforma��es.NewRow();
            item�nico[colPessoa] = Pessoa.Nome;
            item�nico[colFuncion�rio] = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;
            tabelaInforma��es.Rows.Add(item�nico);

            // Descreve sa�das
            bool primeiro = true;
            foreach (long codSa�da in C�digoSa�das)
            {
                if (!primeiro)
                    item�nico[colSa�das] += ", ";
                else
                    primeiro = false;

                item�nico[colSa�das] += codSa�da.ToString();
            }

            // Descreve retornos
            primeiro = true;
            foreach (long codRetorno in C�digoRetornos)
            {
                if (!primeiro)
                    item�nico[colRetornos] += ", ";
                else
                    primeiro = false;

                item�nico[colRetornos] += codRetorno.ToString();
            }


            List<string> c�digoFormatadoVendas = Entidades.Relacionamento.Venda.Venda.ObterC�digoVendas(C�digoVendas);

            // Descreve vendas
            primeiro = true;
            foreach (string codVenda in c�digoFormatadoVendas)
            {
                if (!primeiro)
                    item�nico[colVendas] += ", ";
                else
                    primeiro = false;

                item�nico[colVendas] += codVenda;
            }

            // Adiciona as tabelas ao dataset.
            ds.Tables.Add(tabelaItens);
            ds.Tables.Add(tabelaInforma��es);

            return ds;
        }


        /// <summary>
        /// Preenche o rastro parte do rastro 'lista', olhando todos os documentos
        /// do tipo deste objeto. 
        /// </summary>
        public List<RastroItem> ObterRastro(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            List<RastroItem> lista = new List<RastroItem>();

            Entidades.Relacionamento.Venda.Venda.PreencherRastro(mercadoria, Pessoa, lista, ExtrairC�digos(acerto.Vendas.ExtrairElementos()));
            Entidades.Relacionamento.Sa�da.Sa�da.PreencherRastro(mercadoria, Pessoa, lista, ExtrairC�digos(acerto.Sa�das.ExtrairElementos()));
            Entidades.Relacionamento.Retorno.Retorno.PreencherRastro(mercadoria, Pessoa, lista, ExtrairC�digos(acerto.Retornos.ExtrairElementos()));

            return lista;
        }

        public void Acertar()
        {
            acerto.Acertar();
        }

        /// <summary>
        /// Obt�m data do primeiro documento n�o acertado.
        /// </summary>
        public static DateTime? ObterPrimeiraDataN�oAcertada(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM "
                        + "((SELECT data FROM saida WHERE pessoa = " + DbTransformar(pessoa.C�digo) + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) )"
                        + " UNION (SELECT data FROM venda WHERE " 
                        + (Entidades.Pessoa.Pessoa.�Cliente(pessoa) ? "cliente" : "vendedor")
                        + " = " + DbTransformar(pessoa.C�digo) + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null))"
                        + " UNION (SELECT data FROM retorno WHERE pessoa = " + DbTransformar(pessoa.C�digo) + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null)  )"
                        +") documentos";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // N�o existem sa�das...
                        return null;
                    }
                }
        }

        /// <summary>
        /// Verifica se o acerto est� correto.
        /// </summary>
        /// <returns>Valida o acerto.</returns>
        public bool Validar()
        {
            bool ok = true;

            List<SaquinhoAcerto> cole��o = Cole��oSaquinhos;
            foreach (SaquinhoAcerto s in cole��o)
                ok &= s.QtdAcerto == 0;

            return ok;
        }

        public class Exce��oAcertoInv�lido : ApplicationException
        {
            public Exce��oAcertoInv�lido(string msg) : base(msg) { }
        }

        /// <summary>
        /// Lan�a venda do que n�o ficou acertado.
        /// </summary>
        /// <returns>Nova venda cadastrada.</returns>
        public Entidades.Relacionamento.Venda.Venda Lan�arVenda()
        {
            Venda venda;
            //DateTime agora = DadosGlobais.Inst�ncia.HoraDataAtual;

            if (!acerto.Cota��o.HasValue)
                throw new Exception("Cota��o n�o foi definida no acerto!");


            List<SaquinhoAcerto> cole��o = Cole��oSaquinhos;

            /* Representantes enviam venda com antec�ncia e, portanto,
             * n�o podem gerar venda a partir das mercadorias que faltam.
             */
            //if (Representante.�Representante(acerto.Cliente))
            //    throw new NotSupportedException("N�o � permitido lan�ar venda do restante do acerto para representante.");

            // Garantir que n�o existe quantidade negativa de saquinhos.
            // Talvez isso poderia entrar como devolu��o, n�o?
            // -- J�lio, 18/01/2007
            //
            // Sim, conforme solicitado pela In�s.
            // -- J�lio, 18/10/2007
            //foreach (SaquinhoAcerto s in cole��o)
            //    if (s.QtdAcerto < 0)
            //        throw new Exce��oAcertoInv�lido("N�o � poss�vel lan�ar venda do restante do acerto, pois existem mercadorias devolvidas a mais. Seria um erro de digita��o?");

            venda = Venda.CriarNovaVenda(acerto.Cliente, Funcion�rio.Funcion�rioAtual);

            venda.TabelaPre�o = acerto.TabelaPre�o;
            venda.Cota��o = acerto.Cota��o.Value;
            
            acerto.Adicionar(venda);


            // Relacionar itens...
            foreach (SaquinhoAcerto s in cole��o)
            {
                /* Se o acerto � positivo, retornaram menos mercadorias
                 * que foram levadas. Portanto, entra como venda.
                 */
                if (s.QtdAcerto > 0)
                    venda.Itens.Relacionar(s.Mercadoria, s.QtdAcerto, s.�ndice);

                /* Se o acerto � negativo, retornaram mais mercadoris do
                 * que foram levadas, ou possivelmente retornaram mercadorias
                 * que nem sequer haviam sido relacionadas na sa�da, caracterizando
                 * assim uma devolu��o de mercadoria.
                 */
                else if (s.QtdAcerto < 0)
                    // Aten��o � quantidade de acerto negativa.
                    venda.ItensDevolu��o.Relacionar(s.Mercadoria, -s.QtdAcerto, s.�ndice);
            }

            // Existe uma regra diferente para alto-atacadistas.
            if (venda.Cliente.Setor.Referente(Setor.ObterSetor(Setor.SetorSistema.AltoAtacado)))
            {
                /* Antes de 2013:
                 * Se o alto-atacadista vender 20% ou mais do valor
                 * das mercadorias de pe�a (que n�o s�o de peso),
                 * ele ganha 15% das mercadorias vendidas. Caso contr�rio,
                 * ele ganha apenas 10% de desconto das mercadorias vendidas.
                 * 
                 * Ap�s 2013: 
                 * Desconto = 12%
                 */
                double total�ndiceSa�da;
                double total�ndiceVendidoMenosDevolvido;
                double totalVendaPe�a = 0;
                double porcentagemAtingida;
                double porcentagemDataDesconto;

                venda.Desconto = acerto.CalcularDesconto(out total�ndiceSa�da,
                    out total�ndiceVendidoMenosDevolvido,
                    out totalVendaPe�a,
                    out porcentagemAtingida,
                    out porcentagemDataDesconto);

                venda.Observa��es =
                        " == C�lculo do desconto == "
                        + "\nTotal �ndice sa�da:" + total�ndiceSa�da.ToString()
                        + "\nTotal �ndice vendido (menos devolu��o): " + total�ndiceVendidoMenosDevolvido.ToString()
                        + "\nTotal vendido em pe�a (valor base para desconto):" + totalVendaPe�a.ToString()
                        + "\nPorcentagem atingida:" + porcentagemAtingida.ToString() + " %"
                        + "\nPorcentagem desconto:" + porcentagemDataDesconto.ToString() + " %"
                        + "\nDesconto atribu�do: " + venda.Desconto.ToString("C");
            }

            if (venda.Cadastrado)
                venda.Atualizar();
            else
                venda.Cadastrar();


            if (acerto.Previs�o.HasValue)
            {
                venda.Data = acerto.Previs�o.Value;
                venda.Atualizar();
            }

            return venda;
        }

        /// <summary>
        /// Pega coluna de devolu��o e retorna o somat�rio em �ndice
        /// </summary>
        /// <param name="depeso"></param>
        /// <returns></returns>
        public double Obter�ndiceDevolvido(bool depeso)
        {
            double total�ndiceDevolvido = 0;
            List<SaquinhoAcerto> cole��o = Cole��oSaquinhos;

            foreach (SaquinhoAcerto s in cole��o)
            {
                if (s.Mercadoria.DePeso == depeso)
                    total�ndiceDevolvido += s.QtdDevolvida * s.�ndice;
            }

            return total�ndiceDevolvido;
        }

        /// <summary>
        /// Obtem a coluna de devolu��o do acerto, soma, e multiplica pela cota��o.
        /// </summary>
        /// <param name="depeso"></param>
        /// <returns></returns>
        public double ObterValorDevolvido(bool depeso)
        {
            if (!acerto.Cota��o.HasValue)
                throw new Exception("Acerto n�o tem cota��o associada");

            return Math.Round(Obter�ndiceDevolvido(depeso) * acerto.Cota��o.Value, 2);
        }

        /// <summary>
        /// Obtem a coluna de itens vendidos do acerto, e retorna a soma de �ndice
        /// </summary>
        /// <param name="depeso"></param>
        /// <returns></returns>
        public double Obter�ndiceVendido(bool depeso)
        {
            double total�ndiceVendido = 0;
            List<SaquinhoAcerto> cole��o = Cole��oSaquinhos;

            foreach (SaquinhoAcerto s in cole��o)
            {
                if (s.Mercadoria.DePeso == depeso)
                    total�ndiceVendido += s.QtdVenda * s.�ndice;
            }

            return total�ndiceVendido;
        }

        /// <summary>
        /// Obtem a coluna de itens vendidos do acerto, e retorna a soma de �ndice, multiplicando pela cota��o do acerto
        /// </summary> 
        public double ObterValorVendido(bool depeso)
        {
            if (!acerto.Cota��o.HasValue)
                throw new Exception("Acerto n�o tem cota��o associada");

            return Math.Round(Obter�ndiceVendido(depeso) * acerto.Cota��o.Value, 2);
        }


        /// <summary>
        /// Soma o campo 'desconto' de cada venda do acerto e retorna a somat�ria
        /// Retorna valor monet�rio.
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
        /// Pega a coluna 'acerto', faz o somat�rio
        /// </summary>
        /// <returns></returns>
        public double Obter�ndiceAcertar()
        {
            double total�ndiceAcertar = 0;
            List<SaquinhoAcerto> cole��o = Cole��oSaquinhos;

            foreach (SaquinhoAcerto s in cole��o)
                    total�ndiceAcertar += s.QtdAcerto * s.�ndice;

            return total�ndiceAcertar;
        }

        /// <summary>
        /// Pega a coluna 'acerto', faz o somat�rio e retorna o �ndice, subtraindo o desconto da venda
        /// </summary>
        /// <returns></returns>
        public double Obter�ndicePagar()
        {
            if (!acerto.Cota��o.HasValue)
                throw new Exception("Acerto n�o tem cota��o associada");

            double total�ndiceAcertar = Obter�ndiceAcertar();
            double totalDesconto = ObterDesconto();
            
            double total�ndicePagar = total�ndiceAcertar - (totalDesconto / acerto.Cota��o.Value);

            return total�ndicePagar;
        }

        /// <summary>
        /// Pega a coluna 'acerto', faz o somat�rio e retorna o �ndice, subtraindo o desconto da venda,
        /// retorna valor em REAL.
        /// </summary>
        public double ObterValorPagar()
        {
            if (!acerto.Cota��o.HasValue)
                throw new Exception("Acerto n�o tem cota��o associada");

            return Math.Round(Obter�ndicePagar() * acerto.Cota��o.Value, 2);
        }
    }
}
