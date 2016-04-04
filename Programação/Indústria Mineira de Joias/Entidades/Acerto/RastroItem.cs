using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Acerto
{
    public class RastroItem
    {
        public enum TipoEnum { Saída, Retorno, Venda }

        private TipoEnum    tipo;
        private DateTime    data;
        private long        códigoDocumento;
        private double      quantidade;
        private string      descrição;
        private string      documento;

        //// Método usado para obter a entidade, caso seja necessária.
        //private Relacionamento.Relacionamento.ObterRelacionamento métodoObterEntidade;

        #region Propriedades

        //public Relacionamento.Relacionamento.ObterRelacionamento MétodoObterEntidade
        //{
        //    get { return métodoObterEntidade; }
        //    set { métodoObterEntidade = value; }
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
        public long CódigoDocumento
        {
            get { return códigoDocumento; }
            set { códigoDocumento = value; }
        }
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        public string Descrição
        {
            get { return descrição; }
            set { descrição = value; }
        }
        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        #endregion

        public RastroItem(TipoEnum tipo, DateTime data, long códigoDocumento, double quantidade)
        {
            this.tipo = tipo;
            this.data = data;
            this.códigoDocumento = códigoDocumento;
            this.quantidade = quantidade;
        }

        /// <summary>
        /// Obtem a venda ou retorno ou saída deste item.
        /// </summary>
        /// <returns></returns>
        public Entidades.Relacionamento.RelacionamentoAcerto ObterRelacionamento()
        {
            switch (tipo)
            {
                case TipoEnum.Retorno:
                    return Entidades.Relacionamento.Retorno.Retorno.ObterRetorno(códigoDocumento);

                case TipoEnum.Venda:
                    return Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoDocumento);

                case TipoEnum.Saída:
                    return Entidades.Relacionamento.Saída.Saída.ObterSaída(códigoDocumento);

                default:
                    throw new Exception("Caso inexistente!");
            }
        }
    }
}
