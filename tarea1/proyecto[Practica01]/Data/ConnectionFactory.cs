using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Almacen.Data
{
    public class ConnectionFactory
    {
        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;

        public ConnectionFactory()
        {
            

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            _provider = DbProviderFactories.GetFactory("System.Data.SqlClient");
            _connectionString = proyecto_Practica01_.Properties.Resources.cnnString;
        }
        public IDbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new Exception();

            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }

    }
}
