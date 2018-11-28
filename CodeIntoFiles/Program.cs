using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CodeIntoFiles
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
                        {
                            ReplaceFileContent(file);
                        }
                    }
                    else
                    {
                        foreach (string file in Directory.GetFiles(args[0], args[1]))
                        {
                            ReplaceFileContent(file);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Usage: {nameof(CodeIntoFiles)} (path to directory)");
                Console.WriteLine($"Also {nameof(CodeIntoFiles)} (path to directory) (search pattern)");
            }
        }

        public static void ReplaceFileContent(string file)
        {
            string filetext = File.ReadAllText(file);
            if (filetext.Contains("public void SetProps"))
            {
                filetext = filetext.Replace("public void SetProps",
                    $"public {Path.GetFileNameWithoutExtension(file)} SetProps");
                int methodIndex = filetext.IndexOf("public void SetProps");
                int methodEnd = filetext.IndexOf("}", methodIndex);
                int insertIndex = filetext.LastIndexOf(";", methodEnd);
                filetext = filetext.Insert(insertIndex + 1, "\n            return this;");
                File.WriteAllText(file, filetext);
            }
        }
    }
}