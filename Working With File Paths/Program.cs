using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Working_With_File_Paths.Abstraction;

namespace Working_With_File_Paths
{
    class Program
    {
        //Для данной папки рекурсивно выдать список её файлов и подпапок.

        static void Main(string[] args)
        {
            string path = $@"X:\Программы\Microsoft Office 2013";
            if (Directory.Exists(path))
            {
                var directoryHandle = new DirectoryHandle();
                var FilesAndSubfolders = directoryHandle.CreateDirectoryEntry(new DirectoryInfo(path));
                directoryHandle.Print(FilesAndSubfolders);
            }
            else
                Console.WriteLine("Ожидался путь к папке !");

            Console.ReadLine();
        }

        
    }
}
