namespace BirthdayManager
{
    partial class BirthdayManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BirthdayManager));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToTray = new System.Windows.Forms.ToolStripMenuItem();
            this.nameList = new System.Windows.Forms.ListBox();
            this.dateShow = new System.Windows.Forms.DateTimePicker();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.startCheck = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.yearLabel = new System.Windows.Forms.Label();
            this.dayLabel = new System.Windows.Forms.Label();
            this.notifyContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.notifyContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.hideToTray,
            this.exitToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(369, 23);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileButton
            // 
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.saveButton,
            this.saveAsButton});
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(37, 19);
            this.fileButton.Text = "File";
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(160, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.open);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 22);
            this.saveButton.Text = "Save (to default)";
            this.saveButton.Click += new System.EventHandler(this.save);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(160, 22);
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.Click += new System.EventHandler(this.saveAs);
            // 
            // hideToTray
            // 
            this.hideToTray.Name = "hideToTray";
            this.hideToTray.Size = new System.Drawing.Size(83, 19);
            this.hideToTray.Text = "Hide to Tray";
            this.hideToTray.Click += new System.EventHandler(this.hide);
            // 
            // nameList
            // 
            this.nameList.FormattingEnabled = true;
            this.nameList.Location = new System.Drawing.Point(12, 31);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(120, 95);
            this.nameList.TabIndex = 2;
            this.nameList.SelectedIndexChanged += new System.EventHandler(this.select);
            // 
            // dateShow
            // 
            this.dateShow.Location = new System.Drawing.Point(138, 31);
            this.dateShow.Name = "dateShow";
            this.dateShow.Size = new System.Drawing.Size(149, 20);
            this.dateShow.TabIndex = 3;
            this.dateShow.ValueChanged += new System.EventHandler(this.dateChange);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(139, 58);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(183, 55);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(104, 20);
            this.nameText.TabIndex = 5;
            this.nameText.TextChanged += new System.EventHandler(this.nameChange);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(138, 78);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.add);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(212, 78);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.remove);
            // 
            // startCheck
            // 
            this.startCheck.AutoSize = true;
            this.startCheck.Location = new System.Drawing.Point(160, 107);
            this.startCheck.Name = "startCheck";
            this.startCheck.Size = new System.Drawing.Size(100, 17);
            this.startCheck.TabIndex = 8;
            this.startCheck.Text = "Start on Startup";
            this.startCheck.UseVisualStyleBackColor = true;
            this.startCheck.CheckedChanged += new System.EventHandler(this.startChecked);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "BirthdayManager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.show);
            this.notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyClick);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(293, 34);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(58, 13);
            this.yearLabel.TabIndex = 9;
            this.yearLabel.Text = "0 years old";
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(293, 58);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(60, 26);
            this.dayLabel.TabIndex = 11;
            this.dayLabel.Text = "0 days until\r\nbirthday";
            // 
            // notifyContext
            // 
            this.notifyContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStripButton,
            this.exitStripButton});
            this.notifyContext.Name = "notifyContext";
            this.notifyContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.notifyContext.Size = new System.Drawing.Size(134, 48);
            // 
            // showStripButton
            // 
            this.showStripButton.Name = "showStripButton";
            this.showStripButton.Size = new System.Drawing.Size(133, 22);
            this.showStripButton.Text = "Show/Hide";
            this.showStripButton.Click += new System.EventHandler(this.toggle);
            // 
            // exitStripButton
            // 
            this.exitStripButton.Name = "exitStripButton";
            this.exitStripButton.Size = new System.Drawing.Size(133, 22);
            this.exitStripButton.Text = "Exit";
            this.exitStripButton.Click += new System.EventHandler(this.exit);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit);
            // 
            // BirthdayManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 131);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.startCheck);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.dateShow);
            this.Controls.Add(this.nameList);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "BirthdayManager";
            this.Text = "BirthdayManager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.notifyContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileButton;
        private System.Windows.Forms.ToolStripMenuItem openButton;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsButton;
        private System.Windows.Forms.ListBox nameList;
        private System.Windows.Forms.DateTimePicker dateShow;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.ToolStripMenuItem hideToTray;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.CheckBox startCheck;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.ContextMenuStrip notifyContext;
        private System.Windows.Forms.ToolStripMenuItem showStripButton;
        private System.Windows.Forms.ToolStripMenuItem exitStripButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

