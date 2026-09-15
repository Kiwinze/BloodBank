using System;
using System.Windows.Forms;
using BloodBank.BLL;

namespace BloodBank.UI
{
    public partial class frmDashboard : Form
    {
        private readonly DashboardBLL _bll = new DashboardBLL();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                // Карточки
                int totalDonors = _bll.GetTotalDonors();
                int totalUsers = _bll.GetTotalUsers();

                lblDonorsValue.Text = totalDonors.ToString();
                lblUsersValue.Text = totalUsers.ToString();

                // Таблица по группам
                var dtStats = _bll.GetBloodGroupStats();
                dgvGroupStats.DataSource = dtStats;

                lblGroupsValue.Text = dtStats.Rows.Count.ToString();

                if (dgvGroupStats.Columns.Count > 0)
                {
                    dgvGroupStats.Columns["BloodGroup"].HeaderText = "Группа крови";
                    dgvGroupStats.Columns["DonorCount"].HeaderText = "Количество доноров";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки статистики: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}