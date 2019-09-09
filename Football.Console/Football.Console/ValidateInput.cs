using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Football.Console
{
	static class ValidateInput
	{
		/// <summary>
		/// This method validates the input provided by the user from the command line
		/// </summary>
		/// <param name="args">Command line arguments</param>
		/// <returns>True or False</returns>
		public static bool IsInputValid(string[] args)
		{
			//Validate Input here from the command line
			return true;
		}

		public static bool IsFileValid(string fileName)
		{
			//Validate that file is correct and can be accessed and read by the application
			var isValid = false;
			if (File.Exists(fileName))
			{
				try
				{
					File.Open(fileName, FileMode.Open, FileAccess.Read).Dispose();
					isValid = true;
				}
				catch (IOException)
				{
					
				}
			}
			return isValid;

		}

	}
}
