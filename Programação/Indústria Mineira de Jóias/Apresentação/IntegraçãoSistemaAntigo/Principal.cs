using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Integra��oSistemaAntigo
{
	public class Principal : Apresenta��o.Formul�rios.BaseFormul�rio
	{
        Apresenta��o.Formul�rios.Bot�o bot�o1 = new Apresenta��o.Formul�rios.Bot�o();
        Apresenta��o.Formul�rios.Bot�o bot�o2 = new Apresenta��o.Formul�rios.Bot�o();
        Apresenta��o.Formul�rios.Bot�o bot�o3 = new Apresenta��o.Formul�rios.Bot�o();
        Apresenta��o.Formul�rios.Bot�o bot�o4 = new Apresenta��o.Formul�rios.Bot�o();
        Apresenta��o.Formul�rios.Bot�o bot�o5 = new Apresenta��o.Formul�rios.Bot�o();
        Apresenta��o.Formul�rios.Bot�o bot�o6 = new Apresenta��o.Formul�rios.Bot�o();
        Apresenta��o.Formul�rios.Bot�o bot�o7 = new Apresenta��o.Formul�rios.Bot�o();


		private System.ComponentModel.IContainer components = null;

		public Principal()
		{
			InitializeComponent();

			bot�o1.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.BaseMercadorias());
            bot�o2.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.BaseCodBarras());
            bot�o3.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.Cadcli.BaseCadCli());
            bot�o4.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.Pagamentos.BasePagamentos());
            bot�o5.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.Consignado.BaseConsignado());
            bot�o6.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.Vendas.BaseVendas());
            bot�o7.AdicionarBaseInferior(new Apresenta��o.Integra��oSistemaAntigo.Fiscal.BaseFiscal());

            //  bot�oMercadorias.AdicionarBaseInferior(new Apresenta��o.Mercadoria.Manuten��o.BaseEdi��o());

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
            // barraBot�es
            // 
            bot�o1.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�o1.Imagem")));
            bot�o1.Ordena��o = 0;
            bot�o1.Texto = "Mercadorias";
            bot�o2.Imagem = global::Apresenta��o.Resource.rod�zio;
            bot�o2.Ordena��o = 0;
            bot�o2.Texto = "C�digo de Barras";
            bot�o3.Imagem = ((System.Drawing.Image)(resources.GetObject("bot�o3.Imagem")));
            bot�o3.Ordena��o = 0;
            bot�o3.Texto = "Cadcli";
            bot�o4.Imagem = global::Apresenta��o.Resource.rod�zio;
            bot�o4.Ordena��o = 0;
            bot�o4.Texto = "Pagamentos";
            bot�o5.Imagem = global::Apresenta��o.Resource.rod�zio;
            bot�o5.Ordena��o = 0;
            bot�o5.Texto = "Consignado";
            bot�o6.Imagem = global::Apresenta��o.Resource.rod�zio;
            bot�o6.Ordena��o = 0;
            bot�o6.Texto = "Vendas";
            bot�o7.Imagem = global::Apresenta��o.Resource.rod�zio;
            bot�o7.Ordena��o = 0;
            bot�o7.Texto = "Fiscal";
            this.barraBot�es.Bot�es = new Apresenta��o.Formul�rios.Bot�o[] {
        bot�o1,
        bot�o2,
        bot�o3,
        bot�o4,
        bot�o5,
        bot�o6,
        bot�o7};
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
            //Integra��o.Apresenta��o.Aplica��oIntegrada.Executar(
            //    typeof(Principal),
            //    "Integra��oSistemaAntigo",
            //    8027,
            //    true,
            //    true);

            Apresenta��o.Formul�rios.Aplica��o.Executar(typeof(Principal), new Acesso.MySQL.MySQLUsu�rios());
		}
	}
}

