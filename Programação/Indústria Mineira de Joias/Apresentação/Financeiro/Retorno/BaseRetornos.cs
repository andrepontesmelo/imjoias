using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Financeiro;
using System.Collections;
using Apresentação.Impressão.Relatórios.Retorno;

namespace Apresentação.Financeiro.Retorno
{
    public partial class BaseRetornos : BaseConsignado
    {
        public BaseRetornos()
        {
            InitializeComponent();
        }

        public BaseRetornos(Entidades.Pessoa.Pessoa cliente) : base(cliente)
        {
            InitializeComponent();
            título.Descrição = "São os documentos que registram as mercadorias que retornaram para a empresa, em consignação com " + cliente.PrimeiroNome;
        }

        protected override Apresentação.Impressão.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresentação.Impressão.TipoDocumento.Retorno;
            }
        }

        /// <summary>
        /// Cria entidade e cadastra no bd
        /// </summary>
        /// <param name="pessoa">relacionado para</param>
        /// <returns></returns>
        protected override Entidades.Relacionamento.Relacionamento CriarEntidade(Entidades.Pessoa.Pessoa pessoa)
        {
            return new Entidades.Relacionamento.Retorno.Retorno(pessoa);
        }

   
        protected override BaseEditarRelacionamento CriarBaseConsignado()
        {
            return new RetornoBaseInferior();
        }

        protected override ListaConsignado ObterLista()
        {
            return lista;
        }
    }
}
