using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Relatórios
{
    class ImpressãoHorário
    {
        private TabelaHorário horários;

        public ImpressãoHorário(TabelaHorário horários)
        {
            this.horários = horários;
        }

        public string Domingo
        {
            get { return EscreverHorários(DayOfWeek.Sunday); }
        }

        public string Segunda
        {
            get { return EscreverHorários(DayOfWeek.Monday); }
        }

        public string Terça
        {
            get { return EscreverHorários(DayOfWeek.Tuesday); }
        }

        public string Quarta
        {
            get { return EscreverHorários(DayOfWeek.Wednesday); }
        }

        public string Quinta
        {
            get { return EscreverHorários(DayOfWeek.Thursday); }
        }

        public string Sexta
        {
            get { return EscreverHorários(DayOfWeek.Friday); }
        }

        public string Sábado
        {
            get { return EscreverHorários(DayOfWeek.Saturday); }
        }

        /// <summary>
        /// Escreve todos os horários de um dia específico da semana.
        /// </summary>
        /// <param name="dia">Dia da semana.</param>
        /// <returns>Texto contendo em cada linha um horário.</returns>
        private string EscreverHorários(DayOfWeek dia)
        {
            string str = "";
            int cnt = 0;

            foreach (Entidades.Pessoa.Horário horário in horários.ObterHorários(dia))
            {
                string aux = String.Format("{0:00}:{1:00}-{2:00}:{3:00}",
                        horário.IniHora, horário.IniMinuto,
                        horário.FimHora, horário.FimMinuto);

                if (cnt++ == 0)
                    str = aux;
                else
                    str += "\n" + aux;
            }

            return str;
        }
    }
}
