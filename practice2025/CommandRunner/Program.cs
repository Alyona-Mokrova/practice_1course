using CommandLib;
using System.Reflection;
using FileSystemCommand;

namespace CommandRunner
{
    public class CommandRunner
    {
        static void Main()
        {
            var path1 = @"C:\Users\Алёна\Desktop\practcice2025-черновик";
            var DirectorySize = new DirectorySizeCommand(path1);
            DirectorySize.Execute();

            Console.WriteLine($"Размер текущей директории: {DirectorySize.DirectorySize}");

            var path2 = @"C:\Users\Алёна\Desktop\practcice2025-черновик\task01";
            var view = "*.*csproj";
            var searchFile = new FindFilesCommand(path2, view);
            searchFile.Execute();

            if (searchFile.FilesWithMask.Length != 0)
            {
                Console.WriteLine("Файлы с выбранной маской:");
                foreach (var FileWithMask in searchFile.FilesWithMask) Console.WriteLine(FileWithMask);
            }
        }
    }
}
