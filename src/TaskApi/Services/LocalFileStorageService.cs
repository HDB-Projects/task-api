using Microsoft.Extensions.Configuration;

namespace TaskApi.Services;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _storagePath;

    public LocalFileStorageService(IConfiguration configuration)
    {
        string relativePath = configuration["Storage:Path"] 
            ?? throw new InvalidOperationException("Storage path configuration missing.");

        _storagePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            relativePath);

        Directory.CreateDirectory(_storagePath);
    }

    public async Task<string> SaveFileAsync(
        Stream fileStream,
        string fileName,
        CancellationToken cancellationToken = default)
    {
        string uniqueFileName = $"{Guid.NewGuid()}_{fileName}";

        string filePath = Path.Combine(_storagePath, uniqueFileName);

        await using FileStream outputStream = new FileStream(filePath, FileMode.Create);

        await fileStream.CopyToAsync(outputStream, cancellationToken);

        return uniqueFileName;
    }
}
