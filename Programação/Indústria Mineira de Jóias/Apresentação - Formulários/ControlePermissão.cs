using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Privil�gio;

namespace Apresenta��o.Formul�rios
{
    /// <summary>
    /// Componente para uso na interface gr�fica que
    /// insere propriedades nos controles gr�ficos para
    /// controlar a permiss�o de edi��o e visualiza��o,
    /// conforme privil�gios do usu�rio.
    /// </summary>
    [ProvideProperty("Permiss�oVisualiza��o", typeof(Control))]
    [ProvideProperty("Permiss�oEdi��o", typeof(Control))]
    public partial class ControlePermiss�o : Component, IExtenderProvider, IP�sCargaSistema
    {
        private Dictionary<Control, Permiss�o> hashVisualiza��o = new Dictionary<Control,Permiss�o>();
        private Dictionary<Control, Permiss�o> hashEdi��o = new Dictionary<Control, Permiss�o>();

        #region IP�sCargaSistema Members

        public void AoCarregarCompletamente(Splash splash)
        {
            foreach (KeyValuePair<Control, Permiss�o> pares in hashVisualiza��o)
                pares.Key.Visible = Permiss�oFuncion�rio.ValidarPermiss�o(pares.Value);

            foreach (KeyValuePair<Control, Permiss�o> pares in hashEdi��o)
                pares.Key.Enabled = Permiss�oFuncion�rio.ValidarPermiss�o(pares.Value);
        }

        #endregion

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is Control && !(extendee is BaseInferior);
        }

        [Description("Determina as permiss�es necess�rias para visualizar o controle."),
         DisplayName("Visualiza��o"),
         Category("Permiss�o"),
         DefaultValue(Permiss�o.Nenhuma)]
        public Permiss�o GetPermiss�oVisualiza��o(Control controle)
        {
            if (hashVisualiza��o.ContainsKey(controle))
                return hashVisualiza��o[controle];
            else
                return Permiss�o.Nenhuma;
        }

        public void SetPermiss�oVisualiza��o(Control controle, Permiss�o valor)
        {
            hashVisualiza��o[controle] = valor;
        }

        [Description("Determina as permiss�es necess�rias para editar o controle."),
         DisplayName("Edi��o"),
         Category("Permiss�o"),
         DefaultValue(Permiss�o.Nenhuma)]
        public Permiss�o GetPermiss�oEdi��o(Control controle)
        {
            if (hashEdi��o.ContainsKey(controle))
                return hashEdi��o[controle];
            else
                return Permiss�o.Nenhuma;
        }

        public void SetPermiss�oEdi��o(Control controle, Permiss�o valor)
        {
            hashEdi��o[controle] = valor;
        }

        #endregion
    }
}