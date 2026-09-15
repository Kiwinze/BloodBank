using System;
using System.Data;
using BloodBank.DAL;

namespace BloodBank.BLL
{
    public class DonorBLL
    {
        private readonly DonorDAL _dal = new DonorDAL();

        public DataTable GetAll() => _dal.SelectAll();

        public DataTable Search(string keyword)
        {
            return string.IsNullOrWhiteSpace(keyword) ? _dal.SelectAll() : _dal.Search(keyword.Trim());
        }

        public DataTable GetByBloodGroup(string bloodGroup)
        {
            if (string.IsNullOrWhiteSpace(bloodGroup))
                return _dal.SelectAll();
            return _dal.SelectByBloodGroup(bloodGroup);
        }

        public string Add(string fullName, string gender, int age, string bloodGroup,
                          string contact, string email, string address,
                          DateTime? lastDonation, string addedBy)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "Введите ФИО донора.";
            if (string.IsNullOrWhiteSpace(gender)) return "Выберите пол.";
            if (age < 18 || age > 65) return "Возраст донора должен быть от 18 до 65 лет.";
            if (string.IsNullOrWhiteSpace(bloodGroup)) return "Выберите группу крови.";
            if (string.IsNullOrWhiteSpace(contact)) return "Введите контактный телефон.";

            return _dal.Insert(fullName, gender, age, bloodGroup, contact, email, address, lastDonation, addedBy)
                ? "OK" : "Не удалось добавить донора.";
        }

        public string Update(int id, string fullName, string gender, int age, string bloodGroup,
                             string contact, string email, string address, DateTime? lastDonation)
        {
            if (id <= 0) return "Выберите донора.";
            if (string.IsNullOrWhiteSpace(fullName)) return "Введите ФИО.";
            if (age < 18 || age > 65) return "Возраст донора должен быть от 18 до 65 лет.";

            return _dal.Update(id, fullName, gender, age, bloodGroup, contact, email, address, lastDonation)
                ? "OK" : "Не удалось обновить данные донора.";
        }

        public string Delete(int id)
        {
            if (id <= 0) return "Выберите донора для удаления.";
            return _dal.Delete(id) ? "OK" : "Не удалось удалить донора.";
        }
    }
}