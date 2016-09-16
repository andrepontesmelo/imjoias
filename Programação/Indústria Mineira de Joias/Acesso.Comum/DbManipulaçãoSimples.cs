using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Acesso.Comum
{
    [Serializable]
    public abstract class DbManipulaçãoSimples
    {
        public static IDbConnection conexãoAlternativa = null;

        protected static IDbConnection Conexão
        {
            get
            {
                if (conexãoAlternativa != null)
                    return conexãoAlternativa;

                Usuário usr;

#if DEBUG
                Rastrear();
#endif

                usr = Usuários.UsuárioAtual;

                return usr != null ? usr.Conexão : null;
            }
        }

#if DEBUG
        private static void Rastrear()
        {
#if RASTRO
			try
			{
				System.Diagnostics.StackTrace pilha;
				System.Diagnostics.StackFrame quadro;
				string arq;
				string [] sep;

				pilha = new System.Diagnostics.StackTrace(2, true);
				quadro = pilha.GetFrame(0);
				arq = quadro.GetFileName();

				if (arq != null)
				{
					sep = arq.Split('\\');
				
					if (sep.Length > 0)
						arq = sep[sep.Length - 1];
				}

				Console.WriteLine("~ Conexão <- {0} ({1}:{2})",
					quadro.GetMethod().Name, arq, quadro.GetFileLineNumber());

				for (int i = 1; i < pilha.FrameCount; i++)
				{
					quadro = pilha.GetFrame(i);
					arq = quadro.GetFileName();

					if (arq != null)
					{
						sep = arq.Split('\\');
				
						if (sep.Length > 0)
							arq = sep[sep.Length - 1];
					}

					Console.WriteLine("             {0} ({1}:{2})",
						quadro.GetMethod().Name, arq, quadro.GetFileLineNumber());
				}

				Console.WriteLine();
			}
			catch (Exception e)
			{
				Console.WriteLine("Erro tentando rastrear acesso à conexão: " + e.Message);
			}
#endif
        }
#endif

        protected static long ObterÚltimoCódigoInserido(IDbConnection conexão)
        {
            return Usuários.UsuárioAtual.ObterÚltimoCódigoInserido(conexão);
        }

        protected static IDbDataAdapter CriarAdaptador(IDbConnection conexão)
        {
            Assembly assembly = conexão.GetType().Assembly;

            foreach (Type tipo in assembly.GetTypes())
            {
                Type tipoInterface = tipo.GetInterface("IDbDataAdapter");

                if (tipoInterface != null)
                    return (IDbDataAdapter) assembly.CreateInstance(tipoInterface.FullName);
            }

            throw new NotSupportedException("Não é possível encontrar a interface para IDbDataAdapter no assembly da conexão fornecida.");
        }

        protected internal static string DbTransformarConjunto(System.Collections.IEnumerable valores)
        {
            StringBuilder consulta = new StringBuilder("(");
            bool primeiro = true;

            foreach (object valor in valores)
            {
                if (primeiro)
                    primeiro = false;
                else
                    consulta.Append(", ");

                consulta.Append(DbTransformar(valor));
            }

            consulta.Append(") ");

            return consulta.ToString();
        }

        protected internal static string DbTransformar(object obj)
        {
            if (obj is string) return DbTransformar((string)obj);
            if (obj is DateTime) return DbTransformar((DateTime)obj);
            if (obj is Double) return DbTransformar((Double)obj);
            if (obj is Decimal) return DbTransformar((Decimal)obj);
            if (obj is Int32) return DbTransformar((Int32)obj);
            if (obj is Int16) return DbTransformar((Int16)obj);
            if (obj is Int64) return DbTransformar((Int64)obj);
            if (obj is Single) return DbTransformar((Single)obj);
            if (obj is UInt16) return DbTransformar((UInt16)obj);
            if (obj is UInt32) return DbTransformar((UInt32)obj);
            if (obj is UInt64) return DbTransformar((UInt64)obj);
            if (obj is Boolean) return DbTransformar((bool)obj);
            if (obj == null) return DbTransformar((string)null);

            // Verifica se existe algum conversor para este tipo...
            DbConversão[] conversores = (DbConversão[])obj.GetType().GetCustomAttributes(typeof(DbConversão), true);

            if (conversores.Length == 1)
            {
                DbConversor conversor = conversores[0].Conversor;
                return DbTransformar(conversor.ConverterParaDB(obj));
            }

            if (obj is DbManipulaçãoAutomática) return DbTransformar((DbManipulaçãoAutomática)obj);

            throw new NotSupportedException("Transformação de objeto do tipo " + obj.GetType().Name + " não suportada!");
        }

        protected internal static string DbTransformar(DbManipulaçãoAutomática entidade)
        {
            if (entidade.InfoManipulação.ChavePrimária.Length + entidade.InfoManipulação.ChavePrimáriaPersonalizável.Length != 1)
                throw new NotSupportedException("Transformação de DbManipulaçãoAutomática do tipo " + entidade.GetType().Name + " não suportada, pois existe mais de uma chave primária.");

            if (entidade.InfoManipulação.ChavePrimária.Length == 1)
                return DbTransformar(entidade.InfoManipulação.ChavePrimária[0].GetValue(entidade));

            if (entidade.InfoManipulação.ChavePrimáriaPersonalizável.Length == 1)
                return DbTransformar(entidade.InfoManipulação.ChavePrimáriaPersonalizável[0].GetValue(entidade));

            throw new NotSupportedException("Código inalcansável atingido!???");
        }

        public static string DbTransformar(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                return "null";
            else
                return "'" + dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + "'";
        }

        protected internal static string DbTransformar(string s)
        {
            return DbTransformar(s, true);
        }

        protected internal static string DbTransformar(string s, bool encapsular)
        {
            if (s == null)
                return "null";

            s = s.Replace("\\", "\\\\");
            s = s.Replace("'", "\\'");

            return encapsular ? DbEncapsular(s) : s;
        }

        protected internal static string DbEncapsular(string s)
        {
            return "'" + s + "'";
        }

        protected internal static string DbTransformar(double d)
        {
#if PREFIXAR_NÚMERO
            return "'" + d.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return d.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(decimal d)
        {
#if PREFIXAR_NÚMERO
            return "'" + d.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return d.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }
        protected internal static string DbTransformar(long l)
        {
#if PREFIXAR_NÚMERO
            return "'" + l.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return l.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(ulong l)
        {
#if PREFIXAR_NÚMERO
            return "'" + l.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return l.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(int i)
        {
#if PREFIXAR_NÚMERO
            return "'" + i.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return i.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(uint i)
        {
#if PREFIXAR_NÚMERO
            return "'" + i.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return i.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(short i)
        {
#if PREFIXAR_NÚMERO
            return "'" + i.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return i.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(ushort i)
        {
#if PREFIXAR_NÚMERO
            return "'" + i.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return i.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(byte b)
        {
#if PREFIXAR_NÚMERO
            return "'" + b.ToString(NumberFormatInfo.InvariantInfo) + "'";
#else
            return b.ToString(NumberFormatInfo.InvariantInfo);
#endif
        }

        protected internal static string DbTransformar(byte? b)
        {
            return b.HasValue ? DbTransformar(b.Value) : "null";
        }

        protected internal static string DbTransformar(bool b)
        {
            return b ? "'1'" : "'0'";
        }

        protected internal static string DbTransformar(long? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(int? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(ulong? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(uint? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(DateTime? valor)
        {
            return valor.HasValue ? "'" + valor.Value.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + "'" : "null";
        }

        protected internal static string DbTransformar(short? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(ushort? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(bool? valor)
        {
            return valor.HasValue ? DbTransformar(valor.Value) : "null";
        }

        protected internal static string DbTransformar(MethodBase mb)
        {
            try
            {
                return mb == null ? "null" : "'" + mb.ToString() + "'";
            }
            catch
            {
                return "null";
            }
        }

        private static CacheMapeamento cacheMapeamento = new CacheMapeamento();

        protected struct ObjCampoValor
        {
            public object objeto;
            public FieldInfo campo;
            public object valor;

            public ObjCampoValor(object objeto, FieldInfo campo, object valor)
            {
                this.objeto = objeto;
                this.campo = campo;
                this.valor = valor;
            }
        }

        private delegate void MapearCampoCallback(object destino, FieldInfo campo, IDataReader leitor, int iColuna);

        private class MapeamentoCampo
        {
            private Dictionary<Type, MapearCampoCallback> hashMapCampo = new Dictionary<Type, MapearCampoCallback>();

            public MapeamentoCampo()
            {
                hashMapCampo.Add(typeof(bool), new MapearCampoCallback(MapearBool));
                hashMapCampo.Add(typeof(TimeSpan), new MapearCampoCallback(MapearTimeSpan));
                hashMapCampo.Add(typeof(System.IO.MemoryStream), new MapearCampoCallback(MapearMemoryStream));
                hashMapCampo.Add(typeof(char), new MapearCampoCallback(MapearChar));
                hashMapCampo.Add(typeof(DayOfWeek), new MapearCampoCallback(MapearDayOfWeek));
                hashMapCampo.Add(typeof(DbFoto), new MapearCampoCallback(MapearDbFoto));
                hashMapCampo.Add(typeof(ushort?), new MapearCampoCallback(MapearNUInt16));
                hashMapCampo.Add(typeof(uint?), new MapearCampoCallback(MapearNUInt32));
                hashMapCampo.Add(typeof(ulong?), new MapearCampoCallback(MapearNUInt64));
                hashMapCampo.Add(typeof(short?), new MapearCampoCallback(MapearNInt16));
                hashMapCampo.Add(typeof(int?), new MapearCampoCallback(MapearNInt32));
                hashMapCampo.Add(typeof(long?), new MapearCampoCallback(MapearNInt64));
                hashMapCampo.Add(typeof(double?), new MapearCampoCallback(MapearNDouble));
                hashMapCampo.Add(typeof(float?), new MapearCampoCallback(MapearNFloat));
            }

            public MapearCampoCallback this[Type tipo]
            {
                get
                {
                    MapearCampoCallback método;

                    if (hashMapCampo.TryGetValue(tipo, out método))
                        return método;

                    return null;
                }
            }

            public void Adicionar(Type tipo, MapearCampoCallback método)
            {
                hashMapCampo.Add(tipo, método);
            }

            private void MapearBool(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, leitor.GetBoolean(iColuna));
            }

            private void MapearTimeSpan(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, TimeSpan.FromSeconds(leitor.GetInt64(iColuna)));
            }

            private void MapearMemoryStream(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, new System.IO.MemoryStream((byte[])leitor.GetValue(iColuna), false));
            }

            private void MapearChar(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, leitor.GetChar(iColuna));
            }

            private void MapearDayOfWeek(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (DayOfWeek)leitor.GetInt16(iColuna));
            }

            private void MapearDbFoto(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (DbFoto)((byte[])leitor.GetValue(iColuna)));
            }

            private void MapearNUInt32(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (uint?)leitor.GetInt32(iColuna));
            }

            private void MapearNInt32(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (int?)leitor.GetInt32(iColuna));
            }

            private void MapearNUInt64(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (ulong?)leitor.GetInt64(iColuna));
            }

            private void MapearNInt64(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (long?)leitor.GetInt64(iColuna));
            }

            private void MapearNUInt16(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (ushort?)leitor.GetInt16(iColuna));
            }

            private void MapearNInt16(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (short?)leitor.GetInt16(iColuna));
            }

            private static void MapearNDateTime(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (DateTime?)leitor.GetDateTime(iColuna));
            }

            private void MapearNDouble(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (double?)leitor.GetDouble(iColuna));
            }

            private void MapearNFloat(object destino, FieldInfo campo, IDataReader leitor, int iColuna)
            {
                campo.SetValue(destino, (float?)leitor.GetFloat(iColuna));
            }

            public bool Conhece(Type tipo)
            {
                return hashMapCampo.ContainsKey(tipo);
            }
        }

        /// <summary>
        /// Indexador que mapea tipo para método de recuperação do banco de dados.
        /// </summary>
        private static MapeamentoCampo mapeamentoCampo = new MapeamentoCampo();

        /// <summary>
        /// Mapear uma linha de uma tabela via ADO.NET para
        /// Value-Object.
        /// </summary>
        /// <param name="tipo">Tipo dos dados a serem mapeados.</param>
        /// <param name="comando">Comando a ser executado.</param>
        /// <returns>Lista com o resultado da consulta.</returns>
        protected static List<DbTipo> Mapear<DbTipo>(string comando) where DbTipo : new()
        {
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = comando;

                    List<DbTipo> resultado = Mapear<DbTipo>(cmd);

                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);

                    return resultado;
                }

            }
        }

        protected static List<long> MapearCódigos(string sql)
        {
            List<long> resultado = new List<long>();

            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = sql;

                using (IDataReader leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                        resultado.Add(leitor.GetInt64(0));

                    if (!leitor.IsClosed)
                        leitor.Close();
                }
            }

            return resultado;
        }


        protected static List<DbTipo> Mapear<DbTipo>(IDbCommand cmd) where DbTipo : new()
        {
            List<DbTipo> conjunto = new List<DbTipo>();

            Mapear(cmd, conjunto);

            return conjunto;
        }

        protected internal static FieldInfo[] MapearAtributos(Type tipo, IDataReader dao)
        {
            FieldInfo[] atributos;
            int colunas;

            colunas = dao.FieldCount;
            atributos = new FieldInfo[colunas];

            for (int i = 0; i < colunas; i++)
            {
                string colunaDao = dao.GetName(i);

                atributos[i] = tipo.GetField(colunaDao,
                    BindingFlags.NonPublic | BindingFlags.Instance
                    | BindingFlags.Public);

                if (atributos[i] == null)
                {
                    bool ok = false;

                    ok = VerificarAtributosPersonalizados(tipo, atributos, i, colunaDao, ok);

                    if (!ok)
                    {
                        System.Diagnostics.Debug.Assert(ok, "Incompatibilidade do modelo relacional com o DAO!\n\nAtributo não encontrado: " + dao.GetName(i) + " (tipo: " + tipo.Name + ")");
                        throw new Exception("Incompatibilidade do modelo relacional com o DAO!\n\nAtributo não encontrado: " + dao.GetName(i) + " (tipo: " + tipo.Name + ")");
                    }
                }

                DbConversão[] conversões = (DbConversão[])atributos[i].FieldType.GetCustomAttributes(typeof(DbConversão), true);

                if (conversões.Length > 0 && !mapeamentoCampo.Conhece(atributos[i].FieldType))
                    mapeamentoCampo.Adicionar(atributos[i].FieldType, new MapearCampoCallback(conversões[0].Conversor.MapearCampo));
            }

            return atributos;
        }

        private static bool VerificarAtributosPersonalizados(Type tipo, FieldInfo[] atributos, int i, string colunaDao, bool ok)
        {
            foreach (FieldInfo campo in tipo.GetFields(
                BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public))
            {
                DbColuna[] custAtrib = (DbColuna[])campo.GetCustomAttributes(typeof(DbColuna), true);

                foreach (DbColuna coluna in custAtrib)
                    if (string.Compare(coluna.Coluna, colunaDao, true) == 0)
                    {
                        atributos[i] = campo;
                        ok = true;
                        break;
                    }
            }

            return ok;
        }

        protected static DbTipo MapearLinhaObjeto<DbTipo>(IDataReader dao, FieldInfo[] atributos, LinkedList<ObjCampoValor> mapeamentoPendente) where DbTipo : new()
        {
            Type tipo = typeof(DbTipo);

            if (tipo.IsValueType)
            {
                object capsula = (object)(new DbTipo());
                MapearLinhaObjeto(tipo, dao, atributos, capsula, mapeamentoPendente);
                return (DbTipo)capsula;
            }
            else
            {
                DbTipo obj = new DbTipo();
                MapearLinhaObjeto(tipo, dao, atributos, obj, mapeamentoPendente);
                return obj;
            }
        }

        private static void MapearLinhaObjeto(Type tipo, IDataReader dao, FieldInfo[] atributos, object obj, LinkedList<ObjCampoValor> mapeamentoPendente)
        {
            for (int i = 0; i < atributos.Length; i++)
            {
                    if (!dao.IsDBNull(i))
                    {
                        if (atributos[i].GetCustomAttributes(typeof(DbRelacionamento), true).Length > 0)
                        {
                            object valor = dao[i];
 
                            MapearPosteriormente(obj, atributos[i], valor, mapeamentoPendente);
                        }
                        else
                        {
                            MapearCampoCallback método;
                            Type atTipo = atributos[i].FieldType;

                            método = mapeamentoCampo[atTipo];

                            if (método == null)
                            {
                                object valor = dao[i];

                                atributos[i].SetValue(obj, valor);
                            }
                            else
                                método(obj, atributos[i], dao, i);
                        } 
                    } 
                    else if (atributos[i].FieldType.IsSubclassOf(typeof(Nullable)))
                        atributos[i].SetValue(obj, null);
            } 

            if (tipo.IsSubclassOf(typeof(DbManipulação)))
            {
                DbManipulação dbObj = (DbManipulação)((object)obj);
                dbObj.cadastrado = dbObj.atualizado = true;
            }
        }

        private static void MapearPosteriormente(object obj, FieldInfo campo, object valor, LinkedList<ObjCampoValor> mapeamentoPendente)
        {
            mapeamentoPendente.AddLast(new ObjCampoValor(obj, campo, valor));
        }

        protected static void ResolverPendências(IDbCommand cmd, LinkedList<ObjCampoValor> mapeamentoPendente)
        {
#if DEBUG
            DateTime inicio = DateTime.Now;
#endif
            if (mapeamentoPendente != null && mapeamentoPendente.Count > 0)
            {
                LinkedList<ObjCampoValor> pendênciaLocal = mapeamentoPendente;
                Adaptadores.ComandoConcorrente cmdConcorrente = cmd as Adaptadores.ComandoConcorrente;
                Adaptadores.ConexãoConcorrente conexão = null;
                int ocupação_anterior = 0;

                mapeamentoPendente = null;

                if (cmdConcorrente != null)
                {
                    conexão = (Adaptadores.ConexãoConcorrente)cmdConcorrente.Connection;
                    ocupação_anterior = conexão.Ocupado;
                    conexão.Ocupado = 0;
                }

                try
                {
                    foreach (ObjCampoValor pendência in pendênciaLocal)
                    {
                        object pEntidade = Cache.CacheDb.Instância.ObterEntidade(pendência.campo.FieldType, pendência.valor);
                        DbManipulação pManipulável = pEntidade as DbManipulação;
                        
                        pendência.campo.SetValue(
                            pendência.objeto,
                            pEntidade);

                        if (pManipulável != null && pendência.objeto is DbManipulação)
                            pManipulável.Referentes.Add((DbManipulação)pendência.objeto);
                    }
                }     
                finally
                {
                    if (conexão != null)
                    {
                        System.Diagnostics.Debug.Assert(conexão.Ocupado == 0, "Conexão não foi liberada após resolver pendências.");
                        conexão.Ocupado = ocupação_anterior;
                    }
                }

#if DEBUG
                TimeSpan tempo = DateTime.Now - inicio;
                double totalMs = tempo.TotalMilliseconds;

                if (totalMs > maxTempoMs)
                {
                    Console.WriteLine("=============================================== Novo recorde de demora para resolver pendências. ===============================================");
                    Console.Write(totalMs);
                    Console.Write("\t");
                    Console.WriteLine(pendênciaLocal.First.Value.objeto.GetType().ToString());

                    maxTempoMs = totalMs;
                }
#endif
            }
        }

#if DEBUG
        private static double maxTempoMs = 0;
#endif


        /// <summary>
        /// Mapear uma linha de uma tabela via ADO.NET para
        /// Value-Object.
        /// </summary>
        /// <param name="tipo">Tipo dos dados a serem mapeados</param>
        /// <param name="cmd">Comando do banco de dados.</param>
        /// <param name="conjunto">Lista onde serão inseridos os dados</param>
        protected static List<DbTipo> Mapear<DbTipo>(IDbCommand cmd, List<DbTipo> conjunto) where DbTipo : new()
        {
            LinkedList<ObjCampoValor> mapeamentoPendente = new LinkedList<ObjCampoValor>();

            Type tipo = typeof(DbTipo);

            using (IDataReader dao = cmd.ExecuteReader())
            {
                FieldInfo[] atributos;

                atributos = cacheMapeamento[tipo, cmd.CommandText];

                if (atributos == null)
                    cacheMapeamento[tipo, cmd.CommandText] = atributos = MapearAtributos(tipo, dao);

                while (dao.Read())
                    conjunto.Add(MapearLinhaObjeto<DbTipo>(dao, atributos, mapeamentoPendente));

                dao.Close();
            }

            ResolverPendências(cmd, mapeamentoPendente);

            return conjunto;
        }

        protected static DbTipo MapearÚnicaLinha<DbTipo>(string comando) where DbTipo : new()
        {
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
            {
                try
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = comando;

                        return MapearÚnicaLinha<DbTipo>(cmd);
                    }
                }
                finally 
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }
        }

        protected static DbTipo MapearÚnicaLinha<DbTipo>(IDbCommand cmd) where DbTipo : new()
        {
            LinkedList<ObjCampoValor> mapeamentoPendente = new LinkedList<ObjCampoValor>();
            FieldInfo[] atributos;
            IDataReader leitor = null;
            DbTipo obj;
            Type tipo = typeof(DbTipo);

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    atributos = cacheMapeamento[tipo, cmd.CommandText];

                    if (atributos == null)
                        cacheMapeamento[tipo, cmd.CommandText] = atributos = MapearAtributos(tipo, leitor);

                    if (leitor.Read())
                        obj = MapearLinhaObjeto<DbTipo>(leitor, atributos, mapeamentoPendente);
                    else
                        obj = default(DbTipo);
                }
            }
            finally
            {
                if (leitor != null && !leitor.IsClosed)
                    leitor.Close();
            }

            ResolverPendências(cmd, mapeamentoPendente);

            return obj;
        }

        protected static void ExecutarComandoTransação(string comandoSql, IDbTransaction transação)
        {
            if (String.IsNullOrEmpty(comandoSql))
                return;

            IDbCommand comando = transação.Connection.CreateCommand();
            comando.Transaction = transação;

            comando.CommandText = comandoSql;
            comando.ExecuteNonQuery();
        }
    }
}
