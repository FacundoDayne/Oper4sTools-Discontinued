using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oper4sTools
{
	public class ConsoleManager
	{

		public static void OpenConsole()
		{
			// Allocate the console
			AllocConsole();
			// Set up a handler for the ConsoleCancelEventHandler
			Console.CancelKeyPress += Console_CancelKeyPress;			
		}

		private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			e.Cancel = true; // Prevent the default behavior (terminate the application)
			HideConsole();   // Instead, hide the console
		}

		// Method to hide the console
		public static void HideConsole()
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
