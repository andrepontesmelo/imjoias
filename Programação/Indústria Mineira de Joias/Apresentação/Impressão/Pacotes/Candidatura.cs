using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Apresentação.Impressão.Pacotes
{
    unsafe struct Candidatura
    {
        private byte chksum;
        private Comando comando;
        private TipoDocumento tipo;
        private byte tmáquina;          // Tamanho
        private fixed char máquina[32];
        private byte tnome;             // Tamanho
        private fixed char nome[128];

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

        public unsafe Candidatura(string nome)
        {
            this.comando = Comando.Candidatura;
            this.chksum = 0;
            this.cpu = 0;
            this.ram = 0;
            this.velocidade = 0;
            this.colorido = false;
            this.tipo = TipoDocumento.Desconhecido;
            this.tmáquina = 0;

            fixed (char* nptr = this.nome)
                this.tnome = (byte)Útil.PreencherString(nptr, 128, nome);
        }

        public string Máquina
        {
            get
            {
                fixed (char* nptr = this.máquina)
                    return Útil.RecuperarString(nptr, Math.Min(tmáquina, (byte)32));
            }
            set
            {
                fixed (char* nptr = this.máquina)
                    tmáquina = (byte)Útil.PreencherString(nptr, 32, value);
            }
        }

        public string Nome
        {
            get
            {
                fixed (char* nptr  = this.nome)
                    return Útil.RecuperarString(nptr, Math.Min(tnome, (byte)128));
            }
        }

        public float CPU { get { return cpu; } set { cpu = value; } }
        public float RAM { get { return ram; } set { ram = value; } }
        public ulong Velocidade { get { return velocidade; } set { velocidade = value; } }
        public bool Colorido { get { return colorido; } set { colorido = value; } }
        public TipoDocumento Tipo { get { return tipo; } set { tipo = value; } }
    }
}
