using System;
using System.Data;
using System.Windows.Forms;
using BloodBank.BLL;

namespace BloodBank.UI
{
    public partial class frmLogin : Form
    {
        private readonly LoginBLL _loginBll = new LoginBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите логин и пароль.", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = _loginBll.Login(username, password);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    MessageBox.Show($"Добро пожаловать, {row["FullName"]}!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmMain main = new frmMain(
                        Convert.ToInt32(row["Id"]),
                        row["FullName"].ToString(),
                        row["UserType"].ToString());

                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.", "Ошибка входа",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}