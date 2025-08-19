using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Cliente
    {
        public Cliente(string linea)
        {
            string[] valores = linea.Split(',');
            codigo = valores[0];
            nombre = valores[1];
            apellido = valores[2];
            dni = Convert.ToInt32(valores[3]);
        }

        private string codigo;
        private string nombre;
        private string apellido;
        private int dni;

        public string Codigo { get { return codigo; } set { codigo = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public int Dni { get { return dni; } set { dni = value; } }

        public override string ToString()
        {
            return $"Cliente: {Nombre} {Apellido} | DNI: {Dni} | Código: {Codigo}";
        }
    }
}
