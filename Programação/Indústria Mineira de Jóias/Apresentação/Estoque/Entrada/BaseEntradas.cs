using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Estoque.Entrada
{
    public partial class BaseEntradas : BaseInferior
    {
        public BaseEntradas()
        {
            InitializeComponent();
        }

        private void opção1_Click(object sender, EventArgs e)
        {

        }

        private void opçãoNova_Click(object sender, EventArgs e)
        {
            AbrirBaseEditar(new Entidades.Estoque.Entrada());
        }

        private void AbrirBaseEditar(Entidades.Estoque.Entrada entrada)
        {
            BaseEditarEntrada novaBase = new BaseEditarEntrada();
            novaBase.Abrir(entrada);
            SubstituirBase(novaBase);

        }
        private void listaEntradas_AoDuploClique(object sender, EventArgs e)
        {
            List<Entidades.Estoque.Entrada> lstSeleção = listaEntradas.Seleção;

            if (lstSeleção.Count > 0)
                AbrirBaseEditar(lstSeleção[0]);
        }

        private void opçãoExcluir_Click(object sender, EventArgs eArg)
        {
            List<Entidades.Estoque.Entrada> lstSeleção = listaEntradas.Seleção;

            if (lstSeleção.Count == 0)
            {
                MessageBox.Show(this,
                    "Nada selecionado",
                    "Favor selecionar documentos para exclusão.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            StringBuilder msg = new StringBuilder();
            msg.Append("Deseja apagar o(s) seguinte(s) ");
            msg.Append(lstSeleção.Count);
            msg.Append(" documento(s) ?\n\n");
            
            foreach (Entidades.Estoque.Entrada e in lstSeleção)
            {
                msg.Append(" * ");
                msg.Append(e.Código);
                msg.Append(" ");
                msg.Append(e.Data.ToLongDateString());
                msg.Append(" ");
                msg.AppendLine(e.Observações);
            }

            DialogResult resultado = MessageBox.Show(this,
                msg.ToString(),
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
                return;

            foreach (Entidades.Estoque.Entrada e in lstSeleção)
                e.Descadastrar();

            listaEntradas.Carregar();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaEntradas.Carregar();
        }
    }
}
