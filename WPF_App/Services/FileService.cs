
using System;
using System.IO;

namespace WPF_App.Services;

internal class FileService
{
    private string FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

    // Save contact to Json-file 
    public void Save(string fileContent)
    {
        using var sw = new StreamWriter(FilePath);
        sw.WriteLine(fileContent);
    }

    // finds and reads Json-file
    public string Read()
    {
        try
        {
            using var sr = new StreamReader(FilePath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }
}
