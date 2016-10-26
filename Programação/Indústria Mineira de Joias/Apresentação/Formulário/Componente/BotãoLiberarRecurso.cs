using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Privilégio;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Botão usado para requisitar liberação de recurso.
    /// Caso o funcionário não possua privilégios suficientes,
    /// será pedido usuário e senha de outro funcionário com
    /// privilégios suficientes. Este funcionário terá que
    /// se justificar, registrando no histórico tanto dele
    /// quanto do funcionário que não possui privilégios.
    /// </summary>
    /// <remarks>
    /// Após liberado o recurso, o botão se torna invisível.
    /// </remarks>
    [DefaultEvent("LiberarRecurso"), DefaultProperty("Texto")]
    public partial class BotãoLiberarRecurso : UserControl
    {
        private Permissão privilégios;
        private string recurso;
        private string descrição;

        public event EventHandler LiberarRecurso;

        [DefaultValue("Liberar recurso")]
        public string Texto
        {
            get { return btn.Text; }
            set { btn.Text = value; }
        }

        public Permissão Privilégios
        {
            get { return privilégios; }
            set { privilégios = value; }
        }

        [Description("Nome do recurso a ser liberado. Esta informação constará no histórico.")]
        public string Recurso
        {
            get { return recurso; }
            set { recurso = value; }
        }

        [Description("Descrição do recurso a ser liberado.")]
        public string Descrição
        {
            get { return descrição; }
            set { descrição = value; }
        }

        [DefaultValue(FlatStyle.Standard)]
        public FlatStyle FlatStyle
        {
            get { return btn.FlatStyle; }
            set { btn.FlatStyle = value; }
        }

        public BotãoLiberarRecurso()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (Login.LiberarRecurso(
                ParentForm,
                privilégios,
                recurso,
                descrição))
            {
                Visible = false;
                LiberarRecurso(this, e);
            }
        }
    }
}
