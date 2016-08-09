using System;
using System.Data;
using System.Collections;

namespace Entidades.Mercadoria
{
	/// <summary>
	/// Mercadoria cujos dados s�o carregados do banco de dados
	/// � medida que requisitado.
	/// </summary>
	class MercadoriaCamposLeve : IMercadoriaCampos
	{
        private MercadoriaCampos campos;

        private string refer�nciaFormatada;
        private string refer�ncia;
        private int d�gito = -1;
        private bool? dePeso;
        private double? peso;
        private bool? foraDeLinha = null;
        private bool preparando = false;

        /// <summary>
        /// Constr�i a mercadoria oca.
        /// </summary>
        public MercadoriaCamposLeve(string refer�ncia, int d�gito, bool? foradelinha, bool? dePeso, double? peso)
        {
            this.refer�ncia = refer�ncia;
            this.d�gito = d�gito;
            this.refer�nciaFormatada = Mercadoria.MascararRefer�ncia(refer�ncia, d�gito);
            this.foraDeLinha = true;
            this.dePeso = dePeso;
            this.peso = peso;
        }

        /// <summary>
        /// Recupera dados da mercadoria em segundo plano.
        /// </summary>
        public void Preparar()
        {
            lock (this)
            {
                if (!preparando)
                    preparando = true;

                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Recuperar));
                thread.Name = "MercadoriaOca: " + Refer�ncia;
                thread.Start();

#if DEBUG
            Console.WriteLine("Preparando mercadoria oca...");
#endif
            }
        }

        public bool Preparado
        {
            get { return campos != null; }
        }

        public bool Preparando
        {
            get { return preparando; }
        }


        private void Recuperar()
        {
            if (campos == null)
                campos = MercadoriaCampos.ObterMercadoria(refer�ncia);
        }

        #region IMercadoriaCampos Members

        public string Refer�ncia
        {
            get
            {
                return refer�nciaFormatada;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public int D�gito
        {
            get { return d�gito; }
        }

        public string Refer�nciaNum�rica
        {
            get { return refer�ncia; }
        }

        public string Descri��o
        {
            get
            {
                if (campos == null)
                    Recuperar();

                return campos.Descri��o;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public int Teor
        {
            get
            {
                if (campos == null)
                    Recuperar();

                return campos.Teor;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public double PesoOriginal
        {
            get
            {
                if (campos != null)
                    return campos.PesoOriginal;

                if (peso.HasValue)
                    return peso.Value;

                Recuperar();

                return campos.PesoOriginal;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public string Faixa
        {
            get
            {
                if (campos == null)
                    Recuperar();

                return campos.Faixa;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public int? Grupo
        {
            get
            {
                if (campos == null)
                    Recuperar();

                return campos.Grupo;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public Coeficientes Coeficientes
        {
            get
            {
                if (campos == null)
                    Recuperar();

                return campos.Coeficientes;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public bool DePeso
        {
            get
            {
                if (dePeso.HasValue)
                    return dePeso.Value;

                if (campos == null)
                    Recuperar();

                return campos.DePeso;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        public bool ForaDeLinha
        {
            get
            {
                if (foraDeLinha.HasValue)
                    return foraDeLinha.Value;

                if (campos == null)
                    Recuperar();

                return campos.ForaDeLinha;
            }
            set
            {
                throw new NotSupportedException("Atribui��o n�o � suportada pela mercadoria oca.");
            }
        }

        #endregion
    }
}
