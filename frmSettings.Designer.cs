namespace Car_Wash
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvVehicaleType = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicaleTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditVT = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDeleteVT = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvCostOfGood = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditCoG = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDeleteCoG = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddCostOfGood = new System.Windows.Forms.Button();
            this.txtSearchCoG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicaleType)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostOfGood)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 36);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(949, 402);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.dgvVehicaleType);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(941, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vehicale Type ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(935, 86);
            this.panel2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(871, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 30);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search";
            // 
            // dgvVehicaleType
            // 
            this.dgvVehicaleType.AllowUserToAddRows = false;
            this.dgvVehicaleType.AllowUserToDeleteRows = false;
            this.dgvVehicaleType.AllowUserToResizeColumns = false;
            this.dgvVehicaleType.AllowUserToResizeRows = false;
            this.dgvVehicaleType.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehicaleType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicaleType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehicaleType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicaleType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.VehicaleTypeID,
            this.Column3,
            this.Column4,
            this.btnEditVT,
            this.btnDeleteVT});
            this.dgvVehicaleType.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvVehicaleType.EnableHeadersVisualStyles = false;
            this.dgvVehicaleType.Location = new System.Drawing.Point(3, 3);
            this.dgvVehicaleType.Name = "dgvVehicaleType";
            this.dgvVehicaleType.RowHeadersVisible = false;
            this.dgvVehicaleType.RowHeadersWidth = 51;
            this.dgvVehicaleType.RowTemplate.Height = 26;
            this.dgvVehicaleType.Size = new System.Drawing.Size(935, 285);
            this.dgvVehicaleType.TabIndex = 4;
            this.dgvVehicaleType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicaleType_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "No";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 62;
            // 
            // VehicaleTypeID
            // 
            this.VehicaleTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VehicaleTypeID.DataPropertyName = "VehicaleTypeID";
            this.VehicaleTypeID.HeaderText = "Id";
            this.VehicaleTypeID.MinimumWidth = 6;
            this.VehicaleTypeID.Name = "VehicaleTypeID";
            this.VehicaleTypeID.Width = 54;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "Class";
            this.Column4.HeaderText = "Level";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 83;
            // 
            // btnEditVT
            // 
            this.btnEditVT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnEditVT.HeaderText = "";
            this.btnEditVT.Image = ((System.Drawing.Image)(resources.GetObject("btnEditVT.Image")));
            this.btnEditVT.MinimumWidth = 6;
            this.btnEditVT.Name = "btnEditVT";
            this.btnEditVT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEditVT.Width = 6;
            // 
            // btnDeleteVT
            // 
            this.btnDeleteVT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnDeleteVT.HeaderText = "";
            this.btnDeleteVT.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteVT.Image")));
            this.btnDeleteVT.MinimumWidth = 6;
            this.btnDeleteVT.Name = "btnDeleteVT";
            this.btnDeleteVT.Width = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvCostOfGood);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(941, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cost of Good Sold";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCostOfGood
            // 
            this.dgvCostOfGood.AllowUserToAddRows = false;
            this.dgvCostOfGood.AllowUserToDeleteRows = false;
            this.dgvCostOfGood.AllowUserToResizeColumns = false;
            this.dgvCostOfGood.AllowUserToResizeRows = false;
            this.dgvCostOfGood.BackgroundColor = System.Drawing.Color.White;
            this.dgvCostOfGood.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCostOfGood.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCostOfGood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostOfGood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.CostID,
            this.CostName,
            this.Cost,
            this.CostDate,
            this.btnEditCoG,
            this.btnDeleteCoG});
            this.dgvCostOfGood.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCostOfGood.EnableHeadersVisualStyles = false;
            this.dgvCostOfGood.Location = new System.Drawing.Point(3, 3);
            this.dgvCostOfGood.Name = "dgvCostOfGood";
            this.dgvCostOfGood.RowHeadersVisible = false;
            this.dgvCostOfGood.RowHeadersWidth = 51;
            this.dgvCostOfGood.RowTemplate.Height = 26;
            this.dgvCostOfGood.Size = new System.Drawing.Size(935, 285);
            this.dgvCostOfGood.TabIndex = 6;
            this.dgvCostOfGood.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostOfGood_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 62;
            // 
            // CostID
            // 
            this.CostID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CostID.DataPropertyName = "CostID";
            this.CostID.HeaderText = "Id";
            this.CostID.MinimumWidth = 6;
            this.CostID.Name = "CostID";
            this.CostID.Width = 54;
            // 
            // CostName
            // 
            this.CostName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CostName.DataPropertyName = "CostName";
            this.CostName.HeaderText = "Name";
            this.CostName.MinimumWidth = 6;
            this.CostName.Name = "CostName";
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cost.HeaderText = "Cost";
            this.Cost.MinimumWidth = 6;
            this.Cost.Name = "Cost";
            this.Cost.Width = 78;
            // 
            // CostDate
            // 
            this.CostDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CostDate.DataPropertyName = "CostDate";
            this.CostDate.HeaderText = "Date";
            this.CostDate.MinimumWidth = 6;
            this.CostDate.Name = "CostDate";
            this.CostDate.Width = 81;
            // 
            // btnEditCoG
            // 
            this.btnEditCoG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnEditCoG.HeaderText = "";
            this.btnEditCoG.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCoG.Image")));
            this.btnEditCoG.MinimumWidth = 6;
            this.btnEditCoG.Name = "btnEditCoG";
            this.btnEditCoG.Width = 6;
            // 
            // btnDeleteCoG
            // 
            this.btnDeleteCoG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnDeleteCoG.HeaderText = "";
            this.btnDeleteCoG.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCoG.Image")));
            this.btnDeleteCoG.MinimumWidth = 6;
            this.btnDeleteCoG.Name = "btnDeleteCoG";
            this.btnDeleteCoG.Width = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.btnAddCostOfGood);
            this.panel3.Controls.Add(this.txtSearchCoG);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(935, 86);
            this.panel3.TabIndex = 5;
            // 
            // btnAddCostOfGood
            // 
            this.btnAddCostOfGood.FlatAppearance.BorderSize = 0;
            this.btnAddCostOfGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCostOfGood.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCostOfGood.Image")));
            this.btnAddCostOfGood.Location = new System.Drawing.Point(860, 19);
            this.btnAddCostOfGood.Name = "btnAddCostOfGood";
            this.btnAddCostOfGood.Size = new System.Drawing.Size(50, 50);
            this.btnAddCostOfGood.TabIndex = 3;
            this.btnAddCostOfGood.UseVisualStyleBackColor = true;
            this.btnAddCostOfGood.Click += new System.EventHandler(this.btnAddCostOfGood_Click);
            // 
            // txtSearchCoG
            // 
            this.txtSearchCoG.Location = new System.Drawing.Point(90, 29);
            this.txtSearchCoG.Name = "txtSearchCoG";
            this.txtSearchCoG.Size = new System.Drawing.Size(200, 30);
            this.txtSearchCoG.TabIndex = 1;
            this.txtSearchCoG.TextChanged += new System.EventHandler(this.txtSearchCoG_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtCompanyAddress);
            this.tabPage3.Controls.Add(this.txtCompanyName);
            this.tabPage3.Controls.Add(this.btnCancel);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(941, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Company Name";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(303, 145);
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(410, 30);
            this.txtCompanyAddress.TabIndex = 8;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(303, 81);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(410, 30);
            this.txtCompanyName.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(551, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 49);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(303, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 49);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Company Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company Name:";
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(949, 438);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicaleType)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostOfGood)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvVehicaleType;
        private System.Windows.Forms.DataGridView dgvCostOfGood;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddCostOfGood;
        private System.Windows.Forms.TextBox txtSearchCoG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostDate;
        private System.Windows.Forms.DataGridViewImageColumn btnEditCoG;
        private System.Windows.Forms.DataGridViewImageColumn btnDeleteCoG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicaleTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn btnEditVT;
        private System.Windows.Forms.DataGridViewImageColumn btnDeleteVT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}