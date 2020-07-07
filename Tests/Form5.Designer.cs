namespace Tests
{
    partial class Form5
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button_again = new System.Windows.Forms.Button();
            this.button_statistic = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1797, 727);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 815);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Верных ответов: ";
            // 
            // button_again
            // 
            this.button_again.Location = new System.Drawing.Point(1614, 760);
            this.button_again.Name = "button_again";
            this.button_again.Size = new System.Drawing.Size(195, 84);
            this.button_again.TabIndex = 2;
            this.button_again.Text = "Начать заново";
            this.button_again.UseVisualStyleBackColor = true;
            this.button_again.Click += new System.EventHandler(this.button_again_Click);
            // 
            // button_statistic
            // 
            this.button_statistic.Location = new System.Drawing.Point(1413, 760);
            this.button_statistic.Name = "button_statistic";
            this.button_statistic.Size = new System.Drawing.Size(195, 84);
            this.button_statistic.TabIndex = 3;
            this.button_statistic.Text = "Статистика";
            this.button_statistic.UseVisualStyleBackColor = true;
            this.button_statistic.Click += new System.EventHandler(this.button_statistic_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.username.Location = new System.Drawing.Point(12, 760);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(189, 29);
            this.username.TabIndex = 29;
            this.username.Text = "Проходил тест:";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1821, 853);
            this.Controls.Add(this.username);
            this.Controls.Add(this.button_statistic);
            this.Controls.Add(this.button_again);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form5_FormClosed);
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_again;
        private System.Windows.Forms.Button button_statistic;
        private System.Windows.Forms.Label username;
    }
}