using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepciones;

namespace Ejercicio01
{
    public class Banco
    {
        private RepositorioCuentas repositorioCuentas;
        private RepositorioClientes repositorioClientes;

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // public Nombre {get; set;}

        public Banco()
        {
            repositorioCuentas = new RepositorioCuentas();
            repositorioClientes = new RepositorioClientes();
            nombre = "Banco Nacional";
        }

        public void CrearCliente(int dni, string nombre, string apellido, int telefono, string email, string fechaNacimiento)
        {
            try
            {
                var cliente = new Cliente();
                cliente.Dni = dni;
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.Email = email;
                cliente.Telefono = telefono;
                cliente.Email = email;
                cliente.FechaNacimiento = fechaNacimiento;

                repositorioClientes.AgregarCliente(cliente);
            }
            catch(Exception ex)
            {
                throw new DatosInvalidosException($"Error al crear cliente: {ex.Message}");

            }
        }

        public Cliente BuscarCliente(int dni)
        {
            var cliente = repositorioClientes.BuscarCliente(dni);

            if(cliente == null)
                throw new DatosInvalidosException("Cliente no encontrado.");

            return cliente;
        }

        public void EliminarCliente(int dni)
        {
            var cliente = repositorioClientes.BuscarCliente(dni);

            if (cliente == null)
                throw new DatosInvalidosException("Cliente no encontrado.");

            repositorioClientes.EliminarCliente(cliente);
            
        }

        public void EliminarCuenta(string dni)
        {
            repositorioCuentas.EliminarCuenta(dni);
        }

        public void CrearCuentaAhorros(string numeroCuenta)
        {
            try
            {
                Cliente nombreTitular = BuscarCliente(int.Parse(numeroCuenta));
                var cuenta = new CuentaAhorro();
                cuenta.Codigo = numeroCuenta;
                cuenta.Titular = nombreTitular;
                repositorioCuentas.AgregarCuenta(cuenta);
            }
            catch (Exception ex)
            {
                throw new DatosInvalidosException($"Error al crear cuenta de ahorros: {ex.Message}");
            }
        }

        public void CrearCuentaCorriente(string numeroCuenta)
        {
            try
            {
                Cliente nombreTitular = BuscarCliente(int.Parse(numeroCuenta));
                var cuenta = new CuentaCorriente();
                cuenta.Codigo = numeroCuenta;
                cuenta.Titular = nombreTitular;
                repositorioCuentas.AgregarCuenta(cuenta);
            }
            catch (Exception ex)
            {
                throw new DatosInvalidosException($"Error al crear cuenta corriente: {ex.Message}");
            }
        }

        public void RealizarDeposito(string numeroCuenta, decimal monto)
        {
            var cuenta = repositorioCuentas.BuscarCuenta(numeroCuenta);
            if (cuenta == null)
                throw new DatosInvalidosException("Cuenta no encontrada.");

            cuenta.DepositarDinero(monto);
        }

        public void RealizarRetiro(string numeroCuenta, decimal monto)
        {
            var cuenta = repositorioCuentas.BuscarCuenta(numeroCuenta);
            if (cuenta == null)
                throw new DatosInvalidosException("Cuenta no encontrada.");

            cuenta.RetirarDinero(monto);
        }

        public decimal ConsultarSaldo(string numeroCuenta)
        {
            var cuenta = repositorioCuentas.BuscarCuenta(numeroCuenta);
            if (cuenta == null)
                throw new DatosInvalidosException("Cuenta no encontrada.");

            return cuenta.ConsultarSaldo();
        }

        public Cuenta ObtenerCuenta(string numeroCuenta)
        {
            return repositorioCuentas.BuscarCuenta(numeroCuenta);
        }

        public List<Cliente> ObtenerTodasLosClientes()
        {
            return repositorioClientes.ObtenerTodasLosClientes();
        }

        public bool BuscarCuentaPorDni(string dni)
        {
            return repositorioCuentas.ExisteCuenta(dni);

            
        }
    }
}
