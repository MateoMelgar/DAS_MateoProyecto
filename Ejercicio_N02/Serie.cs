using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public enum Genero
    {
        Accion,
        Drama,
        Comedia,
        Documental
    }

    public class Serie
    {
        public Serie(string linea)
        {
            string[] valores = linea.Split(',');

            nombre = valores[0];
            nroTemporadas = Convert.ToInt32(valores[1]);
            nroEpisodios = Convert.ToInt32(valores[2]);
            duracionHoras = Convert.ToInt32(valores[3]);
            ranking = float.Parse(valores[4], CultureInfo.InvariantCulture); // <- cambio clave
            genero = (Genero)Enum.Parse(typeof(Genero), valores[5], true);
            director = valores[6];
        }

        private string nombre;
        private int nroTemporadas;
        private int nroEpisodios;
        private int duracionHoras;
        private float ranking;
        private Genero genero;
        private string director;

        public int NroTemporadas { get { return nroTemporadas; } set { nroTemporadas = value; } }
        public int NroEpisodios { get { return nroEpisodios; } set { nroEpisodios = value; } }
        public int DuracionHoras { get { return duracionHoras; } set { duracionHoras = value; } }
        public float Ranking { get { return ranking; } set { ranking = value; } }
        public Genero Genero { get { return genero; } set { genero = value; } }
        public string Director { get { return director; } set { director = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }

        public override string ToString()
        {
            return $"Serie: {Nombre} | Género: {Genero} | Director: {Director} | Ranking: {Ranking} | " +
                   $"Temporadas: {NroTemporadas}, Episodios: {NroEpisodios}, Duración: {DuracionHoras}h";
        }
    }
}
