using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Apresenta��o.Financeiro;
using Apresenta��o.Formul�rios;
using System.Runtime.Remoting.Lifetime;
using Apresenta��o.Impress�o.Relat�rios.Sa�da;

namespace Apresenta��o.Financeiro.Sa�da
{
    public partial class BaseSa�das : BaseConsignado
    {
        public BaseSa�das() 
        {
            InitializeComponent();
        }

        public BaseSa�das(Entidades.Pessoa.Pessoa cliente) : base(cliente)
        {
            InitializeComponent();
            t�tulo.Descri��o = "S�o os documentos que registram as mercadorias que sairam da empresa, em consigna��o com " + cliente.PrimeiroNome;
        }

        protected override Apresenta��o.Impress�o.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresenta��o.Impress�o.TipoDocumento.Sa�da;
            }
        }

        /// <summary>
        /// Cria entidade e cadastra no bd
        /// </summary>
        /// <param name="pessoa">relacionado para</param>
        /// <returns></returns>
        protected override Entidades.Relacionamento.Relacionamento CriarEntidade(Entidades.Pessoa.Pessoa pessoa)
        {
            return new Entidades.Relacionamento.Sa�da.Sa�da(pessoa);
        }

        protected override BaseEditarRelacionamento CriarBaseConsignado()
        {
            return new Sa�daBaseInferior();
        }

        protected override ListaConsignado Lista
        {
            get { return listaSa�das; }
        }
    }
}
