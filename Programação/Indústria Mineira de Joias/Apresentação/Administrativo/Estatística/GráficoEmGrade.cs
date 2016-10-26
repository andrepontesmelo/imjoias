using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Estatística.Gráficos;

namespace Apresentação.Estatística.Windows
{
    public abstract partial class GráficoEmGrade : Apresentação.Estatística.Windows.Gráfico
    {
        public GráficoEmGrade()
        {
            InitializeComponent();
        }

        protected new Entidades.Estatística.Gráficos.GráficoEmGrade desenhista
        {
            get { return (Entidades.Estatística.Gráficos.GráficoEmGrade) base.desenhista; }
            set { base.desenhista = value; }
        }

        public string EixoY
        {
            get { return desenhista.EixoY; }
            set { desenhista.EixoY = value; gráfico = null; this.Invalidate(); }
        }

        public string EixoX
        {
            get { return desenhista.EixoX; }
            set { desenhista.EixoX = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoGradeHorizontal)]
        public bool GradeHorizontal
        {
            get { return desenhista.GradeHorizontal; }
            set { desenhista.GradeHorizontal = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoGradeVertical)]
        public bool GradeVertical
        {
            get { return desenhista.GradeVertical; }
            set { desenhista.GradeVertical = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoGapVertical)]
        public int GapVertical
        {
            get { return desenhista.GapVertical; }
            set { desenhista.GapVertical = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoGradeHorizontal)]
        public int GapHorizontal
        {
            get { return desenhista.GapHorizontal; }
            set { desenhista.GapHorizontal = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padrãoMaxY)]
        public double MaxY
        {
            get { return desenhista.MaxY; }
            set { desenhista.MaxY = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padrãoMinY)]
        public double MinY
        {
            get { return desenhista.MinY; }
            set { desenhista.MinY = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoValoresY)]
        public bool ValoresY
        {
            get { return desenhista.ValoresY; }
            set { desenhista.ValoresY = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoValoresX)]
        public bool ValoresX
        {
            get { return desenhista.ValoresX; }
            set { desenhista.ValoresX = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padrãoMinX)]
        public double MinX
        {
            get { return desenhista.MinX; }
            set { desenhista.MinX = value; gráfico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padrãoMaxX)]
        public double MaxX
        {
            get { return desenhista.MaxX; }
            set { desenhista.MaxX = value; gráfico = null; this.Invalidate(); }
        }

        public event Entidades.Estatística.Gráficos.ConversãoValor ValorX
        {
            add { desenhista.ValorX = value; }
            remove { desenhista.ValorX = null; }
        }

        public event ConversãoValor ValorY
        {
            add { desenhista.ValorY = value; }
            remove { desenhista.ValorY = null; }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoForçarValoresX)]
        public bool ForçarEscritaValoresX
        {
            get { return desenhista.ForçarEscritaValoresX; }
            set { desenhista.ForçarEscritaValoresX = value; }
        }

        [Browsable(false), ReadOnly(true)]
        public string[] RótulosX
        {
            get { return desenhista.RótulosX; }
            set { desenhista.RótulosX = value; }
        }

        [DefaultValue(Entidades.Estatística.Gráficos.GráficoEmGrade.padrãoInteiroY)]
        public bool InteiroY
        {
            get { return desenhista.InteiroY; }
            set { desenhista.InteiroY = value; }
        }
    }
}

