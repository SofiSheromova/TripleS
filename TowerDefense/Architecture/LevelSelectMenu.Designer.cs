namespace TowerDefense.Architecture
{
    partial class LevelSelectMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelSelectMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Level1 = new System.Windows.Forms.Button();
            this.Level2 = new System.Windows.Forms.Button();
            this.Level3 = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::TowerDefense.Properties.Resources.castle;
            this.pictureBox1.Location = new System.Drawing.Point(2, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 281);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Level1
            // 
            this.Level1.BackColor = System.Drawing.Color.LavenderBlush;
            this.Level1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Level1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Level1.Font = new System.Drawing.Font("NSimSun", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Level1.Location = new System.Drawing.Point(129, 122);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(120, 39);
            this.Level1.TabIndex = 4;
            this.Level1.Text = "Level 1";
            this.Level1.UseVisualStyleBackColor = false;
            this.Level1.Click += new System.EventHandler(this.Start_Click);
            // 
            // Level2
            // 
            this.Level2.BackColor = System.Drawing.Color.LavenderBlush;
            this.Level2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Level2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Level2.Font = new System.Drawing.Font("NSimSun", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Level2.Location = new System.Drawing.Point(129, 167);
            this.Level2.Name = "Level2";
            this.Level2.Size = new System.Drawing.Size(120, 39);
            this.Level2.TabIndex = 5;
            this.Level2.Text = "Level 2";
            this.Level2.UseVisualStyleBackColor = false;
            this.Level2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Level3
            // 
            this.Level3.BackColor = System.Drawing.Color.LavenderBlush;
            this.Level3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Level3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Level3.Font = new System.Drawing.Font("NSimSun", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Level3.Location = new System.Drawing.Point(129, 212);
            this.Level3.Name = "Level3";
            this.Level3.Size = new System.Drawing.Size(120, 39);
            this.Level3.TabIndex = 6;
            this.Level3.Text = "Level 3";
            this.Level3.UseVisualStyleBackColor = false;
            this.Level3.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.LavenderBlush;
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Back.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Back.Font = new System.Drawing.Font("NSimSun", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Back.Location = new System.Drawing.Point(129, 257);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(120, 39);
            this.Back.TabIndex = 7;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Button3_Click);
            // 
            // LevelSelectMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TowerDefense.Properties.Resources.original;
            this.ClientSize = new System.Drawing.Size(372, 453);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Level3);
            this.Controls.Add(this.Level2);
            this.Controls.Add(this.Level1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LevelSelectMenu";
            this.Text = "LevelSelectMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Level1;
        private System.Windows.Forms.Button Level2;
        private System.Windows.Forms.Button Level3;
        private System.Windows.Forms.Button Back;
    }
}