using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IMJWeb.Dominio;
using IMJWeb.DAO;
using IMJWeb.Dominio.Util;
using IMJWeb.Servico.Comunicacao;

namespace IMJWeb.Servico.Catalogo.TO
{
    [Obsolete]
    static class ContadorVisualizacoes
    {
        private static Timer timerPersistencia;
        private static Dictionary<Referencia, ulong> contagemHits;
        private static Dictionary<Referencia, ulong> contagemVisualizacoes;

        static ContadorVisualizacoes()
        {
#if !DEBUG
            timerPersistencia = new Timer(new TimerCallback(Persistir), null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
#endif
            contagemHits = new Dictionary<Referencia, ulong>();
            contagemVisualizacoes = new Dictionary<Referencia, ulong>();
        }

        /// <summary>
        /// Contabiliza hits na miniatura da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <remarks>Ocorre assincronamente.</remarks>
        public static void ContabilizarHitMiniatura(Referencia referencia)
        {
            lock (contagemHits)
            {
                ulong contagem;

                if (contagemHits.TryGetValue(referencia, out contagem))
                    contagemHits[referencia] = contagem + 1;
                else
                    contagemHits[referencia] = 1;
            }
        }

        /// <summary>
        /// Contabiliza hits na visualização da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência da mercadoria.</param>
        /// <remarks>Ocorre assincronamente.</remarks>
        public static void ContabilizarVisualizacaoMercadoria(Referencia referencia)
        {
            lock (contagemVisualizacoes)
            {
                ulong contagem;

                if (contagemVisualizacoes.TryGetValue(referencia, out contagem))
                    contagemVisualizacoes[referencia] = contagem + 1;
                else
                    contagemVisualizacoes[referencia] = 1;
            }
        }

        /// <summary>
        /// Persiste os dados no banco de dados.
        /// </summary>
        static void Persistir(object obj)
        {
            Dictionary<Referencia, ulong> contagemHits;
            Dictionary<Referencia, ulong> contagemVisualizacoes;

            #region Realiza cópia local das coleções

            lock (ContadorVisualizacoes.contagemHits)
            {
                contagemHits = new Dictionary<Referencia, ulong>(ContadorVisualizacoes.contagemHits);
                ContadorVisualizacoes.contagemHits.Clear();
            }

            lock (ContadorVisualizacoes.contagemVisualizacoes)
            {
                contagemVisualizacoes = new Dictionary<Referencia, ulong>(ContadorVisualizacoes.contagemVisualizacoes);
                ContadorVisualizacoes.contagemVisualizacoes.Clear();
            }

            #endregion

            using (IMercadoriaDAO dao = InjecaoDependencia.Resolver<IMercadoriaDAO>())
            {
                PersistirIncremento(dao.IncrementarHitMiniaturaMercadoria, contagemHits);
                PersistirIncremento(dao.IncrementarVisualizacaoMercadoria, contagemVisualizacoes);
            }
        }

        static void PersistirIncremento(Action<Referencia, ulong> incrementar, IDictionary<Referencia, ulong> contagem)
        {
            foreach (var item in contagem)
            {
                try
                {
                    incrementar(item.Key, item.Value);
                }
                catch (Exception e)
                {
                    try
                    {
                        Correio correio = InjecaoDependencia.Resolver<Correio>();

                        correio.Enviar(e);
                    }
                    catch { }

                    break;
                }
            }
        }
    }
}
