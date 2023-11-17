using System;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Oper4sTools;
using Oper4sTools.Properties;
using PostureCheck.Panels;

namespace PostureCheck
{
	public partial class Oper4sTools : Form
	{
		Form thisForm;
		private NotifyIcon notifyIcon;
		private ContextMenuStrip contextMenuStrip;
		private UserControl activeMask;
		System.Threading.Timer timer;
		public static double timeInterval = 0.5;
		public Oper4sTools()
		{
			thisForm = this;
			InitializeComponent();
			InitializeTrayIcon();
			this.Icon = getIcon("haxxor_icon");
			activeMask = testUserControl1;
			setTimer();
			//ConsoleManager.OpenConsole();
			AllocConsole();
		}

		public static Bitmap getImage(string imageName)
		{
			Bitmap image = (Bitmap)Resources.ResourceManager.GetObject(imageName);
			return image;
		}
		public static Icon getIcon(string iconName)
		{
			Bitmap pngIcon = (Bitmap)Resources.ResourceManager.GetObject(iconName);
			IntPtr hBitmap = pngIcon.GetHicon();
			Icon icon = Icon.FromHandle(hBitmap);
			return icon;
		}

		private void maskChange(UserControl requestedMask)
		{
			this.Controls.Remove(activeMask);
			activeMask.Dispose();
			activeMask = requestedMask;
			activeMask.Dock = System.Windows.Forms.DockStyle.Fill;
			activeMask.Location = new System.Drawing.Point(0, 0);
			activeMask.Name = "activeMask";
			activeMask.Size = new System.Drawing.Size(800, 450);
			activeMask.TabIndex = 0;
			this.Controls.Add(this.activeMask);
			activeMask.Show();

		}

		private void InitializeTrayIcon()
		{
			contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.Add("Welcome to Oper4's Tools", getImage("logo1"));
			contextMenuStrip.Items.Add("-------------------------");
			contextMenuStrip.Items.Add("Home", null, homeContextMenu);
			contextMenuStrip.Items.Add("Posture Check", getImage("skill2"), postureCheckMenu);
			contextMenuStrip.Items.Add("Try Posture Check Sound", getImage("skill3"), tryPostureCheckMenu);
			contextMenuStrip.Items.Add("Open Debug Console", null, openDebugConsole);
			contextMenuStrip.Items.Add("Exit", null, exitToolStripMenuItem);



			notifyIcon = new NotifyIcon();
			notifyIcon.Icon = getIcon("haxxor_icon");
			notifyIcon.Text = "Oper4's Tools";
			notifyIcon.Visible = true;
			notifyIcon.ContextMenuStrip = contextMenuStrip;
			notifyIcon.MouseClick += NotifyIcon_Click;
		}

		public void setTimer()
		{
			Console.WriteLine("Timer starts");
			timer = new System.Threading.Timer(playReminder, null, 0, Int32.Parse((TimeSpan.FromMinutes(timeInterval).TotalMilliseconds).ToString()));
		}
		static void playReminder(object state)
		{
			try
			{
				Console.WriteLine("Playing at {0}", DateTime.Now);
				SoundPlayer player = new SoundPlayer(Resources.clip1);
				player.PlaySync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
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

		private void homeContextMenu(object sender, EventArgs e)
		{
			maskChange(new testUserControl());
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void postureCheckMenu(object sender, EventArgs e)
		{
			maskChange(new CustomUserControls.PostureCheck());
			Show();
			WindowState = FormWindowState.Normal;
		}
		private void tryPostureCheckMenu(object sender, EventArgs e)
		{
			playReminder(null);
		}

		private void openDebugConsole(object sender, EventArgs e)
		{
			ConsoleManager.OpenConsole();
		}
		private void exitToolStripMenuItem(object sender, EventArgs e)
		{
			timer.Dispose();
			notifyIcon.Dispose();
			System.Windows.Forms.Application.Exit();
		}

		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		
	}
}
