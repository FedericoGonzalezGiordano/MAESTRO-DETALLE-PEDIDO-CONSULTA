using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIpoParcial2.Datos.Interfaz;
using TIpoParcial2.Entidades;

namespace TIpoParcial2.Datos.Implementacion
{
    public class PedidoDao : IPedidoDao
    {
        public List<Cliente> ObtenerCliente()
        {
            List<Cliente>lClientes = new List<Cliente>();
            DataTable dataTable = new DataTable();
            dataTable = HelperDao.getInstance().ConsultarSp("SP_CONSULTAR_CLIENTES");
            foreach(DataRow r in dataTable.Rows)
            {
                int id = Convert.ToInt32(r["id_cliente"]);
                string nom = r["nombre"].ToString();
                string ape = r["apellido"].ToString();
                int dni = Convert.ToInt32(r["dni"]);
                int cp = Convert.ToInt32(r["cod_postal"]);

                Cliente cliente = new Cliente(id,nom,ape,dni,cp);
                lClientes.Add(cliente);
            }
            return lClientes;
        }

        //public List<Pedido> ObtenerPedido()
        //{
            

        //}
    }
}
