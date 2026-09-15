using System;
using System.Data;
using System.Data.SqlClient;

namespace BloodBank.DAL
{
    public class DonorDAL
    {
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Id, FullName, Gender, Age, BloodGroup, Contact,
                                        Email, Address, LastDonation, AddedDate, AddedBy
                                 FROM Donors ORDER BY Id DESC";
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
                string query = @"SELECT Id, FullName, Gender, Age, BloodGroup, Contact,
                                        Email, Address, LastDonation, AddedDate, AddedBy
                                 FROM Donors
                                 WHERE FullName LIKE @kw OR BloodGroup LIKE @kw
                                    OR Contact LIKE @kw OR Email LIKE @kw
                                    OR Address LIKE @kw";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable SelectByBloodGroup(string bloodGroup)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT Id, FullName, Gender, Age, BloodGroup, Contact,
                                        Email, Address, LastDonation
                                 FROM Donors
                                 WHERE BloodGroup = @bg
                                 ORDER BY FullName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bg", bloodGroup);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public bool Insert(string fullName, string gender, int age, string bloodGroup,
                           string contact, string email, string address,
                           DateTime? lastDonation, string addedBy)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Donors 
                                 (FullName, Gender, Age, BloodGroup, Contact, Email, Address, LastDonation, AddedBy)
                                 VALUES (@f, @g, @a, @bg, @c, @e, @ad, @ld, @ab)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@f", fullName);
                    cmd.Parameters.AddWithValue("@g", gender);
                    cmd.Parameters.AddWithValue("@a", age);
                    cmd.Parameters.AddWithValue("@bg", bloodGroup);
                    cmd.Parameters.AddWithValue("@c", contact);
                    cmd.Parameters.AddWithValue("@e", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ad", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ld", (object)lastDonation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ab", (object)addedBy ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(int id, string fullName, string gender, int age, string bloodGroup,
                           string contact, string email, string address, DateTime? lastDonation)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Donors SET 
                                 FullName = @f, Gender = @g, Age = @a,
                                 BloodGroup = @bg, Contact = @c, Email = @e,
                                 Address = @ad, LastDonation = @ld
                                 WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@f", fullName);
                    cmd.Parameters.AddWithValue("@g", gender);
                    cmd.Parameters.AddWithValue("@a", age);
                    cmd.Parameters.AddWithValue("@bg", bloodGroup);
                    cmd.Parameters.AddWithValue("@c", contact);
                    cmd.Parameters.AddWithValue("@e", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ad", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ld", (object)lastDonation ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Donors WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}