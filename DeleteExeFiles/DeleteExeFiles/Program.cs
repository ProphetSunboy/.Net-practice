string sourceDir = @"D:\Практика по C#";

try
{
    string[] exeList = Directory.GetFiles(sourceDir, "*.exe", SearchOption.AllDirectories);
    string[] jsonList = Directory.GetFiles(sourceDir, "*.json", SearchOption.AllDirectories);
    string[] dllList = Directory.GetFiles(sourceDir, "*.dll", SearchOption.AllDirectories);
    string[] pdbList = Directory.GetFiles(sourceDir, "*.pdb", SearchOption.AllDirectories);

    foreach (string exe in exeList)
    {
        File.Delete(exe);
    }

    foreach (string json in jsonList)
    {
        File.Delete(json);
    }

    foreach (string dll in dllList)
    {
        File.Delete(dll);
    }

    foreach (string pdb in pdbList)
    {
        File.Delete(pdb);
    }
}

catch (DirectoryNotFoundException dirNotFound)
{
    Console.WriteLine(dirNotFound.Message);
}