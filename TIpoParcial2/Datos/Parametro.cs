using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIpoParcial2.Datos
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametro(string n,object v)
        {
                this.Valor = v;
                this.Nombre = n;
        }
    }
}
