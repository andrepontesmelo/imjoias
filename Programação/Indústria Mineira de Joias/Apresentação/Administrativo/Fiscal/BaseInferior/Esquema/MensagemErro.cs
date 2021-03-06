﻿using Entidades.Fiscal.Exceções;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public class MensagemErro
    {
        public static void MostrarMensagem(IWin32Window dono, ExceçãoFiscal erro, string título)
        {
            MessageBox.Show(dono,
            erro.Message,
            título,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
    }
}
