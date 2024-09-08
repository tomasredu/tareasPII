using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Almacen.Domain;
using Almacen.Data.Interfaces;

namespace Almacen.Data.Implementations
{
    public class FacturaRepository : IFacturaRepository
    {
        DataContext _connection;

        public FacturaRepository(DataContext context)
        {
            _connection = context;
        }
        public IEnumerable<Factura> ToList(IDbCommand command) //recibe un command y devuelve una lista con los resultados de la query
        {

            using (var reader = command.ExecuteReader())
            {
                DataTable t = new DataTable();
                t.Load(reader);

                List<Factura> facturas = new List<Factura>();
                List<Detalle> buffer = new List<Detalle>(); //aca se guardan los detalles a medida que se recorre la dt

                for (int i = 0; i < t.Rows.Count; i++)
                {
                    DataRow row = t.Rows[i];
                    //mapeamos detalle y articulo
                    Detalle d = new Detalle();
                    Articulo a = new Articulo();
                    a.Codigo = (int)row[6];
                    a.Nombre = (string)row[7];
                    a.Precio = decimal.ToDouble((decimal)row[8]);

                    d.Codigo = (int)row[5];
                    d.Articulo = a;
                    d.cantidad = (int)row[9];
                    buffer.Add(d); //guardamos detalle en una lista




                    if (i == t.Rows.Count - 1  //si este detalle es el ultimo
                        || (int)t.Rows[i + 1]["id_factura"] != (int)row["id_factura"]) //si el proximo detalle es de otra factura 
                    {
                        FormaPago fp = new FormaPago();//mapeamos fp
                        fp.Codigo = (int)row[3];
                        fp.Nombre = (string)row[4];

                        Factura factura = new Factura(); //mapeamos factura

                        factura.Detalles = new List<Detalle>(buffer); //cargamos los detalles guardados hasta el momento
                        factura.Codigo = (int)row[0];
                        factura.Fecha = (DateTime)row[1];
                        factura.Cliente = (string)row[2];
                        factura.FormaPago = fp;


                        buffer.Clear(); //reseteamos los detalles
                        facturas.Add(factura); //guardamos la factura
                    }
                }

                return facturas;
            }
        }

        public Factura ToFactura(IDbCommand command) //recibe un command y devuelve una factura con los resultados de la query
        {

            using (var reader = command.ExecuteReader())
            {
                DataTable t = new DataTable();
                t.Load(reader);
                Factura factura = new Factura();
                List<Detalle> detalles = new List<Detalle>(); //aca se guardan los detalles a medida que se recorre la dt
                if (t.Rows.Count > 0) {
                    for (int i = 0; i < t.Rows.Count; i++)
                    {
                        DataRow row = t.Rows[i];
                        //mapeamos detalle y articulo
                        Detalle d = new Detalle();
                        Articulo a = new Articulo();
                        a.Codigo = (int)row[6];
                        a.Nombre = (string)row[7];
                        a.Precio = decimal.ToDouble((decimal)row[8]);

                        d.Codigo = (int)row[5];
                        d.Articulo = a;
                        d.cantidad = (int)row[9];
                        detalles.Add(d); //guardamos detalle en una lista  
                    }
                    FormaPago fp = new FormaPago();//mapeamos fp
                    fp.Codigo = (int)t.Rows[0][3];
                    fp.Nombre = (string)t.Rows[0][4];

                    //mapeamos factura
                    factura.Detalles = new List<Detalle>(detalles); //cargamos los detalles guardados hasta el momento
                    factura.Codigo = (int)t.Rows[0][0];
                    factura.Fecha = (DateTime)t.Rows[0][1];
                    factura.Cliente = (string)t.Rows[0][2];
                    factura.FormaPago = fp;
                }
                else
                {
                    factura.Codigo = -1;
                    factura.Fecha = DateTime.MinValue;
                    factura.Detalles = detalles;
                    factura.Cliente = "Factura no encontrada";
                }

                return factura;
            }
        }

        public void Create(Factura factura)
        {
            using (var command = _connection.CreateCommand())
            {
                //texto y parametros del command
                command.CommandText = "SP_AGREGAR_FACTURA";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@fecha",factura.Fecha),
                    new SqlParameter("@id_forma_pago", factura.FormaPago.Codigo),
                    new SqlParameter("@cliente", factura.Cliente)
                };
                SqlParameter output = new SqlParameter();
                output.ParameterName = "@id_factura";
                output.DbType = DbType.Int32;
                output.Direction = ParameterDirection.Output;
                parameters.Add(output);

                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                //command.Parameters.Add(output);

                command.ExecuteNonQuery();

                int idFactura = (int)output.Value;

                foreach (var d in factura.Detalles)
                {
                    using (var cmdDet = _connection.CreateCommand())
                    {
                        cmdDet.CommandText = "SP_AGREGAR_DETALLE";
                        cmdDet.CommandType = CommandType.StoredProcedure;
                        List<SqlParameter> parametersDet = new List<SqlParameter>() {
                            new SqlParameter("@id_factura",idFactura),
                            new SqlParameter("@id_articulo", d.Articulo.Codigo),
                            new SqlParameter("@cantidad", d.cantidad)
                        };

                        foreach (var p in parametersDet)
                        {
                            cmdDet.Parameters.Add(p);
                        }
                        cmdDet.ExecuteNonQuery();
                    }
                }
            }
        }
        public void Update(Factura factura)
        {
            using (var command = _connection.CreateCommand())
            {
                //texto y parametros del command
                command.CommandText = "SP_EDITAR_FACTURA";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id_factura",factura.Codigo),
                    new SqlParameter("@fecha",factura.Fecha),
                    new SqlParameter("@id_forma_pago", factura.FormaPago.Codigo),
                    new SqlParameter("@cliente", factura.Cliente)
                };

                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();

                foreach (var d in factura.Detalles)
                {
                    using (var cmdDet = _connection.CreateCommand())
                    {
                        cmdDet.CommandText = "SP_EDITAR_DETALLE";
                        cmdDet.CommandType = CommandType.StoredProcedure;
                        List<SqlParameter> parametersDet = new List<SqlParameter>() {
                            new SqlParameter("@id_detalle_factura",d.Codigo),
                            new SqlParameter("@id_factura",factura.Codigo),
                            new SqlParameter("@id_articulo", d.Articulo.Codigo),
                            new SqlParameter("@cantidad", d.cantidad)
                        };

                        foreach (var p in parametersDet)
                        {
                            cmdDet.Parameters.Add(p);
                        }
                        cmdDet.ExecuteNonQuery();
                    }
                }
            }
        }
        public void Delete(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                using (var cmdDet = _connection.CreateCommand())
                {
                    cmdDet.CommandText = "SP_BORRAR_DETALLES_POR_FACTURA";
                    cmdDet.CommandType = CommandType.StoredProcedure;
                    List<SqlParameter> parametersDet = new List<SqlParameter>() {
                            new SqlParameter("@id_factura",id)
                        };

                    foreach (var p in parametersDet)
                    {
                        cmdDet.Parameters.Add(p);
                    }
                    cmdDet.ExecuteNonQuery();
                }

                //texto y parametros del command
                command.CommandText = "SP_BORRAR_FACTURA";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id_factura",id)
                };

                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();


            }
        }
        //get by filtro
        public IEnumerable<Factura> GetByFiltro(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                //texto y parametros del command

                //return ToList();
                return ToList(command);
            }
        }

        public Factura GetById(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                //texto y parametros del command
                command.CommandText = "SP_RECUPERAR_FACTURAS_POR_CODIGO";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id_factura", id)
                };

                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }

                return ToFactura(command);
            }
        }

        public IEnumerable<Factura> GetAll()
        {
            using (var command = _connection.CreateCommand())
            {
                //texto y parametros del command
                command.CommandText = "SP_RECUPERAR_FACTURAS";
                command.CommandType = CommandType.StoredProcedure;

                return ToList(command);
            }
        }


    }
}
