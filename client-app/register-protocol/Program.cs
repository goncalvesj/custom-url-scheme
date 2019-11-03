using Microsoft.Win32;
using System;

namespace Register_Protocol
{
    class Program
    {
        public static void Main(string[] args)
        {
			const string protocol = "clientapp";
			const string desc = "My Desktop App";

			Console.WriteLine("Registering protocol...");
			Console.WriteLine($"Scheme name: {protocol}");
			Console.WriteLine($"Description: {desc}.");

			RegisterUriScheme(protocol, desc);

			Console.WriteLine("Please press any key to continue...");
			Console.ReadLine();
        }

        public static void RegisterUriScheme(string uriScheme, string friendlyName)
        {
            using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + uriScheme))
            {
                key.SetValue("", "URL:" + friendlyName);
                key.SetValue("URL Protocol", "");
                var exeLocation = AppDomain.CurrentDomain.BaseDirectory;
                var indexOfPathNeeded = exeLocation.IndexOf("register-protocol");
                var path = exeLocation.Substring(0, indexOfPathNeeded) + "client-app\\bin\\Debug\\netcoreapp3.0\\win-x64\\Client-App.exe";
                using (var defaultIcon = key.CreateSubKey("DefaultIcon"))
                {
                    defaultIcon.SetValue("", path + ",1");
                }
                using (var commandKey = key.CreateSubKey(@"shell\open\command"))
                {
                    commandKey.SetValue("", "\"" + path + "\" \"%1\"");
                }
            }
        }
    }
}
