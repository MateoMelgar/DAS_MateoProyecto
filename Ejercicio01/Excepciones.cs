using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Excepciones 
    {
        public class FondosInsuficientesException : Exception
        {
            public FondosInsuficientesException(string mensaje) : base(mensaje) { }
        }

        public class LimiteRetirosExcedidoException : Exception
        {
            public LimiteRetirosExcedidoException(string mensaje) : base(mensaje) { }
        }

        public class DatosInvalidosException : Exception
        {
            public DatosInvalidosException(string mensaje) : base(mensaje) { }
        }
    }
}
