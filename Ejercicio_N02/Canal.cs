using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Canal
    {
        private List<Serie> listaSeries;

        public Canal(string n)
        {
            listaSeries = new List<Serie>();
            nombre = n;
        }

        private string nombre;

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public void agregarSerie(Serie s)
        {
            listaSeries.Add(s);
        }

        public void borrarSerie(Serie s)
        {
            listaSeries.Remove(s);
        }

        public Serie buscarSerie(string s)
        {
            return listaSeries.FirstOrDefault(x => x.Nombre == s);
        }

        public List<Serie> devolverSeries()
        {
            return listaSeries;
        }

        public void mostrarSeries()
        {
            foreach (Serie s in listaSeries)
            {
                Console.WriteLine(s);
            }
        }

        public override string ToString()
        {
            return $"Canal: {Nombre} | Series cargadas: {listaSeries.Count}";
        }
    }
}
