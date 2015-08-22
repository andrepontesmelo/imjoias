using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Financeiro.Venda;
using Apresentação.Estoque.Entrada;
using Entidades.Estoque;

namespace Apresentação.Estoque.Extrato
{
    public partial class BaseExtrato : BaseInferior
    {
        public BaseExtrato()
        {
            InitializeComponent();
        }

        internal void Carregar(Entidades.Estoque.Saldo s)
        {
            títuloBaseInferior1.Título = "Extrato de " + s.ReferênciaFormatadaComDígito;

            if (s.Depeso)
                títuloBaseInferior1.Título += " - " + s.Peso.ToString() + "g";

            listaExtrato.Carregar(s);
        }

        private void listaExtrato_QuerAbrirDocumento(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            Apresentação.Financeiro.BaseEditarRelacionamento novaBase;

            if (relacionamento is Entidades.Relacionamento.Venda.Venda)
            {
                novaBase = new BaseEditarVenda();
            }
            else if (relacionamento is Entidades.Estoque.Entrada)
            {
                novaBase = new BaseEditarEntrada();
            }
            else
                throw new NotImplementedException();

            novaBase.Abrir(relacionamento);
            SubstituirBase(novaBase);
        }
    }
}
