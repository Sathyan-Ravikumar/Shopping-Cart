using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Products.Modal.DataAccess
{
    public class SqlServerConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SqlServerConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SQLConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
