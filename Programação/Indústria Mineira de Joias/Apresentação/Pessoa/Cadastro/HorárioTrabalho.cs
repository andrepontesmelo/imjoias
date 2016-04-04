using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class HorárioTrabalho : UserControl
    {
        public void MostrarEntidade(Entidades.Pessoa.Funcionário entidade)
        {
            tabelaHorário.MostrarEntidade(entidade.TabelaHorário);
        }

        public void AtualizarEntidade(Entidades.Pessoa.Funcionário entidade)
        {
            tabelaHorário.AtualizarEntidade(entidade.TabelaHorário);
        }

        public HorárioTrabalho()
        {
            InitializeComponent();
        }
    }
}
