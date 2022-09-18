string sourceDirectory = @"E:\";


try
{
    DriveInfo[] drives = DriveInfo.GetDrives();
    DirectoryInfo dr = new DirectoryInfo(drives[0].Name);
    foreach (DriveInfo drive in drives)
    {
        if (drive.IsReady && (drive.DriveType == DriveType.Removable))
        {
            sourceDirectory = drive.Name;
            dr = new DirectoryInfo(drive.Name);
        }
    }
    if (sourceDirectory == string.Empty)
        Console.WriteLine("Флешка не найдена");

    Console.Write("Введите путь файла: ");
    string file = Console.ReadLine();

    FileAttributes attributes = File.GetAttributes(dr.FullName);
    if (!((attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint))
    {
        var txtFiles = Directory.EnumerateFiles(sourceDirectory, file, SearchOption.AllDirectories);
        foreach (string currentFile in txtFiles)
        {
                Console.WriteLine(currentFile);
                FileStream f = new FileStream(currentFile, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(f);
                Console.WriteLine(sr.ReadToEnd());
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}