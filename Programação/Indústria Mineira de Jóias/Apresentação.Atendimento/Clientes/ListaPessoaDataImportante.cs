using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Atendimento.Clientes
{
    public partial class ListaPessoaDataImportante : Apresentação.Atendimento.Comum.ListaPessoasItem
    {
        private DataRelevante data;

        public DataRelevante Data { get { return data; } }

        public ListaPessoaDataImportante(DataRelevante data)
        {
            StringBuilder telefones = new StringBuilder();

            InitializeComponent();

            foreach (Telefone telefone in data.Pessoa.Telefones)
            {
                if (telefones.Length > 0)
                    telefones.Append("; ");
                telefones.AppendFormat("{0}: {1}", telefone.Descrição, telefone.Número);
            }

            lblPrimária.Text = data.Pessoa.Nome;
            lblSecundária.Text = telefones.ToString();
            lblDescrição.Text = string.Format(
                "{0:dd/MM} - {1} {2}\n{3}",
                data.Data, DateTime.Now.Year - data.Data.Year,
                DateTime.Now.Year - data.Data.Year > 1 ? "anos" : "ano",
                data.Descrição);

            this.data = data;

            if (data.Pessoa.Foto != null)
                picFoto.Image = data.Pessoa.Foto;
        }

        public override int CompareTo(object obj)
        {
            DateTime outro = (((ListaPessoaDataImportante)obj).data.Data);

            return new DateTime(DateTime.Now.Year, data.Data.Month, data.Data.Day).CompareTo(
                new DateTime(DateTime.Now.Year, outro.Month, outro.Day));
        }

        protected internal override void Desselecionar()
        {
            base.Desselecionar();
            this.BackColor = Color.Transparent;
        }
    }
}
