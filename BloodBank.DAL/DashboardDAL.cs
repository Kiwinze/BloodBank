using System.Data;
using System.Data.SqlClient;

namespace BloodBank.DAL
{
    public class DashboardDAL
    {
        /// <summary>
        /// Возвращает статистику по группам крови: группа + количество доноров.
        /// </summary>
        public DataTable GetBloodGroupStats()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT BloodGroup, COUNT(*) AS DonorCount
                                 FROM Donors
                                 GROUP BY BloodGroup
                                 ORDER BY BloodGroup";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public int GetTotalDonors()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Donors";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int GetTotalUsers()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}