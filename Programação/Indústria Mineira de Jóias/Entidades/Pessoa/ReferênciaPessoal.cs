//using System;
//using System.Collections.Generic;
//using System.Text;
//using Acesso.Comum;

//namespace Entidades.Pessoa
//{
//    /// <summary>
//    /// Informações de referência pessoal.
//    /// </summary>
//    public class ReferênciaPessoal : DbManipulaçãoAutomática
//    {
//        [DbChavePrimária, DbRelacionamento("codigo", "pessoa")]
//        private Pessoa pessoa;

//        [DbChavePrimária, DbRelacionamento("codigo", "referencia"), DbColuna("referencia")]
//        private PessoaJurídica referência;

//        private string contato;

//        [DbColuna("observacoes")]
//        private string observações;

//        #region Propriedades

//        public Pessoa Pessoa { get { return pessoa; } }
//        public PessoaJurídica Referência { get { return referência; } set { referência = value; DefinirDesatualizado(); } }
//        public string Contato { get { return contato; } set { contato = value; DefinirDesatualizado();  } }
//        public string Observações { get { return observações; } set { observações = value; DefinirDesatualizado(); } }

//        #endregion
//    }
//}
