using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Acerto
{
    public partial class MostradorAcerto : UserControl
    {
        private DateTime dataInicial, dataFinal;
        private List<MostradorAcertoItem> itens;

        public DateTime DataInicial
        {
            get { return dataInicial; }
        }

        public DateTime DataFinal
        {
            get { return dataFinal; }
        }

        public MostradorAcerto()
        {
            InitializeComponent();
        }

        public void Carregar(List<Entidades.Relacionamento.Relacionamento> saidas, List<Entidades.Relacionamento.Relacionamento> retornos, List<IDadosVenda> vendas)
        {
            dataInicial = DateTime.MaxValue;
            dataFinal = DateTime.MinValue;
            itens = new List<MostradorAcertoItem>();
            Graphics g = this.CreateGraphics();

            foreach (Entidades.Relacionamento.Relacionamento s in saidas)
            {
                ComputarDocumento(s.Data);
                itens.Add(new MostradorAcertoItemSaída(this, g, s.Data));
            }

            foreach (Entidades.Relacionamento.Relacionamento r in retornos)
            {
                ComputarDocumento(r.Data);
                itens.Add(new MostradorAcertoItemRetorno(this, g, r.Data));
            }

            foreach (IDadosVenda v in vendas)
            {
                ComputarDocumento(v.Data);
                itens.Add(new MostradorAcertoItemVenda(this, g, v.Data));
            }

            Desenhar();       
        }

        private void ComputarDocumento(DateTime data)
        {
            if (data < DataInicial)
                dataInicial = data;

            if (data > DataFinal)
                dataFinal = data;
        }

        private void MostradorAcerto_Paint(object sender, PaintEventArgs e)
        {
            Desenhar();
        }

        private void MostradorAcerto_Resize(object sender, EventArgs e)
        {
            Desenhar();
        }

        private void Desenhar()
        {
            this.CreateGraphics().Clear(Color.LightSlateGray);

            if (itens == null) return;

            foreach (MostradorAcertoItem item in itens)
                item.Desenhar();
        }
    }


    public abstract class MostradorAcertoItem
    {

        private MostradorAcerto mostrador;
        private Graphics g;
        //private double posiçãoRelativa;    // 0 inicio, 1 fim
        private DateTime data;

        public MostradorAcertoItem(MostradorAcerto mostrador, Graphics g, DateTime data)
        {
            this.mostrador = mostrador;
            this.g = g;
            this.data = data;
            //posiçãoRelativa = CalcularPosiçãoRelativa(data);
        }

        public void Desenhar()
        {
            g.DrawString(Letra(), mostrador.Font, Brushes.Blue, CalcularX(), 5, StringFormat.GenericDefault);
        }

        protected abstract string Letra();
        protected abstract Color Cor();

        private int CalcularX()
        {
            return (int) (0.9 * CalcularPosiçãoRelativa(data) * mostrador.Width);
        }

        private double CalcularPosiçãoRelativa(DateTime data)
        {
            if (mostrador.DataInicial == mostrador.DataFinal)
                return 0.5;

            TimeSpan antes = data - mostrador.DataInicial;
            TimeSpan depois = mostrador.DataFinal - data;

            if ((antes.Ticks + depois.Ticks) != 0)
                return antes.Ticks / (antes.Ticks + depois.Ticks);
            else 
                return 1;
        }
    }

    public class MostradorAcertoItemSaída : MostradorAcertoItem
    {
        public MostradorAcertoItemSaída(MostradorAcerto mostrador, Graphics g, DateTime data)
            : base(mostrador, g, data)
        {
        }
        protected override string Letra()
        {
            return "S";
        }

        protected override Color Cor()
        {
            return Color.Red;
        }
    }

    public class MostradorAcertoItemRetorno : MostradorAcertoItem
    {
        public MostradorAcertoItemRetorno(MostradorAcerto mostrador, Graphics g, DateTime data)
            : base(mostrador, g, data)
        {
        }

        protected override string Letra()
        {
            return "R";
        }

        protected override Color Cor()
        {
            return Color.Green;
        }
    }

    public class MostradorAcertoItemVenda : MostradorAcertoItem
    {
        public MostradorAcertoItemVenda(MostradorAcerto mostrador, Graphics g, DateTime data)
            : base(mostrador, g, data)
        {
        }
        protected override string Letra()
        {
            return "V";
        }

        protected override Color Cor()
        {
            return Color.Black;
        }
    }
}
