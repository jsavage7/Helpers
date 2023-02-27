using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpers.Txt;

public static class TextDocHelpers
{
    public static string GetTextIndex(List<string>? list, int index)
    {
        if (list?.Count > index)
        {
            return list[index];
        }

        return string.Empty;
    }
    
    public static bool CheckMatchingTextNotCaseSensitive(string text, string textToMatch)
    {
        return text.ToLower().Equals(textToMatch.ToLower());
    }
    
    public static bool CheckMatchingTextCaseSensitive(string text, string textToMatch)
    {
        return text.Equals(textToMatch);
    }
    
    public static string SubstringText(string text, int startIndex, int length)
    {
        return text.Length < startIndex + length ? text.Substring(startIndex) : text.Substring(startIndex, length);
    }
    
    public static string RegexReplaceText(string text, string pattern, string replacement)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern)|| string.IsNullOrEmpty(replacement))
            return string.Empty;
        
        return Regex.Replace(text, pattern, replacement);
    }
    
    public static int CountTextOccurrences(string text, string textToCount)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(textToCount))
            return 0;
        
        return Regex.Matches(text, textToCount).Count;
    }

    public static bool IsValidEmail(string emailAddress)
    {
        try
        {
            var m = new MailAddress(emailAddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
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