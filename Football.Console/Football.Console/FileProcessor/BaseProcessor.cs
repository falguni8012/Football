using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Football.Console.FileProcessor
{
	abstract class BaseProcessor
	{
		public virtual bool ValidateColumn(List<string> columns)
		{
            //validate the column structure here 
            //method is virtual so that child class can overrite this method if required
            const int cnCols = 9; // count total columns
            
            List<string> colHeader = new List<string>();
            colHeader.Add("Team");
            colHeader.Add("P");
            colHeader.Add("W");
            colHeader.Add("L");
            colHeader.Add("D");
            colHeader.Add("F");
            colHeader.Add("-");
            colHeader.Add("A");
            colHeader.Add("Pts");

            bool isValidate = false;


            var inputCols = columns[0].Split(",").ToArray();

            bool equals = colHeader.OrderBy(x => x).SequenceEqual(inputCols.OrderBy(y => y)); // Checking same value in columns

            if (inputCols.Count() == cnCols && equals) // if both the conditions are true, execute file
                isValidate =  true;

            return isValidate;
		}
	}
}
