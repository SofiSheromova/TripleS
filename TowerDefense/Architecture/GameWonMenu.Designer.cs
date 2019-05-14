namespace TowerDefense.Architecture
{
    partial class GameWonMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWonMenu));
            this.MainMenu = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.LavenderBlush;
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainMenu.Font = new System.Drawing.Font("NSimSun", 10.8F, System.Drawing.FontStyle.Bold);
            this.MainMenu.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainMenu.Location = new System.Drawing.Point(133, 193);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(120, 39);
            this.MainMenu.TabIndex = 7;
            this.MainMenu.Text = "Main menu";
            this.MainMenu.UseVisualStyleBackColor = false;
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.LavenderBlush;
            this.Restart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Restart.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Restart.Font = new System.Drawing.Font("NSimSun", 10.8F, System.Drawing.FontStyle.Bold);
            this.Restart.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Restart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Restart.Location = new System.Drawing.Point(133, 148);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(120, 39);
            this.Restart.TabIndex = 6;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palace Script MT", 36F, System.Drawing.FontStyle.Italic);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(102, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 56);
            this.label1.TabIndex = 5;
            this.label1.Text = "You Won!!";
            // 
            // GameWonMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TowerDefense.Properties.Resources.original;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWonMenu";
            this.Text = "GameWonMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MainMenu;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Label label1;
    }
}