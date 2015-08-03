using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Formulários;
using System.Windows.Forms;

namespace Apresentação.Usuário.Funcionários
{
    class ControladorInútil : ControladorBaseInferior
    {
        public override void Exibir()
        {
            MessageBox.Show("Aeee! Você clicou em um botão! =)");
        }

        protected override void AoCarregarCompletamente(Splash splash)
        {
        }

        protected override void AoEsconder()
        {
        }

        protected override void AoExibir()
        {
        }

        protected override void AoInserirBaseInferior(BaseInferior baseInferior)
        {
        }

        protected override void MostrarBaseFormulário(BaseInferior novaBase)
        {
        }

        public override BaseFormulário Formulário
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }
}
