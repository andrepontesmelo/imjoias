﻿using Acesso.Comum;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Pdf
{
    public class CacheIds : DbManipulaçãoSimples
    {
        private string relação;
        private HashSet<string> hash;

        public CacheIds(string relação)
        {
            this.relação = relação;
        }

        public HashSet<string> Hash
        {
            get
            {
                if (hash == null)
                    hash = new HashSet<string>(MapearStrings("select id from " + relação));

                return hash;
            }
        }

        public void LimparCache()
        {
            hash = null;
        }

        public bool Contém(string id)
        {
            return Hash.Contains(id);
        }

        public void Adicionar(string id)
        {
            Hash.Add(id);
        }

        internal void Remover(string idSaidaFiscal)
        {
            Hash.Remove(idSaidaFiscal);
        }
    }
}
