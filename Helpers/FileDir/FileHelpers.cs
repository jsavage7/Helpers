using System.Text;

namespace Helpers.FileDir;

public static class FileHelpers
{
    public static bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }
    
    public static bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public static void CreateDirectory(string path)
    {
        if (string.IsNullOrEmpty(path))
            return;
        
        if (!DirectoryExists(path))
            Directory.CreateDirectory(path);
    }

    public static void CreateDirectoryFromFileName(string fullPathWithFile)
    {
        var path = Path.GetDirectoryName(fullPathWithFile);
        CreateDirectory(path);
    }

    public static void WriteStringListToFile(List<string> strings, string fullFilePath, bool append = true)
    {
        CreateDirectoryFromFileName(fullFilePath);
        
        using var sw = new StreamWriter(fullFilePath, append);
        
        foreach (var str in strings)
        {
            sw.WriteLine(str);
        }
    }
    
    public static string GetTextDoc(string path)
    {
        try
        {
            if (FileExists(path))
                return File.ReadAllText(path);
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
        }
        
        return string.Empty;
    }

    public static string[] GetTextDocAsArray(string path)
    {
        if (!FileExists(path))
            return null;
        
        var strings = new List<string>();

        using var sr = new StreamReader(path);
        while (sr.ReadLine() is { } line)
        {
            strings.Add(line);
        }

        return strings.ToArray();
    }
    
    public static List<string> GetTextDocAsList(string path)
    {
        if (!FileExists(path))
            return null;
        
        var strings = new List<string>();

        using var sr = new StreamReader(path);
        while (sr.ReadLine() is { } line)
        {
            strings.Add(line);
        }

        return strings;
    }
    
    public static string ConvertStringListToCSV(List<string> list, string separator =",", string quote ="\"")
    {
        return string.Join(separator, list.Select(x => $"{quote}{x}{quote}"));
    }
    
    public static string BuildCsvDocument(List<List<string>> list, string separator = ",", string quote = "\"")
    {
        var csv = new StringBuilder();
        foreach (var item in list)
        {
            csv.AppendLine(ConvertStringListToCSV(item, separator, quote));
        }

        return csv.ToString();
    }

}