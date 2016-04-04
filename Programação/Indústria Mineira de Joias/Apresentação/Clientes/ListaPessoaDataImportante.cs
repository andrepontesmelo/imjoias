using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;
using Apresentação.Atendimento.Comum;

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
                    telefones.AppendLine();

                telefones.Append(telefone.Número);

                break;
            }

            lblPrimária.Text = data.Pessoa.Nome;

            lblSecundária.Text = telefones.ToString();
            lblDescrição.Text = string.Format(
                "{0:dd/MM} - {1} {2}",
                data.Data, DateTime.Now.Year - data.Data.Year,
                DateTime.Now.Year - data.Data.Year > 1 ? "anos" : "ano");

            this.data = data;

            picFoto.Image = ControladorÍconePessoa.ObterÍcone(data.Pessoa);

            //if (data.Pessoa.Foto != null)
            //    picFoto.Image = data.Pessoa.Foto;
        }

        public override int CompareTo(object obj)
        {
            DateTime outro = (((ListaPessoaDataImportante)obj).data.Data);

            try
            {
                return new DateTime(DateTime.Now.Year, data.Data.Month, data.Data.Day).CompareTo(
                    new DateTime(DateTime.Now.Year, outro.Month, outro.Day));
            }
            catch (Exception)
            {
                // Erro ao criar data 29 de fevereiro;
                return 0;
            }
        }

        protected internal override void Desselecionar()
        {
            base.Desselecionar();
            this.BackColor = Color.Transparent;
        }
    }
}
