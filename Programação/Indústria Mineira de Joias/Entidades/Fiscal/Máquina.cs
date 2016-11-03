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

            var máquinas = from m
                           in Máquinas
                           where m.Modelo.Equals(modelo) && m.Fabricação.Equals(númeroFabricação)
                           select m;

            var máquina = máquinas.FirstOrDefault();

            if (máquina == null)
            {
                Máquina novaMáquina = Cadastrar(modelo, númeroFabricação);
                lstMáquinas.Add(novaMáquina);
                return novaMáquina.Código;
            }
                
            return máquina.Código;
        }

        private static Máquina Cadastrar(string modelo, string númeroFabricação)
        {
            var máquina = new Máquina(modelo, númeroFabricação);
            máquina.Cadastrar();

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
