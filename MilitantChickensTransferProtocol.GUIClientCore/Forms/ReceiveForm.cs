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
    public partial class ReceiveForm : Form
    {
        public ReceiveForm()
        {
            InitializeComponent();
        }
        private void requestButton_Click(object sender, EventArgs e)
        {
            try
            {
                string file = filePathBox.Text;
                RequestHeader clientHeader = new GetRequestHeader(file, Program.client.key);
                byte[] requestHeader = clientHeader.ReturnRawHeader();
                Program.client.SendHeader(requestHeader);
                Program.client.stream.Flush();
                messageBox.Text = Program.client.HandleResponse(false, file).Value;
            }
            catch (Exception ex)
            {
                messageBox.Text = ex.Message;
            }
        }
    }
}
