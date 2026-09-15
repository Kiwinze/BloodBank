using System;
using System.Windows.Forms;
using BloodBank.BLL;

namespace BloodBank.UI
{
    public partial class frmDonors : Form
    {
        private readonly DonorBLL _bll = new DonorBLL();
        private readonly string _currentUserName;

        public frmDonors(string currentUserName)
        {
            InitializeComponent();
            _currentUserName = currentUserName;
        }

        private void frmDonors_Load(object sender, EventArgs e)
        {
            cmbFilterGroup.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            dgvDonors.DataSource = _bll.GetAll();
            ConfigureColumns();
        }

        private void ConfigureColumns()
        {
            if (dgvDonors.Columns.Count == 0) return;

            dgvDonors.Columns["Id"].HeaderText = "ID";
            dgvDonors.Columns["FullName"].HeaderText = "ФИО";
            dgvDonors.Columns["Gender"].HeaderText = "Пол";
            dgvDonors.Columns["Age"].HeaderText = "Возраст";
            dgvDonors.Columns["BloodGroup"].HeaderText = "Группа крови";
            dgvDonors.Columns["Contact"].HeaderText = "Телефон";
            dgvDonors.Columns["Email"].HeaderText = "Email";
            dgvDonors.Columns["Address"].HeaderText = "Адрес";
            dgvDonors.Columns["LastDonation"].HeaderText = "Последняя сдача";
            dgvDonors.Columns["AddedDate"].HeaderText = "Дата добавления";
            dgvDonors.Columns["AddedBy"].HeaderText = "Добавил";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int age;
            if (!int.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Возраст должен быть числом.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = _bll.Add(
                txtFullName.Text,
                cmbGender.SelectedItem?.ToString(),
                age,
                cmbBloodGroup.SelectedItem?.ToString(),
                txtContact.Text,
                txtEmail.Text,
                txtAddress.Text,
                dtpLastDonation.Value,
                _currentUserName);

            ShowResult(result);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Выберите донора из таблицы.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age;
            if (!int.TryParse(txtAge.Text, out age)) return;

            string result = _bll.Update(
                int.Parse(txtId.Text),
                txtFullName.Text,
                cmbGender.SelectedItem?.ToString(),
                age,
                cmbBloodGroup.SelectedItem?.ToString(),
                txtContact.Text,
                txtEmail.Text,
                txtAddress.Text,
                dtpLastDonation.Value);

            ShowResult(result);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Выберите донора для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить донора?", "Подтверждение",
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
            txtFullName.Clear();
            cmbGender.SelectedIndex = -1;
            txtAge.Clear();
            cmbBloodGroup.SelectedIndex = -1;
            txtContact.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            dtpLastDonation.Value = DateTime.Today;
            txtSearch.Clear();
            cmbFilterGroup.SelectedIndex = 0;
        }

        private void dgvDonors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDonors.Rows[e.RowIndex];

            txtId.Text = row.Cells["Id"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            cmbGender.SelectedItem = row.Cells["Gender"].Value?.ToString();
            txtAge.Text = row.Cells["Age"].Value?.ToString();
            cmbBloodGroup.SelectedItem = row.Cells["BloodGroup"].Value?.ToString();
            txtContact.Text = row.Cells["Contact"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();

            if (row.Cells["LastDonation"].Value != null &&
                row.Cells["LastDonation"].Value != DBNull.Value)
            {
                dtpLastDonation.Value = Convert.ToDateTime(row.Cells["LastDonation"].Value);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvDonors.DataSource = _bll.Search(txtSearch.Text);
            ConfigureColumns();
        }

        private void cmbFilterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterGroup.SelectedItem == null) return;

            string group = cmbFilterGroup.SelectedItem.ToString();
            if (group == "Все")
            {
                LoadData();
            }
            else
            {
                dgvDonors.DataSource = _bll.GetByBloodGroup(group);
                ConfigureColumns();
            }
        }
    }
}