
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using WPF_App.Mvvm.Models;

namespace WPF_App.Services;

internal class FileService
{
    private string FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

    // Save contact to Json-file on desktop
    public void Save(string fileContent)
    {
        using var sw = new StreamWriter(FilePath);
        sw.WriteLine(fileContent);
    }

    // finds and reads Json-file
    public ObservableCollection<ContactModel> Read()
    {
        try
        {
            using var sr = new StreamReader(FilePath);
            return JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;
        }
        catch { return new ObservableCollection<ContactModel>();}
    }
}
