//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using Entidades.Pessoa;

//namespace Apresentação.Pessoa.Cadastro
//{
//    public partial class DadosReferência : UserControl, Formulários.IEditorItem<Entidades.Pessoa.ReferênciaPessoal>
//    {
//        private Entidades.Pessoa.ReferênciaPessoal item;

//        public DadosReferência()
//        {
//            InitializeComponent();

//            throw new NotImplementedException();
//        }

//        private void txtFirma_Validated(object sender, EventArgs e)
//        {
//            item.Referência = txtFirma.Pessoa as Entidades.Pessoa.PessoaJurídica;

//            if (item.Referência == null && txtFirma.Text.Length > 0)
//            {
//                if (MessageBox.Show(
//                    ParentForm,
//                    "Não foi possível encontrar nenhuma firma com o nome " + txtFirma.Text + ". Deseja cadastrá-lo?",
//                    "Cadastro de firma",
//                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                {
//                    PessoaJurídica pessoa = Apresentação.Pessoa.Cadastro.CadastroPessoa.CadastrarNovaPessoaJurídica();

//                    if (pessoa != null)
//                    {
//                        txtFirma.Pessoa = pessoa;
//                        item.Referência = pessoa;
//                    }
//                }
//            }
//        }

//        public Entidades.Pessoa.ReferênciaPessoal Item
//        {
//            get
//            {
//                return item;
//            }
//            set
//            {
//                item = value;
//            }
//        }
//    }
//}
