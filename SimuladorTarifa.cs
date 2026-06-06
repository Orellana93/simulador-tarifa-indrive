public static class SimuladorTarifa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("========================================================");
        Console.WriteLine("               InDrive - Simulador de Tarifa            ");
        Console.WriteLine("========================================================");
        //Entrada de Datos
        Console.Write("Nombre del Pasajero: ");
        string nombrePasajero = Console.ReadLine();

        Console.Write("Ingrese distancia del viaje (KM): ");
        double distancia = Convert.ToDouble(Console.ReadLine());

        Console.Write("Hora de Salida (0 hrs - 23 hrs): ");
        int horaSalida = Convert.ToInt32(Console.ReadLine());

        Console.Write("\n Tipo de Vehículo: ");
        Console.WriteLine("1. Económico");
        Console.WriteLine("2. Confort");
        Console.WriteLine("3. Premium");    
        Console.WriteLine("4. Moto");    
        int tipoVehiculo = Convert.ToInt32(Console.ReadLine());

        //Proceso
        
        switch (tipoVehiculo)
        {
            case 1:
                Console.WriteLine($"\nTarifa para {nombrePasajero}: ${distancia * 1.0}");
                break;
            case 2:
                Console.WriteLine($"\nTarifa para {nombrePasajero}: ${distancia * 1.5}");
                break;
            case 3:
                Console.WriteLine($"\nTarifa para {nombrePasajero}: ${distancia * 2.0}");
                break;
            case 4:
                Console.WriteLine($"\nTarifa para {nombrePasajero}: ${distancia * 0.8}");
                break;
            default:
                Console.WriteLine("\nTipo de vehículo no válido.");
                break;
        }


    }
}