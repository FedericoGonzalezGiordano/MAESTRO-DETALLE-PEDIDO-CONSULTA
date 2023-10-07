using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIpoParcial2.Datos.Implementacion;
using TIpoParcial2.Datos.Interfaz;
using TIpoParcial2.Entidades;
using TIpoParcial2.Servicios.Interfaz;

namespace TIpoParcial2.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IPedidoDao _pedidoDao;

        public Servicio()
        {
            _pedidoDao = new PedidoDao();
        }
        public List<Cliente> TraerClientes()
        {
            return _pedidoDao.ObtenerCliente();
        }

        //public List<Pedido> TraerPedidos()
        //{
        //    return _pedidoDao.ObtenerPedido();
        //}
    }
}
