using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class PSilver : Paquete
    {
        private List<Canal> canales;
        private List<Cliente> clientes;

        public PSilver()
        {
            canales = new List<Canal>();
            clientes = new List<Cliente>();

            // === Canales iniciales ===
            Canal fox = new Canal("FOX");
            Canal history = new Canal("History");
            Canal c5n = new Canal("C5N");
            Canal tyc = new Canal("TycSport");

            canales.Add(fox);
            canales.Add(history);
            canales.Add(c5n);
            canales.Add(tyc);

            // === Series FOX ===
            fox.agregarSerie(new Serie("TheSimpsons,34,750,300,4.4,Comedia,MattGroening"));
            fox.agregarSerie(new Serie("PrisonBreak,5,90,65,4.2,Drama,PaulScheuring"));
            fox.agregarSerie(new Serie("24,9,204,150,4.3,Accion,JoelSurnow"));

            // === Series History ===
            history.agregarSerie(new Serie("Vikings,6,89,70,4.5,Drama,MichaelHirst"));
            history.agregarSerie(new Serie("TheUniverse,7,88,60,4.3,Documental,MorganFreeman"));
            history.agregarSerie(new Serie("AncientAliens,18,200,140,3.8,Documental,HistoryTeam"));
            history.agregarSerie(new Serie("Curiosidades,2,20,20,2.9,Documental,HistoryTeam"));

            // === Series C5N ===
            c5n.agregarSerie(new Serie("MinutoUno,10,200,100,3.5,Documental,GustavoSylvestre"));
            c5n.agregarSerie(new Serie("EconomiaHoy,8,150,80,3.7,Documental,C5NTeam"));
            c5n.agregarSerie(new Serie("PoliticaAlDia,12,250,120,3.6,Documental,C5NPolitica"));
            c5n.agregarSerie(new Serie("NoticiasFlash,6,120,60,3.2,Documental,C5N"));

            // === Series TyC Sports ===
            tyc.agregarSerie(new Serie("PasoAPaso,20,400,150,4.1,Documental,TyCTeam"));
            tyc.agregarSerie(new Serie("PlanetaGol,15,300,120,4.3,Documental,ArielRodriguez"));
            tyc.agregarSerie(new Serie("BoxeoDePrimera,10,120,90,3.9,Documental,OsvaldoPrincipi"));

            // === Clientes iniciales ===
            clientes.Add(new Cliente("S001,Pablo,Rojas,41333444"));
            clientes.Add(new Cliente("S002,María,López,42333444"));
            clientes.Add(new Cliente("S003,Carolina,Sosa,43333444"));
        }


        public void agregarCanal(Canal c)
        {
            canales.Add(c);
        }

        public void agregarCliente(Cliente cl)
        {
            clientes.Add(cl);
        }

        public void borrarCanal(Canal c)
        {
            canales.Remove(c);
        }

        public void borrarCliente(Cliente cl)
        {
            clientes.Remove(cl);
        }

        public Canal buscarCanal(string nombre)
        {
            return canales.FirstOrDefault(x => x.Nombre == nombre);
        }

        public Cliente buscarCliente(string nombre)
        {
            return clientes.FirstOrDefault(x => x.Nombre == nombre);
        }

        public List<Canal> devolverCanales()
        {
            return canales;
        }

        public List<Cliente> devolverClientes()
        {
            return clientes;
        }

        public void mostrarContenido()
        {
            foreach (Canal c in canales)
            {
                Console.WriteLine($"Canal: {c.Nombre}");
                c.mostrarSeries();
                Console.WriteLine();
            }
        }
    }
}
