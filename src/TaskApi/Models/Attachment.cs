using TaskApi.DTOs;

namespace TaskApi.Models;

public class Attachment
{
    public Guid Id { get; set; }

    public Guid TaskItemId { get; set; }

    public string BlobName { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long Size { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public TaskItem? TaskItem { get; set; }

    public static Attachment Create(
        Guid taskItemId, 
        FileUploadMetadata metadata,
        string blobName)
    {
        return new Attachment
        {
            Id = Guid.NewGuid(),
            TaskItemId = taskItemId,
            BlobName = blobName,
            OriginalFileName = metadata.OriginalFileName,
            ContentType = metadata.ContentType,
            Size = metadata.Size
        };
    }
}
