using System;

namespace ClientApp
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Client-App invoked");
			Console.WriteLine("Arguments:");

			foreach (var s in args)
			{
				Console.WriteLine(CleanArguments(s));
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}

		private static string CleanArguments(string argument)
		{
			var i = argument.IndexOf(':');
			return i > 0 ? argument.Substring(i + 1) : string.Empty;
		}

	}
}
