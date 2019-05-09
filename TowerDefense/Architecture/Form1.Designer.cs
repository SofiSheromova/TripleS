namespace TowerDefense.Architecture
{
    partial class GameOverWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.Restart = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.LavenderBlush;
            resources.ApplyResources(this.Restart, "Restart");
            this.Restart.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Restart.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Restart.Name = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.LavenderBlush;
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainMenu.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.UseVisualStyleBackColor = false;
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // GameOverWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TowerDefense.Properties.Resources.original;
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.label1);
            this.Name = "GameOverWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button MainMenu;
    }
}