using Helpers.FileDir;

namespace Helpers.Tests;

public class FileHelpersTests
{
    [Test]
    public void DirectoryExistsTest()
    {
        if (!FileHelpers.DirectoryExists(@"C:\TestHelpers"))
            FileHelpers.CreateDirectory(@"C:\TestHelpers");
        
        if (FileHelpers.DirectoryExists(@"C:\TestHelpers"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void FileExistsTest()
    {
        if (!FileHelpers.FileExists(@"C:\TestHelpers\TestFile.txt"))
            FileHelpers.WriteStringListToFile(new List<string> {"Test"}, @"C:\TestHelpers\TestFile.txt");
        
        if (FileHelpers.FileExists(@"C:\TestHelpers\TestFile.txt"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void CreateDirectoryTest()
    {
        if (!FileHelpers.DirectoryExists(@"C:\TestHelpers"))
            FileHelpers.CreateDirectory(@"C:\TestHelpers");
        
        if (FileHelpers.DirectoryExists(@"C:\TestHelpers"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void CreateDirectoryFromFileNameTest()
    {
        FileHelpers.CreateDirectoryFromFileName(@"C:\TestHelpers\TestDir\TestFile.txt");
        
        if (FileHelpers.DirectoryExists(@"C:\TestHelpers\TestDir"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void WriteStringListToFileTest()
    {
        FileHelpers.WriteStringListToFile(new List<string> {"Test"}, @"C:\TestHelpers\TestFile.txt");
        
        if (FileHelpers.FileExists(@"C:\TestHelpers\TestFile.txt"))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetTextDocTest()
    {
        FileHelpers.WriteStringListToFile(new List<string> {"Test"}, @"C:\TestHelpers\TestFile.txt");
        
        if (FileHelpers.GetTextDoc(@"C:\TestHelpers\TestFile.txt") != string.Empty)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetTextDocAsArrayTest()
    {
        FileHelpers.WriteStringListToFile(new List<string> {"Test"}, @"C:\TestHelpers\TestFile.txt");
        
        if (FileHelpers.GetTextDocAsArray(@"C:\TestHelpers\TestFile.txt").Length > 0)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetTextDocAsListTest()
    {
        FileHelpers.WriteStringListToFile(new List<string> {"Test"}, @"C:\TestHelpers\TestFile.txt");
        
        if (FileHelpers.GetTextDocAsList(@"C:\TestHelpers\TestFile.txt").Count > 0)
            Assert.Pass();
        else
            Assert.Fail();
    }

}
