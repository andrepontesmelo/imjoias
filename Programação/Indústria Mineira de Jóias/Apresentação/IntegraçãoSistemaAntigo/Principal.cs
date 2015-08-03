using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.IntegraçãoSistemaAntigo
{
	public class Principal : Apresentação.Formulários.BaseFormulário
	{
        Apresentação.Formulários.Botão botão1 = new Apresentação.Formulários.Botão();
        Apresentação.Formulários.Botão botão2 = new Apresentação.Formulários.Botão();
        Apresentação.Formulários.Botão botão3 = new Apresentação.Formulários.Botão();
        Apresentação.Formulários.Botão botão4 = new Apresentação.Formulários.Botão();
        Apresentação.Formulários.Botão botão5 = new Apresentação.Formulários.Botão();
        Apresentação.Formulários.Botão botão6 = new Apresentação.Formulários.Botão();
        Apresentação.Formulários.Botão botão7 = new Apresentação.Formulários.Botão();


		private System.ComponentModel.IContainer components = null;

		public Principal()
		{
			InitializeComponent();

			botão1.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.BaseMercadorias());
            botão2.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.BaseCodBarras());
            botão3.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.Cadcli.BaseCadCli());
            botão4.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.Pagamentos.BasePagamentos());
            botão5.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.Consignado.BaseConsignado());
            botão6.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.Vendas.BaseVendas());
            botão7.AdicionarBaseInferior(new Apresentação.IntegraçãoSistemaAntigo.Fiscal.BaseFiscal());

            //  botãoMercadorias.AdicionarBaseInferior(new Apresentação.Mercadoria.Manutenção.BaseEdição());

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.topo.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraBotões
            // 
            botão1.Imagem = ((System.Drawing.Image)(resources.GetObject("botão1.Imagem")));
            botão1.Ordenação = 0;
            botão1.Texto = "Mercadorias";
            botão2.Imagem = global::Apresentação.Resource.rodízio;
            botão2.Ordenação = 0;
            botão2.Texto = "Código de Barras";
            botão3.Imagem = ((System.Drawing.Image)(resources.GetObject("botão3.Imagem")));
            botão3.Ordenação = 0;
            botão3.Texto = "Cadcli";
            botão4.Imagem = global::Apresentação.Resource.rodízio;
            botão4.Ordenação = 0;
            botão4.Texto = "Pagamentos";
            botão5.Imagem = global::Apresentação.Resource.rodízio;
            botão5.Ordenação = 0;
            botão5.Texto = "Consignado";
            botão6.Imagem = global::Apresentação.Resource.rodízio;
            botão6.Ordenação = 0;
            botão6.Texto = "Vendas";
            botão7.Imagem = global::Apresentação.Resource.rodízio;
            botão7.Ordenação = 0;
            botão7.Texto = "Fiscal";
            this.barraBotões.Botões = new Apresentação.Formulários.Botão[] {
        botão1,
        botão2,
        botão3,
        botão4,
        botão5,
        botão6,
        botão7};
            // 
            // Principal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "Principal";
            this.topo.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        [STAThreadAttribute()]
		public static void Main(string [] args)
		{
            //Integração.Apresentação.AplicaçãoIntegrada.Executar(
            //    typeof(Principal),
            //    "IntegraçãoSistemaAntigo",
            //    8027,
            //    true,
            //    true);

            Apresentação.Formulários.Aplicação.Executar(typeof(Principal), new Acesso.MySQL.MySQLUsuários());
		}
	}
}

