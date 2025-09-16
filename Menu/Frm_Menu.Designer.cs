namespace Menu
{
    partial class Frm_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Menu));
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_halloffame = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.Yellow;
            this.btn_play.Location = new System.Drawing.Point(12, 468);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(93, 23);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "PLAY";
            this.btn_play.UseVisualStyleBackColor = false;
            // 
            // btn_setting
            // 
            this.btn_setting.BackColor = System.Drawing.Color.Yellow;
            this.btn_setting.Location = new System.Drawing.Point(155, 468);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(93, 23);
            this.btn_setting.TabIndex = 1;
            this.btn_setting.Text = "SETTING";
            this.btn_setting.UseVisualStyleBackColor = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_halloffame
            // 
            this.btn_halloffame.BackColor = System.Drawing.Color.Yellow;
            this.btn_halloffame.Location = new System.Drawing.Point(271, 468);
            this.btn_halloffame.Name = "btn_halloffame";
            this.btn_halloffame.Size = new System.Drawing.Size(145, 23);
            this.btn_halloffame.TabIndex = 2;
            this.btn_halloffame.Text = "HALL OF FAME";
            this.btn_halloffame.UseVisualStyleBackColor = false;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Yellow;
            this.btn_exit.Location = new System.Drawing.Point(433, 468);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(99, 23);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(544, 603);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_halloffame);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.btn_play);
            this.Name = "Frm_Menu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_halloffame;
        private System.Windows.Forms.Button btn_exit;
    }
}

