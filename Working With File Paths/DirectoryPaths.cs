using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Working_With_File_Paths.Abstraction;

namespace Working_With_File_Paths
{
    class DirectoryPath
    {
        private static void RecursiveFileEnumeration(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                var dirInfo = new DirectoryInfo(dirName);
                var fileAndDirectories = new DirectoryEntry(dirInfo.Name, dirInfo.FullName, FolderContents(dirInfo.Name,dirInfo.FullName));
                CreateList(fileAndDirectories,"");
            }
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
                fileSystemEntries.Add(new DirectoryEntry(directoryInfo.Name, directoryInfo.FullName, FolderContents(directoryInfo.Name, directoryInfo.FullName) ));
            }

            return fileSystemEntries;
        }

        private static void CreateList(IFileSystemEntry fileSystemEntry, string prefix)
        {
            Console.WriteLine(prefix + fileSystemEntry.Name);

            foreach (var x in fileSystemEntry.Enteries)
            {
                CreateList(x, prefix + "\t");
            }
        }        

        public void DirectoryHandler(string path)
        {
            RecursiveFileEnumeration(path);
        }
    }
}
