using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Configuração;

namespace Apresentação.Impressão
{
    public struct DadosCandidatura
    {
        private DateTime quando;
        private string máquina;
        private string impressora;

        /// <summary>
        /// Uso da CPU.
        /// </summary>
        private float cpu;

        /// <summary>
        /// RAM disponível.
        /// </summary>
        private float ram;

        /// <summary>
        /// Velocidade de processamento.
        /// </summary>
        private ulong velocidade;

        /// <summary>
        /// Se imprime colorido ou não.
        /// </summary>
        private bool colorido;

        public DadosCandidatura(string máquina, string impressora, float cpu, float ram, ulong velocidade, bool colorido)
        {
            this.máquina = máquina;
            this.impressora = impressora;
            this.cpu = cpu;
            this.ram = ram;
            this.velocidade = velocidade;
            this.colorido = colorido;
            this.quando = DateTime.Now;
        }

        public DateTime Quando { get { return quando; } }
        public string Máquina { get { return máquina; } }
        public string Impressora { get { return impressora; } }
        public float CPU { get { return cpu; } }
        public float RAM { get { return ram; } }
        public ulong Velocidade { get { return velocidade; } }
        public bool Colorido { get { return colorido; } }

        public float Nota
        {
            get
            {
                // percentual * 100 MHz, normalizado em 1,5 GHz
                return (100 - cpu) / 100f * (Velocidade / 100f) / 10f
                    * Math.Min(ram / 32f, 1f);
            }
        }

        public string Chave { get { return Máquina + Impressora; } }
    }
}
