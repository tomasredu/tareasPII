// See https://aka.ms/new-console-template for more information

// during app start
using Almacen;
using Almacen.Domain;
using System.Security.Cryptography;
using Almacen.Data.Implementations;
using Almacen.Data;
using Almacen.Services;
using Almacen.Testing;
using System.Reflection.Metadata.Ecma335;




var mng = new AlmacenManager();
Start(mng);






void PrintList(IEnumerable<object> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item.ToString());
    }
}
void PrintItem(object item)
{
    Console.WriteLine(item.ToString());
}


void Start(AlmacenManager m)
{
    bool again = false;
    do
    {
        using (var uow = m.GetContext().CreateUnitOfWork())
        {
            int input = 0;
            do
            {
                Console.Clear();
                Menu.Main();
                input = Menu.getUserInput();
                switch (input)
                {

                    case 1:
                        m.AddFactura(NuevaFactura(m));
                        Console.Clear();
                        break;
                    case 2:
                        m.UpdateFactura(EditarFactura(m));
                        Console.Clear();
                        break;
                    case 3:
                        PrintList(m.GetAllFacturas());
                        m.DeleteFactura(Menu.getUserChoice("Ingrese el codigo de la factura a borrar:"));
                        break;
                    case 4:
                        PrintList(m.GetAllFacturas());
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 5:
                        PrintItem(m.GetFacturaById(Menu.getUserChoice("Ingrese el codigo de la factura:")));
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 6:
                        m.AddArticulo(NuevoArticulo(m));
                        break;
                    case 7:
                        m.UpdateArticulo(EditarArticulo(m));
                        break;
                    case 8:
                        PrintList(m.GetAllArticulos());
                        m.DeleteArticulo(Menu.getUserChoice("Ingrese el codigo del articulo a borrar:"));
                        break;
                    case 9:
                        PrintList(m.GetAllArticulos());
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 10:
                        m.UpdatePrices(Menu.getUserDouble("Ingrese el aumento a aplicar (1.25 = 125%)"));
                        break;
                    case 11:
                        m.AddFormaPago(NuevaFormaPago(m));
                        break;
                    case 12:
                        m.UpdateFormaPago(EditarFormaPago(m));
                        break;
                    case 13:
                        PrintList(m.GetAllFormasPagos());
                        m.DeleteFormaPago(Menu.getUserChoice("Ingrese el codigo de la forma a borrar:"));
                        break;
                    case 14:
                        PrintList(m.GetAllFormasPagos());
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case 15:

                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
            } while (!(input == 0 || input == 15));

            if (input == 15)
            {
                uow.SaveChanges();
                Console.WriteLine("Cambios guardados con exito!");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }

            else
            {
                //uow.Dispose();
                Console.WriteLine("Cambios descartados!");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
            }

            Console.WriteLine("Continuar? y/n");
            char aux = (char)Console.ReadLine()[0];
            switch (aux)
            {
                case 'y':
                    again = true;
                    break;
                case 'n':
                    again = false;
                    break;
                default:
                    again = false;
                    break;
            }

        }


    } while (again);




}
Factura NuevaFactura(AlmacenManager m)
{
    
    List<Detalle> detalles = new List<Detalle>();
    Dictionary<int, int> dict = new Dictionary<int, int>();
    Factura f = new Factura();
    f.Fecha = DateTime.Now;
    f.Cliente = Menu.getUserString("Ingrese el cliente:");
    PrintList(m.GetAllFormasPagos());
    f.FormaPago = new FormaPago(Menu.getUserChoice("Ingrese la forma de pago:"));
    int input = 0;
    do
    {
        
        

        Detalle d = new Detalle();
        Articulo a = new Articulo();
        PrintList(m.GetAllArticulos());
        a.Codigo = Menu.getUserChoice("Ingrese el codigo de articulo:");
        d.Articulo = a;
        d.cantidad = Menu.getUserChoice("Ingrese la cantidad:");

        bool isRepeated = false;
        foreach(Detalle detalle in detalles)
        {
            if(detalle.Articulo.Codigo == a.Codigo)
            {
                detalle.cantidad += d.cantidad;
                isRepeated = true;
            }
        }
        if (!isRepeated)
        {
            detalles.Add(d);
        }
        
        //Console.Clear();

        Menu.Detalles();
        input = Menu.getUserInput();

    } while (input != 2);
    
    f.Detalles = detalles;

    return f;
}

Factura EditarFactura(AlmacenManager m)
{

    PrintList(m.GetAllFacturas());
    Factura f =  m.GetFacturaById(Menu.getUserChoice("Ingrese el codigo de la factura a editar: "));
    f.Cliente = Menu.getUserString("Ingrese el cliente:");
    PrintList(m.GetAllFormasPagos());
    f.FormaPago = new FormaPago(Menu.getUserChoice("Ingrese la forma de pago:"));
    

    return f;
}

Articulo NuevoArticulo(AlmacenManager m)
{
    Articulo a = new Articulo();
    a.Nombre = Menu.getUserString("Ingrese el nombre del articulo:");
    a.Precio = Menu.getUserDouble("Ingrese el precio del articulo:");

    return a;
}

Articulo EditarArticulo(AlmacenManager m)
{
    PrintList(m.GetAllArticulos());
    Articulo a = new Articulo();
    a.Codigo = Menu.getUserChoice("Ingrese el codigo del articulo a editar: ");
    a.Nombre = Menu.getUserString("Ingrese el nombre del articulo:");
    a.Precio = Menu.getUserDouble("Ingrese el precio del articulo:");

    return a;
}

FormaPago NuevaFormaPago(AlmacenManager m)
{
    FormaPago fp = new FormaPago();
    fp.Nombre = Menu.getUserString("Ingrese el nombre de la forma de pago:");

    return fp;
}

FormaPago EditarFormaPago(AlmacenManager m)
{
    PrintList(m.GetAllFormasPagos());
    FormaPago fp = new FormaPago();
    fp.Codigo = Menu.getUserChoice("Ingrese el codigo de la forma a editar: ");
    fp.Nombre = Menu.getUserString("Ingrese el nombre de la forma de pago:");

    return fp;
}
