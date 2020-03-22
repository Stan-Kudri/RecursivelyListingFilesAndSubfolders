using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_With_File_Paths.Abstraction
{
    interface IFileSystemEntry
    {
        IReadOnlyList <IFileSystemEntry> Enteries { get; }
        string Name { get; }
        string FullPath { get; }
    }
}
