using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CuentaCorriente : Cuenta
    {
        private decimal limiteCredito;
        private const decimal LIMITE_SOBREGIRO = 100000;

        public decimal LimiteCredito
        {
            get { return limiteCredito; }
            set { limiteCredito = value; }
        }

        public CuentaCorriente() : base()
        {
            limiteCredito = LIMITE_SOBREGIRO;
        }

        public override void RetirarDinero(decimal monto)
        {
            if (monto > Saldo)
                throw new FondosInsuficientesException("Fondos insuficientes para realizar el retiro.");

            decimal saldoDisponible = Saldo + limiteCredito;

            if (monto > saldoDisponible)
                throw new FondosInsuficientesException($"Fondos insuficientes. Saldo disponible: ${saldoDisponible:N2}");

            Saldo -= monto;
        }

        public decimal ObtenerSaldoDisponible()
        {
            return Saldo + limiteCredito;
        }

        public override string ObtenerTipoCuenta()
        {
            return "Cuenta Corriente";
        }
    }
}
