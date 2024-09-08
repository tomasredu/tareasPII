using Almacen.Data;
using Almacen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Testing
{
    public static class Menu
    {

        public static int getUserInput()
        {
            int aux = 0;
            try
            {
                string s = Console.ReadLine();                
                aux = int.Parse(s);
            }
            catch(Exception e){
                Console.WriteLine(e);
            }
            return aux;
        }

        public static int getUserChoice(string s)
        {
            int aux = 0;
            Console.WriteLine(s);
            try
            {
                aux = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ingrese una opcion valida.");
            }
            return aux;
        }

        public static string getUserString(string s)
        {
            string aux = string.Empty;
            Console.WriteLine(s);
            try
            {
                aux = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Ingrese un nombre valido.");
            }
            return aux;
        }

        public static double getUserDouble(string s)
        {
            double aux = 0;
            Console.WriteLine(s);
            try
            {
                decimal d= decimal.Parse(Console.ReadLine());
                aux = decimal.ToDouble(d);
            }
            catch
            {
                Console.WriteLine("Ingrese un numero valido.");
            }
            return aux;
        }

        public static void Main()
        {
            Console.WriteLine("1. Nueva factura");
            Console.WriteLine("2. Editar factura");
            Console.WriteLine("3. Borrar factura");
            Console.WriteLine("4. Mostrar facturas");
            Console.WriteLine("5. Buscar factura por codigo");
            Console.WriteLine("6. Nuevo articulo");
            Console.WriteLine("7. Editar articulo");
            Console.WriteLine("8. Borrar articulo");
            Console.WriteLine("9. Mostrar articulos");
            Console.WriteLine("10. Aplicar aumento");
            Console.WriteLine("11. Nueva forma de pago");
            Console.WriteLine("12. Editar forma de pago");
            Console.WriteLine("13. Borrar forma de pago");
            Console.WriteLine("14. Mostrar formas de pagos");
            Console.WriteLine("15. Guardar");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Ingrese un numero para seleccionar una opcion");
        }
        public static void Facturas()
        {
            Console.WriteLine("1. Nueva factura");
            Console.WriteLine("2. Editar factura");
            Console.WriteLine("3. Borrar factura");
            Console.WriteLine("4. Mostrar facturas");
            Console.WriteLine("5. Buscar factura por codigo");
            Console.WriteLine("6. Guardar");
            Console.WriteLine("7. Descartar");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Ingrese un numero para seleccionar una opcion");
        }

        public static void Articulos()
        {
            Console.WriteLine("1. Nuevo articulo");
            Console.WriteLine("2. Editar articulo");
            Console.WriteLine("3. Borrar articulo");
            Console.WriteLine("4. Mostrar articulos");
            Console.WriteLine("5. Aplicar aumento");
            Console.WriteLine("6. Guardar");
            Console.WriteLine("7. Descartar");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Ingrese un numero para seleccionar una opcion");
        }

        public static void FormasPago()
        {
            Console.WriteLine("1. Nueva forma de pago");
            Console.WriteLine("2. Editar forma de pago");
            Console.WriteLine("3. Borrar forma de pago");
            Console.WriteLine("4. Mostrar formas de pagos");
            Console.WriteLine("5. Guardar");
            Console.WriteLine("6. Descartar");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Ingrese un numero para seleccionar una opcion");
        }

        public static void Detalles()
        {
            Console.WriteLine("1. Ingresar nuevo detalle");
            Console.WriteLine("2. Terminar");
        }


        
    }
}
