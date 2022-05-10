using BlueMedia.Models;

namespace BlueMedia.Services.Interfaces;

public interface IBlueMediaService
{
    Task<TransactionUrlDto?> GetUrlAsync(decimal amount, CancellationToken cancellationToken = default);
    void UpdateStatus(IFormCollection formCollection, CancellationToken token = default);
}