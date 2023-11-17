using Oper4sTools;
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
			Console.WriteLine("This will appear in the console.");

			// Initialize console-related code
			ConsoleManager.OpenConsole();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Oper4sTools mainForm = new Oper4sTools();
			Application.Run();
		}
	}
}
