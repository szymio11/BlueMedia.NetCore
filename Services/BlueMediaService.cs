using System.Globalization;
using BlueMedia.Extensions;
using BlueMedia.Models;
using BlueMedia.Services.Interfaces;
using Flurl.Http;

namespace BlueMedia.Services;

public class BlueMediaService : IBlueMediaService
{
    private const string BmHeader = "BmHeader";
    private const string PayBmContinueTransactionUrl = "pay-bm-continue-transaction-url";
    private const string ServiceId = "ServiceID";
    private const string OrderId = "OrderID";
    private const string Amount = "Amount";
    private const string Description = "Description";
    private const string Hash = "Hash";
    private const string Transactions = "transactions";
    
    private readonly BlueMediaOptions _blueMediaOptions;

    public BlueMediaService(BlueMediaOptions blueMediaOptions)
    {
        _blueMediaOptions = blueMediaOptions;
    }
    
    public async Task<TransactionUrlDto?> GetUrlAsync(decimal amount, CancellationToken cancellationToken = default)
    {
        var orderId = Guid.NewGuid().ToString("N");
        var amountString = amount.ToString("0.00", CultureInfo.InvariantCulture);
        var dateTime = DateTime.Now.ToString("G");
        var hash = $"{_blueMediaOptions.ServiceId}|{orderId}|{amountString}|{dateTime}|{_blueMediaOptions.Key}".Sha256();
        
        var response = await _blueMediaOptions.Url
            .WithHeader(BmHeader, PayBmContinueTransactionUrl)
            .PostMultipartAsync(mp =>
            {
                mp.AddString(ServiceId, _blueMediaOptions.ServiceId);
                mp.AddString(OrderId, orderId);
                mp.AddString(Amount, amountString);
                mp.AddString(Description, dateTime);
                mp.AddString(Hash, hash);
            }, cancellationToken);
        
        return (await response.GetStringAsync())
            .FromXml<TransactionUrlDto>();
    }

    public void UpdateStatus(IFormCollection formCollection, CancellationToken token = default)
    {
        var isTransactionExists = formCollection.TryGetValue(Transactions, out var stringValues);
        if (!isTransactionExists)
        {
            throw new NullReferenceException();
        }
        
        var result = stringValues
            .ToString()
            .DecodeBase64()
            .FromXml<TransactionList>();

        var transaction = result?.Transactions?.Transaction?.FirstOrDefault();
        if (transaction is null)
        {
            throw new NullReferenceException(nameof(transaction));
        }
        
        if (Enum.TryParse(transaction.PaymentStatus, true, out TipStatus status))
        {
           // save new status
        }
    }
}