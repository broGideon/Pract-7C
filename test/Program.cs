using System.Diagnostics;
using Pract777;

public static class Global
{
    public static int Count = 0;
}

public class Explorerr
{
    public static void Main()
    {
        DriveInfo[] allDrivers = DriveInfo.GetDrives();
        string[] Disks = new string[allDrivers.Length];
        for (int i = 0; i < allDrivers.Length; i++)
        {
            Disks[i] = allDrivers[i].Name;
        }
        MenuArrows.Strelochki(Disks, "qwe");
        return;
    }
    public static void ShowPapka(string way)
    {
        while (true)
        {
            if (File.Exists(way) == true)
            {
                Process.Start(new ProcessStartInfo { FileName = way, UseShellExecute = true });
                Global.Count--;
                return;
            }
            else
            {
                string[] path_papki = Directory.GetDirectories(way);
                string[] path_fiels = Directory.GetFiles(way);
                string[] a = path_papki.Concat(path_fiels).ToArray();
                var wayy = MenuArrows.Strelochki(a, way);
                if (wayy == "Назад")
                {
                    Console.Clear();
                    if (Global.Count == 0)
                    {
                        Main();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        return;
                    }
                }
                ShowPapka(wayy);
            }
        }
    }
}
