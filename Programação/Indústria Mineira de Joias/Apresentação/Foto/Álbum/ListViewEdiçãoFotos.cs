using Apresenta��o.�lbum.Edi��o.Fotos;
using Apresenta��o.Formul�rios;
using Apresenta��o.Mercadoria;
using Entidades.�lbum;
using System;
using System.Windows.Forms;

namespace Apresenta��o.�lbum.Edi��o.�lbuns
{
    public partial class ListViewEdi��oFotos : ListaFotos
    {
        private Entidades.�lbum.�lbum �lbum;
        private BaseInferior baseInferior;

        public BaseInferior BaseInferior
        { set { baseInferior = value; } }

        public Entidades.�lbum.�lbum �lbum
        {
            get { return �lbum; }
            set
            {
                if (�lbum != null)
                {
                    lock (�lbum)
                    {
                        �lbum.Fotos.AoAdicionar -= new Acesso.Comum.DbComposi��o<Foto>.EventoComposi��o(Fotos_AoAdicionar);
                        �lbum.Fotos.AoRemover -= new Acesso.Comum.DbComposi��o<Foto>.EventoComposi��o(Fotos_AoRemover);
                    }
                }

                �lbum = value;

                if (�lbum == null)
                    Limpar();
                else
                {
                    lock (�lbum)
                    {
                        base.Carregar(�lbum);
                        �lbum.Fotos.AoAdicionar += new Acesso.Comum.DbComposi��o<Foto>.EventoComposi��o(Fotos_AoAdicionar);
                        �lbum.Fotos.AoRemover += new Acesso.Comum.DbComposi��o<Foto>.EventoComposi��o(Fotos_AoRemover);
                    }
                }
            }
        }

        public ListViewEdi��oFotos()
        {
            InitializeComponent();

            try
            {
                lst.AllowDrop = true;
            }
#if !DEBUG
            catch (Exception e)
            {
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
            }
#else
            catch (Exception e)
            {
                MessageBox.Show("N�o foi poss�vel permitir o drag'n'drop no ListViewEdi��oFotos.");
                MessageBox.Show(e.ToString());
                MessageBox.Show("Erro ignorado (inclusive em modo Release).");
            }
#endif
        }

        public override void Carregar(Entidades.�lbum.�lbum �lbum)
        {
            this.�lbum = �lbum;
        }

        public override void Adicionar(Foto foto)
        {
            �lbum.Fotos.Adicionar(foto);
        }

        void Fotos_AoRemover(Acesso.Comum.DbComposi��o<Foto> composi��o, Foto entidade)
        {
            �lbum.Fotos.Atualizar();
        }

        void Fotos_AoAdicionar(Acesso.Comum.DbComposi��o<Foto> composi��o, Foto entidade)
        {
            base.Adicionar(entidade);
            �lbum.Fotos.Atualizar();
        }

        private void ListViewEdi��oFotos_AoSelecionar(Foto foto)
        {
            btnEditar.Enabled = foto != null;
            btnRemover.Enabled = Sele��es.Length > 0;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Foto[] fotos = Sele��es;

            if (fotos.Length == 0)
                return;

            if (MessageBox.Show(this, 
                String.Format("Deseja remover {0} foto(s) ?", fotos.Length),
                "Confirma��o de exclus�o",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            foreach (Foto f in fotos)
                �lbum.Fotos.Remover(f);

            Carregar(�lbum);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Sele��o == null)
                return;

            AguardeDB.Mostrar();

            Fot�grafo f = new Fot�grafo();
            baseInferior.SubstituirBase(f);
            f.Editar(Sele��o);

            AguardeDB.Fechar();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            baseInferior.SubstituirBase(new Fot�grafo());
        }

        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            Foto[] fotos = (Foto[])e.Data.GetData(typeof(Foto[]));

            if (fotos == null)
                return;

            UseWaitCursor = true;
            AguardeDB.Mostrar();

            foreach (Foto foto in fotos)
                Adiciona(foto);

            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private void Adiciona(Foto foto)
        {
            try
            {
                if (!�lbum.Fotos.Cont�m(foto))
                    �lbum.Fotos.Adicionar(foto);
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);

                MessageBox.Show(
                    ParentForm,
                    "N�o foi poss�vel adicionar a foto ao �lbum. Ocorreu o seguinte erro:\n\n" + erro.ToString(),
                    "Adicionar foto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Foto[])))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }


        private void btnConsultarFotografia_Click(object sender, EventArgs e)
        {
            AbrirJanelaInforma��esMercadoria();
        }

        private void AbrirJanelaInforma��esMercadoria()
        {
            if (Sele��o != null)
                JanelaInforma��esMercadoriaResumo.Abrir(Sele��o.Refer�nciaNum�rica);
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            AbrirJanelaInforma��esMercadoria();
        }
    }
}

