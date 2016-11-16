using Entidades.Configuração;
using Entidades.Fiscal;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Lista
{
    public partial class ListaMáquinasECF : UserControl
    {
        public ListaMáquinasECF()
        {
            InitializeComponent();
            if (!DadosGlobais.ModoDesenho)
                Carregar();
        }

        private void Carregar()
        {
            var máquinas = Máquina.Máquinas;
            ListViewItem[] itens = new ListViewItem[máquinas.Count];
            int x = 0;

            foreach (Máquina m in máquinas)
            {
                itens[x++] = new ListViewItem(new string[] { m.Código.ToString(),
                m.Modelo, m.Fabricação});
            }

            lista.Items.AddRange(itens);
        }
    }
}
