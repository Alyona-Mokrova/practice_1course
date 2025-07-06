public class DirectorySizeCommand : ICommand
{
    private readonly string pathDirectory;
    public long DirectorySize { get; private set; }

    public DirectorySizeCommand(string pathDirectory)
    {
        this.pathDirectory = pathDirectory;
    }

    public void Execute()
    {
        DirectorySize = GetDirectorySize(pathDirectory);
    }

    private long GetDirectorySize(string pathDirectory)
    {
        return Directory
            .EnumerateFiles(pathDirectory, "*", SearchOption.AllDirectories)
            .Sum(file => new FileInfo(file).Length);
    }

}

public class FindFilesCommand : ICommand
{
    private readonly string pathDirectory;
    private readonly string searchMask;
    public string[] FilesWithMask { get; private set; } = Array.Empty<string>();

    public FindFilesCommand(string pathDirectory, string searchMask)
    {
        this.pathDirectory = pathDirectory; 
        this.searchMask = searchMask;
    }

    public void Execute()
    {
        if (!Directory.Exists(pathDirectory))
            throw new DirectoryNotFoundException(pathDirectory);

        FilesWithMask = Directory.GetFiles(pathDirectory, searchMask, SearchOption.TopDirectoryOnly);

    }
}
