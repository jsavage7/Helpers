using System.Xml;
using System.Xml.XPath;

namespace Helpers.Xml;

public class XmlDocHelpers
{
    public XmlDocument XDoc { get; set; } = new XmlDocument();
    public readonly XPathNavigator? Navigator;
    public string Error { get; set; } = string.Empty;
    
    public bool HasError => !string.IsNullOrEmpty(Error);
    
    public XmlDocHelpers(string document)
    {
        try
        {
            XDoc.LoadXml(document);
            Navigator = XDoc.CreateNavigator(); 
        }
        catch (Exception e)
        {
            Error = e.Message;
        }
    }
    
    public string? GetNodeValue(string xpath)
    {
        var node = XDoc.SelectSingleNode(xpath);
        return node?.InnerText;
    }
    
    public string? GetNodeAttributeValue(string xpath, string attribute)
    {
        var node = XDoc.SelectSingleNode(xpath);
        return node?.Attributes?[attribute]?.Value;
    }
    
    public List<string>? GetNodeValuesList(string xpath)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Select(x => x.InnerText).ToList();
    }
    
    public List<string>? GetNodeAttributeValuesList(string xpath, string attribute)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Select(x => x.Attributes?[attribute]?.Value).ToList();
    }
    
    public List<XmlNode>? GetNodesList(string xpath)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().ToList();
    }
    
    public List<XmlNode>? GetNodesAttributeList(string xpath, string attribute, string value)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Where(x => x.Attributes?[attribute]?.Value == value).ToList();
    }
    
    public List<XmlNode>? GetNodesAttributeList(string xpath, string attribute)
    {
        
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Where(x => x.Attributes?[attribute] != null).ToList();
    }
    
    public double SumNodesValues(string xpath)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Sum(x => Convert.ToDouble(x.InnerText)) ?? 0;
    }
    
    public double SumNodesAttributeValues(string xpath, string attribute)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Sum(x => Convert.ToDouble(x.Attributes[attribute]?.Value)) ?? 0;
    }

    public List<string> DistinctNodesValues(string xpath)
    {
        var nodes = XDoc.SelectNodes(xpath);
        return nodes?.Cast<XmlNode>().Select(x => x.InnerText).Distinct().ToList();
    }
    
    public string GetRootNodeName()
    {
        return XDoc.DocumentElement?.Name;
    }
    
    public DateTime? GetNodeValueAsDateTime(string xpath)
    {
        var node = XDoc.SelectSingleNode(xpath);
        return node != null ? Convert.ToDateTime(node.InnerText) : null;
    }
    
    public double? GetNodeValueAsDouble(string xpath)
    {
        var node = XDoc.SelectSingleNode(xpath);
        return node != null ? Convert.ToDouble(node.InnerText) : null;
    }
    
    public int? GetNodeValueAsInt(string xpath)
    {
        var node = XDoc.SelectSingleNode(xpath);
        return node != null ? Convert.ToInt32(node.InnerText) : null;
    }
    
    public bool? GetNodeValueAsBool(string xpath)
    {
        var node = XDoc.SelectSingleNode(xpath);
        return node != null ? Convert.ToBoolean(node.InnerText) : null;
    }
    
   public string EvaluateXPath(string xpath)
    {
        try
        {
            XPathNodeIterator xpathIt = (XPathNodeIterator)Navigator.Evaluate(xpath);
            var result = xpathIt.Current.Value;
            
            return result?.ToString();
        }
        catch (Exception e)
        {
            return string.Empty;
        }
    }
   
    public string EvaluateXPathWithNamespace(string xpath, List<XPathNameSpace> nameSpaces)
    {
        try
        {
            var ns = new XmlNamespaceManager(XDoc.NameTable);
            
            foreach (var nsValues in nameSpaces)
            {
                ns.AddNamespace(nsValues.Prefix, nsValues.Uri);
            }
            XPathNodeIterator xpathIt = (XPathNodeIterator)Navigator.Evaluate(xpath, ns);
            var result = xpathIt.Current.Value;
            
            return result?.ToString();
        }
        catch (Exception e)
        {
            return string.Empty;
        }
    }
    
    public string EvaluateXPathWithNamespace(string xpath, string prefix, string uri)
    {
        try
        {
            var ns = new XmlNamespaceManager(XDoc.NameTable);
            ns.AddNamespace(prefix, uri);
            XPathNodeIterator xpathIt = (XPathNodeIterator)Navigator.Evaluate(xpath, ns);
            var result = xpathIt.Current.Value;
            return result?.ToString();
        }
        catch (Exception e)
        {
            return string.Empty;
        }
    }
}