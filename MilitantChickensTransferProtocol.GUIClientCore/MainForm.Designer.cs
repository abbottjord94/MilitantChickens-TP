namespace MilitantChickensTransferProtocol.GUIClientCore
{
    partial class MainForm
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.recieveFile = new FontAwesome.Sharp.IconButton();
            this.sendFileButton = new FontAwesome.Sharp.IconButton();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.titleBar = new System.Windows.Forms.Panel();
            this.minimizeButton = new FontAwesome.Sharp.IconButton();
            this.maximizeButton = new FontAwesome.Sharp.IconButton();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.recieveFile);
            this.menuPanel.Controls.Add(this.sendFileButton);
            this.menuPanel.Controls.Add(this.logoPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 450);
            this.menuPanel.TabIndex = 0;
            // 
            // recieveFile
            // 
            this.recieveFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.recieveFile.FlatAppearance.BorderSize = 0;
            this.recieveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recieveFile.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.recieveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recieveFile.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.recieveFile.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.recieveFile.IconColor = System.Drawing.SystemColors.ControlDark;
            this.recieveFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.recieveFile.IconSize = 32;
            this.recieveFile.Location = new System.Drawing.Point(0, 194);
            this.recieveFile.Name = "recieveFile";
            this.recieveFile.Rotation = 0D;
            this.recieveFile.Size = new System.Drawing.Size(200, 60);
            this.recieveFile.TabIndex = 2;
            this.recieveFile.Text = "Receive File";
            this.recieveFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.recieveFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.recieveFile.UseVisualStyleBackColor = true;
            this.recieveFile.Click += new System.EventHandler(this.recieveFile_Click);
            // 
            // sendFileButton
            // 
            this.sendFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.sendFileButton.FlatAppearance.BorderSize = 0;
            this.sendFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendFileButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.sendFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendFileButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.sendFileButton.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.sendFileButton.IconColor = System.Drawing.SystemColors.ControlDark;
            this.sendFileButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.sendFileButton.IconSize = 32;
            this.sendFileButton.Location = new System.Drawing.Point(0, 134);
            this.sendFileButton.Name = "sendFileButton";
            this.sendFileButton.Rotation = 0D;
            this.sendFileButton.Size = new System.Drawing.Size(200, 60);
            this.sendFileButton.TabIndex = 1;
            this.sendFileButton.Text = "Upload File";
            this.sendFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.sendFileButton.UseVisualStyleBackColor = true;
            this.sendFileButton.Click += new System.EventHandler(this.sendFileButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(200, 134);
            this.logoPanel.TabIndex = 0;
            // 
            // titleBar
            // 
            this.titleBar.Controls.Add(this.minimizeButton);
            this.titleBar.Controls.Add(this.maximizeButton);
            this.titleBar.Controls.Add(this.closeButton);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(200, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(600, 65);
            this.titleBar.TabIndex = 1;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.minimizeButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.minimizeButton.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
            this.minimizeButton.IconColor = System.Drawing.SystemColors.ControlDark;
            this.minimizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimizeButton.IconSize = 32;
            this.minimizeButton.Location = new System.Drawing.Point(474, 10);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Rotation = 0D;
            this.minimizeButton.Size = new System.Drawing.Size(35, 38);
            this.minimizeButton.TabIndex = 5;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.maximizeButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.maximizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.maximizeButton.IconColor = System.Drawing.SystemColors.ControlDark;
            this.maximizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximizeButton.IconSize = 32;
            this.maximizeButton.Location = new System.Drawing.Point(515, 10);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Rotation = 0D;
            this.maximizeButton.Size = new System.Drawing.Size(35, 38);
            this.maximizeButton.TabIndex = 4;
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.closeButton.IconColor = System.Drawing.SystemColors.ControlDark;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeButton.IconSize = 32;
            this.closeButton.Location = new System.Drawing.Point(556, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Rotation = 0D;
            this.closeButton.Size = new System.Drawing.Size(35, 38);
            this.closeButton.TabIndex = 3;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // childFormPanel
            // 
            this.childFormPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.childFormPanel.Location = new System.Drawing.Point(200, 65);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(600, 385);
            this.childFormPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.menuPanel);
            this.Name = "MainForm";
            this.Text = "FTP Client";
            this.menuPanel.ResumeLayout(false);
            this.titleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private FontAwesome.Sharp.IconButton sendFileButton;
        private System.Windows.Forms.Panel logoPanel;
        private FontAwesome.Sharp.IconButton recieveFile;
        private System.Windows.Forms.Panel titleBar;
        private FontAwesome.Sharp.IconButton minimizeButton;
        private FontAwesome.Sharp.IconButton maximizeButton;
        private FontAwesome.Sharp.IconButton closeButton;
        private System.Windows.Forms.Panel childFormPanel;

    }
}


