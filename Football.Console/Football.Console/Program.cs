using System;

namespace Football.Console
{
	class Program
	{
		static void Main(string[] args)
		{
            

            if (ValidateInput.IsInputValid(args))
			{

                string fileName;
                System.Console.Write("Enter file path: ");
                fileName = System.Console.ReadLine();
                //User input is valid
                if (ValidateInput.IsFileValid(fileName))
				{					
					try
					{
						var service = new MainService();
						service.Process(fileName);
						var response = service.Response;
                        System.Console.WriteLine($"{response}");
					}
					catch (Exception ex)
					{

                        System.Console.WriteLine($"{ex.Message}");
					}
				}
			}
			else
			{

			}

		}

		static void ShowHelp()
		{
            System.Console.Write("Pass the csv filename");
		}
	}
}
