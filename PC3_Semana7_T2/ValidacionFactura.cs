
public static class ValidacionFactura
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el número de factura: (YXXX-XXXXXXXX)");
        string numeroFactura = Console.ReadLine();
        
        mostrarMensaje(ValidarFormatoFactura(numeroFactura),numeroFactura);        
    }    

    public static bool ValidarFormatoFactura(string _numeroFactura)
    {
        bool esvalida = false;
        if (_numeroFactura.Length == 13 && (_numeroFactura[0] == 'B' || _numeroFactura[1] == 'F') && _numeroFactura[4] == '-')
        {
            esvalida = ValidarNrosFactura(_numeroFactura);
        }
        else
        {
            esvalida = false;
        }

        return esvalida;
    }

    public static bool ValidarNrosFactura(string _numeroFactura)
    {
        bool esvalida = false;
        for (int i = 1; i < 4; i++)
        {
            if (ValidarNumeros(_numeroFactura[i].ToString()))
            {
                esvalida = true;
            }
            else
            {
                esvalida = false;
                break;
            }
        }
        if (esvalida)
        {
             for (int i = 5; i < 13; i++){
                if (ValidarNumeros(_numeroFactura[i].ToString()))
                {
                    esvalida = true;
                }
                else
                {
                    esvalida = false;
                    break;
                }
            }
        }       
        return esvalida;
    }

    public static bool ValidarNumeros(string _valor)
    {
        bool esvalida = false;
        switch (_valor)
        {
            case "0":
                esvalida = true;
                break;
            case "1":
                esvalida = true;    
                break;
            case "2":
                esvalida = true;    
                break;
            case "3":
                esvalida = true;
                break;
            case "4":
                esvalida = true;    
                break;
            case "5":
                esvalida = true;    
                break;
            case "6":
                esvalida = true;
                break;
            case "7":
                esvalida = true;    
                break;
            case "8":
                esvalida = true;    
                break;
            case "9":
                esvalida = true;    
                break;
            default:
                esvalida = false;
                break;
        }
        return esvalida;        
    }

    public static void mostrarMensaje(bool _esvalida, string _numeroFactura)
    {
        Console.WriteLine("======================================================");        
        if (_esvalida)
        {
            if(_numeroFactura[0] == 'F')
            {
                Console.WriteLine("========= Validación de Factura Correcta =============");
            }
            else
            {
                Console.WriteLine("========= Validación de Boleta Correcta  =============");
            }
        }
        else
        {
            Console.WriteLine("========= Factura/Boleta es incorrecta   =============");
        }        
        Console.WriteLine("======================================================");
    }
}