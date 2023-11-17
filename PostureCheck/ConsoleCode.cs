using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oper4sTools
{
	public class ConsoleCode
	{

		public static void OpenConsole()
		{
			IntPtr hwndConsole = GetConsoleWindow();

			// If the console window is not already open, allocate and attach a new console
			if (hwndConsole == IntPtr.Zero)
			{
				AllocConsole();
			}
			else
			{
				// If the console window is already open, bring it to the foreground
				ShowWindow(hwndConsole, SW_RESTORE);
			}
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
		private const int SW_RESTORE = 9;
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
