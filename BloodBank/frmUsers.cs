using System;
using System.Windows.Forms;
using BloodBank.BLL;

namespace BloodBank.UI
{
    public partial class frmUsers : Form
    {
        private readonly UserBLL _bll = new UserBLL();
        private readonly int _currentUserId;

        public frmUsers(int currentUserId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvUsers.DataSource = _bll.GetAll();
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Id"].HeaderText = "ID";
                dgvUsers.Columns["Username"].HeaderText = "Логин";
                dgvUsers.Columns["Password"].Visible = false;
                dgvUsers.Columns["FullName"].HeaderText = "ФИО";
                dgvUsers.Columns["Email"].HeaderText = "Email";
                dgvUsers.Columns["Contact"].HeaderText = "Телефон";
                dgvUsers.Columns["Address"].HeaderText = "Адрес";
                dgvUsers.Columns["UserType"].HeaderText = "Тип";
                dgvUsers.Columns["AddedDate"].HeaderText = "Дата добавления";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string result = _bll.Add(
                txtUsername.Text, txtPassword.Text, txtFullName.Text,
                txtEmail.Text, txtContact.Text, txtAddress.Text,
                cmbUserType.SelectedItem?.ToString());

            ShowResult(result);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Выберите пользователя из таблицы.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = _bll.Update(
                int.Parse(txtId.Text), txtUsername.Text, txtPassword.Text,
                txtFullName.Text, txtEmail.Text, txtContact.Text,
                txtAddress.Text, cmbUserType.SelectedItem?.ToString());

            ShowResult(result);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Выберите пользователя для удаления.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.Parse(txtId.Text) == _currentUserId)
            {
                MessageBox.Show("Нельзя удалить самого себя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Удалить пользователя?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ShowResult(_bll.Delete(int.Parse(txtId.Text)));
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ShowResult(string result)
        {
            if (result == "OK")
            {
                MessageBox.Show("Операция выполнена успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show(result, "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            cmbUserType.SelectedIndex = -1;
            txtSearch.Clear();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvUsers.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value?.ToString();
            txtUsername.Text = row.Cells["Username"].Value?.ToString();
            txtPassword.Text = row.Cells["Password"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtContact.Text = row.Cells["Contact"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            cmbUserType.SelectedItem = row.Cells["UserType"].Value?.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _bll.Search(txtSearch.Text);
        }
    }
}