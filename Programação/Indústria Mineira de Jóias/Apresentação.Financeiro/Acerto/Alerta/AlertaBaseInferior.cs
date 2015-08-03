//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using Apresentação.Formulários;
//using Entidades.Relacionamento.Venda;
//using Entidades.Relacionamento;
//using Entidades.Acerto;

//namespace Apresentação.Financeiro.Acerto.Alerta
//{
//    public partial class AlertaBaseInferior : BaseInferior
//    {
//        List<AcertoAlerta> inconsistências;
//        private AcertoDocumentos documentos;

//        public AlertaBaseInferior()
//        {
//            InitializeComponent();
//        }

//        public void Carregar(AcertoDocumentos documentos)
//        {
//            AguardeDB.Mostrar();
            
//            this.documentos = documentos;
//            inconsistências = AcertoAlerta.ObterAlertas(documentos);

//            foreach (AcertoAlerta i in inconsistências)
//                flow.Controls.Add(AlertaQuadro.CriarQuadro(i));

//            AguardeDB.Fechar();
//        }

//        protected override void AoExibir()
//        {
//            base.AoExibir();

//            if (irParaAnterior)
//            {
//                irParaAnterior = false;
//                SubstituirBaseParaAnterior();
//            }
//            else
//            {
//                if (inconsistências.Count == 0)
//                    IrBaseResumo();
//            }
//        }

//        private bool irParaAnterior = false;
//        public void RetornarBaseAnterior()
//        {
//            irParaAnterior = true;
//        }

//        private void IrBaseResumo()
//        {
//            AguardeDB.Mostrar();
//            ResumoBaseInferior b = new ResumoBaseInferior();
//            b.Carregar(documentos);
            
//            // Caso usuário volte da futura base, vá para anterior.
//            irParaAnterior = true;

//            SubstituirBase(b);
//            AguardeDB.Fechar();
//        }

//        private void opçãoResumo_Click(object sender, EventArgs e)
//        {
//            IrBaseResumo();
//        }
//    }
//}
