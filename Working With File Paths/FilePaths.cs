using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Working_With_File_Paths.Abstraction;

namespace Working_With_File_Paths
{
    class FilePaths
    {
        private static void RecursiveFileEnumeration(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                var fileAndDirectories = new DirectoryEntry(dirName);
                CreateList(fileAndDirectories,"");
            }
        }

        public static void CreateList(IFileSystemEntry fileSystemEntry, string prefix)
        {
            foreach (var x in fileSystemEntry.Enteries)
            {
                if (x is DirectoryEntry)
                {
                    Console.WriteLine(prefix + x.Name);
                    CreateList(x, prefix + "\t");
                }
                if(x is FileEntry)
                {
                    Console.WriteLine(prefix  + x.Name);
                }
            }
        }

        public void Task(string path)
        {
            RecursiveFileEnumeration(path);
        }
    }
}
