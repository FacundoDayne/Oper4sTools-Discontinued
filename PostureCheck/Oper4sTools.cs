using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PostureCheck
{
	public partial class Oper4sTools : Form
	{
		Form thisForm;
		private NotifyIcon notifyIcon;
		private ContextMenuStrip contextMenuStrip;

		public Oper4sTools()
		{
			thisForm = this;
			InitializeComponent();
			InitializeTrayIcon();
		}

		static Icon getIcon()
		{
			Bitmap pngIcon = Properties.Resources.haxxor_icon;
			IntPtr hBitmap = pngIcon.GetHicon();
			Icon icon = Icon.FromHandle(hBitmap);
			return icon;
		}

		private void InitializeTrayIcon()
		{	
			contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.Add("Exit", null, exitToolStripMenuItem);



			notifyIcon = new NotifyIcon();
			notifyIcon.Icon = getIcon();
			notifyIcon.Text = "Oper4's Tools";
			notifyIcon.Visible = true;
			notifyIcon.ContextMenuStrip = contextMenuStrip;
			notifyIcon.MouseClick += NotifyIcon_Click;
		}

		private void NotifyIcon_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Show();
				WindowState = FormWindowState.Normal;
			}
			else if (e.Button == MouseButtons.Right) contextMenuStrip.Show(Cursor.Position);


		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Hide(); // Hide the main form
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true; // Cancel the default close operation
				WindowState = FormWindowState.Minimized; // Minimize the form
				ShowInTaskbar = false; // Hide the form from the taskbar
			}

			base.OnFormClosing(e);
		}

		private void exitToolStripMenuItem(object sender, EventArgs e)
		{
			// Clean up resources and close the application
			notifyIcon.Dispose();
			System.Windows.Forms.Application.Exit();
		}
	}
}
