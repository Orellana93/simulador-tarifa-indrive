public static class CalculeSLA
{    
   
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la fecha y hora de inicio del servicio (dd/MM/yyyy HH:mm):");
        string fechaHoraInicio = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha y hora de finalización del servicio (dd/MM/yyyy HH:mm):");
        string fechaHoraFinalizacion = Console.ReadLine();

        DateTime inicio = DateTime.ParseExact(fechaHoraInicio, "dd/MM/yyyy HH:mm", null);
        DateTime finalizacion = DateTime.ParseExact(fechaHoraFinalizacion, "dd/MM/yyyy HH:mm", null);
        List<FechayHorasSLA> diasYHorasHabiles = ObtenerDiasHabiles(inicio, finalizacion);

        mostrarMensaje(diasYHorasHabiles);                     
    }
 
    public class FechayHorasSLA
    {
        public DateTime Fecha { get; set; }
        public int hora { get; set; }            
    }
    
    public static List<FechayHorasSLA> ObtenerDiasHabiles(DateTime _fechaInicio, DateTime _fechaFin)
    {
        int diasHabiles = 0;
        int _horasHabiles = 0;
        DateTime fechaInicio = _fechaInicio;
        DateTime fechaFin = _fechaFin;

        List<FechayHorasSLA> listFechas = new List<FechayHorasSLA>();
                
        while (_fechaInicio.Date <= _fechaFin.Date)
        {                        
            if (_fechaInicio.DayOfWeek != DayOfWeek.Saturday && _fechaInicio.DayOfWeek != DayOfWeek.Sunday)
            {                
                diasHabiles++; 

                if (_fechaInicio.Date == _fechaFin.Date)
                {
                    while (fechaInicio.Hour < _fechaFin.Hour){                                  
                        if (fechaInicio.DayOfWeek != DayOfWeek.Saturday && fechaInicio.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (fechaInicio.Hour >= 9 && fechaInicio.Hour < 17) // Considerando horario laboral de 9 a 17 horas
                            {
                                _horasHabiles++;
                            }                
                        }
                        fechaInicio = fechaInicio.AddHours(1);  
                    }

                }
                else
                {        
                     while (fechaInicio.Hour < 17){
                        
                        if (fechaInicio.DayOfWeek != DayOfWeek.Saturday && fechaInicio.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (fechaInicio.Hour >= 9 && fechaInicio.Hour < 17) // Considerando horario laboral de 9 a 17 horas
                            {
                                _horasHabiles++;
                            }                
                        }
                        fechaInicio = fechaInicio.AddHours(1);
                    }            
                }                  

                FechayHorasSLA nuevaFecha = new FechayHorasSLA
                {
                    Fecha = _fechaInicio,
                    hora = _horasHabiles
                };
                listFechas.Add(nuevaFecha); 

            }
            _horasHabiles = 0; // Reiniciar las horas hábiles para el siguiente día
            _fechaInicio = _fechaInicio.AddDays(1);
            if (_fechaInicio.Date == fechaInicio.Date)
            {
                fechaInicio  = _fechaInicio; // Reiniciar la fecha de inicio para el siguiente día    
            }
            else
            {
                fechaInicio  = _fechaInicio; // Reiniciar la fecha de inicio para el siguiente día
                fechaInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, fechaInicio.Day, 9, 0, 0); // Reiniciar la hora a las 9:00 AM
            }
            
        }
        
        return listFechas;
    }

     public static string diasSemana(int _dia)
    {
        string diaSemana = "";
        switch (_dia)
        {
            case 0:
                diaSemana = "Domingo";
                break;
            case 1:
                diaSemana = "Lunes";
                break;
            case 2:
                diaSemana = "Martes";
                break;
            case 3:
                diaSemana = "Miércoles";
                break;
            case 4:
                diaSemana = "Jueves";
                break;
            case 5:
                diaSemana = "Viernes";
                break;
            case 6:
                diaSemana = "Sábado";
                break;
            default:
                diaSemana = "Día inválido";
                break;
        }
        return diaSemana;
    }

    public static void mostrarMensaje(List<FechayHorasSLA> _diasYHorasHabiles)
    {
        int totalHoras = 0;        

        Console.WriteLine("======================================================");
        Console.WriteLine("========== DÍAS Y HORAS DE SLAS APLICADOS ============");
        Console.WriteLine("======================================================");
        foreach (var fechas in _diasYHorasHabiles)
        {
            Console.WriteLine($"Horas Laborales: {fechas.hora} el día {diasSemana((int)fechas.Fecha.DayOfWeek)}");
            totalHoras += fechas.hora;
        }
        Console.WriteLine("======================================================");
        Console.WriteLine("============ TOTAL DE HORAS APLICADAS ================");
        Console.WriteLine($"============ {totalHoras} horas =====================");
        
        if (totalHoras > 8)
        {
            int diferenciaHoras = totalHoras - 8;
            Console.WriteLine("======================================================");
            Console.WriteLine($"============ SLA EXCEDIDO, INCUMPLIDO: {diferenciaHoras} HORAS ======");
        }
        else
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"============ SLA CUMPLIDO CORRECTAMENTE: {totalHoras} HORAS =====");
        }        
        Console.WriteLine("======================================================");
    }

    /* Pruebas de ejecución:
    Inicio: 29/06/2026 15:11 15 a 17 2 horas
    30/06/2026 09:00 09 a 17 8 horas
    Fin: 01/07/2026 18:11 09 a 18 8 horas 

    Inicio: 29/06/2026 15:11 15 a 17 2 horas
    30/06/2026 09:00 09 a 17 8 horas
    Fin: 01/07/2026 16:11 09 a 16 7 horas 

    Inicio: 29/06/2026 09:11 15 a 17 8 horas
    30/06/2026 09:00 09 a 17 8 horas
    Fin: 01/07/2026 12:11 09 a 12 3 horas 

    Inicio: 01/07/2026 12:11
    Fin: 01/07/2026 15:11  3 horas

    Inicio: 30/06/2026 15:11 2 horas
    Fin: 01/07/2026 10:11  1 horas
    */
}