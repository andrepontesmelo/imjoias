using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Acerto
{
    public class RastroItem
    {
        public enum TipoEnum { Sa�da, Retorno, Venda }

        private TipoEnum    tipo;
        private DateTime    data;
        private long        c�digoDocumento;
        private double      quantidade;
        private string      descri��o;
        private string      documento;

        //// M�todo usado para obter a entidade, caso seja necess�ria.
        //private Relacionamento.Relacionamento.ObterRelacionamento m�todoObterEntidade;

        #region Propriedades

        //public Relacionamento.Relacionamento.ObterRelacionamento M�todoObterEntidade
        //{
        //    get { return m�todoObterEntidade; }
        //    set { m�todoObterEntidade = value; }
        //}
        public TipoEnum Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        } 
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        public long C�digoDocumento
        {
            get { return c�digoDocumento; }
            set { c�digoDocumento = value; }
        }
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        public string Descri��o
        {
            get { return descri��o; }
            set { descri��o = value; }
        }
        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        #endregion

        public RastroItem(TipoEnum tipo, DateTime data, long c�digoDocumento, double quantidade)
        {
            this.tipo = tipo;
            this.data = data;
            this.c�digoDocumento = c�digoDocumento;
            this.quantidade = quantidade;
        }

        /// <summary>
        /// Obtem a venda ou retorno ou sa�da deste item.
        /// </summary>
        /// <returns></returns>
        public Entidades.Relacionamento.RelacionamentoAcerto ObterRelacionamento()
        {
            switch (tipo)
            {
                case TipoEnum.Retorno:
                    return Entidades.Relacionamento.Retorno.Retorno.ObterRetorno(c�digoDocumento);

                case TipoEnum.Venda:
                    return Entidades.Relacionamento.Venda.Venda.ObterVenda(c�digoDocumento);

                case TipoEnum.Sa�da:
                    return Entidades.Relacionamento.Sa�da.Sa�da.ObterSa�da(c�digoDocumento);

                default:
                    throw new Exception("Caso inexistente!");
            }
        }
    }
}
