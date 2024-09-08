using Almacen.Data.Interfaces;
using Almacen.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Data.Implementations
{
    public class ArticuloRepository : IArticuloRepository
    {
        DataContext _connection;

        public ArticuloRepository(DataContext context)
        {
            _connection = context;
        }
        public IEnumerable<Articulo> ToList(IDbCommand command) //recibe un command y devuelve una lista con los resultados de la query
        {

            using (var reader = command.ExecuteReader())
            {
                DataTable t = new DataTable();
                t.Load(reader);

                List<Articulo> articulos = new List<Articulo>();

                for (int i = 0; i < t.Rows.Count; i++)
                {
                    DataRow row = t.Rows[i];

                    Articulo a = new Articulo();
                    a.Codigo = (int)row[0];
                    a.Nombre = (string)row[1];
                    a.Precio = decimal.ToDouble((decimal)row[2]);

                    articulos.Add(a);

                }

                return articulos;
            }
        }


        public void Create(Articulo a)
        {
            using( var command = _connection.CreateCommand())
            {
                //params y texto del command
                command.CommandText = "SP_AGREGAR_ARTICULO";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@nombre",a.Nombre),
                    new SqlParameter("@precio", a.Precio)
                };

                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            //params y texto del command
            using ( var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_BORRAR_ARTICULO";
                command.CommandType = CommandType.StoredProcedure;
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id_articulo",id)
                };
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
            }
            
        }

        public IEnumerable<Articulo> GetAll()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_RECUPERAR_ARTICULOS";
                command.CommandType = CommandType.StoredProcedure;

                return ToList(command);
            }
        }

        public void Update(Articulo a)
        {
            //params y texto del command
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_EDITAR_ARTICULO";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id_articulo",a.Codigo),
                    new SqlParameter("@nombre",a.Nombre),
                    new SqlParameter("@precio", a.Precio)
                };
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
            }
            
        }

        public void UpdatePrice(double d)
        {
            //params y texto del command
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_AUMENTAR_PRECIOS";
                command.CommandType = CommandType.StoredProcedure;


                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@aumento", (decimal)d)
                };
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
            }

        }

    }
}
