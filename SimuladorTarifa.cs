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

        Console.WriteLine("\n Tipo de Vehículo: ");
        Console.WriteLine("1. Económico");
        Console.WriteLine("2. Confort");
        Console.WriteLine("3. Premium");    
        Console.WriteLine("4. Moto");    
        int tipoVehiculo = Convert.ToInt32(Console.ReadLine());

        //Declaración de variables
        double tarifaBase = 0;
        double tarifaFinal = 0.0;
        double subtotal = 0.0;
        double costoKM = 0;
        bool esDistancia = false;
        bool esHoraPico = false;
        string tipoVehiculoStr = "";

        //Proceso
        
        switch (tipoVehiculo)
        {
            case 1:
                tarifaBase = 2;
                costoKM = 1.5;
                tipoVehiculoStr = "Eco";
                break;
            case 2:
                tarifaBase = 3;
                costoKM = 2;
                tipoVehiculoStr = "Confort";
                break;
            case 3:
                tarifaBase = 5;
                costoKM = 3;
                tipoVehiculoStr = "Premium";
                break;
            case 4:
                tarifaBase = 1.5;
                costoKM = 1;
                tipoVehiculoStr = "Moto";
                break;
            default:
                Console.WriteLine("\nTipo de vehículo no válido.");
                break;
        }

        subtotal = tarifaBase + (costoKM * distancia);

        if ((horaSalida >= 7 && horaSalida <= 9) || (horaSalida >= 17 && horaSalida <= 20)){
          esHoraPico = true;  
          subtotal *= 1.3; // Incremento del 30% en hora pico
        }

        if (distancia > 15){
          esDistancia = true;  
          subtotal *= 0.95; // Descuento del 5% por distancia larga
        }

        tarifaFinal = Math.Max(Math.Round(subtotal, 2), 5.0); // Tarifa mínima de 5 soles

        //Salida de Datos
        Console.WriteLine("\n========================================================");
        Console.WriteLine($"Pasajero: {nombrePasajero}");
        Console.WriteLine($"Tipo de Vehículo: {tipoVehiculoStr}");
        Console.WriteLine($"Distancia a Recorrer: {distancia} KM");
        Console.WriteLine($"Hora de Salida: {horaSalida} hrs");
        Console.WriteLine($"Tarifa Base: S/. {tarifaBase}");
        Console.WriteLine($"Costo por KM: S/. {costoKM}");
        if (esHoraPico){
            Console.WriteLine("Incremento de 30% en hora pico");
        }
        if (esDistancia){
            Console.WriteLine("Descuento de 5% por Distancia Larga");        
        }

        Console.WriteLine($"Tarifa Final de recorrido: S/. {tarifaFinal:F2}");

    }
}