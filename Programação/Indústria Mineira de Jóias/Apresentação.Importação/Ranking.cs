using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Apresentação.Importação
{
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {
            List<RankingItem> rankingItens = RankingItem.ObterRanking();

            foreach (RankingItem item in rankingItens)
            {
                ListViewItem i = new ListViewItem(new string[2] { item.Colaborador, item.Intervenções.ToString() });
                lista.Items.Add(i);
            }
        }

        private void Ranking_Resize(object sender, EventArgs e)
        {
            colIntervenções.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}