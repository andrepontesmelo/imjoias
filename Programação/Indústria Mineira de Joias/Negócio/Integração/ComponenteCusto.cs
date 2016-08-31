using System;
using System.Collections.Generic;
using System.Data;

namespace Negócio.Integração
{
    public class ComponenteCusto
    {
        List<Entidades.Mercadoria.ComponenteCusto> lstPendênciaCadastro;
        List<Entidades.Mercadoria.ComponenteCusto> lstPendênciaAtualização;

        public ComponenteCusto()
        {
            lstPendênciaCadastro = new List<Entidades.Mercadoria.ComponenteCusto>();
            lstPendênciaAtualização = new List<Entidades.Mercadoria.ComponenteCusto>();
        }

        public void Transpor(DataSet legado)
        {
            foreach (DataRow itemAtual in legado.Tables["ccusto"].Rows)
                TransporItem(itemAtual);

            Entidades.Mercadoria.ComponenteCusto.CadastrarAtualizarTransaçãoÚnica(lstPendênciaCadastro, lstPendênciaAtualização);
        }

        private void TransporItem(DataRow legado)
        {
            Entidades.Mercadoria.ComponenteCusto componente = ObterComponente(legado);
            AdicionarPendência(componente);
        }

        private void AdicionarPendência(Entidades.Mercadoria.ComponenteCusto componente)
        {
            if (componente.Código == null)
                throw new Exception("Código nulo");

            if (!componente.Cadastrado)
                lstPendênciaCadastro.Add(componente);

            if (componente.Cadastrado && !componente.Atualizado)
                lstPendênciaAtualização.Add(componente);
        }

        private static Entidades.Mercadoria.ComponenteCusto ObterComponente(DataRow itemLegado)
        {
            Entidades.Mercadoria.ComponenteCusto componente =
                Entidades.Mercadoria.ComponenteCusto.Obter(itemLegado["CC_COD"].ToString().Trim());

            if (componente == null)
                componente = new Entidades.Mercadoria.ComponenteCusto();

            TransporAtributos(itemLegado, componente);
            return componente;
        }

        private static void TransporAtributos(DataRow itemLegado, Entidades.Mercadoria.ComponenteCusto componente)
        {
            componente.Nome = itemLegado["CC_NOME"].ToString();
            componente.Código = itemLegado["CC_COD"].ToString().ToUpper().Trim();

            bool transpondoDólar = componente.Código.Equals("10");
            double valorEmDólar = double.Parse(itemLegado["CC_DOLAR"].ToString());
            bool itemCotadoEmDólar = valorEmDólar != 0;

            if (!transpondoDólar && itemCotadoEmDólar)
            {
                componente.MultiplicarComponenteCusto = "10";
                componente.Valor = valorEmDólar;
            }
            else
            {
                componente.MultiplicarComponenteCusto = null;
                componente.Valor = double.Parse(itemLegado["CC_VALOR"].ToString());
            }
        }
    }
}
