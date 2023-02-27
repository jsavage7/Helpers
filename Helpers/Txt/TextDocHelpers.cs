using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Helpers.Txt;

public static class TextDocHelpers
{
    public static string GetTextIndex(List<string>? list, int index)
    {
        if (list != null && list.Count > index)
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
}