using System.Data;
using BloodBank.DAL;

namespace BloodBank.BLL
{
    public class LoginBLL
    {
        private readonly LoginDAL _dal = new LoginDAL();

        public DataTable Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return new DataTable();

            return _dal.Login(username.Trim(), password.Trim());
        }
    }
}