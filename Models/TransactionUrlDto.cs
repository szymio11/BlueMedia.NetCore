using System.Xml.Serialization;

namespace BlueMedia.Models;

[XmlRoot(ElementName="transaction")]
public class TransactionUrlDto { 

    [XmlElement(ElementName="status")] 
    public string? Status { get; set; } 
    
    [XmlElement(ElementName="redirecturl")] 
    public string? RedirectUrl { get; set; } 

    [XmlElement(ElementName="orderID")] 
    public string? OrderId { get; set; } 
    
    [XmlElement(ElementName="remoteID")] 
    public string? RemoteId { get; set; } 
    
    [XmlElement(ElementName="hash")] 
    public string? Hash { get; set; } 
}