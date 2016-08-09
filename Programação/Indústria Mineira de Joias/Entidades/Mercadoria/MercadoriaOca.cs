using System;
using System.Data;
using System.Collections;

namespace Entidades.Mercadoria
{
	/// <summary>
	/// Mercadoria cujos dados são carregados do banco de dados
	/// à medida que requisitado.
	/// </summary>
	class MercadoriaCamposLeve : IMercadoriaCampos
	{
        private MercadoriaCampos campos;

        private string referênciaFormatada;
        private string referência;
        private int dígito = -1;
        private bool? dePeso;
        private double? peso;
        private bool? foraDeLinha = null;
        private bool preparando = false;

        /// <summary>
        /// Constrói a mercadoria oca.
        /// </summary>
        public MercadoriaCamposLeve(string referência, int dígito, bool? foradelinha, bool? dePeso, double? peso)
        {
            this.referência = referência;
            this.dígito = dígito;
            this.referênciaFormatada = Mercadoria.MascararReferência(referência, dígito);
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
                thread.Name = "MercadoriaOca: " + Referência;
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
                campos = MercadoriaCampos.ObterMercadoria(referência);
        }

        #region IMercadoriaCampos Members

        public string Referência
        {
            get
            {
                return referênciaFormatada;
            }
            set
            {
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
            }
        }

        public int Dígito
        {
            get { return dígito; }
        }

        public string ReferênciaNumérica
        {
            get { return referência; }
        }

        public string Descrição
        {
            get
            {
                if (campos == null)
                    Recuperar();

                return campos.Descrição;
            }
            set
            {
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
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
                throw new NotSupportedException("Atribuição não é suportada pela mercadoria oca.");
            }
        }

        #endregion
    }
}
