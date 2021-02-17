namespace Test1
{
    partial class Menu
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
            this.ButtonExit = new System.Windows.Forms.Button();
            this.startGame = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.setting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonExit
            // 
            this.ButtonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.ButtonExit.Location = new System.Drawing.Point(312, 301);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(117, 61);
            this.ButtonExit.TabIndex = 12;
            this.ButtonExit.Text = "Esci";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // startGame
            // 
            this.startGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.startGame.Location = new System.Drawing.Point(247, 73);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(246, 57);
            this.startGame.TabIndex = 11;
            this.startGame.Text = "Inizia Simulazione";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // help
            // 
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.help.Location = new System.Drawing.Point(247, 150);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(246, 56);
            this.help.TabIndex = 13;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // setting
            // 
            this.setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.setting.Location = new System.Drawing.Point(247, 223);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(246, 55);
            this.setting.TabIndex = 14;
            this.setting.Text = "Impostazioni";
            this.setting.UseVisualStyleBackColor = true;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 516);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.help);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.startGame);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button setting;
    }
}