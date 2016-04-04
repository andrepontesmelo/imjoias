using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Horário
{
    public partial class TabelaHorário : UserControl
    {
        public TabelaHorário()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mostra a entidade na interface gráfica.
        /// </summary>
        /// <param name="entidade">Entidade do banco de dados.</param>
        public void MostrarEntidade(Entidades.Pessoa.TabelaHorário entidade)
        {
            Dia[] controles;

            controles = ObterControles();

            foreach (Dia controle in controles)
                controle.ControleHorário.Limpar();

            foreach (Entidades.Pessoa.Horário horário in entidade)
                controles[(int)horário.DiaSemana].ControleHorário.Adicionar(
                    horário.IniHora, horário.IniMinuto,
                    horário.FimHora, horário.FimMinuto);
        }

        /// <summary>
        /// Constrói um vetor de controles de dia.
        /// </summary>
        private Dia[] ObterControles()
        {
            Dia[] controles;

            controles = new Dia[] {
                domingo,
                segunda,
                terça,
                quarta,
                quinta,
                sexta,
                sábado };

            return controles;
        }

        /// <summary>
        /// Atualiza os dados da entidade a partir da interface gráfica.
        /// </summary>
        /// <param name="entidade">Entidade do banco de dados.</param>
        public void AtualizarEntidade(Entidades.Pessoa.TabelaHorário entidade)
        {
            Dia[] controles = ObterControles();

            entidade.Limpar();
            
            foreach (Dia controle in controles)
                foreach (Horário horário in controle.ControleHorário.Horários)
                {
                    Entidades.Pessoa.Horário dbHorário;

                    dbHorário = new Entidades.Pessoa.Horário(
                        entidade.Funcionário);

                    dbHorário.DiaSemana = controle.DiaSemana;
                    dbHorário.IniHora = horário.InícioHora;
                    dbHorário.IniMinuto = horário.InícioMinuto;
                    dbHorário.FimHora = horário.FinalHora;
                    dbHorário.FimMinuto = horário.FinalMinuto;

                    entidade.Adicionar(dbHorário);
                }
        }
    }
}
