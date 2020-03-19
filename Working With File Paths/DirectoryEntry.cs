using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Working_With_File_Paths.Abstraction;
using System.IO;

namespace Working_With_File_Paths
{
    class DirectoryEntry:IFileSystemEntry
    {
        public string Name { get; }
        public string FullPath { get; }
        public List<IFileSystemEntry> Enteries { get; }

        public DirectoryEntry(string listingNames)
        {
            var dirInfo = new DirectoryInfo(listingNames);
            Name = dirInfo.Name;
            FullPath = dirInfo.FullName;

            Enteries = new List<IFileSystemEntry>();

            foreach(var fileInfo in dirInfo.GetFiles())
            {
                Enteries.Add(new FileEntry(fileInfo.FullName));
            }

            foreach(var directoryInfo in dirInfo.GetDirectories())
            {    
                Enteries.Add(new DirectoryEntry(directoryInfo.FullName));
            }
        }
    }
}
