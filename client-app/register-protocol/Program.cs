using Microsoft.Win32;
using System;

namespace Register_Protocol
{
    class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine(args[0]);
            if (args.Length < 2)
            {
                Console.WriteLine("Registering protocol requires two arguements.");
                Console.WriteLine("Argument1: Scheme name.");
                Console.WriteLine("Argument2: Protocol name.");
                return 1;
            }

            RegisterUriScheme(args[0], args[1]);

            return 0;
        }

        public static void RegisterUriScheme(string uriScheme, string friendlyName)
        {
            using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + uriScheme))
            {
                key.SetValue("", "URL:" + friendlyName);
                key.SetValue("URL Protocol", "");
                var exeLocation = AppDomain.CurrentDomain.BaseDirectory;
                var indexOfPathNeeded = exeLocation.IndexOf("register-protocol");
                var path = exeLocation.Substring(0, indexOfPathNeeded) + "client-app\\bin\\Release\\netcoreapp3.0\\win-x64\\Client-App.exe";
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
