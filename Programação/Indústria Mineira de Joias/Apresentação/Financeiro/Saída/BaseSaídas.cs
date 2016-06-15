using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Apresentação.Financeiro;
using Apresentação.Formulários;
using System.Runtime.Remoting.Lifetime;
using Apresentação.Impressão.Relatórios.Saída;

namespace Apresentação.Financeiro.Saída
{
    public partial class BaseSaídas : BaseConsignado
    {
        public BaseSaídas() 
        {
            InitializeComponent();
        }

        public BaseSaídas(Entidades.Pessoa.Pessoa cliente) : base(cliente)
        {
            InitializeComponent();
            título.Descrição = "São os documentos que registram as mercadorias que sairam da empresa, em consignação com " + cliente.PrimeiroNome;
        }

        protected override Apresentação.Impressão.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresentação.Impressão.TipoDocumento.Saída;
            }
        }

        /// <summary>
        /// Cria entidade e cadastra no bd
        /// </summary>
        /// <param name="pessoa">relacionado para</param>
        /// <returns></returns>
        protected override Entidades.Relacionamento.Relacionamento CriarEntidade(Entidades.Pessoa.Pessoa pessoa)
        {
            return new Entidades.Relacionamento.Saída.Saída(pessoa);
        }

        protected override BaseEditarRelacionamento CriarBaseConsignado()
        {
            return new SaídaBaseInferior();
        }

        protected override ListaConsignado Lista
        {
            get { return listaSaídas; }
        }
    }
}
