using Football.Console.FileProcessor;
using Football.Console.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Console.Factory
{
	static class FactoryProcessor
	{
		public static IProcessor GetProcessor(FileType fileType)
		{
            if (fileType == FileType.csv)
                return new CsvProcessor();
            else if (fileType == FileType.dat)
                return new DatProcessor();
            else
                return null;
		}
	}
}
