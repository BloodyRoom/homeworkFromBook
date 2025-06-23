using System;
using System.IO;

namespace fromBookHM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DisplayImageFiles();
            // DriveInfoDisplay();
            WriteIntoFile();
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            Console.WriteLine($"Found {imageFiles.Length} *.jpg files\n");

            foreach ( FileInfo f in imageFiles )
            {
                Console.WriteLine("***************************");
                Console.WriteLine($"File name: {f.Name}");
                Console.WriteLine($"File size: {f.Length}");
                Console.WriteLine($"Creation: {f.CreationTime}");
                Console.WriteLine($"Attributes: {f.Attributes}");
                Console.WriteLine("***************************\n");
            }
        }

        static void DriveInfoDisplay()
        {
            Console.WriteLine("***** Fun with Drivelnfo *****\n");

            DriveInfo[] myDrives = DriveInfo.GetDrives();

            foreach ( DriveInfo d in myDrives )
            {
                Console.WriteLine($"Name: {d.Name}");
                Console.WriteLine($"Type: {d.DriveType}");

                if (d.IsReady)
                {
                    Console.WriteLine($"Free space: {d.TotalFreeSpace}");

                    Console.WriteLine($"Format: {d.DriveFormat}");
                    Console.WriteLine($"Label: {d.VolumeLabel}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void WriteIntoFile()
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = { "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Xbox One"};

            File.WriteAllLines(@"tasks.txt", myTasks);

            foreach (var task in File.ReadAllLines(@"tasks.txt"))
            {
                Console.WriteLine($"TODO: {task}");
            }
            Console.ReadLine();
        }
    }
}
