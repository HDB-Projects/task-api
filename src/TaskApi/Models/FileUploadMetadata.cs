namespace TaskApi.Models;

public class FileUploadMetadata
{
    public string OriginalFileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long Size { get; set; }
}
