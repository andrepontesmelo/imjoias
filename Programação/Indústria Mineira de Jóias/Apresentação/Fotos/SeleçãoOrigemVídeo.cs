/*
 * using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using DirectX.Capture;

namespace Apresentação.Álbum.Edição.Fotos
{
    /// <summary>
    /// Janela para seleção de origem de captura de vídeo.
    /// </summary>
    public partial class SeleçãoOrigemVídeo : JanelaExplicativa
    {
        private Capture captura;

        public SeleçãoOrigemVídeo(Capture captura)
        {
            InitializeComponent();

            this.captura = captura;

            lstOrigem.DisplayMember = "Name";

            foreach (Source origem in captura.VideoSources)
                lstOrigem.Items.Add(origem);

            lstOrigem.SelectedItem = captura.VideoSource;
        }

        private void lstOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrigem.SelectedItem != null)
            {
                try
                {
                    captura.VideoSource = (Source)lstOrigem.SelectedItem;
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

                    captura.Stop();
                    captura.VideoSource = (Source)lstOrigem.SelectedItem;
                    captura.Start();
                }
            }
        }
    }
}
*/