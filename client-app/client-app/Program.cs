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
				Console.WriteLine("Arguments:");

				foreach (var s in args)
				{
					var cleanString = CleanArguments(s);
					Console.WriteLine(cleanString);

					var decoded = System.Web.HttpUtility.UrlDecode(cleanString);
					Console.WriteLine(decoded);

					//var token = JToken.Parse(decoded);
					//var json = JObject.Parse((string)token);
					//Console.WriteLine(json);
					var byteArray = Convert.FromBase64String(decoded);
					var jsonBack = Encoding.UTF8.GetString(byteArray);
					//var accountBack = JsonConvert.DeserializeObject<ExternalAccount>(jsonBack);

					Console.WriteLine(jsonBack);

					var d = JsonSerializer.Deserialize("{name:joao}", typeof(DataObject));
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
