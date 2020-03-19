using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Working_With_File_Paths;
using Working_With_File_Paths.Abstraction;
using System.IO;

namespace Working_With_File_Paths
{
    class FileEntry : IFileSystemEntry
    {
        public string Name { get; }
        public string FullPath { get; }
        public List <IFileSystemEntry> Enteries { get; }

        public FileEntry(string listingNames)
        {
            Name = Path.GetFileName(listingNames);
            FullPath = Path.GetFullPath(listingNames);
        }        
    }

}
