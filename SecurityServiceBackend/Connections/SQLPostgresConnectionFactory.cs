using Npgsql;

namespace SecurityServiceBackend.Connections
{
    public class SQLPostgresConnectionFactory
    {
        private readonly string _connection;

        public SQLPostgresConnectionFactory(IConfiguration config)
        {
            _connection = config.GetConnectionString("DbPostgres");
        }

        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connection);
        }
    }
}
