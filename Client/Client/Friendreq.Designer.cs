namespace Client
{
    partial class Friendreq
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CancelmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_frdputreq = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lv_frdreq = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 28);
            // 
            // CancelToolStripMenuItem
            // 
            this.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            this.CancelToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.CancelToolStripMenuItem.Text = "取消请求";
            this.CancelToolStripMenuItem.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelmuToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(139, 28);
            // 
            // CancelmuToolStripMenuItem
            // 
            this.CancelmuToolStripMenuItem.Name = "CancelmuToolStripMenuItem";
            this.CancelmuToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.CancelmuToolStripMenuItem.Text = "取消请求";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_frdputreq);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(320, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发出的好友请求";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_frdputreq
            // 
            this.lv_frdputreq.HideSelection = false;
            this.lv_frdputreq.Location = new System.Drawing.Point(0, 0);
            this.lv_frdputreq.Margin = new System.Windows.Forms.Padding(4);
            this.lv_frdputreq.Name = "lv_frdputreq";
            this.lv_frdputreq.Size = new System.Drawing.Size(312, 409);
            this.lv_frdputreq.TabIndex = 0;
            this.lv_frdputreq.UseCompatibleStateImageBehavior = false;
            this.lv_frdputreq.View = System.Windows.Forms.View.Details;
            this.lv_frdputreq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_frdputreq_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lv_frdreq);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(320, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "收到的好友请求";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lv_frdreq
            // 
            this.lv_frdreq.HideSelection = false;
            this.lv_frdreq.Location = new System.Drawing.Point(5, 4);
            this.lv_frdreq.Margin = new System.Windows.Forms.Padding(4);
            this.lv_frdreq.Name = "lv_frdreq";
            this.lv_frdreq.Size = new System.Drawing.Size(304, 402);
            this.lv_frdreq.TabIndex = 0;
            this.lv_frdreq.UseCompatibleStateImageBehavior = false;
            this.lv_frdreq.View = System.Windows.Forms.View.Details;
            this.lv_frdreq.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_frdreq_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(328, 469);
            this.tabControl1.TabIndex = 1;
            // 
            // Friendreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 510);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Friendreq";
            this.Text = "Friendreq";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Friendreq_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Friendreq_FormClosed);
            this.Load += new System.EventHandler(this.Friendreq_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CancelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem CancelmuToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lv_frdputreq;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lv_frdreq;
        private System.Windows.Forms.TabControl tabControl1;
    }
}