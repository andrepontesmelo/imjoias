using Apresentação.Atendimento.Comum;
using Entidades;

namespace Apresentação.Atendimento.Atendente
{
    public partial class ListaPessoasVisitante : ListaPessoasItem
    {
        private Visita visita;

        public Visita Visita { get { return visita; } }

        public ListaPessoasVisitante(Visita visita)
        {
            InitializeComponent();

            lblPrimária.Text = visita.ExtrairNomes();
            lblSecundária.Text = visita.Setor != null ? visita.Setor.Nome : "N/D";

            this.visita = visita;

            if (visita.Saída.HasValue)
            {
                if (visita.Atendente != null)
                {
                    lblDescrição.Text = string.Format(
                        "Atendido em {0:dd/MM/yyyy, HH:mm} por {1}",
                        visita.Espera.HasValue ? visita.Entrada.AddSeconds(visita.Espera.Value) : visita.Entrada,
                        visita.Atendente.Nome);
                }
                else
                    lblDescrição.Text = string.Format(
                        "Chegou em {0:dd/MM/yyyy, HH:mm} e saiu sem ser atendido às {1:HH:mm}",
                        visita.Entrada, visita.Saída.Value);
            }
            else if (visita.Atendente == null)
            {
                lblDescrição.Text = string.Format(
                    "Aguardando atendimento desde {0:dd/MM/yyyy, HH:mm}",
                    visita.Entrada);

                picFoto.Image = Resource.lendo1;
            }
            else
            {
                lblDescrição.Text = string.Format(
                    "Em atendimento desde {0:dd/MM/yyyy, HH:mm} por {1}",
                    visita.Espera.HasValue ? visita.Entrada.AddSeconds(visita.Espera.Value) : visita.Entrada,
                    visita.Atendente.PrimeiroNome);
            }
        }

        public override int CompareTo(object obj)
        {
            return -visita.Entrada.CompareTo(((ListaPessoasVisitante)obj).visita.Entrada);
        }
    }
}
