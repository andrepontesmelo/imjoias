using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Álbum;
using Apresentação.Álbum.Edição.Álbuns.Desenhista;

namespace Apresentação.Álbum.Edição.Impressão
{
    public partial class JanelaOpçõesImpressão : JanelaExplicativa
    {
        public ItensImpressão Itens
        {
            get
            {
                ItensImpressão itens = ItensImpressão.Foto;

                if (chkReferência.Checked)
                    itens |= ItensImpressão.Referência;

                if (chkPeso.Checked)
                    itens |= ItensImpressão.Peso;

                if (chkDescrição.Checked)
                    itens |= ItensImpressão.Descrição;

                if (chkDescriçãoMercadoria.Checked)
                    itens |= ItensImpressão.DescriçãoMercadoria;

                if (chkFornecedor.Checked)
                    itens |= ItensImpressão.Fornecedor;

                if (chkDescriçãoFornecedor.Checked)
                    itens |= ItensImpressão.FornecedorReferência;

                if (chkFaixaGrupo.Checked)
                    itens |= ItensImpressão.FaixaGrupo;

                if (chkÍndice.Checked)
                    itens |= ItensImpressão.Índice;

                if (chkLogotipo.Checked)
                    itens |= ItensImpressão.Logotipo;

                if (chkForaDeLinha.Checked)
                    itens |= ItensImpressão.ForaDeLinha;

                return itens;
            }
        }

        public JanelaOpçõesImpressão()
        {
            InitializeComponent();
        }
    }
}