using Helpers.FileDir;
using Helpers.Txt;
using NUnit.Framework;

namespace Helpers.Tests;

public class TextDocHelpersTests
{
    [Test]
    public void ConvertStringListToCsvTest()
    {
        var list = new List<string> { "Test", "Test2", "Test3" };
        string data = TextDocHelpers.ConvertStringListToCSV(list);

        if (data.Contains(",")) // Test if the string contains a comma
            Assert.Pass();
        else
            Assert.Fail();
    }

    [Test]
    public void BuildCsvDocumentTest()
    {
        var list = new List<string> { "Test", "Test2", "Test3" };
        var list2 = new List<string> { "Test4", "Test5", "Test6" };

        var listOfLines = new List<List<string>> { list, list2 };

        string data = TextDocHelpers.BuildCsvDocument(listOfLines);

        if (data.Contains("\r\n") && data.Contains(",")) // Test if the string contains a comma and CRLF
            Assert.Pass();
        else
            Assert.Fail();
    }

    [Test]
    public void GetTextIndexTest()
    {
        var list = new List<string> { "Test", "Test2", "Test3" };
        string data = TextDocHelpers.GetTextIndex(list, 1);
        string data2 = TextDocHelpers.GetTextIndex(list, 0);

        if (data.Equals("Test2") && data2.Equals("Test"))
            Assert.Pass();
        else
            Assert.Fail();

    }
    
    [Test]
    public void CheckMatchingTextNotCaseSensitiveTest()
    {
        string data = "Test";
        string data2 = "test";

        if (TextDocHelpers.CheckMatchingTextNotCaseSensitive(data, data2))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void CheckMatchingTextCaseSensitiveTest()
    {
        string data = "Test";
        string data2 = "test";

        if (!TextDocHelpers.CheckMatchingTextCaseSensitive(data, data2))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void SubstringTest()
    {
        string data = "Test";
        string data2 = "test";

        if (TextDocHelpers.SubstringText(data, 0, 2).Equals("Te"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void RegexReplaceTextTest()
    {
        string data = "Test";
        string data2 = "test";

        if (TextDocHelpers.RegexReplaceText(data, "e", "a").Equals("Tast"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void CountTextOccurrencesTest()
    {
        string data = "Test";
        string data2 = "test";

        if (TextDocHelpers.CountTextOccurrences(data, "e") == 1)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void IsValidEmailTest()
    {
        string data = "Test";
        string data2 = "test";

        if (!TextDocHelpers.IsValidEmail(data))
            Assert.Pass();
        else
            Assert.Fail();
    }
}