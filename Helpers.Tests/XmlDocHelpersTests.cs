using Helpers.Xml;

namespace Helpers.Tests;

public class XmlDocHelpersTests
{
    [Test]
    public void GetNodeValueTest()
    {
        var xml = new XmlDocHelpers("<root><test>Test</test></root>");
        string? data = xml.GetNodeValue("/root/test");
        if (data == "Test")
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeAttributeValueTest()
    {
        var xml = new XmlDocHelpers("<root><test test2=\"Test2\">Test</test></root>");
        string? data = xml.GetNodeAttributeValue("/root/test", "test2");
        if (data == "Test2")
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeValuesListTest()
    {
        var xml = new XmlDocHelpers("<root><test>Test</test><test>Test2</test><test>Test3</test></root>");
        List<string>? data = xml.GetNodeValuesList("/root/test");
        if (data != null && data is ["Test", "Test2", "Test3"])
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeAttributeValuesListTest()
    {
        var xml = new XmlDocHelpers("<root><test test2=\"Test2\">Test</test><test test2=\"Test3\">Test2</test><test test2=\"Test4\">Test3</test></root>");
        List<string>? data = xml.GetNodeAttributeValuesList("/root/test", "test2");
        if (data is ["Test2", "Test3", "Test4"])
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodesListTest()
    {
        var xml = new XmlDocHelpers("<root><test>Test</test><test>Test2</test><test>Test3</test></root>");
        var data = xml.GetNodesList("/root/test");
        if (data.Count > 0)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodesAttributeListTest()
    {
        var xml = new XmlDocHelpers("<root><test test2=\"Test2\">Test</test><test test2=\"Test3\">Test2</test><test test2=\"Test4\">Test3</test></root>");
        var data = xml.GetNodesAttributeList("/root/test", "test2");
        if (data.Count > 0)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void SumNodesValuesTest()
    {
        var xml = new XmlDocHelpers("<root><test>1</test><test>2</test><test>3</test></root>");
        var data = xml.SumNodesValues("/root/test");
        if (data == 6)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void SumNodesAttributeValuesTest()
    {
        var xml = new XmlDocHelpers("<root><test test2=\"1\">Test</test><test test2=\"2\">Test2</test><test test2=\"3\">Test3</test></root>");
        var data = xml.SumNodesAttributeValues("/root/test", "test2");
        if (data == 6)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void DistinctNodesValuesTest()
    {
        var xml = new XmlDocHelpers("<root><test>Test</test><test>Test</test><test>Test3</test></root>");
        var data = xml.DistinctNodesValues("/root/test");
        if (data.Count == 2)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetRootNodeNameTest()
    {
        var xml = new XmlDocHelpers("<root><test>Test</test><test>Test</test><test>Test3</test></root>");
        var data = xml.GetRootNodeName();
        if (data == "root")
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeValueAsDateTimeTest()
    {
        var xml = new XmlDocHelpers("<root><test>2021-01-01</test></root>");
        var data = xml.GetNodeValueAsDateTime("/root/test");
        if (data == new DateTime(2021, 1, 1))
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeValueAsIntTest()
    {
        var xml = new XmlDocHelpers("<root><test>1</test></root>");
        var data = xml.GetNodeValueAsInt("/root/test");
        if (data == 1)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeValueAsDoubleTest()
    {
        var xml = new XmlDocHelpers("<root><test>1.1</test></root>");
        var data = xml.GetNodeValueAsDouble("/root/test");
        if (data == 1.1)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void GetNodeValueAsBoolTest()
    {
        var xml = new XmlDocHelpers("<root><test>true</test></root>");
        var data = xml.GetNodeValueAsBool("/root/test");
        if (data.HasValue && data.Value)
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void EvaluateXPathTest()
    {
        var xml = new XmlDocHelpers("<root><test>Test</test></root>");
        var data = xml.EvaluateXPath("/root/test");
        if (data is "Test")
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void EvaluateXPathWithNamespaceTest()
    {
        var xml = new XmlDocHelpers("<root xmlns:ns=\"http://www.w3.org/2005/Atom\"><test>Test</test></root>");
        var nameSpace = new XPathNameSpace
        {
            Prefix = "ns",
            Uri = "http://www.w3.org/2005/Atom"
        };
        var nameSpaceList = new List<XPathNameSpace> { nameSpace };

        var data = xml.EvaluateXPathWithNamespace("/root/ns:test", nameSpaceList);
        if (data is "Test")
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    public void EvaluateXPathWithNamespaceParamTest()
    {
        var xml = new XmlDocHelpers("<root xmlns:ns=\"http://www.w3.org/2005/Atom\"><test>Test</test></root>");
        var data = xml.EvaluateXPathWithNamespace("/root/ns:test", "ns", "http://www.w3.org/2005/Atom");
        if (data is "Test")
            Assert.Pass();
        else
            Assert.Fail();
    }
}
