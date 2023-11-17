﻿using Oper4sTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oper4sTools
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//AllocConsole();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Oper4sTools mainForm = new Oper4sTools();
			Application.Run(new Oper4sTools());
			FreeConsole();
		}

		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		[DllImport("kernel32.dll")]
		private static extern bool FreeConsole();
	}
}
