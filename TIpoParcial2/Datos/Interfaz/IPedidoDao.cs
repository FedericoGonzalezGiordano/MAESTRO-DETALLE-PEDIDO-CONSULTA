using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIpoParcial2.Entidades;

namespace TIpoParcial2.Datos.Interfaz
{
    public interface IPedidoDao
    {
        List<Cliente> ObtenerCliente();
        //List<Pedido> ObtenerPedido();
    }
}
