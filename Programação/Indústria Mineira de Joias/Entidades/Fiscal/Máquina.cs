using Acesso.Comum;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Entidades.Fiscal
{
    [DbTabela("maquinafiscal")]
    public class Máquina : DbManipulaçãoAutomática
    {
        [DbChavePrimária(true)]
        private int codigo;
        private string modelo;
        private string fabricacao;

        public int Código => codigo;
        public string Modelo => modelo;
        public string Fabricação => fabricacao;

        private static List<Máquina> lstMáquinas = null;

        public Máquina()
        {
        }

        public Máquina(string modelo, string fabricacao)
        {
            this.modelo = modelo;
            this.fabricacao = fabricacao;
        }
        
        public static int ObterCódigoMáquinaInserindo(string modelo, string númeroFabricação)
        {
            modelo = modelo.Trim().ToUpper();
            númeroFabricação = númeroFabricação.Trim().ToUpper();

            Máquina máquina = ObterMáquina(modelo, númeroFabricação);

            if (máquina == null)
                máquina = CadastrarMáquina(modelo, númeroFabricação);

            return máquina.Código;
        }

        private static Máquina CadastrarMáquina(string modelo, string númeroFabricação)
        {
            var novaMáquina = new Máquina(modelo, númeroFabricação);
            novaMáquina.Cadastrar();
            lstMáquinas.Add(novaMáquina);

            return novaMáquina;
        }

        private static Máquina ObterMáquina(string modelo, string númeroFabricação)
        {
            var máquinas = from m
                                       in Máquinas
                           where m.Modelo.Equals(modelo) && m.Fabricação.Equals(númeroFabricação)
                           select m;

            var máquina = máquinas.FirstOrDefault();
            return máquina;
        }

        public static List<Máquina> Máquinas
        {
            get
            {
                if (lstMáquinas == null)
                    Carregar();

                return lstMáquinas;
            }
        }

        private static void Carregar()
        {
            lstMáquinas = Mapear<Máquina>("select * from maquinafiscal");
        }
    }
}
