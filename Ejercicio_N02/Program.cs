using Ejercicio2;
using System.Security.Cryptography.X509Certificates;

PNormal pNormal = new PNormal();
PPremium pPremium = new PPremium();
PSilver pSilver = new PSilver();
RepositorioGral repositorioGral = new RepositorioGral();



try
{
    mostrarMenu();
}
catch (Exception ex)
{

}


void mostrarMenu()
{
    int respuesta = 0;

    while (respuesta != 8)
    {
        Console.WriteLine("_______________________FLOW2________________________");
        Console.WriteLine("\n\n 1_ Ingresar nuevo cliente");
        Console.WriteLine(" 2_ Igresar nuevo canal");
        Console.WriteLine(" 3_ Ingresar nueva serie");
        Console.WriteLine(" 4_ Consultar contenido paquetes");
        Console.WriteLine(" 5_ Total recaudado");
        Console.WriteLine(" 6_ Paquete mas vendido");
        Console.WriteLine(" 7_ Series mayores a 3.5 en el ranking");
        Console.WriteLine(" 8_ Salir");

        respuesta = Convert.ToInt32(Console.ReadLine());

        switch (respuesta)
        {
            case 1:
                string clNombre;
                string clCodigo;
                string clApellido;
                int clDni;
                int clPaquete;

                Console.WriteLine("ingrese el nombre del nuevo cliente");
                clNombre = Console.ReadLine();

                Console.WriteLine("ingrese el Codigo del nuevo cliente");
                clCodigo = Console.ReadLine();

                Console.WriteLine("ingrese el apellido del nuevo cliente");
                clApellido = Console.ReadLine();

                Console.WriteLine("ingrese el DNI del nuevo cliente");
                clDni = Convert.ToInt32(Console.ReadLine());

                Cliente cl = new Cliente("" + clCodigo + "," + clNombre + "," + clApellido + "," + clDni + "");

                Console.WriteLine("que plan desea contratar?\n1_ Normal     2_ Silver     3_ Premium");
                clPaquete = Convert.ToInt32(Console.ReadLine());

                if (clPaquete == 1)
                {
                    pNormal.agregarCliente(cl);
                }
                else
                {
                    if (clPaquete == 2)
                    {
                        pSilver.agregarCliente(cl);
                    }
                    else
                    {
                        if (clPaquete == 3)
                        {
                            pPremium.agregarCliente(cl);
                        }
                    }
                }

                guardarCambios();
                Console.WriteLine("Cliente agregado con éxito!");
                break;

            case 2:
                string nombre;
                int paquete;

                Console.WriteLine("ingrese el nombre del nuevo canal");
                nombre = Console.ReadLine();

                Canal c = new Canal(nombre);

                Console.WriteLine("a que paquete pertenecera este canal?\n1_ Normal     2_ Silver     3_ Premium");
                paquete = Convert.ToInt32(Console.ReadLine());

                if (paquete == 1)
                {
                    pNormal.agregarCanal(c);
                }
                else
                {
                    if (paquete == 2)
                    {
                        pSilver.agregarCanal(c);
                    }
                    else
                    {
                        if (paquete == 3)
                        {
                            pPremium.agregarCanal(c);
                        }
                    }
                }

                guardarCambios();
                Console.WriteLine("Canal agregado con éxito!");
                break;

            case 3:
                string sNombre;
                int sNroTemporadas;
                int sNroEpisodios;
                int sDuracionHoras;
                float sRanking;
                string sGenero;
                string sDirector;
                string canal;

                Console.WriteLine("Ingrese el nombre de la serie:");
                sNombre = Console.ReadLine();

                Console.WriteLine("Ingrese el número de temporadas:");
                sNroTemporadas = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el número de episodios:");
                sNroEpisodios = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese la duración en horas:");
                sDuracionHoras = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el ranking:");
                sRanking = float.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el género (Accion, Drama, Comedia, Documental):");
                sGenero = Console.ReadLine();

                Console.WriteLine("Ingrese el director:");
                sDirector = Console.ReadLine();

                Serie nuevaSerie = new Serie($"{sNombre},{sNroTemporadas},{sNroEpisodios},{sDuracionHoras},{sRanking},{sGenero},{sDirector}");

                Console.WriteLine("ingrese el nombre del canal al que quiere agregar esta serie");
                canal = Console.ReadLine();

                if (pNormal.buscarCanal(canal) != null)
                {
                    pNormal.buscarCanal(canal).agregarSerie(nuevaSerie);
                }
                else
                {
                    if (pSilver.buscarCanal(canal) != null)
                    {
                        pSilver.buscarCanal(canal).agregarSerie(nuevaSerie);
                    }
                    else
                    {
                        if (pPremium.buscarCanal(canal) != null)
                        {
                            pPremium.buscarCanal(canal).agregarSerie(nuevaSerie);
                        }
                        else
                        {
                            Console.WriteLine("Canal no Encontrado");
                        }
                    }
                }

                guardarCambios();
                Console.WriteLine("Serie agregada con éxito!");
                break;

            case 4:
                Console.WriteLine("Contenido del paquete Normal:");
                pNormal.mostrarContenido();
                Console.WriteLine("\nContenido del paquete Silver:");
                pSilver.mostrarContenido();
                Console.WriteLine("\nContenido del paquete Premium:");
                pPremium.mostrarContenido();
                break;

            case 5:
                Console.WriteLine("\n--- Total recaudado por la empresa ---\n");

                double abonoBase = 10000;

                List<Cliente> clientesNormal = pNormal.devolverClientes();
                List<Cliente> clientesSilver = pSilver.devolverClientes();
                List<Cliente> clientesPremium = pPremium.devolverClientes();

                double totalNormal = clientesNormal.Count * abonoBase;
                double totalSilver = clientesSilver.Count * abonoBase * 1.15;
                double totalPremium = clientesPremium.Count * abonoBase * 1.20;

                double total = totalNormal + totalSilver + totalPremium;

                Console.WriteLine($"\nABONO BASE: ${abonoBase}\n");

                Console.WriteLine($"Paquete Normal  - Clientes: {clientesNormal.Count} - Total: ${totalNormal}");
                Console.WriteLine($"Paquete Silver  - Clientes: {clientesSilver.Count} - Total: ${totalSilver}");
                Console.WriteLine($"Paquete Premium - Clientes: {clientesPremium.Count} - Total: ${totalPremium}");

                Console.WriteLine($"\nTOTAL GENERAL RECAUDADO: ${total}");
                break;

            case 6:
                Console.WriteLine("\n--- Paquete más vendido ---\n");
                int clientesN = pNormal.devolverClientes().Count;
                int clientesS = pSilver.devolverClientes().Count;
                int clientesP = pPremium.devolverClientes().Count;

                if (clientesN > clientesS && clientesN > clientesP)
                {
                    Console.WriteLine("El paquete más vendido es el Normal con " + clientesN + " clientes.");
                }
                else if (clientesS > clientesN && clientesS > clientesP)
                {
                    Console.WriteLine("El paquete más vendido es el Silver con " + clientesS + " clientes.");
                }
                else if (clientesP > clientesN && clientesP > clientesS)
                {
                    Console.WriteLine("El paquete más vendido es el Premium con " + clientesP + " clientes.");
                }
                else if (clientesP == 0 & clientesN == 0 & clientesS == 0)
                {
                    Console.WriteLine("No hay clientes en ningún paquete.");
                }
                else if (clientesN == clientesS && clientesN > clientesP)
                {
                    Console.WriteLine("Los paquetes Normal y Silver tienen la misma cantidad de clientes: " + clientesN);
                }
                else if (clientesN == clientesP && clientesN > clientesS)
                {
                    Console.WriteLine("Los paquetes Normal y Premium tienen la misma cantidad de clientes: " + clientesN);
                }
                else if (clientesS == clientesP && clientesS > clientesN)
                {
                    Console.WriteLine("Los paquetes Silver y Premium tienen la misma cantidad de clientes: " + clientesS);
                }
                else
                {
                    Console.WriteLine("Todos los paquetes tienen la misma cantidad de clientes.");
                }
                break;

            case 7:
                foreach (Canal canal7 in pNormal.devolverCanales())
                {
                    foreach (Serie serie in canal7.devolverSeries())
                    {
                        if (serie.Ranking > 3.5)
                        {
                            Console.WriteLine($"Serie: {serie.Nombre} | Ranking: {serie.Ranking:F1}");
                        }
                    }
                }
                foreach (Canal canal7 in pSilver.devolverCanales())
                {
                    foreach (Serie serie in canal7.devolverSeries())
                    {
                        if (serie.Ranking > 3.5)
                        {
                            Console.WriteLine($"Serie: {serie.Nombre} | Ranking: {serie.Ranking:F1}");
                        }
                    }
                }
                foreach (Canal canal7 in pPremium.devolverCanales())
                {
                    foreach (Serie serie in canal7.devolverSeries())
                    {
                        if (serie.Ranking > 3.5)
                        {
                            Console.WriteLine($"Serie: {serie.Nombre} | Ranking: {serie.Ranking:F1}");
                        }
                    }
                }
                var totalSeriesmas = pNormal.devolverCanales().Sum(c => c.devolverSeries().Count) +pSilver.devolverCanales().Sum(c => c.devolverSeries().Count) +pPremium.devolverCanales().Sum(c => c.devolverSeries().Count);
                if (totalSeriesmas == 0)
                {
                    Console.WriteLine("\nNo hay series con un ranking mayor a 3.5 en ningún paquete.\n");
                }
                else
                {
                    Console.WriteLine($"\nTotal de series con ranking mayor a 3.5: {totalSeriesmas}\n");
                }

                var totalSeriesmenos = pNormal.devolverCanales().Sum(c => c.devolverSeries().Count(s => s.Ranking <= 3.5)) + pSilver.devolverCanales().Sum(c => c.devolverSeries().Count(s => s.Ranking <= 3.5)) + pPremium.devolverCanales().Sum(c => c.devolverSeries().Count(s => s.Ranking <= 3.5));
                if (totalSeriesmenos == 0)
                {
                    Console.WriteLine("\nNo hay series con un ranking menor o igual a 3.5 en ningún paquete.\n");
                }
                else
                {
                    Console.WriteLine($"\nTotal de series con ranking menor o igual a 3.5: {totalSeriesmenos}\n");
                }
                break;
            case 8:
                Console.WriteLine("\nSaliendo del programa...");
                break;
        }
    }
}

void guardarCambios()
{
    if(repositorioGral != null){
        repositorioGral.quitar(pNormal);
        repositorioGral.quitar(pSilver);
        repositorioGral.quitar(pPremium);
    }
    repositorioGral.agregar(pNormal);
    repositorioGral.agregar(pSilver);        
    repositorioGral.agregar(pPremium);
}
