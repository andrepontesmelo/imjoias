using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMJWeb.Dominio.Util
{
    public class CacheFraca<Chave, Tipo>
    {
        private WeakReference hashCache;
        private Func<Chave, Tipo> recuperacao;

        private Dictionary<Chave, WeakReference> Hash
        {
            get
            {
                Dictionary<Chave, WeakReference> hash;

                if (hashCache == null || !hashCache.IsAlive)
                    hash = null;
                else
                {
                    try
                    {
                        hash = (Dictionary<Chave, WeakReference>)hashCache.Target;
                    }
                    catch (InvalidOperationException)
                    {
                        hash = null;
                    }
                }

                if (hash == null)
                {
                    hash = new Dictionary<Chave, WeakReference>();
                    hashCache = new WeakReference(hash);
                }

                return hash;
            }
        }

        public Tipo this[Chave chave]
        {
            get
            {
                WeakReference objeto;
                Tipo valor = default(Tipo);

                if (Hash.TryGetValue(chave, out objeto))
                {
                    if (objeto.IsAlive)
                        try
                        {
                            valor = (Tipo)objeto.Target;
                        }
                        catch (InvalidOperationException)
                        {
                        }
                }

                if (valor == null)
                {
                    valor = recuperacao(chave);

                    lock (this)
                    {
                        Hash[chave] = new WeakReference(valor);
                    }
                }

                return valor;
            }
        }

        public CacheFraca(Func<Chave, Tipo> recuperacao)
        {
            this.recuperacao = recuperacao;
        }
    }
}
