using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.Json;

namespace ClientApp
{
	internal class DataObject
	{
		public string Name { get; set; }
	}
    internal static class Program
	{
		private static void Main(string[] args)
		{
			try
			{
                // put all code in here ...
                Console.WriteLine("Client-App invoked");
				Console.WriteLine("Argument: "+ args[0]);
                var cleanedString = CleanArguments(args[0]);
                var customerArgs = cleanedString.Split("%20");
                var decoded = System.Web.HttpUtility.UrlDecode(customerArgs[1]);
                switch (int.Parse(customerArgs[0]))
                {
                    case 1:
                        Console.WriteLine(customerArgs[1]);
                        break;
                    case 2:
                        Console.WriteLine(decoded);
                        var deserializedProduct = JsonConvert.DeserializeObject<DataObject>(decoded);
                        Console.WriteLine(deserializedProduct.Name);
                        break;
                    case 3:
                        var byteArray = Convert.FromBase64String(decoded);
                        var jsonBack = Encoding.UTF8.GetString(byteArray);
                        Console.WriteLine(jsonBack);
                        break;
                }

				Console.WriteLine("Press any key to continue...");
				Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				Console.Write("Press Enter to close window ...");
				Console.Read();
			}
		}

		private static string CleanArguments(string argument)
		{
			var i = argument.IndexOf(':');
			return i > 0 ? argument.Substring(i + 1) : string.Empty;
		}

	}
}
