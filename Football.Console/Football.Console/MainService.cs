using Football.Console.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Football.Console;

namespace Football.Console
{
	class MainService
	{
		public string Response { get; private set; }
		public void Process(string fileName)
		{
			var fileExtension = Path.GetExtension(fileName);
           
            if (Enum.TryParse<FileType>(fileExtension.TrimStart('.').ToLower(), out FileType fileType))
			{
				try
				{
					var processor = FactoryProcessor.GetProcessor(fileType);
					Response = processor.Process(fileName);
				}
				catch (Exception)
				{
					
					//here error occurred means something went wrong which we were not expecting				
					throw new Exception("An error occurred while processing the file");
				}
			}
			else
			{

                System.Console.WriteLine($"File extension {fileExtension} is not supported");				
				//throw new Exception("$"File extension { fileExtension } is not supported");
				
			}
		}
	}
}
