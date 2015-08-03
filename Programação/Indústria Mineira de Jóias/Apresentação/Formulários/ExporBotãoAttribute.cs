using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Entidades.Privilégio;

namespace Apresentação.Formulários
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
    public class ExporBotãoAttribute : Attribute
    {
        private Permissão permissões;
        private string texto;
        private Type[] bases;
        private bool retornarÀPrimeira = false;
        private Type controlador = null;
        private int? ordenação = null;
        private Type botão = null;
        private bool exigirFuncionário = true;

        /// <summary>
        /// Exporta um botão para o formulário.
        /// </summary>
        /// <param name="privilégios">Privilégios necessários.</param>
        /// <param name="texto">Texto do botão.</param>
        /// <param name="retornarÀPrimeira">Se deve retornar à primeira base inferior, quando clicado.</param>
        /// <param name="basesInferiores">Tipos que herdam de <c>BaseInferior</c>.</param>
        public ExporBotãoAttribute(Permissão privilégios, int ordenação, string texto, bool retornarÀPrimeira, params Type[] basesInferiores)
            : this(privilégios, texto, retornarÀPrimeira, basesInferiores)
        {
            this.ordenação = ordenação;
        }

        /// <summary>
        /// Exporta um botão para o formulário.
        /// </summary>
        /// <param name="privilégios">Privilégios necessários.</param>
        /// <param name="texto">Texto do botão.</param>
        /// <param name="retornarÀPrimeira">Se deve retornar à primeira base inferior, quando clicado.</param>
        /// <param name="basesInferiores">Tipos que herdam de <c>BaseInferior</c>.</param>
        public ExporBotãoAttribute(string texto, bool retornarÀPrimeira, params Type[] basesInferiores)
            : this(Permissão.Nenhuma, texto, retornarÀPrimeira, basesInferiores)
        {
        }

        /// <summary>
        /// Exporta um botão para o formulário.
        /// </summary>
        /// <param name="privilégios">Privilégios necessários.</param>
        /// <param name="texto">Texto do botão.</param>
        /// <param name="retornarÀPrimeira">Se deve retornar à primeira base inferior, quando clicado.</param>
        /// <param name="basesInferiores">Tipos que herdam de <c>BaseInferior</c>.</param>
        public ExporBotãoAttribute(Permissão privilégios, string texto, bool retornarÀPrimeira, params Type[] basesInferiores)
        {
            this.permissões = privilégios;
            this.texto = texto;
            this.bases = basesInferiores;
            this.retornarÀPrimeira = retornarÀPrimeira;
        }

        /// <summary>
        /// Exporta um botão para o formulário.
        /// </summary>
        /// <param name="controlador">Tipo que herda de <c>ControladorBaseInferior</c>.</param>
        /// <param name="privilégios">Privilégios necessários.</param>
        /// <param name="imagem">Imagem do botão.</param>
        /// <param name="texto">Texto do botão.</param>
        /// <param name="retornarÀPrimeira">Se deve retornar à primeira base inferior, quando clicado.</param>
        /// <param name="basesInferiores">Tipos que herdam de <c>BaseInferior</c>.</param>
        public ExporBotãoAttribute(int ordenação, Type controlador, Permissão privilégios, string texto, bool retornarÀPrimeira, params Type[] basesInferiores)
            : this(privilégios, texto, retornarÀPrimeira, basesInferiores)
        {
            this.ordenação = ordenação;
            this.controlador = controlador;
        }

        /// <summary>
        /// Exporta um botão personalizado.
        /// </summary>
        /// <param name="botão">Tipo herdeiro de botão.</param>
        public ExporBotãoAttribute(Type botão)
        {
            this.botão = botão;
        }

        public Type Controlador { get { return controlador; } }
        public Permissão Permissões { get { return permissões; } }
        public string Texto { get { return texto; } }
        public Type[] Bases { get { return bases; } }
        public bool RetornarÀPrimeira { get { return retornarÀPrimeira; } }
        public int? Ordenação { get { return ordenação; } }
        public Type Botão { get { return botão; } }
        public bool ExigirFuncionário { get { return exigirFuncionário; } set { exigirFuncionário = value; } }
    }
}
