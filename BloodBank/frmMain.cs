using System;
using System.Windows.Forms;

namespace BloodBank.UI
{
    public partial class frmMain : Form
    {
        public int CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }
        public string CurrentUserType { get; set; }

        public frmMain(int userId, string fullName, string userType)
        {
            InitializeComponent();
            CurrentUserId = userId;
            CurrentUserName = fullName;
            CurrentUserType = userType;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"{CurrentUserName} ({CurrentUserType})";

            // Скрываем управление пользователями для обычной роли
            if (CurrentUserType != "Admin")
                btnUsers.Visible = false;
        }

        private void OpenChild(Form child)
        {
            panelContent.Controls.Clear();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panelContent.Controls.Add(child);
            child.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChild(new frmUsers(CurrentUserId));
        }

        private void btnDonors_Click(object sender, EventArgs e)
        {
            OpenChild(new frmDonors(CurrentUserName));
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChild(new frmDashboard());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из системы?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }
        }
    }
}