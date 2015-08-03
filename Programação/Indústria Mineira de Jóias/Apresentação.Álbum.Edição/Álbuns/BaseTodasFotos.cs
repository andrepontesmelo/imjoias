using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Álbum;

namespace Apresentação.Álbum.Edição.Álbuns
{
    public partial class BaseTodasFotos : Apresentação.Formulários.BaseInferior
    {
        public BaseTodasFotos()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();
            todasFotos.Carregar();
        }

        private void opçãoPrefetch_Click(object sender, EventArgs e)
        {
            CacheMiniaturas cache = Entidades.Álbum.CacheMiniaturas.Instância;

            Aguarde janela = new Aguarde("Aguarde enquanto o arquivo de miniaturas é construído. Este processo pode demorar.", 1, "Processamento de miniaturas", cache.arquivoXml);
            janela.Abrir();

            cache.CarregarCacheMiniaturas();
            janela.Close();
        }
    }
}
