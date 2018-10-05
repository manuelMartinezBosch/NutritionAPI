using System;
using Npgsql;

namespace NutritionApi.Helpers
{
    public class PostgreSQLConnection
    {
        public NpgsqlConnection Connection;

        public PostgreSQLConnection()
        {
            NpgsqlConnectionStringBuilder conn_string = new NpgsqlConnectionStringBuilder();
            conn_string.Host = "horton.elephantsql.com";
            conn_string.Username = "haavpbgt";
            conn_string.Password = "rBkLiKV_slwTYeP1RsjbnagbWaC4gGTl";
            conn_string.Database = "haavpbgt";
            conn_string.SslMode = SslMode.Disable;
            Connection = new NpgsqlConnection(conn_string.ToString());
        }
    }
}