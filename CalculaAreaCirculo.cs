using System.Formats.Asn1;

public static class CalculaAreaCirculo
{
    public static void Main(string[] args)
    {
        //Entrada
        //Declaración
        double radio = 0.0;
        double resultado = 0.0;
        Console.WriteLine("Ingrese radio del cículo:");
        radio =double.Parse(Console.ReadLine());

        resultado = AreaCirculo(radio);
        Console.WriteLine("El resultado es: " + resultado);
    }

    public static double AreaCirculo(double _radio)
    {
        double area;
        area = Math.PI * Math.Pow(_radio, 2);
        return Math.Round(area, 2);
    }
}