using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIpoParcial2.Entidades;

namespace TIpoParcial2.Servicios.Interfaz
{
    public interface IServicio
    {
        List<Cliente> TraerClientes();
        //List<Pedido>TraerPedidos();
    }
}
