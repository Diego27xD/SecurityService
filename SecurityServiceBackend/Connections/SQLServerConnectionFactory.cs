using Microsoft.Data.SqlClient;

namespace SecurityServiceBackend.Connections
{
    public class SQLServerConnectionFactory
    {
        private readonly string _connection;

        public SQLServerConnectionFactory(IConfiguration config)
        {
            _connection = config.GetConnectionString("DbSQLServer");
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connection);
        }
    }
}
