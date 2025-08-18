using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public abstract class Cuenta : Excepciones
    {
        private Cliente titular;
        private string codigo;
        private decimal saldo;

        public Cliente Titular { get; set; }
        public string Codigo { get; set; }
        public decimal Saldo {  get; set; }
        

        public Cuenta()
        {
            saldo = 0;
        }

        public virtual void DepositarDinero(decimal monto)
        {
            if (monto <= 0)
                throw new DatosInvalidosException("El monto a depositar debe ser mayor a cero.");

            saldo += monto;
        }

        public abstract void RetirarDinero(decimal monto);

        public virtual decimal ConsultarSaldo()
        {
            return saldo;
        }

        public abstract string ObtenerTipoCuenta();

    }
}
