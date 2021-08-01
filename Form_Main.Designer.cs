
namespace MailClient
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.Status_Smtp = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Pop = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_User_Smtp = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_User_Pop = new System.Windows.Forms.ToolStripStatusLabel();
            this.Button_Write = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Label_List_Title = new System.Windows.Forms.Label();
            this.ToolStrip_DownMenu = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_Login = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Setting = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel_Mail = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Subject = new System.Windows.Forms.Label();
            this.Label_Subject_V = new System.Windows.Forms.Label();
            this.Label_From = new System.Windows.Forms.Label();
            this.Label_From_V = new System.Windows.Forms.Label();
            this.Label_To = new System.Windows.Forms.Label();
            this.Label_To_V = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.ToolStrip_DownMenu.SuspendLayout();
            this.tableLayoutPanel_Mail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.Button_Write, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_List_Title, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ToolStrip_DownMenu, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel_Mail, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 433);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip, 2);
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_Smtp,
            this.Status_Pop,
            this.Status_User_Smtp,
            this.Status_User_Pop});
            this.statusStrip.Location = new System.Drawing.Point(0, 410);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(702, 23);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // Status_Smtp
            // 
            this.Status_Smtp.Name = "Status_Smtp";
            this.Status_Smtp.Size = new System.Drawing.Size(79, 17);
            this.Status_Smtp.Text = "Smtp:220";
            // 
            // Status_Pop
            // 
            this.Status_Pop.Name = "Status_Pop";
            this.Status_Pop.Size = new System.Drawing.Size(75, 17);
            this.Status_Pop.Text = "Pop:+OK";
            // 
            // Status_User_Smtp
            // 
            this.Status_User_Smtp.Name = "Status_User_Smtp";
            this.Status_User_Smtp.Size = new System.Drawing.Size(104, 17);
            this.Status_User_Smtp.Text = "Smtp:Offiline";
            // 
            // Status_User_Pop
            // 
            this.Status_User_Pop.Name = "Status_User_Pop";
            this.Status_User_Pop.Size = new System.Drawing.Size(93, 17);
            this.Status_User_Pop.Text = "Pop:Ofiiline";
            // 
            // Button_Write
            // 
            this.Button_Write.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_Write.Location = new System.Drawing.Point(42, 4);
            this.Button_Write.Name = "Button_Write";
            this.Button_Write.Size = new System.Drawing.Size(91, 33);
            this.Button_Write.TabIndex = 1;
            this.Button_Write.Text = "写信";
            this.Button_Write.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(3, 85);
            this.listBox1.Name = "listBox1";
            this.tableLayoutPanel1.SetRowSpan(this.listBox1, 7);
            this.listBox1.Size = new System.Drawing.Size(169, 281);
            this.listBox1.TabIndex = 2;
            // 
            // Label_List_Title
            // 
            this.Label_List_Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_List_Title.AutoSize = true;
            this.Label_List_Title.Location = new System.Drawing.Point(54, 54);
            this.Label_List_Title.Name = "Label_List_Title";
            this.Label_List_Title.Size = new System.Drawing.Size(67, 15);
            this.Label_List_Title.TabIndex = 3;
            this.Label_List_Title.Text = "信件列表";
            // 
            // ToolStrip_DownMenu
            // 
            this.ToolStrip_DownMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip_DownMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip_DownMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_Login,
            this.ToolStripButton_Refresh,
            this.ToolStripButton_Setting});
            this.ToolStrip_DownMenu.Location = new System.Drawing.Point(0, 369);
            this.ToolStrip_DownMenu.Name = "ToolStrip_DownMenu";
            this.ToolStrip_DownMenu.Size = new System.Drawing.Size(175, 41);
            this.ToolStrip_DownMenu.TabIndex = 4;
            this.ToolStrip_DownMenu.Text = "toolStrip1";
            // 
            // ToolStripButton_Login
            // 
            this.ToolStripButton_Login.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Login.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Login.Image")));
            this.ToolStripButton_Login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Login.Name = "ToolStripButton_Login";
            this.ToolStripButton_Login.Size = new System.Drawing.Size(29, 38);
            this.ToolStripButton_Login.Text = "toolStripButton1";
            // 
            // ToolStripButton_Refresh
            // 
            this.ToolStripButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Refresh.Image")));
            this.ToolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Refresh.Name = "ToolStripButton_Refresh";
            this.ToolStripButton_Refresh.Size = new System.Drawing.Size(29, 38);
            this.ToolStripButton_Refresh.Text = "toolStripButton2";
            // 
            // ToolStripButton_Setting
            // 
            this.ToolStripButton_Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Setting.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Setting.Image")));
            this.ToolStripButton_Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Setting.Name = "ToolStripButton_Setting";
            this.ToolStripButton_Setting.Size = new System.Drawing.Size(29, 38);
            this.ToolStripButton_Setting.Text = "toolStripButton3";
            // 
            // tableLayoutPanel_Mail
            // 
            this.tableLayoutPanel_Mail.ColumnCount = 2;
            this.tableLayoutPanel_Mail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_Mail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel_Mail.Controls.Add(this.Label_To_V, 1, 2);
            this.tableLayoutPanel_Mail.Controls.Add(this.Label_To, 0, 2);
            this.tableLayoutPanel_Mail.Controls.Add(this.Label_From_V, 1, 1);
            this.tableLayoutPanel_Mail.Controls.Add(this.Label_From, 0, 1);
            this.tableLayoutPanel_Mail.Controls.Add(this.Label_Subject_V, 1, 0);
            this.tableLayoutPanel_Mail.Controls.Add(this.Label_Subject, 0, 0);
            this.tableLayoutPanel_Mail.Controls.Add(this.textBox_Message, 0, 3);
            this.tableLayoutPanel_Mail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Mail.Location = new System.Drawing.Point(178, 3);
            this.tableLayoutPanel_Mail.Name = "tableLayoutPanel_Mail";
            this.tableLayoutPanel_Mail.RowCount = 4;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel_Mail, 10);
            this.tableLayoutPanel_Mail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel_Mail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel_Mail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel_Mail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel_Mail.Size = new System.Drawing.Size(521, 404);
            this.tableLayoutPanel_Mail.TabIndex = 5;
            // 
            // Label_Subject
            // 
            this.Label_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Subject.AutoSize = true;
            this.Label_Subject.Location = new System.Drawing.Point(3, 12);
            this.Label_Subject.Name = "Label_Subject";
            this.Label_Subject.Size = new System.Drawing.Size(150, 15);
            this.Label_Subject.TabIndex = 0;
            this.Label_Subject.Text = "标题：";
            // 
            // Label_Subject_V
            // 
            this.Label_Subject_V.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Subject_V.AutoSize = true;
            this.Label_Subject_V.Location = new System.Drawing.Point(159, 12);
            this.Label_Subject_V.Name = "Label_Subject_V";
            this.Label_Subject_V.Size = new System.Drawing.Size(359, 15);
            this.Label_Subject_V.TabIndex = 1;
            this.Label_Subject_V.Text = "label1";
            // 
            // Label_From
            // 
            this.Label_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_From.AutoSize = true;
            this.Label_From.Location = new System.Drawing.Point(3, 52);
            this.Label_From.Name = "Label_From";
            this.Label_From.Size = new System.Drawing.Size(150, 15);
            this.Label_From.TabIndex = 2;
            this.Label_From.Text = "发信人：";
            // 
            // Label_From_V
            // 
            this.Label_From_V.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_From_V.AutoSize = true;
            this.Label_From_V.Location = new System.Drawing.Point(159, 52);
            this.Label_From_V.Name = "Label_From_V";
            this.Label_From_V.Size = new System.Drawing.Size(359, 15);
            this.Label_From_V.TabIndex = 3;
            this.Label_From_V.Text = "label1";
            // 
            // Label_To
            // 
            this.Label_To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_To.AutoSize = true;
            this.Label_To.Location = new System.Drawing.Point(3, 92);
            this.Label_To.Name = "Label_To";
            this.Label_To.Size = new System.Drawing.Size(150, 15);
            this.Label_To.TabIndex = 4;
            this.Label_To.Text = "收信人";
            // 
            // Label_To_V
            // 
            this.Label_To_V.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_To_V.AutoSize = true;
            this.Label_To_V.Location = new System.Drawing.Point(159, 92);
            this.Label_To_V.Name = "Label_To_V";
            this.Label_To_V.Size = new System.Drawing.Size(359, 15);
            this.Label_To_V.TabIndex = 5;
            this.Label_To_V.Text = "label1";
            // 
            // textBox_Message
            // 
            this.tableLayoutPanel_Mail.SetColumnSpan(this.textBox_Message, 2);
            this.textBox_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Message.Location = new System.Drawing.Point(3, 123);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(515, 278);
            this.textBox_Message.TabIndex = 6;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ToolStrip_DownMenu.ResumeLayout(false);
            this.ToolStrip_DownMenu.PerformLayout();
            this.tableLayoutPanel_Mail.ResumeLayout(false);
            this.tableLayoutPanel_Mail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Status_Smtp;
        private System.Windows.Forms.ToolStripStatusLabel Status_Pop;
        private System.Windows.Forms.ToolStripStatusLabel Status_User_Smtp;
        private System.Windows.Forms.ToolStripStatusLabel Status_User_Pop;
        private System.Windows.Forms.Button Button_Write;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Label_List_Title;
        private System.Windows.Forms.ToolStrip ToolStrip_DownMenu;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Login;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Refresh;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Setting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Mail;
        private System.Windows.Forms.Label Label_To_V;
        private System.Windows.Forms.Label Label_To;
        private System.Windows.Forms.Label Label_From_V;
        private System.Windows.Forms.Label Label_From;
        private System.Windows.Forms.Label Label_Subject_V;
        private System.Windows.Forms.Label Label_Subject;
        private System.Windows.Forms.TextBox textBox_Message;
    }
}

