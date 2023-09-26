namespace CRUD_Forms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.IdTb = new System.Windows.Forms.TextBox();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CpfTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UpTb = new System.Windows.Forms.Button();
            this.AddBt = new System.Windows.Forms.Button();
            this.RemoveTb = new System.Windows.Forms.Button();
            this.nameRequired = new System.Windows.Forms.Label();
            this.cpfRequired = new System.Windows.Forms.Label();
            this.verifyBtn = new System.Windows.Forms.Button();
            this.labStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.returnUE = new System.Windows.Forms.Label();
            this.returnId = new System.Windows.Forms.Label();
            this.returnLb = new System.Windows.Forms.Label();
            this.LeaveButton = new System.Windows.Forms.Button();
            this.IndexButton = new System.Windows.Forms.Button();
            this.indexResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv.Location = new System.Drawing.Point(12, 229);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(599, 121);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            // 
            // IdTb
            // 
            this.IdTb.Location = new System.Drawing.Point(16, 32);
            this.IdTb.Name = "IdTb";
            this.IdTb.Size = new System.Drawing.Size(196, 20);
            this.IdTb.TabIndex = 2;
            // 
            // NameTb
            // 
            this.NameTb.Location = new System.Drawing.Point(16, 93);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(196, 20);
            this.NameTb.TabIndex = 4;
            this.NameTb.Text = "Nicolas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // CpfTb
            // 
            this.CpfTb.Location = new System.Drawing.Point(16, 167);
            this.CpfTb.Name = "CpfTb";
            this.CpfTb.Size = new System.Drawing.Size(196, 20);
            this.CpfTb.TabIndex = 6;
            this.CpfTb.Text = "999.999.999-99";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "CPF";
            // 
            // UpTb
            // 
            this.UpTb.Enabled = false;
            this.UpTb.Location = new System.Drawing.Point(238, 124);
            this.UpTb.Name = "UpTb";
            this.UpTb.Size = new System.Drawing.Size(124, 25);
            this.UpTb.TabIndex = 7;
            this.UpTb.Text = "Edit";
            this.UpTb.UseVisualStyleBackColor = true;
            this.UpTb.Click += new System.EventHandler(this.UpTb_Click);
            // 
            // AddBt
            // 
            this.AddBt.Location = new System.Drawing.Point(238, 61);
            this.AddBt.Name = "AddBt";
            this.AddBt.Size = new System.Drawing.Size(124, 25);
            this.AddBt.TabIndex = 8;
            this.AddBt.Text = "Add";
            this.AddBt.UseVisualStyleBackColor = true;
            this.AddBt.Click += new System.EventHandler(this.AddBt_Click);
            // 
            // RemoveTb
            // 
            this.RemoveTb.Location = new System.Drawing.Point(238, 93);
            this.RemoveTb.Name = "RemoveTb";
            this.RemoveTb.Size = new System.Drawing.Size(124, 25);
            this.RemoveTb.TabIndex = 9;
            this.RemoveTb.Text = "Remove";
            this.RemoveTb.UseVisualStyleBackColor = true;
            this.RemoveTb.Click += new System.EventHandler(this.RemoveTb_Click);
            // 
            // nameRequired
            // 
            this.nameRequired.AutoSize = true;
            this.nameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameRequired.ForeColor = System.Drawing.Color.Red;
            this.nameRequired.Location = new System.Drawing.Point(13, 118);
            this.nameRequired.Name = "nameRequired";
            this.nameRequired.Size = new System.Drawing.Size(94, 13);
            this.nameRequired.TabIndex = 10;
            this.nameRequired.Text = "Name Required";
            this.nameRequired.Visible = false;
            // 
            // cpfRequired
            // 
            this.cpfRequired.AutoSize = true;
            this.cpfRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpfRequired.ForeColor = System.Drawing.Color.Red;
            this.cpfRequired.Location = new System.Drawing.Point(13, 192);
            this.cpfRequired.Name = "cpfRequired";
            this.cpfRequired.Size = new System.Drawing.Size(85, 13);
            this.cpfRequired.TabIndex = 11;
            this.cpfRequired.Text = "CPF Required";
            this.cpfRequired.Visible = false;
            // 
            // verifyBtn
            // 
            this.verifyBtn.FlatAppearance.BorderSize = 2;
            this.verifyBtn.Location = new System.Drawing.Point(238, 28);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(124, 25);
            this.verifyBtn.TabIndex = 15;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.UseVisualStyleBackColor = true;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(13, 353);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(0, 14);
            this.labStatus.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.returnUE);
            this.groupBox1.Controls.Add(this.returnId);
            this.groupBox1.Controls.Add(this.returnLb);
            this.groupBox1.Location = new System.Drawing.Point(387, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 121);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verify Result";
            // 
            // returnUE
            // 
            this.returnUE.AutoSize = true;
            this.returnUE.Location = new System.Drawing.Point(7, 86);
            this.returnUE.Name = "returnUE";
            this.returnUE.Size = new System.Drawing.Size(84, 14);
            this.returnUE.TabIndex = 2;
            this.returnUE.Text = "User Expected: ";
            // 
            // returnId
            // 
            this.returnId.AutoSize = true;
            this.returnId.Location = new System.Drawing.Point(6, 56);
            this.returnId.Name = "returnId";
            this.returnId.Size = new System.Drawing.Size(21, 14);
            this.returnId.TabIndex = 1;
            this.returnId.Text = "Id: ";
            // 
            // returnLb
            // 
            this.returnLb.AutoSize = true;
            this.returnLb.Location = new System.Drawing.Point(7, 25);
            this.returnLb.Name = "returnLb";
            this.returnLb.Size = new System.Drawing.Size(45, 14);
            this.returnLb.TabIndex = 0;
            this.returnLb.Text = "Return: ";
            // 
            // LeaveButton
            // 
            this.LeaveButton.Location = new System.Drawing.Point(238, 155);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(124, 25);
            this.LeaveButton.TabIndex = 19;
            this.LeaveButton.Text = "Leave";
            this.LeaveButton.UseVisualStyleBackColor = true;
            this.LeaveButton.Visible = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // IndexButton
            // 
            this.IndexButton.Location = new System.Drawing.Point(387, 155);
            this.IndexButton.Name = "IndexButton";
            this.IndexButton.Size = new System.Drawing.Size(124, 25);
            this.IndexButton.TabIndex = 20;
            this.IndexButton.Text = "Index Search";
            this.IndexButton.UseVisualStyleBackColor = true;
            this.IndexButton.Click += new System.EventHandler(this.IndexButton_Click);
            // 
            // indexResult
            // 
            this.indexResult.AutoSize = true;
            this.indexResult.Location = new System.Drawing.Point(387, 192);
            this.indexResult.Name = "indexResult";
            this.indexResult.Size = new System.Drawing.Size(0, 14);
            this.indexResult.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 359);
            this.Controls.Add(this.indexResult);
            this.Controls.Add(this.IndexButton);
            this.Controls.Add(this.LeaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.verifyBtn);
            this.Controls.Add(this.cpfRequired);
            this.Controls.Add(this.nameRequired);
            this.Controls.Add(this.RemoveTb);
            this.Controls.Add(this.AddBt);
            this.Controls.Add(this.UpTb);
            this.Controls.Add(this.CpfTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dgv);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IdTb;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CpfTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UpTb;
        private System.Windows.Forms.Button AddBt;
        private System.Windows.Forms.Button RemoveTb;
        private System.Windows.Forms.Label nameRequired;
        private System.Windows.Forms.Label cpfRequired;
        private System.Windows.Forms.Button verifyBtn;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label returnLb;
        private System.Windows.Forms.Label returnUE;
        private System.Windows.Forms.Label returnId;
        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.Button IndexButton;
        private System.Windows.Forms.Label indexResult;
    }
}

