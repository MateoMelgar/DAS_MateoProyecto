using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepciones;

namespace Ejercicio01
{
    public class RepositorioCuentas
    {
        private List<Cuenta> cuentas;

        public RepositorioCuentas()
        {
            cuentas = new List<Cuenta>();
        }

        public void AgregarCuenta(Cuenta cuenta)
        {
            if (cuenta == null)
                throw new DatosInvalidosException("La cuenta no puede ser nula.");

            if (string.IsNullOrWhiteSpace(cuenta.Codigo))
                throw new DatosInvalidosException("El número de cuenta no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(cuenta.Titular.Nombre))
                throw new DatosInvalidosException("El titular no puede estar vacío.");

            if (ExisteCuenta(cuenta.Codigo))
                throw new DatosInvalidosException("Ya existe una cuenta con ese número.");

            cuentas.Add(cuenta);
        }

        public Cuenta BuscarCuenta(string numeroCuenta)
        {
            return cuentas.FirstOrDefault(c => c.Codigo == numeroCuenta);
        }

        public bool ExisteCuenta(string numeroCuenta)
        {
            return cuentas.Any(c => c.Codigo == numeroCuenta);
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return cuentas.ToList();
        }

        public void EliminarCuenta(string numeroCuenta)
        {
            var cuenta = BuscarCuenta(numeroCuenta);

            if (cuenta != null && cuenta.Saldo == 0)
            {
                cuentas.Remove(cuenta);
            }
            else if(cuenta.Saldo > 0)
            {
                throw new Exception("Error: El saldo no es 0, no se puede eliminar la cuenta");
            }

        }
    }
}
