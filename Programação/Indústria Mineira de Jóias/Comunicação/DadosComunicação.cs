using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace Comunicação
{
    public class DadosConexão<EstadoComunicação>
    {
        private TcpClient cliente;
        private DateTime últimaComunicação;

        private EstadoComunicação estado;

        /* Estado                     Valor de objEstado
         * ===============================================
         * PreparandoAcerto           DadosDocumento
         */
        private object objEstado;

        public DadosConexão(TcpClient cliente)
        {
            this.cliente = cliente;
            últimaComunicação = DateTime.Now;
        }

        public TcpClient Cliente { get { return cliente; } }
        public DateTime ÚltimaComunicação { get { return últimaComunicação; } set { últimaComunicação = value; } }
        public EstadoComunicação Estado { get { return estado; } set { estado = value; } }
        public object ObjEstado { get { return objEstado; } set { objEstado = value; } }
    }
}
