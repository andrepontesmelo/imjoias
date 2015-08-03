using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Privilégio;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Componente para uso na interface gráfica que
    /// insere propriedades nos controles gráficos para
    /// controlar a permissão de edição e visualização,
    /// conforme privilégios do usuário.
    /// </summary>
    [ProvideProperty("PermissãoVisualização", typeof(Control))]
    [ProvideProperty("PermissãoEdição", typeof(Control))]
    public partial class ControlePermissão : Component, IExtenderProvider, IPósCargaSistema
    {
        private Dictionary<Control, Permissão> hashVisualização = new Dictionary<Control,Permissão>();
        private Dictionary<Control, Permissão> hashEdição = new Dictionary<Control, Permissão>();

        #region IPósCargaSistema Members

        public void AoCarregarCompletamente(Splash splash)
        {
            foreach (KeyValuePair<Control, Permissão> pares in hashVisualização)
                pares.Key.Visible = PermissãoFuncionário.ValidarPermissão(pares.Value);

            foreach (KeyValuePair<Control, Permissão> pares in hashEdição)
                pares.Key.Enabled = PermissãoFuncionário.ValidarPermissão(pares.Value);
        }

        #endregion

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is Control && !(extendee is BaseInferior);
        }

        [Description("Determina as permissões necessárias para visualizar o controle."),
         DisplayName("Visualização"),
         Category("Permissão"),
         DefaultValue(Permissão.Nenhuma)]
        public Permissão GetPermissãoVisualização(Control controle)
        {
            if (hashVisualização.ContainsKey(controle))
                return hashVisualização[controle];
            else
                return Permissão.Nenhuma;
        }

        public void SetPermissãoVisualização(Control controle, Permissão valor)
        {
            hashVisualização[controle] = valor;
        }

        [Description("Determina as permissões necessárias para editar o controle."),
         DisplayName("Edição"),
         Category("Permissão"),
         DefaultValue(Permissão.Nenhuma)]
        public Permissão GetPermissãoEdição(Control controle)
        {
            if (hashEdição.ContainsKey(controle))
                return hashEdição[controle];
            else
                return Permissão.Nenhuma;
        }

        public void SetPermissãoEdição(Control controle, Permissão valor)
        {
            hashEdição[controle] = valor;
        }

        #endregion
    }
}