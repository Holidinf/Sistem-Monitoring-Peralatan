namespace Mission3.View
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.lblAddSensorDevice = new System.Windows.Forms.LinkLabel();
            this.tmrSaveData = new System.Windows.Forms.Timer(this.components);
            this.lblSensorDataHistory = new System.Windows.Forms.LinkLabel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.AllowUserToDeleteRows = false;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvDevice.Location = new System.Drawing.Point(12, 12);
            this.dgvDevice.MultiSelect = false;
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            this.dgvDevice.RowTemplate.Height = 23;
            this.dgvDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevice.Size = new System.Drawing.Size(334, 197);
            this.dgvDevice.TabIndex = 0;
            // 
            // lblAddSensorDevice
            // 
            this.lblAddSensorDevice.AutoSize = true;
            this.lblAddSensorDevice.Location = new System.Drawing.Point(355, 23);
            this.lblAddSensorDevice.Name = "lblAddSensorDevice";
            this.lblAddSensorDevice.Size = new System.Drawing.Size(85, 12);
            this.lblAddSensorDevice.TabIndex = 1;
            this.lblAddSensorDevice.TabStop = true;
            this.lblAddSensorDevice.Text = "Tambahkan perangkat sensor";
            this.lblAddSensorDevice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddSensorDevice_LinkClicked);
            // 
            // tmrSaveData
            // 
            this.tmrSaveData.Enabled = true;
            this.tmrSaveData.Interval = 5000;
            this.tmrSaveData.Tick += new System.EventHandler(this.tmrSaveData_Tick);
            // 
            // lblSensorDataHistory
            // 
            this.lblSensorDataHistory.AutoSize = true;
            this.lblSensorDataHistory.Location = new System.Drawing.Point(355, 50);
            this.lblSensorDataHistory.Name = "lblSensorDataHistory";
            this.lblSensorDataHistory.Size = new System.Drawing.Size(85, 12);
            this.lblSensorDataHistory.TabIndex = 2;
            this.lblSensorDataHistory.TabStop = true;
            this.lblSensorDataHistory.Text = "Daftar informasi sensor";
            this.lblSensorDataHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSensorDataHistory_LinkClicked);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DeviceId";
            this.Column1.HeaderText = "ID perangkat sensor";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CurrentTemperature";
            dataGridViewCellStyle3.Format = "N1";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.FillWeight = 80F;
            this.Column2.HeaderText = "Suhu saat ini";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CurrentHumidity";
            dataGridViewCellStyle4.Format = "N1";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "Kelembapan saat ini";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 220);
            this.Controls.Add(this.lblSensorDataHistory);
            this.Controls.Add(this.lblAddSensorDevice);
            this.Controls.Add(this.dgvDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem monitoring suhu dan kelembapan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.LinkLabel lblAddSensorDevice;
        private System.Windows.Forms.Timer tmrSaveData;
        private System.Windows.Forms.LinkLabel lblSensorDataHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}