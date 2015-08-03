using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.�lbum;
using Apresenta��o.Formul�rios;
using Apresenta��o.�lbum.Edi��o.Fotos;

namespace Apresenta��o.�lbum.Edi��o.�lbuns
{
    public partial class ListViewEdi��oFotos : ListaFotos
    {
        private Entidades.�lbum.�lbum �lbum;
        private BaseInferior baseInferior;

        #region Propriedades

        public BaseInferior BaseInferior
        { set { baseInferior = value; } }

        /// <summary>
        /// Entidade de �lbum em edi��o.
        /// </summary>
        public Entidades.�lbum.�lbum �lbum
        {
            get { return �lbum; }
            set
            {
                if (�lbum != null)
                {
                    lock (�lbum)
                    {
                        // Desregistra eventos passados
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

        #endregion

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

        /// <summary>
        /// Carrega um �lbum para edi��o.
        /// </summary>
        /// <param name="�lbum">�lbum a ser editado.</param>
        public override void Carregar(Entidades.�lbum.�lbum �lbum)
        {
            this.�lbum = �lbum;
        }

        /// <summary>
        /// Adiciona um item ao �lbum.
        /// </summary>
        /// <param name="foto">Foto a ser adicionada.</param>
        public override void Adicionar(Foto foto)
        {
            �lbum.Fotos.Adicionar(foto);

            // A interface ser� modificada pelo evento da composi��o.
        }

        ///// <summary>
        ///// Remove um item do �lbum.
        ///// </summary>
        ///// <param name="foto">Foto a ser removida.</param>
        //public override void Remover(Foto foto)
        //{
        //    �lbum.Fotos.Remover(foto);

        //    // A interface ser� modificada pelo evento da composi��o.
        //}

        /// <summary>
        /// Ocorre ao remover um item da composi��o do �lbum.
        /// </summary>
        void Fotos_AoRemover(Acesso.Comum.DbComposi��o<Foto> composi��o, Foto entidade)
        {
            //base.Remover(entidade);
            �lbum.Fotos.Atualizar();
        }

        /// <summary>
        /// Ocorre ao adicionar um item da composi��o do �lbum.
        /// </summary>
        void Fotos_AoAdicionar(Acesso.Comum.DbComposi��o<Foto> composi��o, Foto entidade)
        {
            base.Adicionar(entidade);
            �lbum.Fotos.Atualizar();
        }

        /// <summary>
        /// Ocorre ao mudar a sele��o.
        /// </summary>
        private void ListViewEdi��oFotos_AoSelecionar(Foto foto)
        {
            btnEditar.Enabled = foto != null;
            btnRemover.Enabled = Sele��es.Length > 0;
        }

        /// <summary>
        /// Ocorre quando usu�rio clica em remover foto selecionada.
        /// </summary>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            Foto[] fotos = Sele��es;

            foreach (Foto f in fotos)
                �lbum.Fotos.Remover(f);

            Carregar(�lbum);
        }

        /// <summary>
        /// Ocorre quando usu�rio clica em editar foto selecionada.
        /// </summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Sele��o != null)
            {
                AguardeDB.Mostrar();
                Fot�grafo f = new Fot�grafo();
                baseInferior.SubstituirBase(f);
                f.Editar(Sele��o);
                AguardeDB.Fechar();
            }
        }

        /// <summary>
        /// Ocorre quando usu�rio clica em capturar nova foto.
        /// </summary>
        private void btnCapturar_Click(object sender, EventArgs e)
        {
            baseInferior.SubstituirBase(new Fot�grafo());
            //Fot�grafo.Inst�ncia.Controlador.Exibir();
            //Fot�grafo.Inst�ncia.lista�lbuns.Marcar(�lbum);
        }

        ///// <summary>
        ///// Dispara duplo clique ao receber um.
        ///// </summary>
        //private void lst_DoubleClick(object sender, EventArgs e)
        //{
        //    OnDoubleClick(e);
        //}

        /// <summary>
        /// Ocorre ao receber um elemento por drag'n'drop.
        /// </summary>
        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();
            Foto[] fotos = (Foto[])e.Data.GetData(typeof(Foto[]));

            if (fotos != null)
                foreach (Foto foto in fotos)
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

            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Foto[])))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}

