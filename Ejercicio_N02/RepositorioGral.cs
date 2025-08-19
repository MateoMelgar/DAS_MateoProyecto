using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class RepositorioGral
    {
        public List<Paquete> lista;
        public RepositorioGral()
        {
            lista = new List<Paquete>();
        }
        
        public void agregar(Paquete p)
        {
            lista.Add(p);
        }

        public void quitar(Paquete p)
        {
            lista.Remove(p);
        }
    }
}
