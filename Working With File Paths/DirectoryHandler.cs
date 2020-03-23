using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Working_With_File_Paths.Abstraction;

namespace Working_With_File_Paths
{
    class DirectoryHandle
    {
        public DirectoryEntry RecursiveFileEnumeration(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                var dirInfo = new DirectoryInfo(dirName);
                var fileAndDirectories = new DirectoryEntry(dirInfo.Name, dirInfo.FullName, FolderContents(dirInfo.Name, dirInfo.FullName));
                return fileAndDirectories;
            }
            else
                throw new ArgumentException("Ожидался путь к папке");
        }

        public void Print(DirectoryEntry fileAndDirectories)
        {
            PrintingFilesAndDirectories(fileAndDirectories, "");
        }

        private static IReadOnlyList<IFileSystemEntry> FolderContents(string name, string fullName)
        {
            var fileSystemEntries = new List<IFileSystemEntry>();
            DirectoryInfo dirInfo = new DirectoryInfo(fullName);

            foreach (var fileInfo in dirInfo.GetFiles())
            {
                fileSystemEntries.Add(new FileEntry(fileInfo.Name, fileInfo.FullName));
            }

            foreach (var directoryInfo in dirInfo.GetDirectories())
            {
                string directoryName = directoryInfo.Name;
                string directoryFullName = directoryInfo.FullName;
                fileSystemEntries.Add(new DirectoryEntry(directoryName, directoryFullName, FolderContents(directoryName, directoryFullName)));
            }

            return fileSystemEntries;
        }

        private static void PrintingFilesAndDirectories(IFileSystemEntry fileSystemEntry, string prefix)
        {
            Console.WriteLine(prefix + fileSystemEntry.Name);

            foreach (var x in fileSystemEntry.Enteries)
            {
                PrintingFilesAndDirectories(x, prefix + "\t");
            }
        }        
    }
}
