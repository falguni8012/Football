using Football.Console.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace Football.Console.FileProcessor
{
	class CsvProcessor : BaseProcessor, IProcessor
	{
		public string Process(string fileName)
		{
			//Write csv code handling here
			if (base.ValidateColumn(GetColumns(fileName)))
			{
				//csv reading and everything here				
				try
				{
                    
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;
                        IDictionary<int, string> smallestList = new Dictionary<int, string>();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] lineContents = reader.ReadLine().Split(new char[] { ',' });
                           
                            int rowDataF = 0;
                            int rowDataA = 0;
                            string rowDataSymbols = string.Empty;
                            string teamName = string.Empty;

                            for (int i = 0; i <= lineContents.Length - 1; i++)
                            {
                                if (!string.IsNullOrEmpty(lineContents[i]))
                                {
                                    if (i == 5)
                                        rowDataF = i == 5 ? Convert.ToInt32(lineContents[i]):0;
                                    if (i == 6)
                                        rowDataSymbols = lineContents[i];
                                    if (i == 7)
                                        rowDataA = Convert.ToInt32(lineContents[i]);
                                   
                                    if (i == 0)
                                        teamName = lineContents[i];
                                }
                               
                            }

                            int? diffValue = null;
                            if (rowDataSymbols == "-")
                                diffValue = rowDataF - rowDataA;

                            smallestList.Add(Convert.ToInt32(diffValue.Value), teamName);
                        }

                        

                    }                    
                }
				catch (Exception ex)
				{
                    //Application should log the exception here and throw to upper layer
                    throw ex;
				}                
			}
            return "";
        }

		private List<string> GetColumns(string fileName)
		{
            List<string> columnData = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                
                string line;
                while ((line = reader.ReadLine()) != null)
                {                 
                     columnData = line.Split(new char[] { '\t' }).ToList();                   
                     return columnData;
                }
            }

            return columnData;

        }
	}
}
