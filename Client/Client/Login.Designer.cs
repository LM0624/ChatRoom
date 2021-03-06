namespace Client
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_SignUp = new System.Windows.Forms.Button();
            this.lb_ShowMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // tb_Username
            // 
            this.tb_Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Username.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tb_Username.Location = new System.Drawing.Point(145, 60);
            this.tb_Username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(132, 25);
            this.tb_Username.TabIndex = 2;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(145, 111);
            this.tb_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(132, 25);
            this.tb_Password.TabIndex = 3;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(186, 177);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(100, 29);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.Location = new System.Drawing.Point(52, 177);
            this.btn_SignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(100, 29);
            this.btn_SignUp.TabIndex = 5;
            this.btn_SignUp.Text = "注册";
            this.btn_SignUp.UseVisualStyleBackColor = true;
            this.btn_SignUp.Click += new System.EventHandler(this.btn_SignUp_Click);
            // 
            // lb_ShowMsg
            // 
            this.lb_ShowMsg.AutoSize = true;
            this.lb_ShowMsg.Location = new System.Drawing.Point(183, 160);
            this.lb_ShowMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ShowMsg.Name = "lb_ShowMsg";
            this.lb_ShowMsg.Size = new System.Drawing.Size(0, 15);
            this.lb_ShowMsg.TabIndex = 6;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 273);
            this.Controls.Add(this.lb_ShowMsg);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_SignUp;
        private System.Windows.Forms.Label lb_ShowMsg;
    }
}