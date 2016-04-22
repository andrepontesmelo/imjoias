//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using Apresentação.Formulários;
//using Entidades.Acerto;

//namespace Apresentação.Financeiro.Acerto.Alerta
//{
//    public partial class AlertaQuadro : UserControl
//    {
//        public AlertaQuadro()
//        {
//            InitializeComponent();
//        }

//        public string Descrição
//        {
//            set 
//            {
//                lblDescrição.Text = value
//                    + "\nOs seguintes documentos violam esta regra:";
//            }
//        }

//        public List<long> Códigos
//        {
//            set
//            {
//                bool primeiro = true;
//                string códigos = "";

//                if (value.Count == 0) return;

//                foreach (long código in value)
//                {
//                    if (primeiro)
//                        primeiro = false;
//                    else
//                        códigos += "; ";

//                    códigos += código.ToString();
//                }

//                lblCódigos.Text = códigos;
//            }
//        }

//        public string Título
//        {
//            set { quadro1.Título = value; }
//        }

//        public static AlertaQuadro CriarQuadro(AcertoAlerta i)
//        {
//            AlertaQuadro a = new AlertaQuadro();
//            a.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            
//            a.Códigos = i.Códigos;
//            a.Descrição = i.Descrição;
//            a.Título = i.Nome;

//            return a;
//        }
//    }
//}
