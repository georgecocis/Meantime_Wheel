namespace SEProject
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameText = new System.Windows.Forms.TextBox();
            this.lastNameText = new System.Windows.Forms.TextBox();
            this.countryText = new System.Windows.Forms.TextBox();
            this.emailText = new System.Windows.Forms.TextBox();
            this.phoneText = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.confirmText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 116);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(537, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREATE YOUR ACCOUNT";
            // 
            // firstNameText
            // 
            this.firstNameText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameText.ForeColor = System.Drawing.Color.DimGray;
            this.firstNameText.Location = new System.Drawing.Point(60, 166);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(259, 40);
            this.firstNameText.TabIndex = 2;
            this.firstNameText.Text = "first name";
            this.firstNameText.Enter += new System.EventHandler(this.firstNameText_Enter);
            this.firstNameText.Leave += new System.EventHandler(this.firstNameText_Leave);
            // 
            // lastNameText
            // 
            this.lastNameText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameText.ForeColor = System.Drawing.Color.DimGray;
            this.lastNameText.Location = new System.Drawing.Point(387, 166);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(258, 40);
            this.lastNameText.TabIndex = 3;
            this.lastNameText.Text = "last name";
            this.lastNameText.Enter += new System.EventHandler(this.lastNameText_Enter);
            this.lastNameText.Leave += new System.EventHandler(this.lastNameText_Leave);
            // 
            // countryText
            // 
            this.countryText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryText.ForeColor = System.Drawing.Color.DimGray;
            this.countryText.Location = new System.Drawing.Point(60, 239);
            this.countryText.Name = "countryText";
            this.countryText.Size = new System.Drawing.Size(259, 40);
            this.countryText.TabIndex = 4;
            this.countryText.Text = "country";
            this.countryText.Enter += new System.EventHandler(this.countryText_Enter);
            this.countryText.Leave += new System.EventHandler(this.countryText_Leave);
            // 
            // emailText
            // 
            this.emailText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailText.ForeColor = System.Drawing.Color.DimGray;
            this.emailText.Location = new System.Drawing.Point(387, 239);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(258, 40);
            this.emailText.TabIndex = 5;
            this.emailText.Text = "e-mail";
            this.emailText.Enter += new System.EventHandler(this.emailText_Enter);
            this.emailText.Leave += new System.EventHandler(this.emailText_Leave);
            // 
            // phoneText
            // 
            this.phoneText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneText.ForeColor = System.Drawing.Color.DimGray;
            this.phoneText.Location = new System.Drawing.Point(60, 318);
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(259, 40);
            this.phoneText.TabIndex = 6;
            this.phoneText.Text = "phone";
            this.phoneText.Enter += new System.EventHandler(this.phoneText_Enter);
            this.phoneText.Leave += new System.EventHandler(this.phoneText_Leave);
            // 
            // usernameText
            // 
            this.usernameText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.ForeColor = System.Drawing.Color.DimGray;
            this.usernameText.Location = new System.Drawing.Point(387, 318);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(258, 40);
            this.usernameText.TabIndex = 7;
            this.usernameText.Text = "username";
            this.usernameText.Enter += new System.EventHandler(this.usernameText_Enter);
            this.usernameText.Leave += new System.EventHandler(this.usernameText_Leave);
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.ForeColor = System.Drawing.Color.DimGray;
            this.passwordText.Location = new System.Drawing.Point(60, 392);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(259, 40);
            this.passwordText.TabIndex = 8;
            this.passwordText.Text = "password";
            this.passwordText.Enter += new System.EventHandler(this.passwordText_Enter);
            this.passwordText.Leave += new System.EventHandler(this.passwordText_Leave);
            // 
            // confirmText
            // 
            this.confirmText.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmText.ForeColor = System.Drawing.Color.DimGray;
            this.confirmText.Location = new System.Drawing.Point(387, 392);
            this.confirmText.Name = "confirmText";
            this.confirmText.Size = new System.Drawing.Size(258, 40);
            this.confirmText.TabIndex = 9;
            this.confirmText.Text = "confirm password";
            this.confirmText.Enter += new System.EventHandler(this.confirmText_Enter);
            this.confirmText.Leave += new System.EventHandler(this.confirmText_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(262, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "REGISTER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(718, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.phoneText);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.countryText);
            this.Controls.Add(this.lastNameText);
            this.Controls.Add(this.firstNameText);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameText;
        private System.Windows.Forms.TextBox lastNameText;
        private System.Windows.Forms.TextBox countryText;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.TextBox phoneText;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox confirmText;
        private System.Windows.Forms.Button button1;
    }
}