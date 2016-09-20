using Entidades.Mercadoria.Componente;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negócio.Integração
{
    public class IntegraçãoComponenteCusto
    {
        List<ComponenteCusto> lstPendênciaCadastro;
        List<ComponenteCusto> lstPendênciaAtualização;

        public IntegraçãoComponenteCusto()
        {
            lstPendênciaCadastro = new List<ComponenteCusto>();
            lstPendênciaAtualização = new List<ComponenteCusto>();
        }

        public void Transpor(DataSet legado)
        {
            foreach (DataRow itemAtual in legado.Tables["ccusto"].Rows)
                TransporItem(itemAtual);

            ComponenteCusto.CadastrarAtualizarTransaçãoÚnica(lstPendênciaCadastro, lstPendênciaAtualização);
        }

        private void TransporItem(DataRow legado)
        {
            AdicionarPendência(ObterComponente(legado));
        }

        private void AdicionarPendência(ComponenteCusto componente)
        {
            if (componente.Código == null)
                throw new Exception("Código nulo");

            if (!componente.Cadastrado)
                lstPendênciaCadastro.Add(componente);

            if (componente.Cadastrado && !componente.Atualizado)
                lstPendênciaAtualização.Add(componente);
        }

        private static ComponenteCusto ObterComponente(DataRow itemLegado)
        {
            ComponenteCusto componente = ComponenteCusto.Obter(itemLegado["CC_COD"].ToString().Trim());

            if (componente == null)
                componente = new ComponenteCusto();

            TransporAtributos(itemLegado, componente);
            return componente;
        }

        private static void TransporAtributos(DataRow itemLegado, ComponenteCusto componente)
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
