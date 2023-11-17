using Oper4sTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

			// Set up a handler for the ConsoleCancelEventHandler
			Console.CancelKeyPress += Console_CancelKeyPress;

			Console.WriteLine("This will appear in the console.");

			// Allocate the console
			AllocConsole();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Oper4sTools mainForm = new Oper4sTools();
			Application.Run();
			FreeConsole();
		}

		private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			e.Cancel = true; // Prevent the default behavior (terminate the application)
			HideConsole();   // Instead, hide the console
		}

		private static void HideConsole()
		{
			IntPtr hwndConsole = GetConsoleWindow();

			// If the console window is open, minimize it
			if (hwndConsole != IntPtr.Zero)
			{
				ShowWindow(hwndConsole, SW_MINIMIZE);
			}
		}

		// Constants for ShowWindow method
		private const int SW_MINIMIZE = 6;

		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		[DllImport("kernel32.dll")]
		private static extern bool FreeConsole();

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
	}
}
