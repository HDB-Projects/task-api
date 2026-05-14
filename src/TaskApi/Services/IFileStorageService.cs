namespace TaskApi.Services;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(
        Stream fileStream,
        string fileName,
        CancellationToken cancellationToken = default);
}
