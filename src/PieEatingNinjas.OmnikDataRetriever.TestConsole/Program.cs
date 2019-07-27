using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PieEatingNinjas.OmnikDataRetriever.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var gw = new Gateway();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var passwd = GetPassword();
            Console.WriteLine("\nLogging in...");
            var user = gw.Login(username, ConvertToUnsecureString(passwd)).Result;
            gw.SetUserData(user.Data);

            if (user != null)
            {
                Console.WriteLine("Logged in!");

                var plant = gw.GetPlantList().Result.Data;
                Console.WriteLine($"Found {plant.Count} plant{(plant.Count == 1 ? "" : "s")}");
                foreach (var item in plant.Plants)
                {
                    Console.WriteLine("Plant data:");
                    Console.WriteLine($"Country:\t{item.Country}");
                    Console.WriteLine($"City:\t\t{item.City}");
                    Console.WriteLine($"Total energy:\t{item.TotalEnergy}kWh");
                    Console.WriteLine($"Current power:\t{item.CurrentPower}kW");
                    var data = gw.GetPlantData(item.PlantId).Result.Data;
                    Console.WriteLine($"Today energy:\t{data.TodayEnergy}kWh");
                }
            }
            Console.ReadKey();
        }

        public static SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }

        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
