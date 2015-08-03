using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Formulários.Consultas
{
    /// <summary>
    /// Controla o limite do coletor automaticamente.
    /// O limite deve respeitar o limiteMínimo e não exceder a demoraMáxima.
    /// </summary>
    public class ControladorLimiteColetor
    {
        private int         limiteDinâmico;
        private int         limiteMínimo;
        private int?        limiteMáximo;
        private int         demoraMáximaMs;
        private DateTime    tempoInício;
        
        private bool        cronometroIniciado;

        /// <summary>
        /// É o limite ideal para obtenção de entidades.
        /// Chame os métodos Cronometrar... antes e depois da obtenção de entidades no coletor específico.
        /// </summary>
        public int LimiteDinâmico
        {
            get { return limiteDinâmico; }
        }

        public ControladorLimiteColetor(int limiteMínimo, int? limiteMáximo, int demoraMáximaMs)
        {
            this.limiteMínimo = limiteMínimo;
            this.demoraMáximaMs = demoraMáximaMs;
            this.limiteMáximo = limiteMáximo;

            //É razoável que o quantidade de entidades obtidadas inicialmente seja o triplo do mínimo
            limiteDinâmico = limiteMínimo * 3;

            cronometroIniciado = false;
        }

        /// <summary>
        /// Deve ser chamado pelo coletor específico antes de chamar o método
        /// de obter entidades do banco de dados.
        /// O objeto é obter o tempo da obtenção de dados para regulagem do limite.
        /// </summary>
        public void CronometrarInicioObter()
        {
            tempoInício = DateTime.Now;
            cronometroIniciado = true;
        }

        /// <summary>
        /// Deve ser chamado após dados sejam obtidos do banco de dados.
        /// O objeto é obter o tempo da obtenção de dados para regulagem do limite.
        /// </summary>
        public void CronometrarFimObter()
        {
            if (!cronometroIniciado)
            {
#if DEBUG
                throw new Exception("Chamado o método Fim ante do Inciio!");
#else
                return;
#endif
            } 
              
            DateTime tempoFim = DateTime.Now;
            TimeSpan tempoPassado = tempoFim - tempoInício;
            Console.WriteLine("Tempo = {0}", tempoPassado.TotalMilliseconds.ToString());

            if (tempoPassado.TotalMilliseconds > demoraMáximaMs)
            {
                // Temos que reduzir o tempo.
                if (limiteDinâmico <= limiteMínimo)
                {
                    Console.WriteLine("Maquina lenta!!!! limite não pode ser rebaixado. Limite=" + limiteMínimo.ToString()); 
                    // A máquina é muito lenta.
                    return;
                }
                else
                {
                    // Vamos reduzir o tempo diminuindo o limite de entidades obtidas.
                     Console.WriteLine("Limite da maquina!!!! Limite=" + limiteDinâmico.ToString());

                    if (limiteDinâmico / 2 >= limiteMínimo)
                        limiteDinâmico /= 2;
                    else
                        limiteDinâmico--;
                }
            }
            else
            {
                if (!limiteMáximo.HasValue ||
                    limiteDinâmico * 2 <= limiteMáximo.Value)
                {
                    // Podemos obter mais entidades, a maquina é rapida
                    //limiteDinâmico++;
                    limiteDinâmico *= 2;
                    Console.WriteLine("Maquina rapida. Limite aumentado para =" + limiteDinâmico.ToString());
                }
                else
                {
                    limiteDinâmico = limiteMáximo.Value;
                    Console.WriteLine("Maquina rapida, mas limite não pode ser excedido de = " + limiteDinâmico.ToString());
                }
            }
                
            cronometroIniciado = false;
        }
    }
}
