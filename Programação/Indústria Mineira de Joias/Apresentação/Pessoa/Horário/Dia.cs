using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Horário
{
    partial class Dia : UserControl
    {
        public DayOfWeek diaSemana;

        /// <summary>
        /// Dia da semana.
        /// </summary>
        public DayOfWeek DiaSemana
        {
            get { return diaSemana; }
            set
            {
                diaSemana = value;

                switch (diaSemana)
                {
                    case DayOfWeek.Sunday:
                        lblDia.Text = "Dom.";
                        break;

                    case DayOfWeek.Monday:
                        lblDia.Text = "Seg.";
                        break;

                    case DayOfWeek.Tuesday:
                        lblDia.Text = "Terça";
                        break;

                    case DayOfWeek.Wednesday:
                        lblDia.Text = "Quarta";
                        break;

                    case DayOfWeek.Thursday:
                        lblDia.Text = "Quinta";
                        break;

                    case DayOfWeek.Friday:
                        lblDia.Text = "Sexta";
                        break;

                    case DayOfWeek.Saturday:
                        lblDia.Text = "Sábado";
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// Horários.
        /// </summary>
        public ControleHorário ControleHorário
        {
            get { return controleHorário; }
        }

        public Dia()
        {
            InitializeComponent();
        }
    }
}
