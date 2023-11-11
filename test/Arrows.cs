using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract777
{
    public class MenuArrows
    {
        public static string Strelochki(string[] elementals_of_directoty, string Wayy)
        {
            Console.WriteLine("Проводник");
            Console.SetCursorPosition(51, 0);
            Console.WriteLine("Раширение файла");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(90, 6);
            Console.WriteLine("F1 - Создание файла");
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("F2 - Создание папки");
            Console.SetCursorPosition(90, 8);
            Console.WriteLine("F3 - Удаление");
            int pos = 2;
            foreach (string i in elementals_of_directoty)
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  " + i);
                Console.SetCursorPosition(50, pos);
                FileInfo fileinfo = new FileInfo(elementals_of_directoty[pos - 2]);
                Console.WriteLine("|   " + fileinfo.Extension);
                pos++;
            }
            var position = 2;
            while (true)
            {
                ConsoleKeyInfo UserButton;
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                UserButton = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                if (UserButton.Key == ConsoleKey.DownArrow & position != elementals_of_directoty.Count() + 1)
                {
                    position++;
                }
                else if (UserButton.Key == ConsoleKey.UpArrow & position != 2)
                {
                    position--;
                }
                else if (UserButton.Key == ConsoleKey.Enter)
                {
                    if (Global.Count == 0)
                    {
                        Console.SetCursorPosition(2, position);
                        string Way = elementals_of_directoty[position - 2];
                        Console.Clear();
                        Global.Count++;
                        Explorerr.ShowPapka(Way);
                        return "Назад";
                    }
                    else
                    {
                        Console.SetCursorPosition(2, position);
                        string Way = elementals_of_directoty[position - 2];
                        Console.Clear();
                        Global.Count++;
                        return Way;
                    }
                }
                else if (UserButton.Key == ConsoleKey.Escape)
                {
                    if (Global.Count != 0)
                    {
                        Global.Count--;
                        Console.Clear();
                        return "Назад";
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else if (UserButton.Key == ConsoleKey.F1)
                {
                    SaveDelete.SaveFile(Wayy);
                }
                else if (UserButton.Key == ConsoleKey.F2)
                {
                    SaveDelete.SaveDirectory(Wayy);
                }
                else if (UserButton.Key == ConsoleKey.F3)
                {
                    string Way = elementals_of_directoty[position - 2];
                    SaveDelete.DeleteFileOfDirectory(Way);
                }
            }
        }
    }
    public static class SaveDelete
    {
        static public void SaveFile(string Way)
        {
            if (Global.Count != 0)
            {
                Console.SetCursorPosition(90, 9);
                string FileName = Console.ReadLine();
                try
                {
                    File.Create(Way + "\\" + FileName);
                }
                catch { }
            }
        }
        static public void SaveDirectory(string Way)
        {
            if (Global.Count != 0)
            {
                Console.SetCursorPosition(90, 9);
                string DirectoryName = Console.ReadLine();
                try
                {
                    Directory.CreateDirectory(Way + "\\" + DirectoryName);
                }
                catch { }
            }
        }
        static public void DeleteFileOfDirectory(string WayToDelete)
        {
            try
            {
                File.Delete(WayToDelete);
            }
            catch { }
            try
            {
                Directory.Delete(WayToDelete, true);
            }
            catch { }
        }
    }
}
