
namespace WinFormRoleGuest
{
    partial class ChangePasswordForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.NewPasswordField = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.FirstNameField = new System.Windows.Forms.TextBox();
            this.EmailField = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MainPanel.Controls.Add(this.NewPasswordField);
            this.MainPanel.Controls.Add(this.buttonLogin);
            this.MainPanel.Controls.Add(this.FirstNameField);
            this.MainPanel.Controls.Add(this.EmailField);
            this.MainPanel.Controls.Add(this.panel2);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(510, 479);
            this.MainPanel.TabIndex = 2;
            this.MainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // NewPasswordField
            // 
            this.NewPasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewPasswordField.Location = new System.Drawing.Point(106, 288);
            this.NewPasswordField.Name = "NewPasswordField";
            this.NewPasswordField.Size = new System.Drawing.Size(291, 35);
            this.NewPasswordField.TabIndex = 6;
            this.NewPasswordField.Enter += new System.EventHandler(this.NewPasswordField_Enter);
            this.NewPasswordField.Leave += new System.EventHandler(this.NewPasswordField_Leave);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonLogin.FlatAppearance.BorderSize = 2;
            this.buttonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonLogin.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.Location = new System.Drawing.Point(106, 377);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(291, 62);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "save";
            this.buttonLogin.UseVisualStyleBackColor = false;
            //this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // FirstNameField
            // 
            this.FirstNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameField.Location = new System.Drawing.Point(106, 224);
            this.FirstNameField.Name = "FirstNameField";
            this.FirstNameField.Size = new System.Drawing.Size(291, 35);
            this.FirstNameField.TabIndex = 3;
            this.FirstNameField.Enter += new System.EventHandler(this.FirstNameField_Enter);
            this.FirstNameField.Leave += new System.EventHandler(this.FirstNameField_Leave);
            // 
            // EmailField
            // 
            this.EmailField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailField.Location = new System.Drawing.Point(106, 157);
            this.EmailField.Name = "EmailField";
            this.EmailField.Size = new System.Drawing.Size(291, 35);
            this.EmailField.TabIndex = 2;
            this.EmailField.Enter += new System.EventHandler(this.EmailField_Enter);
            this.EmailField.Leave += new System.EventHandler(this.EmailField_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.close);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 116);
            this.panel2.TabIndex = 0;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.BackColor = System.Drawing.Color.MidnightBlue;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close.ForeColor = System.Drawing.SystemColors.Control;
            this.close.Location = new System.Drawing.Point(461, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(36, 40);
            this.close.TabIndex = 1;
            this.close.Text = "x";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(43, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 479);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePasswordForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox FirstNameField;
        private System.Windows.Forms.TextBox EmailField;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewPasswordField;
    }
}