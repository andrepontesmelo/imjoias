using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Privilégio;

namespace Apresentação.Pessoa
{
    public class AlertaClassificação
    {
        /// <summary>
        /// Alerta o usuário caso exista classificação que requera
        /// um alerta pré-definido.
        /// </summary>
        public static void Alertar(Entidades.Pessoa.Pessoa pessoa, ItemAlertável.TipoAlerta alerta)
        {
            Classificação[] classificações = Classificação.ObterClassificações(
                pessoa.Classificações,
                alerta);

            Entidades.Pessoa.Histórico[] histórico = Entidades.Pessoa.Histórico.ObterHistórico(
                pessoa, alerta);

            if (classificações.Length > 0)
            {
                string msg = "Atenção! Este cliente está marcado com a(s) seguinte(s) classificação(ões):\n";

                foreach (Classificação classificação in classificações)
                    msg += "\n" + classificação.Denominação;

                AguardeDB.Suspensão(true);

                Apresentação.Útil.Beepador.Aviso();

                MessageBox.Show(
                    msg,
                    "Alerta de classificação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                AguardeDB.Suspensão(false);
            }

            if (histórico.Length > 0)
                foreach (Entidades.Pessoa.Histórico item in histórico)
                    Histórico.Alerta.Mostrar(item, alerta);

            foreach (Classificação classificação in classificações)
                if (classificação.ExigirPrivilégios != Permissão.Nenhuma)
                {
                    if (!Login.ExigirIdentificação(
                        null,
                        classificação.ExigirPrivilégios,
                        pessoa,
                        classificação.Denominação,
                        "Autorização para prosseguir com atividade",
                        "Para prosseguir, é necessário confirmar estar ciente da classificação de " + pessoa.Nome))
                        throw new PermissãoNegada(Funcionário.FuncionárioAtual);
                }
        }
    }
}
