namespace BloodBank.UI
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelGroups = new System.Windows.Forms.Panel();
            this.lblGroupsValue = new System.Windows.Forms.Label();
            this.lblGroupsLabel = new System.Windows.Forms.Label();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.lblUsersValue = new System.Windows.Forms.Label();
            this.lblUsersLabel = new System.Windows.Forms.Label();
            this.panelDonors = new System.Windows.Forms.Panel();
            this.lblDonorsValue = new System.Windows.Forms.Label();
            this.lblDonorsLabel = new System.Windows.Forms.Label();
            this.lblGroupStats = new System.Windows.Forms.Label();
            this.dgvGroupStats = new System.Windows.Forms.DataGridView();
            this.panelStats.SuspendLayout();
            this.panelGroups.SuspendLayout();
            this.panelUsers.SuspendLayout();
            this.panelDonors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupStats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(27, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(311, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Панель управления";
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.panelGroups);
            this.panelStats.Controls.Add(this.panelUsers);
            this.panelStats.Controls.Add(this.panelDonors);
            this.panelStats.Location = new System.Drawing.Point(27, 74);
            this.panelStats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1413, 160);
            this.panelStats.TabIndex = 1;
            // 
            // panelGroups
            // 
            this.panelGroups.BackColor = System.Drawing.Color.SeaGreen;
            this.panelGroups.Controls.Add(this.lblGroupsValue);
            this.panelGroups.Controls.Add(this.lblGroupsLabel);
            this.panelGroups.Location = new System.Drawing.Point(960, 0);
            this.panelGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(453, 160);
            this.panelGroups.TabIndex = 2;
            // 
            // lblGroupsValue
            // 
            this.lblGroupsValue.AutoSize = true;
            this.lblGroupsValue.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold);
            this.lblGroupsValue.ForeColor = System.Drawing.Color.White;
            this.lblGroupsValue.Location = new System.Drawing.Point(33, 25);
            this.lblGroupsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupsValue.Name = "lblGroupsValue";
            this.lblGroupsValue.Size = new System.Drawing.Size(70, 78);
            this.lblGroupsValue.TabIndex = 0;
            this.lblGroupsValue.Text = "0";
            // 
            // lblGroupsLabel
            // 
            this.lblGroupsLabel.AutoSize = true;
            this.lblGroupsLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.lblGroupsLabel.ForeColor = System.Drawing.Color.White;
            this.lblGroupsLabel.Location = new System.Drawing.Point(40, 111);
            this.lblGroupsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupsLabel.Name = "lblGroupsLabel";
            this.lblGroupsLabel.Size = new System.Drawing.Size(147, 27);
            this.lblGroupsLabel.TabIndex = 1;
            this.lblGroupsLabel.Text = "Групп крови";
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.SteelBlue;
            this.panelUsers.Controls.Add(this.lblUsersValue);
            this.panelUsers.Controls.Add(this.lblUsersLabel);
            this.panelUsers.Location = new System.Drawing.Point(480, 0);
            this.panelUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(453, 160);
            this.panelUsers.TabIndex = 1;
            // 
            // lblUsersValue
            // 
            this.lblUsersValue.AutoSize = true;
            this.lblUsersValue.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold);
            this.lblUsersValue.ForeColor = System.Drawing.Color.White;
            this.lblUsersValue.Location = new System.Drawing.Point(33, 25);
            this.lblUsersValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsersValue.Name = "lblUsersValue";
            this.lblUsersValue.Size = new System.Drawing.Size(70, 78);
            this.lblUsersValue.TabIndex = 0;
            this.lblUsersValue.Text = "0";
            // 
            // lblUsersLabel
            // 
            this.lblUsersLabel.AutoSize = true;
            this.lblUsersLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.lblUsersLabel.ForeColor = System.Drawing.Color.White;
            this.lblUsersLabel.Location = new System.Drawing.Point(40, 111);
            this.lblUsersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsersLabel.Name = "lblUsersLabel";
            this.lblUsersLabel.Size = new System.Drawing.Size(180, 27);
            this.lblUsersLabel.TabIndex = 1;
            this.lblUsersLabel.Text = "Пользователей";
            // 
            // panelDonors
            // 
            this.panelDonors.BackColor = System.Drawing.Color.Firebrick;
            this.panelDonors.Controls.Add(this.lblDonorsValue);
            this.panelDonors.Controls.Add(this.lblDonorsLabel);
            this.panelDonors.Location = new System.Drawing.Point(0, 0);
            this.panelDonors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelDonors.Name = "panelDonors";
            this.panelDonors.Size = new System.Drawing.Size(453, 160);
            this.panelDonors.TabIndex = 0;
            // 
            // lblDonorsValue
            // 
            this.lblDonorsValue.AutoSize = true;
            this.lblDonorsValue.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold);
            this.lblDonorsValue.ForeColor = System.Drawing.Color.White;
            this.lblDonorsValue.Location = new System.Drawing.Point(33, 25);
            this.lblDonorsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonorsValue.Name = "lblDonorsValue";
            this.lblDonorsValue.Size = new System.Drawing.Size(70, 78);
            this.lblDonorsValue.TabIndex = 0;
            this.lblDonorsValue.Text = "0";
            // 
            // lblDonorsLabel
            // 
            this.lblDonorsLabel.AutoSize = true;
            this.lblDonorsLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.lblDonorsLabel.ForeColor = System.Drawing.Color.White;
            this.lblDonorsLabel.Location = new System.Drawing.Point(40, 111);
            this.lblDonorsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonorsLabel.Name = "lblDonorsLabel";
            this.lblDonorsLabel.Size = new System.Drawing.Size(107, 27);
            this.lblDonorsLabel.TabIndex = 1;
            this.lblDonorsLabel.Text = "Доноров";
            // 
            // lblGroupStats
            // 
            this.lblGroupStats.AutoSize = true;
            this.lblGroupStats.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblGroupStats.ForeColor = System.Drawing.Color.Firebrick;
            this.lblGroupStats.Location = new System.Drawing.Point(27, 258);
            this.lblGroupStats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupStats.Name = "lblGroupStats";
            this.lblGroupStats.Size = new System.Drawing.Size(334, 29);
            this.lblGroupStats.TabIndex = 2;
            this.lblGroupStats.Text = "Доноры по группам крови";
            // 
            // dgvGroupStats
            // 
            this.dgvGroupStats.AllowUserToAddRows = false;
            this.dgvGroupStats.AllowUserToDeleteRows = false;
            this.dgvGroupStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupStats.Location = new System.Drawing.Point(27, 302);
            this.dgvGroupStats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGroupStats.Name = "dgvGroupStats";
            this.dgvGroupStats.ReadOnly = true;
            this.dgvGroupStats.RowHeadersWidth = 51;
            this.dgvGroupStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupStats.Size = new System.Drawing.Size(1413, 468);
            this.dgvGroupStats.TabIndex = 3;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1467, 788);
            this.Controls.Add(this.dgvGroupStats);
            this.Controls.Add(this.lblGroupStats);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDashboard";
            this.Text = "Панель управления";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panelStats.ResumeLayout(false);
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            this.panelDonors.ResumeLayout(false);
            this.panelDonors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelDonors;
        private System.Windows.Forms.Label lblDonorsValue;
        private System.Windows.Forms.Label lblDonorsLabel;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label lblUsersValue;
        private System.Windows.Forms.Label lblUsersLabel;
        private System.Windows.Forms.Panel panelGroups;
        private System.Windows.Forms.Label lblGroupsValue;
        private System.Windows.Forms.Label lblGroupsLabel;
        private System.Windows.Forms.Label lblGroupStats;
        private System.Windows.Forms.DataGridView dgvGroupStats;
    }
}