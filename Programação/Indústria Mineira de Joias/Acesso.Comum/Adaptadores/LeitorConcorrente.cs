using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Acesso.Comum.Adaptadores
{
    /// <summary>
    /// Adaptador de DataReader que marca como ocupada
    /// uma conexão enquanto existem dados a serem lidos
    /// no banco de dados.
    /// </summary>
    [Serializable]
    public class LeitorConcorrente : IDataReader
    {
        private ConexãoConcorrente conexão;
        private IDataReader leitor;

#if DEBUG
        private bool liberado = false;
        private DateTime início;
#endif

        public LeitorConcorrente(ConexãoConcorrente conexão, IDataReader leitor)
        {
            this.conexão = conexão;
            this.leitor = leitor;
#if DEBUG
            início = DateTime.Now;
            //Console.WriteLine("\n({0}) Iniciando leitura de dados do DataReader.", início.ToLongTimeString());
            //conexão.cmdLeitor = conexão.cmdTexto;
            //conexão.cmdLeitorPilha = new System.Diagnostics.StackTrace(3, true);
#endif
        }

        public void Close()
        {
#if DEBUG
            DateTime término = DateTime.Now;
            TimeSpan dif = término - início;

            //Console.WriteLine("Fim de leitura. ({0}; Tempo total: {1}s)",
            //    término.ToLongTimeString(),
            //    dif.TotalMilliseconds.ToString());

            conexão.cmdLeitor = null;
            liberado = true;
#endif
            leitor.Close();
        }

        public int Depth
        {
            get { return leitor.Depth; }
        }

        public DataTable GetSchemaTable()
        {
            return leitor.GetSchemaTable();
        }

        public bool IsClosed
        {
            get { return leitor.IsClosed; }
        }

        public bool NextResult()
        {
            return leitor.NextResult();
        }

        public bool Read()
        {
            return leitor.Read();
        }

        public int RecordsAffected
        {
            get { return leitor.RecordsAffected; }
        }

        #region IDisposable Members

        public void Dispose()
        {
#if DEBUG
            if (!liberado)
            {
                conexão.cmdLeitor = null;
                liberado = true;
            }
#endif
            leitor.Dispose();
        }

        #endregion

        #region IDataRecord Members

        public int FieldCount
        {
            get { return leitor.FieldCount; }
        }

        public bool GetBoolean(int i)
        {
            return leitor.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return leitor.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return leitor.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return leitor.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return leitor.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return leitor.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return leitor.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            return leitor.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return leitor.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return leitor.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return leitor.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return leitor.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return leitor.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return leitor.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return leitor.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return leitor.GetInt64(i);
        }

        public string GetName(int i)
        {
            return leitor.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return leitor.GetOrdinal(name);
        }

        public string GetString(int i)
        {
            return leitor.GetString(i);
        }

        public object GetValue(int i)
        {
            return leitor.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return leitor.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return leitor.IsDBNull(i);
        }

        public object this[string name]
        {
            get { return leitor[name]; }
        }

        public object this[int i]
        {
            get { return leitor[i]; }
        }

        #endregion
    }
}
