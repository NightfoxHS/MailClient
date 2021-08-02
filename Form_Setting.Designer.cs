
namespace MailClient
{
    partial class Form_Setting
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Smtp = new System.Windows.Forms.Label();
            this.Label_Smtp_Port = new System.Windows.Forms.Label();
            this.Label_Pop = new System.Windows.Forms.Label();
            this.Label_Pop_Port = new System.Windows.Forms.Label();
            this.Label_UserName = new System.Windows.Forms.Label();
            this.Label_Password = new System.Windows.Forms.Label();
            this.TextBox_Smtp = new System.Windows.Forms.TextBox();
            this.TextBox_Smtp_Port = new System.Windows.Forms.TextBox();
            this.TextBox_Pop = new System.Windows.Forms.TextBox();
            this.TextBox_Pop_Smtp = new System.Windows.Forms.TextBox();
            this.TextBox_UserName = new System.Windows.Forms.TextBox();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.TextBox_UserName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Pop_Smtp, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Pop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Smtp_Port, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_Smtp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_Smtp_Port, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_Pop, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_Pop_Port, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_UserName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_Password, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Smtp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Password, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Button_OK, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Button_Cancel, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Label_Smtp
            // 
            this.Label_Smtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Smtp.AutoSize = true;
            this.Label_Smtp.Location = new System.Drawing.Point(3, 38);
            this.Label_Smtp.Name = "Label_Smtp";
            this.Label_Smtp.Size = new System.Drawing.Size(150, 15);
            this.Label_Smtp.TabIndex = 0;
            this.Label_Smtp.Text = "Smtp服务器地址：";
            // 
            // Label_Smtp_Port
            // 
            this.Label_Smtp_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Smtp_Port.AutoSize = true;
            this.Label_Smtp_Port.Location = new System.Drawing.Point(367, 38);
            this.Label_Smtp_Port.Name = "Label_Smtp_Port";
            this.Label_Smtp_Port.Size = new System.Drawing.Size(72, 15);
            this.Label_Smtp_Port.TabIndex = 1;
            this.Label_Smtp_Port.Text = "端口：";
            // 
            // Label_Pop
            // 
            this.Label_Pop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Pop.AutoSize = true;
            this.Label_Pop.Location = new System.Drawing.Point(3, 129);
            this.Label_Pop.Name = "Label_Pop";
            this.Label_Pop.Size = new System.Drawing.Size(150, 15);
            this.Label_Pop.TabIndex = 2;
            this.Label_Pop.Text = "Pop服务器地址：";
            // 
            // Label_Pop_Port
            // 
            this.Label_Pop_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Pop_Port.AutoSize = true;
            this.Label_Pop_Port.Location = new System.Drawing.Point(367, 129);
            this.Label_Pop_Port.Name = "Label_Pop_Port";
            this.Label_Pop_Port.Size = new System.Drawing.Size(72, 15);
            this.Label_Pop_Port.TabIndex = 3;
            this.Label_Pop_Port.Text = "端口：";
            // 
            // Label_UserName
            // 
            this.Label_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_UserName.AutoSize = true;
            this.Label_UserName.Location = new System.Drawing.Point(3, 220);
            this.Label_UserName.Name = "Label_UserName";
            this.Label_UserName.Size = new System.Drawing.Size(150, 15);
            this.Label_UserName.TabIndex = 4;
            this.Label_UserName.Text = "用户名：";
            // 
            // Label_Password
            // 
            this.Label_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(3, 311);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(150, 15);
            this.Label_Password.TabIndex = 5;
            this.Label_Password.Text = "密码：";
            // 
            // TextBox_Smtp
            // 
            this.TextBox_Smtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Smtp.Location = new System.Drawing.Point(159, 33);
            this.TextBox_Smtp.Name = "TextBox_Smtp";
            this.TextBox_Smtp.Size = new System.Drawing.Size(202, 25);
            this.TextBox_Smtp.TabIndex = 6;
            // 
            // TextBox_Smtp_Port
            // 
            this.TextBox_Smtp_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Smtp_Port.Location = new System.Drawing.Point(445, 33);
            this.TextBox_Smtp_Port.Name = "TextBox_Smtp_Port";
            this.TextBox_Smtp_Port.Size = new System.Drawing.Size(74, 25);
            this.TextBox_Smtp_Port.TabIndex = 7;
            // 
            // TextBox_Pop
            // 
            this.TextBox_Pop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Pop.Location = new System.Drawing.Point(159, 124);
            this.TextBox_Pop.Name = "TextBox_Pop";
            this.TextBox_Pop.Size = new System.Drawing.Size(202, 25);
            this.TextBox_Pop.TabIndex = 8;
            // 
            // TextBox_Pop_Smtp
            // 
            this.TextBox_Pop_Smtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Pop_Smtp.Location = new System.Drawing.Point(445, 124);
            this.TextBox_Pop_Smtp.Name = "TextBox_Pop_Smtp";
            this.TextBox_Pop_Smtp.Size = new System.Drawing.Size(74, 25);
            this.TextBox_Pop_Smtp.TabIndex = 9;
            // 
            // TextBox_UserName
            // 
            this.TextBox_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_UserName.Location = new System.Drawing.Point(159, 215);
            this.TextBox_UserName.Name = "TextBox_UserName";
            this.TextBox_UserName.Size = new System.Drawing.Size(202, 25);
            this.TextBox_UserName.TabIndex = 10;
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Password.Location = new System.Drawing.Point(159, 306);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(202, 25);
            this.TextBox_Password.TabIndex = 11;
            this.TextBox_Password.UseSystemPasswordChar = true;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(367, 395);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(72, 31);
            this.Button_OK.TabIndex = 12;
            this.Button_OK.Text = "确定";
            this.Button_OK.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.Location = new System.Drawing.Point(445, 395);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(74, 32);
            this.Button_Cancel.TabIndex = 13;
            this.Button_Cancel.Text = "取消";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 458);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Setting";
            this.Text = "设置";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Label_Smtp;
        private System.Windows.Forms.TextBox TextBox_UserName;
        private System.Windows.Forms.TextBox TextBox_Pop_Smtp;
        private System.Windows.Forms.TextBox TextBox_Pop;
        private System.Windows.Forms.TextBox TextBox_Smtp_Port;
        private System.Windows.Forms.Label Label_Smtp_Port;
        private System.Windows.Forms.Label Label_Pop;
        private System.Windows.Forms.Label Label_Pop_Port;
        private System.Windows.Forms.Label Label_UserName;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.TextBox TextBox_Smtp;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
    }
}