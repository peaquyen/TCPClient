namespace Menu
{
    partial class Frm_HallOfFame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HallOfFame));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_halloffame = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(471, 257);
            this.dataGridView1.TabIndex = 0;
            // 
            // lb_halloffame
            // 
            this.lb_halloffame.AutoSize = true;
            this.lb_halloffame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_halloffame.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_halloffame.ForeColor = System.Drawing.Color.Yellow;
            this.lb_halloffame.Location = new System.Drawing.Point(67, 28);
            this.lb_halloffame.Name = "lb_halloffame";
            this.lb_halloffame.Size = new System.Drawing.Size(300, 42);
            this.lb_halloffame.TabIndex = 1;
            this.lb_halloffame.Text = "HALL OF FAME";
            //this.lb_halloffame.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(418, 336);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "BACK";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // Frm_HallOfFame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(496, 362);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lb_halloffame);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm_HallOfFame";
            this.Text = "Frm_HallOfFame";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_halloffame;
        private System.Windows.Forms.Button btn_back;
    }
}