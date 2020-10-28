using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using MilitantChickensTransferProtocol.GUIClient.Forms;

namespace MilitantChickensTransferProtocol.GUIClient
{
    public partial class MainForm : Form
    {
        private IconButton currentButton;
        private Panel leftBorderPanel;
        private Form currentChildForm;
        public MainForm()
        {
            InitializeComponent();
            leftBorderPanel = new Panel();
            leftBorderPanel.Size = new Size(10, 60);
            menuPanel.Controls.Add(leftBorderPanel);
            this.Text = "";
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void HighlightButton(object sender, Color color)
        {
            DisableHighlight();

            if (sender != null)
            {
                currentButton = (IconButton)sender;
                currentButton.BackColor = Color.FromArgb(43, 28, 86);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderPanel.BackColor = color;
                leftBorderPanel.Location = new Point(0, currentButton.Location.Y);
                leftBorderPanel.Visible = true;
                leftBorderPanel.BringToFront();
            }
        }
        private void DisableHighlight()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(17, 22, 37);
                currentButton.ForeColor = Color.FromName("ControlDark");
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.FromName("ControlDark");
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void sendFileButton_Click(object sender, EventArgs e)
        {
            HighlightButton(sender, Color.FromArgb(162, 0, 202));
            OpenChildForm(new SendForm());
        }
        private void recieveFile_Click(object sender, EventArgs e)
        {
            HighlightButton(sender, Color.FromArgb(162, 0, 202));
            OpenChildForm(new ReceiveForm());
        }
        /*private void logoBox_Click(object sender, EventArgs e)
        {
            ResetHighlighting();
        }*/
        private void ResetHighlighting()
        {
            DisableHighlight();
            leftBorderPanel.Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int WParam, int lParam);
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
               }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }
    }
}
