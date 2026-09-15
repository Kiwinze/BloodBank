using System.Data.SqlClient;

namespace BloodBank.DAL
{
    /// <summary>
    /// Единая точка подключения к базе данных BloodBankDB.
    /// </summary>
    public class DbConnection
    {
        // Измените строку подключения под свой SQL Server
        public static readonly string ConnectionString =
            @"Data Source=DESKTOP-LH3UBGG;Initial Catalog=BloodBankDB;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}