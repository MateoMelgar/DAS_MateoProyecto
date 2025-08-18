using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepciones;

namespace Ejercicio01
{
    public class RepositorioClientes
    {
        private List<Cliente> clientes;

        public RepositorioClientes()
        {
            clientes = new List<Cliente>();
        }

        public void AgregarCliente(Cliente unCliente)
        {
            if (unCliente == null)
                throw new DatosInvalidosException("El cliente no puede ser nulo.");

            if (ExisteCliente(unCliente.Dni))
                throw new DatosInvalidosException("Ya existe un cliente con ese dni.");

            clientes.Add(unCliente);
        }

        public Cliente BuscarCliente(int dni)
        {
            return clientes.FirstOrDefault(c => c.Dni == dni);
        }

        public bool ExisteCliente(int dni)
        {
            return clientes.Any(c => c.Dni == dni);
        }

        public void EliminarCliente(Cliente cliente)
        {
            clientes.Remove(cliente);
        }

        public List<Cliente> ObtenerTodasLosClientes()
        {
            return clientes.ToList();
        }
    }
}
