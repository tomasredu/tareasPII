using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Data.Interfaces;
using Almacen.Domain;

namespace Almacen.Data.Implementations
{
    public class FormaPagoRepository : IFormaPagoRepository
    {
        DataContext _connection;

        public FormaPagoRepository(DataContext context)
        {
            _connection = context;
        }
        public IEnumerable<FormaPago> ToList(IDbCommand command) //recibe un command y devuelve una lista con los resultados de la query
        {

            using (var reader = command.ExecuteReader())
            {
                DataTable t = new DataTable();
                t.Load(reader);

                List<FormaPago> formasPago = new List<FormaPago>();

                for (int i = 0; i < t.Rows.Count; i++)
                {
                    DataRow row = t.Rows[i];
                    FormaPago fp = new FormaPago();//mapeamos fp
                    fp.Codigo = (int)row[0];
                    fp.Nombre = (string)row[1];

                    formasPago.Add(fp);

                }
                return formasPago;
            }
        }
        public void Create(FormaPago fp)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_AGREGAR_FORMA_PAGO";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@forma",fp.Nombre)
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
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_BORRAR_FORMA_PAGO";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id_forma_pago",id)
                };
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<FormaPago> GetAll()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SP_RECUPERAR_FORMAS_PAGO";
                command.CommandType = CommandType.StoredProcedure;
                return ToList(command);
            }
        }

        public void Update(FormaPago fp)
        {
            using(var command  = _connection.CreateCommand())
            {
                command.CommandText = "SP_EDITAR_FORMA_PAGO";
                command.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@id",fp.Codigo),
                    new SqlParameter("@forma",fp.Nombre)
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
