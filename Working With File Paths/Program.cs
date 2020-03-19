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
        static void Main(string[] args)
        {
            string path = $@"X:\Программы\КОМПАС-3D 16.1.3";
            var fileTask = new FilePaths();
            fileTask.Task(path);

            Console.ReadLine();
        }

        
    }
}
