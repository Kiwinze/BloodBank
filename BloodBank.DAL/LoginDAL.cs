using System.Data;
using System.Data.SqlClient;

namespace BloodBank.DAL
{
    public class LoginDAL
    {
        public DataTable Login(string username, string password)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Id, Username, FullName, Email, Contact, Address, UserType
                                 FROM Users
                                 WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}