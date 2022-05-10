using System.Xml.Serialization;

namespace BlueMedia.Models;

[XmlRoot(ElementName="transaction")]
public class Transaction { 

    [XmlElement(ElementName="orderID")] 
    public Guid OrderId { get; set; } 

    [XmlElement(ElementName="remoteID")] 
    public string? RemoteId { get; set; } 

    [XmlElement(ElementName="amount")] 
    public decimal Amount { get; set; } 

    [XmlElement(ElementName="currency")] 
    public string? Currency { get; set; } 

    [XmlElement(ElementName="gatewayID")] 
    public string? GatewayId { get; set; } 

    [XmlElement(ElementName="paymentDate")] 
    public string? PaymentDate { get; set; } 

    [XmlElement(ElementName="paymentStatus")] 
    public string? PaymentStatus { get; set; } 

    [XmlElement(ElementName="paymentStatusDetails")] 
    public string? PaymentStatusDetails { get; set; } 
}

[XmlRoot(ElementName="transactions")]
public class Transactions { 

    [XmlElement(ElementName="transaction")] 
    public List<Transaction>? Transaction { get; set; } 
}

[XmlRoot(ElementName="transactionList")]
public class TransactionList { 

    [XmlElement(ElementName="serviceID")] 
    public string? ServiceId { get; set; } 

    [XmlElement(ElementName="transactions")] 
    public Transactions? Transactions { get; set; } 

    [XmlElement(ElementName="hash")] 
    public string? Hash { get; set; } 
}