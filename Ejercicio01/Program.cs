using static Ejercicio01.Excepciones;
using System.Globalization;

namespace Ejercicio01
{
    internal class Program
    {
        private static Banco banco;

        static void Main(string[] args)
        {
            banco = new Banco();
            Console.WriteLine("=== SISTEMA BANCARIO ===");
            Console.WriteLine($"Bienvenido a {banco.Nombre}");
            Console.WriteLine();

            bool continuar = true;

            while (continuar)
            {
                try
                {
                    MostrarMenu();
                    int opcion = LeerOpcion();
                    continuar = ProcesarOpcion(opcion);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            // PUNTO 1
            Console.WriteLine("1. Crear Cliente"); 
            Console.WriteLine("2. Modificar datos cliente"); 
            Console.WriteLine("3. Eliminar Cliente"); 
            // PUNTO 2
            Console.WriteLine("4. Crear Cuenta de Ahorros");  
            Console.WriteLine("5. Crear Cuenta Corriente");   
            Console.WriteLine("6. Modificar Titular"); 
            Console.WriteLine("7. Eliminar Cuenta"); 
            // PUNTO 3
            Console.WriteLine("8. Realizar Depósito"); 
            Console.WriteLine("9. Realizar Retiro"); 
            Console.WriteLine("10. Consultar Saldo");
            // PUNTO 4
            Console.WriteLine("11. Listar todos los clientes");
          
            Console.WriteLine("12. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");
        }

        static int LeerOpcion()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new DatosInvalidosException("Debe ingresar un número válido.");
            }
        }

        static bool ProcesarOpcion(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case 1:
                        CrearCliente(); //---------------------------------------------------------
                        break; 
                    case 2:
                        ModificarCliente(); //---------------------------------------------------------
                        break;
                    case 3: 
                        EliminarCliente(); //---------------------------------------------------------
                        break;
                    case 4:
                        CrearCuentaAhorros(); //---------------------------------------------------------
                        break;
                    case 5:
                        CrearCuentaCorriente(); //---------------------------------------------------------
                        break;
                    case 6:
                        ModificarTitularCuenta(); //---------------------------------------------------------
                        break;
                    case 7:
                        EliminarCuenta(); //---------------------------------------------------------
                        break;
                    case 8:
                        RealizarDeposito(); //---------------------------------------------------------
                        break;
                    case 9:
                        RealizarRetiro(); //---------------------------------------------------------
                        break;
                    case 10:
                        ConsultarSaldo(); //---------------------------------------------------------
                        break;
                    case 11:
                        ListarClientes(); //---------------------------------------------------------
                        break;
                    case 12:
                        Console.WriteLine("¡Gracias por usar el sistema bancario!");
                        return false;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
            catch (FondosInsuficientesException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (LimiteRetirosExcedidoException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return true;
        }

        static void CrearCliente()
        {
            Console.WriteLine("\n=== CREAR CLIENTE ===");
            Console.Write("Número de dni: ");
            int dni = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Número de telefono: ");
            int telefono = int.Parse(Console.ReadLine());

            Console.Write("Mail: ");
            string mail = Console.ReadLine();

            Console.WriteLine("Fecha de Nacimiento: ");
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Año: ");
            int año = int.Parse(Console.ReadLine());

            string FechaNacimiento = $"{dia}/{mes}/{año}";

            banco.CrearCliente(dni, nombre, apellido, telefono, mail, FechaNacimiento);

            Console.WriteLine("Cliente creado exitosamente.");
        }

        static void ModificarCliente()
        {
            Console.WriteLine("\n=== MODIFICANDO CLIENTE ===");
            Console.Write("Ingrese dni del cliente a modificar: ");
            int dni = int.Parse(Console.ReadLine());

            var cliente = banco.BuscarCliente(dni);

            Console.Write("Nombre: ");
            cliente.Nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            cliente.Apellido = Console.ReadLine();

            Console.Write("Número de telefono: ");
            cliente.Telefono = int.Parse(Console.ReadLine());

            Console.Write("Mail: ");
            cliente.Email = Console.ReadLine();

            Console.WriteLine("Fecha de Nacimiento: ");
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Año: ");
            int año = int.Parse(Console.ReadLine());

            cliente.FechaNacimiento = $"{dia}/{mes}/{año}";

            Console.WriteLine("Cliente modificado exitosamente.");
        }

        static void EliminarCliente()
        {
            Console.WriteLine("\n=== ELIMINANDO CLIENTE ===");
            Console.Write("Ingrese dni del cliente a eliminar: ");
            int dni = int.Parse(Console.ReadLine());

            banco.EliminarCliente(dni);

            Console.WriteLine("Cliente eliminado exitosamente.");

        }

        static void CrearCuentaAhorros()
        {
            Console.WriteLine("\n=== CREAR CUENTA DE AHORROS ===");
            Console.Write("Dni titular de la cuenta: ");
            string numeroCuenta = Console.ReadLine();
            
            banco.CrearCuentaAhorros(numeroCuenta);
            Console.WriteLine("Cuenta de ahorros creada exitosamente.");
        }

        static void CrearCuentaCorriente()
        {
            Console.WriteLine("\n=== CREAR CUENTA CORRIENTE ===");
            Console.Write("Dni titular de la cuenta: ");
            string numeroCuenta = Console.ReadLine();

            banco.CrearCuentaCorriente(numeroCuenta);
            Console.WriteLine("Cuenta corriente creada exitosamente.");
        }

        static void ModificarTitularCuenta()
        {
            Console.WriteLine("\n=== MODIFICANDO TITULAR DE CUENTA ===");
            Console.Write("Ingrese dni del titular actual de la cuenta: ");
            string dni = Console.ReadLine();

            var cuenta = banco.ObtenerCuenta(dni);

            if(cuenta.Titular.Dni != int.Parse(dni))
            {
                throw new Exception($"El cliente con dni {dni} no posee una cuenta");
            }

            if (cuenta.Titular.Dni == int.Parse(dni))
            {
                Console.Write("Ingrese dni del nuevo titular de la cuenta: ");
                string dniNuevo = Console.ReadLine();

                Cliente cliente = banco.BuscarCliente(int.Parse(dniNuevo));

                if (cliente != null)
                {
                    bool existe = banco.BuscarCuentaPorDni(dniNuevo);

                    if(existe == false)
                    {
                        banco.EliminarCuenta(dni);
                        if (cuenta.ObtenerTipoCuenta() == "Cuenta de Ahorro")
                        {
                            banco.CrearCuentaAhorros(dniNuevo);
                        }

                        if (cuenta.ObtenerTipoCuenta() == "Cuenta Corriente")
                        {
                            banco.CrearCuentaCorriente(dniNuevo);
                        }

                        Console.WriteLine("Titular de la cuenta modificado exitosamente.");
                    }
                    else
                    {
                        throw new Exception($"No se pudo modificar el titular, el cliente con el dni {dniNuevo} ya posee otra cuenta");
                    }

                }
            }
        }

        static void EliminarCuenta()
        {
            Console.WriteLine("\n=== ELIMINANDO CUENTA ===");
            Console.Write("Ingrese dni del titular de la cuenta a eliminar: ");
            string dni = Console.ReadLine();

            banco.EliminarCuenta(dni);

            Console.WriteLine("Cuenta eliminada exitosamente.");
        }

        static void RealizarDeposito()
        {
            Console.WriteLine("\n=== REALIZAR DEPÓSITO ===");
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Console.Write("Monto a depositar: $");
            decimal monto = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            banco.RealizarDeposito(numeroCuenta, monto);
            Console.WriteLine($"Depósito de ${monto:N2} realizado exitosamente.");
            Console.WriteLine($"Nuevo saldo: ${banco.ConsultarSaldo(numeroCuenta):N2}");
        }

        static void RealizarRetiro()
        {
            Console.WriteLine("\n=== REALIZAR RETIRO ===");
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Console.Write("Monto a retirar: $");
            decimal monto = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            banco.RealizarRetiro(numeroCuenta, monto);
            Console.WriteLine($"Retiro de ${monto:N2} realizado exitosamente.");
            Console.WriteLine($"Nuevo saldo: ${banco.ConsultarSaldo(numeroCuenta):N2}");
        }

        static void ConsultarSaldo()
        {
            Console.WriteLine("\n=== CONSULTAR SALDO ===");
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            decimal saldo = banco.ConsultarSaldo(numeroCuenta);
            var cuenta = banco.ObtenerCuenta(numeroCuenta);

            Console.WriteLine($"Tipo de cuenta: {cuenta.ObtenerTipoCuenta()}");
            Console.WriteLine($"Titular: {cuenta.Titular}");
            Console.WriteLine($"Saldo actual: ${saldo:N2}");

            if (cuenta is CuentaCorriente cc)
            {
                Console.WriteLine($"Saldo disponible (con sobregiro): ${cc.ObtenerSaldoDisponible():N2}");
            }
        }

        static void ListarClientes()
        {
            Console.WriteLine("\n=== LISTADO DE CLIENTES ===");
            var clientes = banco.ObtenerTodasLosClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay cuentas registradas.");
                return;
            }

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Dni: {cliente.Dni}");
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                
                
                

                Console.WriteLine(new string('-', 30));
            }
        }
    
    }

}
