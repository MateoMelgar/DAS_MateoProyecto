using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CuentaAhorro : Cuenta
    {

        public override void RetirarDinero(decimal monto)
        {
            if(monto > Saldo)
                throw new FondosInsuficientesException("Fondos insuficientes para realizar el retiro.");
            
            if(monto <= 0)
                throw new DatosInvalidosException("El monto a retirar debe ser mayor a cero.");

            Saldo -= monto; 
        }

        public override string ObtenerTipoCuenta()
        {
            return "Cuenta de Ahorro";
        }
    }
}
