using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Estat�stica.Gr�ficos;

namespace Apresenta��o.Estat�stica.Windows
{
    public abstract partial class Gr�ficoEmGrade : Apresenta��o.Estat�stica.Windows.Gr�fico
    {
        public Gr�ficoEmGrade()
        {
            InitializeComponent();
        }

        protected new Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade desenhista
        {
            get { return (Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade) base.desenhista; }
            set { base.desenhista = value; }
        }

        public string EixoY
        {
            get { return desenhista.EixoY; }
            set { desenhista.EixoY = value; gr�fico = null; this.Invalidate(); }
        }

        public string EixoX
        {
            get { return desenhista.EixoX; }
            set { desenhista.EixoX = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oGradeHorizontal)]
        public bool GradeHorizontal
        {
            get { return desenhista.GradeHorizontal; }
            set { desenhista.GradeHorizontal = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oGradeVertical)]
        public bool GradeVertical
        {
            get { return desenhista.GradeVertical; }
            set { desenhista.GradeVertical = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oGapVertical)]
        public int GapVertical
        {
            get { return desenhista.GapVertical; }
            set { desenhista.GapVertical = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oGradeHorizontal)]
        public int GapHorizontal
        {
            get { return desenhista.GapHorizontal; }
            set { desenhista.GapHorizontal = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padr�oMaxY)]
        public double MaxY
        {
            get { return desenhista.MaxY; }
            set { desenhista.MaxY = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padr�oMinY)]
        public double MinY
        {
            get { return desenhista.MinY; }
            set { desenhista.MinY = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oValoresY)]
        public bool ValoresY
        {
            get { return desenhista.ValoresY; }
            set { desenhista.ValoresY = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oValoresX)]
        public bool ValoresX
        {
            get { return desenhista.ValoresX; }
            set { desenhista.ValoresX = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padr�oMinX)]
        public double MinX
        {
            get { return desenhista.MinX; }
            set { desenhista.MinX = value; gr�fico = null; this.Invalidate(); }
        }

        [DefaultValue(Desenhista.padr�oMaxX)]
        public double MaxX
        {
            get { return desenhista.MaxX; }
            set { desenhista.MaxX = value; gr�fico = null; this.Invalidate(); }
        }

        public event Entidades.Estat�stica.Gr�ficos.Convers�oValor ValorX
        {
            add { desenhista.ValorX = value; }
            remove { desenhista.ValorX = null; }
        }

        public event Convers�oValor ValorY
        {
            add { desenhista.ValorY = value; }
            remove { desenhista.ValorY = null; }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oFor�arValoresX)]
        public bool For�arEscritaValoresX
        {
            get { return desenhista.For�arEscritaValoresX; }
            set { desenhista.For�arEscritaValoresX = value; }
        }

        [Browsable(false), ReadOnly(true)]
        public string[] R�tulosX
        {
            get { return desenhista.R�tulosX; }
            set { desenhista.R�tulosX = value; }
        }

        [DefaultValue(Entidades.Estat�stica.Gr�ficos.Gr�ficoEmGrade.padr�oInteiroY)]
        public bool InteiroY
        {
            get { return desenhista.InteiroY; }
            set { desenhista.InteiroY = value; }
        }
    }
}

