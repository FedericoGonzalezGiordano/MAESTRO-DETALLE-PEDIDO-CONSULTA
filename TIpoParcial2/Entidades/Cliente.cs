using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIpoParcial2.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int Cp { get; set; }
        public List <Pedido>LPedidos { get; set; }

       
        public Cliente()
        {
          LPedidos = new List<Pedido>();
        }

        public Cliente(int id, string nombre, string apellido, int dni, int cp)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Cp = cp;
            LPedidos = new List<Pedido>();
        }

        public void AgregarPedido(Pedido oPedido)
        {
            if (oPedido != null)
                LPedidos.Add(oPedido);
        }

        public void QuitarPedido(Pedido oPedido)
        {
            if (oPedido != null)
                LPedidos.Remove(oPedido);
        }
    }
}
