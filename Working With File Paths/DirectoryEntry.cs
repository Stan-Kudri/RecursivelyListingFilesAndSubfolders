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
        public IReadOnlyList<IFileSystemEntry> Enteries { get; } 

        public DirectoryEntry(string name, string fullName, IReadOnlyList<IFileSystemEntry> entries)
        {
            Name = name;
            FullPath = fullName;
            Enteries = entries ?? Array.Empty<IFileSystemEntry>();            
        }
    }
}
