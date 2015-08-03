using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using Entidades.Álbum;
using System.Collections;

namespace Apresentação.Álbum.Edição.Álbuns.Desenhista
{
    /// <summary>
    /// Controla a impressão do álbum de fotos.
    /// </summary>
    public class ControleImpressão
    {
        private Entidades.Álbum.Álbum álbum;
        private Página página;
        private int última;
        private Foto[] fotos;
        private ItensImpressão itens = ItensImpressão.Referência | ItensImpressão.Foto;
        private int daPágina = 1, atéPágina = int.MaxValue;

        private ControleImpressão(Entidades.Álbum.Álbum álbum, ItensImpressão itens)
        {
            List<Foto> listaFotos;

            this.álbum = álbum;
            this.itens = itens;

            if ((itens & ItensImpressão.ForaDeLinha) == 0)
            {
                listaFotos = new List<Foto>();

                foreach (Foto foto in álbum.Fotos)
                    if (!foto.ObterMercadoria().ForaDeLinha)
                        listaFotos.Add(foto);
            }
            else
                listaFotos = new List<Foto>(álbum.Fotos);

            listaFotos.Sort();

            fotos = listaFotos.ToArray();
        }

        public static void Imprimir(Entidades.Álbum.Álbum álbum, ItensImpressão itens)
        {
            using (PrintDocument documento = new PrintDocument())
            {
                documento.DocumentName = "Álbum " + álbum.Nome;

                using (PrintDialog dlg = new PrintDialog())
                {
                    dlg.AllowCurrentPage = false;
                    dlg.AllowSelection = false;
                    dlg.AllowSomePages = true;
                    dlg.UseEXDialog = true;
                    dlg.Document = documento;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ControleImpressão ctrl = new ControleImpressão(álbum, itens);

                        ctrl.página = new Página(
                                documento.PrinterSettings.DefaultPageSettings.PrintableArea.Width / 100f,
                                documento.PrinterSettings.DefaultPageSettings.PrintableArea.Height / 100f,
                                4, 5);
            
                        ctrl.daPágina = dlg.PrinterSettings.FromPage;
                        ctrl.atéPágina = dlg.PrinterSettings.ToPage != 0 ?
                            dlg.PrinterSettings.ToPage : int.MaxValue;

                        documento.PrintPage += new PrintPageEventHandler(ctrl.ImprimirPágina);
                        documento.Print();
                    }
                }
            }
        }

        void ImprimirPágina(object sender, PrintPageEventArgs e)
        {
            while (página.página < daPágina)
            {
                página.página++;
                última += página.Linhas * página.Colunas + 1;
            }


            if (última < fotos.Length)
                última = página.Imprimir(e.Graphics, álbum.Nome, fotos, itens, última);

            e.HasMorePages = última < fotos.Length && página.página <= atéPágina;
        }
    }
}
