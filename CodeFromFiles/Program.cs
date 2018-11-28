using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeFromFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length >= 1)
            {
                if (Directory.Exists(args[0]))
                {
                    if (args.Length == 1)
                    {
                        foreach (string file in Directory.GetFiles(args[0]))
                            Console.WriteLine($"public {Path.GetFileNameWithoutExtension(file)} {Path.GetFileNameWithoutExtension(file)} => new {Path.GetFileNameWithoutExtension(file)}(Visa, null, CommandsType.C);");
                    }
                    else
                    {
                        foreach (string file in Directory.GetFiles(args[0], args[1]))
                            Console.WriteLine($"public {Path.GetFileNameWithoutExtension(file)} {Path.GetFileNameWithoutExtension(file)} => new {Path.GetFileNameWithoutExtension(file)}(Visa, null, CommandsType.C);");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Usage: {nameof(CodeFromFiles)} (path to directory)");
                Console.WriteLine($"Also {nameof(CodeFromFiles)} (path to directory) (search pattern)");
            }
        }
    }
}