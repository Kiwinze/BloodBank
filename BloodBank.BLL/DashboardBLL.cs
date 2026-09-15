using System.Data;
using BloodBank.DAL;

namespace BloodBank.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dal = new DashboardDAL();

        public DataTable GetBloodGroupStats() => _dal.GetBloodGroupStats();
        public int GetTotalDonors() => _dal.GetTotalDonors();
        public int GetTotalUsers() => _dal.GetTotalUsers();
    }
}