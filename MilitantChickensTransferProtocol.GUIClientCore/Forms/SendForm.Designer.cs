namespace MilitantChickensTransferProtocol.GUIClientCore.Forms
{
    partial class SendForm
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
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label messageBox;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(145, 116);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(206, 20);
            this.filePathBox.TabIndex = 0;
            // 
            // requestButton
            // 
            this.sendButton.Location = new System.Drawing.Point(205, 166);
            this.sendButton.Name = "requestButton";
            this.sendButton.Size = new System.Drawing.Size(97, 31);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Upload File";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageBox
            // 
            this.Controls.Add(this.messageBox);
            this.messageBox.AutoSize = true;
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.messageBox.Location = new System.Drawing.Point(141, 223);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(174, 20);
            this.messageBox.TabIndex = 2;
            this.messageBox.Text = "Fuck You Visual Studio";
            // ReceiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.filePathBox);
            this.Name = "ReceiveForm";
            this.Text = "ReceiveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}