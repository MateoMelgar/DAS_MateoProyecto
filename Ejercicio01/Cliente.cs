using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Cliente
    {
        private int dni;
        private string nombre;
        private string apellido;
        private int telefono;
        private string email;
        private string fechaNacimiento;

        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
    }
}
