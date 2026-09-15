using System.Data;
using System.Data.SqlClient;

namespace BloodBank.DAL
{
    public class UserDAL
    {
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Id, Username, Password, FullName, Email, Contact, 
                                        Address, UserType, AddedDate
                                 FROM Users ORDER BY Id DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable Search(string keyword)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Id, Username, Password, FullName, Email, Contact,
                                        Address, UserType, AddedDate
                                 FROM Users
                                 WHERE Username LIKE @kw OR FullName LIKE @kw
                                    OR Email LIKE @kw OR Contact LIKE @kw";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public bool Insert(string username, string password, string fullName, string email,
                           string contact, string address, string userType)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Users 
                                 (Username, Password, FullName, Email, Contact, Address, UserType)
                                 VALUES (@u, @p, @f, @e, @c, @a, @t)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@f", fullName);
                    cmd.Parameters.AddWithValue("@e", (object)email ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@c", (object)contact ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@a", (object)address ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@t", userType);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(int id, string username, string password, string fullName, string email,
                           string contact, string address, string userType)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Users SET 
                                 Username = @u, Password = @p, FullName = @f,
                                 Email = @e, Contact = @c, Address = @a, UserType = @t
                                 WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@f", fullName);
                    cmd.Parameters.AddWithValue("@e", (object)email ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@c", (object)contact ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@a", (object)address ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@t", userType);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UsernameExists(string username, int excludeId = 0)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @u AND Id <> @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@id", excludeId);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}