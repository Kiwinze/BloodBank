using System.Data;
using BloodBank.DAL;

namespace BloodBank.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _dal = new UserDAL();

        public DataTable GetAll() => _dal.SelectAll();

        public DataTable Search(string keyword)
        {
            return string.IsNullOrWhiteSpace(keyword) ? _dal.SelectAll() : _dal.Search(keyword.Trim());
        }

        public string Add(string username, string password, string fullName, string email,
                          string contact, string address, string userType)
        {
            if (string.IsNullOrWhiteSpace(username)) return "Введите логин.";
            if (string.IsNullOrWhiteSpace(password)) return "Введите пароль.";
            if (string.IsNullOrWhiteSpace(fullName)) return "Введите ФИО.";
            if (string.IsNullOrWhiteSpace(userType)) return "Выберите тип пользователя.";
            if (_dal.UsernameExists(username)) return "Пользователь с таким логином уже существует.";

            return _dal.Insert(username, password, fullName, email, contact, address, userType)
                ? "OK" : "Не удалось добавить пользователя.";
        }

        public string Update(int id, string username, string password, string fullName, string email,
                             string contact, string address, string userType)
        {
            if (id <= 0) return "Выберите пользователя.";
            if (string.IsNullOrWhiteSpace(username)) return "Введите логин.";
            if (_dal.UsernameExists(username, id)) return "Логин занят другим пользователем.";

            return _dal.Update(id, username, password, fullName, email, contact, address, userType)
                ? "OK" : "Не удалось обновить данные.";
        }

        public string Delete(int id)
        {
            if (id <= 0) return "Выберите пользователя для удаления.";
            return _dal.Delete(id) ? "OK" : "Не удалось удалить пользователя.";
        }
    }
}