using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostureCheck
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			// Instantiate the MainForm without showing it
			Oper4sTools mainForm = new Oper4sTools();

			// Start the application with the NotifyIcon
			Application.Run();
		}
	}
}
