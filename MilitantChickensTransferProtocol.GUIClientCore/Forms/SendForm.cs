using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MilitantChickensTranferProtocol.Library;

namespace MilitantChickensTransferProtocol.GUIClientCore.Forms
{
    public partial class SendForm : Form
    {
        public SendForm()
        {
            InitializeComponent();
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string file = filePathBox.Text;
                RequestHeader clientHeader = new PostRequestHeader(file, Program.client.key);
                byte[] requestHeader = clientHeader.ReturnRawHeader();
                Program.client.SendHeader(requestHeader);
                Program.client.HandleResponse(true, file);
                messageBox.Text = "Success!";
            }
            catch (Exception ex)
            {
                messageBox.Text = ex.Message;
            }
        }
    }
}
