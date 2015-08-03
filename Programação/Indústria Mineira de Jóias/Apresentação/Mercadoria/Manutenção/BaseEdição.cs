using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;
using Apresentação.Formulários;

namespace Apresentação.Mercadoria.Manutenção
{
    public partial class BaseEdição : Apresentação.Formulários.BaseInferior
    {
        // Atributos
        //MercadoriaManutenção mercadoriaManutenção;

        public BaseEdição()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JanelaEdiçãoVínculo janela = new JanelaEdiçãoVínculo();
            janela.Show();
        }

        public void Abrir(MercadoriaManutenção entidade)
        {
            //this.mercadoriaManutenção = entidade;
            Entidades.Mercadoria.Mercadoria mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(entidade.Referência, null);
            
            informaçõesAlterações.Mercadoria = entidade;
            informaçõesVigentes.Mercadoria = MercadoriaManutenção.Criar(mercadoria);
            listaComponentesMercadoria.Carregar(mercadoria);
        }
    }
}
