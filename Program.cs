using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MergeFrontEnd
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo();

				string argString = "";
				foreach (string arg in args)
					argString += string.Format(" \"{0}\"", arg);

				if (argString.Length > 0)
					argString = argString.Substring(1);

				argString = "-db " + argString;

				string mergedFilePath = args[3];
				File.WriteAllText(mergedFilePath, "");

				startInfo.FileName = @"C:\Program Files\Perforce\p4merge.exe";
				startInfo.Arguments = argString;

				Process mergeTool = Process.Start(startInfo);
				mergeTool.WaitForExit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error:\n" + e.ToString());
			}
		}
	}
}
