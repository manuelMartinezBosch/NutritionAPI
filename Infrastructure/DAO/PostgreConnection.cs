using System;
using Npgsql;

namespace NutritionApi.Infrastructure.DAO
{
    public class PostgreConnection
    {
        public NpgsqlConnection Connection;

        public PostgreConnection()
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