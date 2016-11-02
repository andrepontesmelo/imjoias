using Apresentação.Formulário.Exceção;
using System.Windows.Forms;

namespace Apresentação.Formulário
{
    public partial class ComboRígido : ComboBox
    {
        public ComboRígido()
        {
            InitializeComponent();
        }

        private void ComboRígido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = SeleçãoNula;
        }

        protected virtual bool SeleçãoNula
        {
            get
            {
                throw new ExceçãoChamadaMétodoAbstrato();
            }
        }
    }
}
