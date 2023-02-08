namespace TestDrive
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.DeleteDriver = new System.Windows.Forms.Button();
            this.UpdateDriver = new System.Windows.Forms.Button();
            this.AddDriver = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label999 = new System.Windows.Forms.Label();
            this.DriverID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TLF = new System.Windows.Forms.TextBox();
            this.CPRNR = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 103);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(14, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(948, 97);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.label1.Location = new System.Drawing.Point(194, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver Management";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(12, 132);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(974, 348);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.Exit);
            this.panel5.Controls.Add(this.DeleteDriver);
            this.panel5.Controls.Add(this.UpdateDriver);
            this.panel5.Controls.Add(this.AddDriver);
            this.panel5.Location = new System.Drawing.Point(735, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(227, 319);
            this.panel5.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Exit.Location = new System.Drawing.Point(26, 257);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(179, 30);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Main Menu";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // DeleteDriver
            // 
            this.DeleteDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DeleteDriver.Location = new System.Drawing.Point(26, 194);
            this.DeleteDriver.Name = "DeleteDriver";
            this.DeleteDriver.Size = new System.Drawing.Size(179, 30);
            this.DeleteDriver.TabIndex = 2;
            this.DeleteDriver.Text = "Delete Driver";
            this.DeleteDriver.UseVisualStyleBackColor = true;
            this.DeleteDriver.Click += new System.EventHandler(this.DeleteDriver_Click);
            // 
            // UpdateDriver
            // 
            this.UpdateDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateDriver.Location = new System.Drawing.Point(26, 82);
            this.UpdateDriver.Name = "UpdateDriver";
            this.UpdateDriver.Size = new System.Drawing.Size(179, 28);
            this.UpdateDriver.TabIndex = 1;
            this.UpdateDriver.Text = "Update Driver";
            this.UpdateDriver.UseVisualStyleBackColor = true;
            this.UpdateDriver.Click += new System.EventHandler(this.UpdateDriver_Click);
            // 
            // AddDriver
            // 
            this.AddDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddDriver.Location = new System.Drawing.Point(26, 15);
            this.AddDriver.Name = "AddDriver";
            this.AddDriver.Size = new System.Drawing.Size(179, 30);
            this.AddDriver.TabIndex = 0;
            this.AddDriver.Text = "Add Driver";
            this.AddDriver.UseVisualStyleBackColor = true;
            this.AddDriver.Click += new System.EventHandler(this.AddDriver_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.label999);
            this.panel4.Controls.Add(this.DriverID);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.TLF);
            this.panel4.Controls.Add(this.CPRNR);
            this.panel4.Controls.Add(this.Name);
            this.panel4.Location = new System.Drawing.Point(14, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(715, 319);
            this.panel4.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(436, 93);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // label999
            // 
            this.label999.AutoSize = true;
            this.label999.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label999.Location = new System.Drawing.Point(29, 12);
            this.label999.Name = "label999";
            this.label999.Size = new System.Drawing.Size(67, 20);
            this.label999.TabIndex = 7;
            this.label999.Text = "DriverID";
            // 
            // DriverID
            // 
            this.DriverID.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.DriverID.Location = new System.Drawing.Point(151, 12);
            this.DriverID.Name = "DriverID";
            this.DriverID.ReadOnly = true;
            this.DriverID.Size = new System.Drawing.Size(73, 20);
            this.DriverID.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(29, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "TLF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(29, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPR NR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // TLF
            // 
            this.TLF.Location = new System.Drawing.Point(151, 157);
            this.TLF.Name = "TLF";
            this.TLF.Size = new System.Drawing.Size(159, 20);
            this.TLF.TabIndex = 2;
            // 
            // CPRNR
            // 
            this.CPRNR.Location = new System.Drawing.Point(151, 105);
            this.CPRNR.Name = "CPRNR";
            this.CPRNR.Size = new System.Drawing.Size(159, 20);
            this.CPRNR.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(151, 58);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(159, 20);
            this.Name.TabIndex = 0;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(26, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 492);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Text = "Driver Management";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button DeleteDriver;
        private System.Windows.Forms.Button UpdateDriver;
        private System.Windows.Forms.Button AddDriver;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox TLF;
        private System.Windows.Forms.TextBox CPRNR;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DriverID;
        private System.Windows.Forms.Label label999;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button1;
    }
}