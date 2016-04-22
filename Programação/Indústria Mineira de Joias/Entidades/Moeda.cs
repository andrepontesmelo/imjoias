using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using Acesso.Comum.Cache;
using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Moeda a ser utilizada na cotação.
    /// </summary>
    [DbTransação, Cacheável("ObterMoeda"), DbTabela("moeda"), Validade(6, 0, 0), NãoCopiarCache]
    public class Moeda : DbManipulaçãoAutomática
    {
        public enum MoedaSistema : uint
        {
            Ouro = 1,
            Onça = 2,
            DólarParalelo = 3,
            OuroVarejo = 4,
            DólarComercial = 6
        }

        #region Atributos

#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'
        [DbColuna("codigo"), DbChavePrimária(true)]
        private uint código;

        /// <summary>
        /// Determina se é uma moeda do sistema.
        /// </summary>
        private bool sistema;
#pragma warning restore 0649

        /// <summary>
        /// Nome da moeda.
        /// </summary>
        private string nome;

        ///// <summary>
        ///// Moeda vinculada.
        ///// </summary>
        ///// <example>
        ///// Ouro Atacado -> Ouro
        ///// </example>
        //[DbRelacionamento("código", "vinculo")]
        //private Moeda vínculo;

        ///// <summary>
        ///// Setores cuja moeda é utilizada.
        ///// </summary>
        //private DbComposição<Setor> setores;

        /// <summary>
        /// Componente de custo cujo valor será atualizado.
        /// </summary>
        [DbRelacionamento("codigo", "componenteCusto")]
        private Mercadoria.ComponenteCusto componenteCusto;

        [DbColuna("icone")]
        private DbFoto ícone;

        /// <summary>
        /// Número de casas decimais.
        /// </summary>
        private byte casasDecimais = 2;

        #endregion

        #region Propriedades

        /// <summary>
        /// Código da moeda.
        /// </summary>
        public uint Código { get { return código; } }

        /// <summary>
        /// Determina se é uma moeda do sistema.
        /// </summary>
        public bool Sistema { get { return sistema; } }

        /// <summary>
        /// Nome da moeda.
        /// </summary>
        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        ///// <summary>
        ///// Moeda vinculada.
        ///// </summary>
        ///// <example>
        ///// Ouro Atacado -> Ouro
        ///// </example>
        //public Moeda Vínculo { get { return vínculo; } set { vínculo = value; DefinirDesatualizado(); } }

        ///// <summary>
        ///// Setores cuja moeda é utilizada.
        ///// </summary>
        //public DbComposição<Setor> Setores
        //{
        //    get
        //    {
        //        if (setores == null)
        //            setores = new DbComposição<Setor>(
        //                ObterSetores(), new DbAção<Setor>(AdicionarSetor),
        //                null, new DbAção<Setor>(RemoverSetor));

        //        return setores;
        //    }
        //}

        /// <summary>
        /// Componente de custo, cujo valor será atualizado.
        /// </summary>
        public Mercadoria.ComponenteCusto ComponenteDeCusto
        {
            get { return componenteCusto; }
            set { componenteCusto = value; DefinirDesatualizado(); }
        }

        public Image Ícone { get { return ícone; } set { ícone = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Número de casas decimais para cotação.
        /// </summary>
        public byte CasasDecimais { get { return casasDecimais; } set { casasDecimais = value; DefinirDesatualizado(); } }

        #endregion

        #region Manipulação de dados

        ///// <summary>
        ///// Obtém setores associados.
        ///// </summary>
        //private IEnumerable<Setor> ObterSetores()
        //{
        //    if (Cadastrado)
        //    {
        //        string cmd = "SELECT s.* FROM setor s JOIN moedasetor m ON s.codigo = m.setor WHERE m.moeda = " +
        //            DbTransformar(código);

        //        return (Setor[])Mapear(typeof(Setor), cmd).ToArray(typeof(Setor));
        //    }
        //    else
        //        return new Setor[0];
        //}

        ///// <summary>
        ///// Adiciona um setor à moeda no banco de dados.
        ///// </summary>
        //private void AdicionarSetor(IDbCommand cmd, Setor setor)
        //{
        //    cmd.CommandText = "INSERT INTO moedasetor (moeda, setor) VALUES" +
        //        " (" + DbTransformar(código) + ", " +
        //        DbTransformar(setor.Código) + ")";

        //    cmd.ExecuteNonQuery();
        //}
        
        ///// <summary>
        ///// Remove um setor da moeda no banco de dados.
        ///// </summary>
        //private void RemoverSetor(IDbCommand cmd, Setor setor)
        //{
        //    cmd.CommandText = "DELETE FROM moedasetor WHERE" +
        //        " moeda = " + DbTransformar(código) + " AND " +
        //        " setor = " + DbTransformar(setor.Código);

        //    cmd.ExecuteNonQuery();
        //}

        /// <summary>
        /// Obtém a moeda a partir de um código.
        /// </summary>
        public static Moeda ObterMoeda(uint código)
        {
            return MapearÚnicaLinha<Moeda>(
                "SELECT * FROM moeda WHERE codigo = " + DbTransformar(código));
        }

        /// <summary>
        /// Obtém todas as moedas, ordenadas alfabeticamente.
        /// </summary>
        /// <returns></returns>
        public static Moeda[] ObterMoedas()
        {
            return Mapear<Moeda>(
                "SELECT * FROM moeda ORDER BY nome").ToArray();
        }

        public static Moeda ObterMoeda(MoedaSistema moeda)
        {
            return ObterMoeda((uint)moeda);
        }

        #endregion
    }
}
